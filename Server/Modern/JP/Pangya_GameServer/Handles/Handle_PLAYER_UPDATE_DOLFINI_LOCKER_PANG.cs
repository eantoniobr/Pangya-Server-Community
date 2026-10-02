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
    public class Handle_PLAYER_UPDATE_DOLFINI_LOCKER_PANG : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            Packet p = new Packet();

            try
            {
                // 1. Leitura dos dados: Opção (0 = Retirar, 1 = Depositar) e Quantidade
                byte opt = _packet.ReadByte();
                ulong pang = _packet.ReadUInt64();

                if (opt == 1) // DEPÓSITO: Player -> Locker
                {
                    if (pang > _session.UserInfo.Statistics.pang)
                    {
                        throw new exception("[Handle_PLAYER_UPDATE_DOLFINI_LOCKER_PANG][Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou depositar pangs[" + pang + "] que não possui.",
                            ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 451, 5100352));
                    }

                    _session.Inventory.DolfineLocker.pang += pang; // Adiciona no cofre
                   _session.UserInfo.consomePang(pang); // Remove do inventário
                }
                else if (opt == 0) // RETIRADA: Locker -> Player
                {
                    if (pang > _session.Inventory.DolfineLocker.pang)
                    {
                        throw new exception("[Handle_PLAYER_UPDATE_DOLFINI_LOCKER_PANG][Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou retirar pangs[" + pang + "] que não estão no Dolfini Locker.",
                            ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 452, 5100353));
                    }

                    _session.Inventory.DolfineLocker.pang -= pang; // Remove do cofre
                   _session.UserInfo.addPang(pang); // Adiciona no inventário
                }
                else
                {
                    throw new exception("[Handle_PLAYER_UPDATE_DOLFINI_LOCKER_PANG][Error] PLAYER [UID=" + _session.UserInfo.uid + "] enviou opção inválida[" + opt + "].",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 450, 5100351));
                }

                _smp.message_pool.getInstance().push(new message("[Dolfini Locker::Update pang][Success] PLAYER [UID=" + _session.UserInfo.uid + "] Atualizou Pang[value=" + pang + ", OPT=" + opt + "].", type_msg.CL_FILE_LOG_AND_CONSOLE));

                // 2. Atualização persistente no Banco de Dados
                NormalManagerDB.getInstance().add(3,
                     new CmdUpdateDolfiniLockerPang(_session.UserInfo.uid, _session.Inventory.DolfineLocker.pang));

                // 3. Sincronização de Pacotes com o Cliente

                // Pacote 0x171: Confirmação da operação
                p.init_plain(0x171);
                p.WriteUInt32(0);
                _session.Send(p);

                // Pacote 0xC8: Atualização visual dos Pangs no inventário principal
                p.init_plain(0xC8);
                p.WriteUInt64(_session.UserInfo.Statistics.pang);
                p.WriteUInt64(pang);
                _session.Send(p);

                // Pacote 0x172: Atualização visual dos Pangs dentro do Dolfini Locker
                p.init_plain(0x172);
                p.WriteUInt64(_session.Inventory.DolfineLocker.pang);
                _session.Send(p);
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_UPDATE_DOLFINI_LOCKER_PANG][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));

                p.init_plain(0x171);
                uint errorCode = (ExceptionError.STDA_SOURCE_ERROR_DECODE_TYPE(e.getCodeError()) == STDA_ERROR_TYPE.CHANNEL)
                    ? ExceptionError.STDA_SYSTEM_ERROR_DECODE(e.getCodeError())
                    : 5100350;

                p.WriteUInt32(errorCode);
                _session.Send(p);
            }
        }
    }
}