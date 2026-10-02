using Pangya_GameServer.Models;
using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Session;
using PangyaAPI.IFF.Flags;
using PangyaAPI.IFF.Handle.JP;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Network.Models;
using PangyaAPI.Network.Repository;
using PangyaAPI.Network.Session;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using snmdb;
using static Pangya_GameServer.Models.DefineConstants;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_SYNC_ITEM_MAIN_LOBBY : IPacketHandler<Player>
    {
        private enum SYNC_ITEM_TYPE : byte
        {
            CADDIE = 1,
            BALL = 2,
            CLUBSET = 3,
            CHARACTER = 4,
            MASCOT = 5
        }

        public async Task Handle(Player _session, Packet _packet)
        {
            SYNC_ITEM_TYPE type = (SYNC_ITEM_TYPE)255;

            try
            {
                type = (SYNC_ITEM_TYPE)_packet.ReadByte();

                int error = 0;
                 
                _smp.message_pool.getInstance().push(new message($"[Handle_PLAYER_SYNC_ITEM_MAIN_LOBBY][Warning] PLAYER[UID: {_session.UserInfo.uid}, REQ: {type}]", type_msg.CL_FILE_LOG_AND_CONSOLE));

                error = type switch
                {
                    SYNC_ITEM_TYPE.CADDIE => HandleChangeCaddie(_session, _packet.ReadInt32()),
                    SYNC_ITEM_TYPE.BALL => HandleChangeComet(_session, _packet.ReadUInt32()),
                    SYNC_ITEM_TYPE.CLUBSET => HandleChangeClubSet(_session, _packet.ReadInt32()),
                    SYNC_ITEM_TYPE.CHARACTER => HandleChangeCharacter(_session, _packet.ReadInt32()),//seguro
                    SYNC_ITEM_TYPE.MASCOT => HandleChangeMascot(_session, _packet.ReadInt32()),
                    _ => throw new exception($"[SyncItem] Tipo desconhecido: {type}",
                                                ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 13, 1)),
                };

                // 1. Atualiza visual para outros players (Channel/Room)
                _session.GetChannel().UpdatePlayerInfo(_session);

                // 2. Envia confirmação (0x4B) para o cliente
                _session.Send(Handle_PACKET_RESPONSE.pacote04B(_session, (byte)type, error));

            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message($"[Handle_PLAYER_SYNC_ITEM_MAIN_LOBBY][ErrorSystem] {e.getFullMessageError()}", type_msg.CL_FILE_LOG_AND_CONSOLE));

                _session.Send(Handle_PACKET_RESPONSE.pacote04B(_session, (byte)type,
                    (int)(ExceptionError.STDA_SOURCE_ERROR_DECODE_TYPE(e.getCodeError()) == STDA_ERROR_TYPE.CHANNEL
                        ? ExceptionError.STDA_SYSTEM_ERROR_DECODE(e.getCodeError()) : 1)));
            }
        }
        private int HandleChangeCaddie(Player _session, int item_id)
        {
            CaddieInfoEx pCi = (item_id != 0) ? _session.Inventory.FindCaddieById(item_id) : null;
            int error = 0;

            // 1. Tenta equipar um novo Caddie
            if (item_id != 0)
            {
                // Validação: Existe e é Caddie?
                if (pCi != null && sIff.getInstance().getItemGroupIdentify(pCi._typeid) == IFF_GROUP.CADDIE)
                {
                    // Checa se o Caddie ou seus Parts expiraram
                    var v_it = _session.Inventory.FindUpdateItemById(pCi.id);
                    if (v_it != null && v_it.Count != 0)
                    {
                        ProcessCaddieUpdateItems(_session, pCi, v_it);

                        // Se após processar o Caddie foi removido (expirou), resetamos para 0
                        if (_session.Inventory.UserEquipment.caddie_id == 0) item_id = 0;
                    }
                    else
                    {
                        // Caddie está íntegro, equipa normalmente
                        _session.Inventory.UserEquippedItem.CaddieEquiped = pCi;
                        _session.Inventory.UserEquipment.caddie_id = item_id;

                        if (_session.CheckCaddieEquiped(_session.Inventory.UserEquipment))
                            item_id = _session.Inventory.UserEquipment.caddie_id;
                    }

                    if (item_id != 0)
                    {
                        SyncCaddieDB(_session.UserInfo.uid, item_id);
                        return 0;
                    }
                }
                else
                {
                    error = (pCi == null) ? 2 : 3;
                }
            }

            // 2. Se item_id for 0 ou houve erro, desequipa o Caddie
            return UnequipCaddie(_session, error);
        }

        private int HandleChangeComet(Player _session, uint item_id)
        {
            WarehouseItemEx pWi = null;
            int error = 0;

            // 1. Tenta equipar a bola solicitada
            if (item_id != 0)
            {
                pWi = _session.Inventory.FindWarehouseItemByTypeid(item_id);

                // Validação: Existe, é do grupo BALL e não expirou?
                if (pWi != null && sIff.getInstance().getItemGroupIdentify(pWi._typeid) == IFF_GROUP.BALL)
                {
                    var c_it = _session.Inventory.FindUpdateItemById(pWi.id);
                    bool isExpired = (pWi.STDA_C_ITEM_TIME > 0 && (c_it == null || c_it.Count == 0));

                    if (!isExpired)
                    {
                        _session.Inventory.UserEquippedItem.Ball_WI = pWi;
                        _session.Inventory.UserEquipment.ball_typeid = pWi._typeid;

                        if (_session.CheckBallEquiped(_session.Inventory.UserEquipment))
                            item_id = _session.Inventory.UserEquipment.ball_typeid;

                        SyncBallDB(_session.UserInfo.uid, item_id);
                        return 0; // Sucesso
                    }
                    error = 6; // Item Expirado
                }
                else
                {
                    error = (pWi == null) ? 2 : 3; // Não encontrado ou grupo errado
                }
            }

            // 2. Fallback: Se chegou aqui, item_id era 0 ou houve erro
            return CreateDefaultComet(_session, error);
        }

        private int HandleChangeClubSet(Player _session, int item_id)
        {
            WarehouseItemEx pWi = _session.Inventory.FindWarehouseItemById(item_id);
            
            // 1. Validação de existência básica
            if (item_id == 0) return CreateDefaultClubSet(_session, item_id, 1);
            if (pWi == null) return CreateDefaultClubSet(_session, item_id, 2);

            // 2. Validação de Tipo (IFF)
            if (sIff.getInstance().getItemGroupIdentify(pWi._typeid) != IFF_GROUP.CLUBSET)
                return CreateDefaultClubSet(_session, item_id, 3);

            var cs_iff = sIff.getInstance().findClubSet(pWi._typeid);
            if (cs_iff == null)
                return CreateDefaultClubSet(_session, item_id, 5);

            // 3. Validação de Tempo (O Ponto Crítico)
            // Se o item tem configuração de tempo (STDA_C_ITEM_TIME > 0), ele é temporário.
            var c_it = _session.Inventory.FindUpdateItemById(item_id);
            bool isTemporary = pWi.STDA_C_ITEM_TIME > 0;

            if (isTemporary && (c_it == null || c_it.Count == 0))
            {
                // O item é temporário mas não está na lista de updates ativos (Expirou)
                return CreateDefaultClubSet(_session, item_id, 6);
            }

            // 4. Sucesso: Equipar o Item
            _session.Inventory.EquipClubSetAction(pWi);

            // Atualiza o item_id caso a ação de equipar tenha alterado algo (ex: IDs de slots)
            if (_session.CheckClubSetEquiped(_session.Inventory.UserEquipment))
                item_id = _session.Inventory.UserEquipment.clubset_id;

            SyncClubDB(_session.UserInfo.uid, item_id);
            return 0;
        }
         

        private int HandleChangeCharacter(Player _session, int item_id)
        {
            CharacterInfo pCe = (item_id != 0) ? _session.Inventory.FindCharacterById(item_id) : null;
            int error = 0;

            if (item_id == 0 || pCe == null || sIff.getInstance().getItemGroupIdentify(pCe._typeid) != IFF_GROUP.CHARACTER)
            {
                error = (item_id == 0) ? 1 : (pCe == null ? 2 : 3);
            }
            //é diferente do outro
            _session.Inventory.SyncCharacter(item_id);
            //UPDATE ON DB
            SyncCharacterDB(_session.Inventory.uid, item_id); 
            return error;
        }

        private int HandleChangeMascot(Player _session, int item_id)
        {
            MascotInfoEx pMi = null;
            int error = 0;

            // 1. Tentativa de Equipar (item_id > 0)
            if (item_id != 0)
            {
                pMi = _session.Inventory.FindMascotById(item_id);

                // Validação de Existência e Grupo IFF
                if (pMi != null && sIff.getInstance().getItemGroupIdentify(pMi._typeid) == IFF_GROUP.MASCOT)
                {
                    // Verifica expiração (Update Items)
                    var m_it = _session.Inventory.FindUpdateItemById(_session.Inventory.UserEquipment.mascot_id);

                    if (m_it.Count > 0)
                    {
                        item_id = 0; // Expulsa o item (expirado)
                        _session.Inventory.UserEquippedItem.MascotEquiped = null;
                        _session.Inventory.UserEquipment.mascot_id = 0;
                    }
                    else
                    {
                        // Equipamento válido
                        _session.Inventory.UserEquippedItem.MascotEquiped = pMi;
                        _session.Inventory.UserEquipment.mascot_id = item_id;

                        // Validação final de integridade do servidor
                        if (_session.CheckMascotEquiped(_session.Inventory.UserEquipment))
                        {
                            item_id = _session.Inventory.UserEquipment.mascot_id;
                        }
                    }

                    SyncMascotDB(_session.UserInfo.uid, item_id);
                }
                else
                {
                    // Caso de Erro: Item não existe ou grupo errado
                    error = (pMi == null) ? 2 : 3;
                    // Força desequipar
                    _session.Inventory.UserEquippedItem.MascotEquiped = null;
                    _session.Inventory.UserEquipment.mascot_id = 0; 
                    SyncMascotDB(_session.UserInfo.uid, 0);
                }
            }
            // 2. Fluxo de Desequipar Manual (item_id == 0)
            else if (_session.Inventory.UserEquipment.mascot_id > 0)
            {
                _session.Inventory.UserEquippedItem.MascotEquiped = null;
                _session.Inventory.UserEquipment.mascot_id = 0;
                SyncMascotDB(_session.UserInfo.uid, 0);
            }

            return error;
        }

        private void SyncMascotDB(uint uid, int item_id)
        {
            // Update ON DB 
            NormalManagerDB.getInstance().add(0, new CmdUpdateMascotEquiped(uid, item_id));
        }

        private void SyncCharacterDB(uint uid, int item_id)
        {
            NormalManagerDB.getInstance().add(0, new CmdUpdateCharacterEquiped(uid, item_id));
        }

        private void SyncClubDB(uint uid, int item_id)
        {
            NormalManagerDB.getInstance().add(0, new CmdUpdateClubsetEquiped(uid, item_id));
        }

        private void SyncCaddieDB(uint uid, int item_id)
        {
            NormalManagerDB.getInstance().add(0, new CmdUpdateCaddieEquiped(uid, item_id));
        }

        private void SyncBallDB(uint uid, uint item_typeid)
        {
            NormalManagerDB.getInstance().add(0, new CmdUpdateBallEquiped(uid, item_typeid));
        }

        private int CreateDefaultClubSet(Player _session, int original_id, int error_code)
        {
            var pWi = _session.Inventory.FindWarehouseItemByTypeid(DEFAULT_CLUB_TYPEID);

            // Se não tem a CV1, tenta adicionar via ItemManager (lógica do BuyItem)
            if (pWi == null)
            {
                pWi = _session.CreateDefaultClubSet();
            }

            if (pWi != null)
            {
                var cs = sIff.getInstance().findClubSet(pWi._typeid);
                if (cs != null) _session.Inventory.EquipClubSetAction(pWi);

                SyncClubDB(_session.UserInfo.uid, pWi.id);
                return 0; // Sucesso ao recuperar
            }

            return error_code; // Falha total
        }

        private int CreateDefaultComet(Player _session, int error_code)
        {
            var pWi = _session.Inventory.FindWarehouseItemByTypeid(DEFAULT_COMET_TYPEID);

            // Se não tem a CV1, tenta adicionar via ItemManager (lógica do BuyItem)
            if (pWi == null)
            {
                pWi = _session.CreateDefaultBall();
            }

            if (pWi != null)
            {
                var cs = sIff.getInstance().findBall(pWi._typeid);
                if (cs != null)
                    SyncBallDB(_session.UserInfo.uid, pWi._typeid);
                return 0; // Sucesso ao recuperar
            }

            return error_code; // Falha total
        }
          
        private void ProcessCaddieUpdateItems(Player _session, CaddieInfoEx pCi, Dictionary<int, UpdateItem> updates)
        {
            foreach (var el in updates)
            {
                if (el.Value.type == UpdateItem.UI_TYPE.CADDIE)
                {
                    // O Caddie em si expirou
                    _session.Inventory.UserEquippedItem.CaddieEquiped = null;
                    _session.Inventory.UserEquipment.caddie_id = 0;
                }
                else if (el.Value.type == UpdateItem.UI_TYPE.CADDIE_PARTS)
                {
                    // Apenas os itens do Caddie expiraram, o Caddie continua
                    pCi.parts_typeid = 0;
                    pCi.parts_end_date_unix = 0;
                    pCi.end_parts_date = new SystemTime();

                    _session.Inventory.UserEquippedItem.CaddieEquiped = pCi;
                    _session.Inventory.UserEquipment.caddie_id = pCi.id;
                }
                // Remove o alerta de update para não processar duas vezes
                _session.Inventory.UpdateItems.Remove(el.Key);
            }
        }

        private int UnequipCaddie(Player _session, int error)
        {
            if (error > 1)
                _smp.message_pool.getInstance().push(new message($"[Caddie] Erro {error} para UID={_session.UserInfo.uid}. Desequipando.", type_msg.CL_FILE_LOG_AND_CONSOLE));

            _session.Inventory.UserEquippedItem.CaddieEquiped = null;
            _session.Inventory.UserEquipment.caddie_id = 0;

            SyncCaddieDB(_session.UserInfo.uid, 0);
            return 0;
        }  
    }
}