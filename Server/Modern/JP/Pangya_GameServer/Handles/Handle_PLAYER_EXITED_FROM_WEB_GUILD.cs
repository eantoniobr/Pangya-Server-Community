using Pangya_GameServer.Feature;
using Pangya_GameServer.Manager;
using Pangya_GameServer.Models;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;

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
    public class Handle_PLAYER_EXITED_FROM_WEB_GUILD : HandleBase<Player, Packet_EXAMPLE>
    {
        public override async Task Handle()
        {
            try
            {
                // Verifica se tem alteração nos pangs
                ulong old_pang = Player.UserInfo.Statistics.pang;

                // Update o pang do server com o valor que está no banco de dados
                Player.UserInfo.updatePang();

                if (old_pang != Player.UserInfo.Statistics.pang)
                {
                    // Atualiza o pangs do Player no jogo
                    Packet p = new Packet((ushort)0xC8);

                    p.WriteUInt64(Player.UserInfo.Statistics.pang);
                    p.WriteUInt64(0);

                    Player.Send(p);
                }

                // Verifica se tem alguma atualização da guild Web para atualizar o Player no server e cliente
                // Só verifica se o Player estiver em uma guild
                if (Player.UserInfo.Guild.uid > 0)
                {
                    CmdGuildUpdateActivityInfo cmd_guai = new CmdGuildUpdateActivityInfo(Player.UserInfo.Guild.uid,
                        Player.UserInfo.uid, true);

                    NormalManagerDB.getInstance().add(0, cmd_guai, null, null);

                    if (cmd_guai.getException().getCodeError() != 0)
                    {
                        throw cmd_guai.getException();
                    }

                    var v_info = cmd_guai.getInfo();

                    if (v_info.Any())
                    {
                        Packet p = new Packet();

                        // Verifica todas as alterações que tem na Guild e trata elas
                        foreach (var el in v_info)
                        {
                            switch (el.type)
                            {
                                case GuildUpdateActivityInfo.TYPE_UPDATE.TU_ACCEPTED_MEMBER:
                                    {
                                        p.init_plain(0x01);
                                        p.WriteUInt32(el.club_uid);
                                        p.WriteUInt32(el.Player_uid);

                                        GameServer.getInstance().sendCommandToOtherServerWithAuthServer(p, 3);

                                        var s = GameServer.getInstance().FindPlayer(el.Player_uid);

                                        if (s != null)
                                        {
                                            CmdMemberInfo cmd_mi = new CmdMemberInfo(s.UserInfo.uid);

                                            NormalManagerDB.getInstance().add(0, cmd_mi, null, null);

                                            if (cmd_mi.getException().getCodeError() != 0)
                                            {
                                                throw cmd_mi.getException();
                                            }

                                            var mi = cmd_mi.getInfo();

                                            if (mi.guild_uid > 0u)
                                            {
                                                s.UserInfo.Member.guild_mark_img_no = mi.guild_mark_img_no;
                                                s.UserInfo.Member.guild_uid = mi.guild_uid;
                                                s.UserInfo.Member.guild_pang = mi.guild_pang;
                                                s.UserInfo.Member.guild_point = mi.guild_point;
                                                s.UserInfo.Member.guild_name = mi.guild_name;
                                                s.UserInfo.Member.guild_mark_img = mi.guild_mark_img;

                                                CmdGuildInfo cmd_gi = new CmdGuildInfo(s.UserInfo.uid, 0);

                                                NormalManagerDB.getInstance().add(0, cmd_gi, null, null);

                                                if (cmd_gi.getException().getCodeError() != 0)
                                                {
                                                    throw cmd_gi.getException();
                                                }

                                                s.UserInfo.Guild = cmd_gi.getInfo();

                                                if (s.GetChannel() != null)
                                                {
                                                    s.GetChannel().UpdatePlayerInfo(s);
                                                    s.GetChannel().SendUpdatePlayerInfo(s, 3);
                                                }
                                            }
                                        }
                                        break;
                                    }
                                case GuildUpdateActivityInfo.TYPE_UPDATE.TU_EXITED_MEMBER:
                                    {
                                        p.init_plain(0x02);
                                        p.WriteUInt32(el.club_uid);
                                        p.WriteUInt32(el.Player_uid);

                                        GameServer.getInstance().sendCommandToOtherServerWithAuthServer(p, 3);

                                        Player.UserInfo.Guild.clear();
                                        Player.UserInfo.Member.guild_mark_img_no = 0;
                                        Player.UserInfo.Member.guild_uid = 0;
                                        Player.UserInfo.Member.guild_pang = 0;
                                        Player.UserInfo.Member.guild_point = 0;
                                        Player.UserInfo.Member.guild_name = "";
                                        Player.UserInfo.Member.guild_mark_img = "";

                                        if (Player.GetChannel() != null)
                                        {
                                            Player.GetChannel()?.UpdatePlayerInfo(Player);
                                            Player.GetChannel()?.SendUpdatePlayerInfo(Player, 3);
                                        }
                                        break;
                                    }
                                case GuildUpdateActivityInfo.TYPE_UPDATE.TU_KICKED_MEMBER:
                                    {
                                        p.init_plain(0x03);
                                        p.WriteUInt32(el.club_uid);
                                        p.WriteUInt32(el.Player_uid);

                                        GameServer.getInstance().sendCommandToOtherServerWithAuthServer(p, 3);

                                        var s = GameServer.getInstance().FindPlayer(el.Player_uid);

                                        if (s != null)
                                        {
                                            s.UserInfo.Guild.clear();
                                            s.UserInfo.Member.guild_mark_img_no = 0;
                                            s.UserInfo.Member.guild_uid = 0;
                                            s.UserInfo.Member.guild_pang = 0;
                                            s.UserInfo.Member.guild_point = 0;
                                            s.UserInfo.Member.guild_name = "";
                                            s.UserInfo.Member.guild_mark_img = "";

                                            if (s.GetChannel() != null)
                                            {
                                                s.GetChannel().UpdatePlayerInfo(s);
                                                s.GetChannel().SendUpdatePlayerInfo(s, 3);
                                            }
                                        }
                                        break;
                                    }
                            }

                            // Atualiza o STATE do guild update activity por que ela já foi tratada
                            NormalManagerDB.getInstance().add(27,
                                 new CmdUpdateGuildUpdateActiviy(el.index),
                                 null, null);
                        }
                    }
                }
            }
            catch (exception e)
            { 
                _smp.message_pool.getInstance().push(new message("[Lobby::RequestExitedFromWebGuild][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
        }
    }
}