using Pangya_GameServer.Flags;
using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using PangyaAPI.Utilities.Models;
using System;
using System.Threading.Tasks;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_MSN_PROTOCOL : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            var subPacketId = MSN_PROTOCOL_FLAGS.REQUEST_FRIEND;

            try
            {
                subPacketId = (MSN_PROTOCOL_FLAGS)_packet.ReadUInt16();

                switch (subPacketId)
                {
                    case MSN_PROTOCOL_FLAGS.SEND_NOTE:
                        HandlesSendNote(_session, _packet, subPacketId);
                        break; 
                    case MSN_PROTOCOL_FLAGS.REQUEST_FRIEND://em teste
                        HandleRequestFriendList(_session, subPacketId);
                        break; 
                    default:
                        // Sub-pacote desconhecido ou não tratado
                        break;
                }
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message($"[Handle_PLAYER_MSN_PROTOCOL][ErrorSystem] {e.getFullMessageError()}", type_msg.CL_FILE_LOG_AND_CONSOLE));


                var p = new Packet();
                // Resposta de Erro Padronizada
                p.init_plain(0x95);
                p.WriteUInt16((ushort)subPacketId);

                uint errorCode = (ExceptionError.STDA_SOURCE_ERROR_DECODE_TYPE(e.getCodeError()) == STDA_ERROR_TYPE.GAME_SERVER)
                    ? ExceptionError.STDA_SYSTEM_ERROR_DECODE_TYPE(e.getCodeError())
                    : 0x5700100;

                p.WriteUInt32(errorCode);
                _session.Send(p);
            }
        }

        private async Task HandlesSendNote(Player _session, Packet _packet, MSN_PROTOCOL_FLAGS subId)
        {
            try
            {
                uint targetUid = _packet.ReadUInt32();
                string msg = _packet.ReadString();
                byte opt = _packet.ReadByte();

                // 1. Validações
                ValidateMessageOff(_session, targetUid, msg, opt, subId);

                // 2. Lógica de Consumo
                _session.UserInfo.consomePang(10);

                // 3. Persistência no DB
                CommandDB.InsertFriendNote(_session.UserInfo.uid, targetUid, msg);

                // 4. Log
                _smp.message_pool.getInstance().push(new message($"[NOTE] Player[UID={_session.UserInfo.uid}] -> Target[UID={targetUid}]: {msg}", type_msg.CL_FILE_LOG_AND_CONSOLE));

                // 5. Resposta de Sucesso
                var response = new Packet();
                response.init_plain(0x95);
                response.WriteUInt16((ushort)subId);
                response.WriteUInt32(0); // Status OK
                response.WriteUInt64(_session.UserInfo.Statistics.pang);

                _session.Send(response);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task HandleRequestFriendList(Player _session, MSN_PROTOCOL_FLAGS subId)
        {
            // 1. Busca a lista de amigos no Banco de Dados 
            var friends = _session.UserInfo.Friends;

            var response = new Packet();
            response.init_plain(0x95);
            response.WriteUInt16((ushort)subId);
            response.WriteUInt32(0); // Status OK
            // Escreve a quantidade de amigos na lista
            response.WriteUInt32((uint)friends.Count);

            foreach (var friend in friends.Values)
            {
                // Estrutura padrão de amigo no PangYa
                response.WriteUInt32(friend.uid); // UID do amigo
                response.WriteByte(friend.sex); // UID do amigo
                response.WriteString(friend.id, 22); // Login ID
                response.WriteString(friend.nickname, 22); // Nickname
                response.WriteString(friend.apelido, 22); // Nickname 
            }
            _smp.message_pool.getInstance().push(new message($"[TESBUG] Player[UID={_session.UserInfo.uid}]", type_msg.CL_FILE_LOG_AND_CONSOLE));

            _session.Send(response);
        }

        private void ValidateMessageOff(Player session, uint targetUid, string msg, byte opt, MSN_PROTOCOL_FLAGS subId)
        {
            if (targetUid == 0)
                throw CreateException(subId, session.UserInfo.uid, "UID inválido (zero)", 1, 0x5700101);

            if (string.IsNullOrEmpty(msg))
                throw CreateException(subId, session.UserInfo.uid, "Mensagem vazia", 2, 0x5700102);

            if (msg.Length > 256)
                throw CreateException(subId, session.UserInfo.uid, $"Mensagem muito longa ({msg.Length})", 3, 0x5700103);

            if (!Tools.Sanitize(msg))
                throw CreateException(subId, session.UserInfo.uid, $"Mensagem muito longa ({msg.Length})", 3, 0x5700103);

            if (opt != 0)
                throw CreateException(subId, session.UserInfo.uid, "Option diferente de 0", 4, 0x5700104);

            if (session.UserInfo.Statistics.pang < 10)
                throw CreateException(subId, session.UserInfo.uid, $"Pangs insuficientes (tem={session.UserInfo.Statistics.pang})", 5, 0x5700105);
        }

        private exception CreateException(MSN_PROTOCOL_FLAGS subId, uint uid, string reason, ushort internalId, uint hexCode)
        {
            return new exception($"[Handle][ID={subId}][Error] Player[UID={uid}] - {reason}.",
                ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, internalId, hexCode));
        }
    }
}