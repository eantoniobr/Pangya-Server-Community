using Pangya_GameServer.Manager;
using Pangya_GameServer.Models;
using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Session;
using PangyaAPI.IFF.Flags;
using PangyaAPI.IFF.Handle.JP;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using snmdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_CHANGE_DOLFINI_LOCKER_MODE : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            Packet p = new Packet();

            try
            {
                // 1. Leitura dos dados do pacote
                byte locker = _packet.ReadByte();
                string pass = _packet.ReadString();

                // 2. Validações de comprimento (Business Logic)
                if (pass.Length == 0)
                {
                    throw new exception("[Handle_PLAYER_CHANGE_DOLFINI_LOCKER_MODE][Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou trocar o modo de entrar no dolfini locker, mas a senha fornecida esta vazia. Hacker ou Bug",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 350, 5100251));
                }

                if (pass.Length > 4)
                {
                    throw new exception("[Handle_PLAYER_CHANGE_DOLFINI_LOCKER_MODE][Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou trocar o modo de entrar no dolfini locker, mas o tamanho da senha é maior que o permitido. Hacker ou Bug",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 351, 5100252));
                }

                // 3. Preparação do pacote de resposta (0x173)
                p.init_plain(0x173);

                // 4. Verificação da senha e execução da troca de modo
                if (string.CompareOrdinal(pass, _session.Inventory.DolfineLocker.pass) != 0)
                {
                    // Senha incorreta
                    _smp.message_pool.getInstance().push(new message("[Dolfini Locker::Change Mode Enter][Success] senha[" + pass + "] incorreta para o PLAYER [UID=" + _session.UserInfo.uid + "]", type_msg.CL_FILE_LOG_AND_CONSOLE));

                    p.WriteUInt32(1); // Erro: Senha não confere
                }
                else
                {
                    // Sucesso: Atualiza o estado na sessão (1 = Locker Ativo, 0 = Inativo)
                    _session.Inventory.DolfineLocker.locker = (locker == 1);

                    p.WriteUInt32(0); // OK

                    _smp.message_pool.getInstance().push(new message("[Dolfini Locker::Change Mode Enter][Success] PLAYER [UID=" + _session.UserInfo.uid + "] alterou o modo do locker com sucesso.", type_msg.CL_FILE_LOG_AND_CONSOLE));

                    // 5. Atualização assíncrona no Banco de Dados
                    // Note: Usei o tipo 2 conforme o seu código original
                    NormalManagerDB.getInstance().add(2, new CmdUpdateDolfiniLockerMode(_session.UserInfo.uid, locker));
                }

                // Envia a resposta final para o cliente
                _session.Send(p);
            }
            catch (exception e)
            {
                // Tratamento de exceções do sistema
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_CHANGE_DOLFINI_LOCKER_MODE][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));

                p.init_plain(0x173);

                uint errorCode = (ExceptionError.STDA_SOURCE_ERROR_DECODE_TYPE(e.getCodeError()) == STDA_ERROR_TYPE.CHANNEL)
                    ? ExceptionError.STDA_SYSTEM_ERROR_DECODE(e.getCodeError())
                    : 5100250;

                p.WriteUInt32(errorCode);
                _session.Send(p);
            }
        } 
    }
}