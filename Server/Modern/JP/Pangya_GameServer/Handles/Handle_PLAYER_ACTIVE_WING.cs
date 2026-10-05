namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_ACTIVE_WING : HandleBase<Player, Packet_EXAMPLE>
    {
        public override async Task Handle()
        {
            try
            {
                var r = Player.GetGameRoom() ?? throw new exception("[Error] PLAYER [UID=" + Player.UserInfo.uid + "] tentou ativar Asa no jogo na sala[NUMERO=" + (Player.UserInfo.Member.sala_numero) + "], mas ele nao esta em nenhuma sala. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        1, 0x6201601));
               
                r.RequestActiveWing(Player, Packet);
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_ACTIVE_WING][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
        }
    }
}