using Pangya_GameServer.Repository;
using Pangya_GameServer.Session;
using PangyaAPI.IFF.Flags;
using PangyaAPI.IFF.Handle.JP;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Models;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_REQUEST_UCC : IPacketHandler<Player>
    {
        public async Task Handle(Player session, Packet packet)
        {
            byte opt = packet.ReadByte();

            try
            {
                switch (opt)
                {
                    case 0: // Save Definitivo
                        HandleSaveForever(session, packet, opt);
                        break;
                    case 1: // Info
                        HandleInfo(session, packet, opt);
                        break;
                    case 2: // Copiar
                        HandleCopy(session, packet, opt);
                        break;
                    case 3: // Save Temporário
                        HandleSaveTemporary(session, packet, opt);
                        break;
                    default:
                        throw new exception($"[UCC] Option {opt} desconhecida para UID={session.UserInfo.uid}.",
                            ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, 1, 0x5200101));
                }
            }
            catch (exception e)
            {
                Console.WriteLine($"[UCC_SYSTEM][Error] {e.getFullMessageError()}");
                var response = new Packet();
                response.init_plain(0x12E);
                response.WriteSByte(-1); // Status Error
                session.Send(response);
            }

        await Task.CompletedTask;
        }

        private async Task HandleSaveForever(Player session, Packet packet, byte opt)
        {
            uint typeid = packet.ReadUInt32();
            string idx = packet.ReadString();
            string name = packet.ReadString();

            ValidateUCC(session, typeid, idx);

            if (string.IsNullOrEmpty(name))
                throw new exception("[UCC] Nome inválido.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, 7, 0x5200107));

            var item = session.Inventory.WarehouseItems.Values.FirstOrDefault(el => el._typeid == typeid && (string.IsNullOrEmpty(el.ucc.name) || el.ucc.name == "0") && el.ucc.idx == idx);

            if (item == null) throw new Exception("UCC não encontrada no Warehouse.");

            item.ucc.status = 1;
            item.ucc.name = name;
            item.ucc.copier_nick = session.UserInfo.nickname;
            item.ucc.copier = session.UserInfo.uid;


            CommandDB.UpdateUCC(session.UserInfo.uid, item, new SystemTime(1), CmdUpdateUCC.T_UPDATE.FOREVER);
            var response = new Packet();
            // Resposta 0x12E
            response.init_plain(0x12E);
            response.WriteByte(opt);
            response.WriteByte(1); // Sucesso
            response.WriteInt32(item.id);
            response.WriteUInt32(item._typeid);
            response.WriteString(item.ucc.idx);
            response.WriteString(item.ucc.name);
            session.Send(response);
        }

        private async Task HandleInfo(Player session, Packet packet, byte opt)
        {
            int uccId = packet.ReadInt32();
            byte owner = packet.ReadByte();

            var item = session.Inventory.FindWarehouseItemById(uccId);

            if (item == null)
                item = CommandDB.FindUCC(uccId);

            if (item == null || item.id <= 0) throw new exception("UCC não encontrada.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, 3, 0x5200103));

            var response = new Packet();
            response.init_plain(0x12E);
            response.WriteByte(opt);
            response.WriteUInt32(item._typeid);
            response.WriteString(item.ucc.idx);
            response.WriteByte(owner);
            response.WriteBytes(item.ToArray());
            session.Send(response);
        }

        private async Task HandleSaveTemporary(Player session, Packet packet, byte opt)
        {
            uint typeid = packet.ReadUInt32();
            string idx = packet.ReadString();

            ValidateUCC(session, typeid, idx);

            var item = session.Inventory.WarehouseItems.Values.FirstOrDefault(el => el._typeid == typeid);
            if (item == null) throw new exception("UCC não encontrada.", 0x5200105);

            item.ucc.status = 2; // Status 2 = Temporário (ainda editável/não batizado)
            item.ucc.name = "0";

            CommandDB.UpdateUCC(session.UserInfo.uid, item, new SystemTime(1), CmdUpdateUCC.T_UPDATE.TEMPORARY);
            var response = new Packet();
            response.init_plain(0x12E);
            response.WriteByte(opt);
            response.WriteUInt32(item._typeid);
            response.WriteString(item.ucc.idx);
            response.WriteByte(1);
            session.Send(response);
        }

        private async Task HandleCopy(Player session, Packet packet, byte opt)
        {
            uint typeid = packet.ReadUInt32();   // UCC de origem
            string idx = packet.ReadString();    // UCC de origem
            ushort seq = packet.ReadUInt16();    // Sequência
            int targetId = packet.ReadInt32();   // ID da UCC "vazia" que receberá a cópia

            ValidateUCC(session, typeid, idx);

            // 1. Localiza a UCC de origem no Warehouse
            var sourceItem = session.Inventory.WarehouseItems.Values.FirstOrDefault(el => el._typeid == typeid && el.ucc.idx == idx);
            if (sourceItem == null) throw new exception("UCC de origem não encontrada.", 0x5200105);

            // 2. Localiza a UCC de destino (onde será colada a arte)
            var targetItem = session.Inventory.FindWarehouseItemById(targetId);
            if (targetItem == null) throw new exception("UCC de destino não encontrada.", 0x5200110);

            // 3. Aplica a cópia logicamente
            targetItem.ucc.status = 1; // Torna permanente
            targetItem.ucc.idx = sourceItem.ucc.idx;
            targetItem.ucc.name = sourceItem.ucc.name;
            targetItem.ucc.copier_nick = session.UserInfo.nickname;
            targetItem.ucc.copier = session.UserInfo.uid;

            // 4. Update no Banco de Dados
            CommandDB.UpdateUCC(session.UserInfo.uid, targetItem, new SystemTime(DateTime.Now), CmdUpdateUCC.T_UPDATE.COPY);

            var response = new Packet();
            // 5. Resposta ao Cliente (0x12E)
            response.init_plain(0x12E);
            response.WriteByte(opt);
            response.WriteUInt32(sourceItem._typeid);
            response.WriteString(sourceItem.ucc.idx);
            response.WriteInt16(sourceItem.ucc.seq);
            response.WriteInt32(targetItem.id);
            response.WriteInt32(targetItem.id);
            response.WriteUInt32(targetItem._typeid);
            response.WriteString(targetItem.ucc.idx);
            response.WriteInt16(targetItem.ucc.seq);
            response.WriteByte(1);
            session.Send(response);
        }

        private void ValidateUCC(Player session, uint typeid, string idx)
        {
            if (typeid == 0 || string.IsNullOrEmpty(idx))
                throw new exception("[UCC] TypeID ou IDX inválidos.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, 4, 0x5200104));

            if (sIff.getInstance().getItemGroupIdentify(typeid) != IFF_GROUP.PART)
                throw new exception("[UCC] Item não é uma parte válida.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, 13, 0x5200113));

            var part = sIff.getInstance().findPart(typeid);
            if (part == null || !part.IsUCC())
                throw new exception("[UCC] IFF não reconhece como UCC.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, 12, 0x5200112));
        }
    }
}