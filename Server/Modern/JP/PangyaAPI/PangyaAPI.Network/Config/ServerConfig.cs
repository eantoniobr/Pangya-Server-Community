using PangyaAPI.Network.Models;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
namespace PangyaAPI.Network.Config;

public class ServerConfig
{
    public ServerInfo _ServerInfo { get; protected set; }
    public ConfigTimeOut Timeouts { get; protected set; }
    public int TimeTickBotLimit { get; protected set; }

    public static void LoadConfig(ref ServerInfo serverInfo, ref ConfigTimeOut timeouts, ref int timeTickBotLimit, TypeServer serverType)
    {
        var config = new ServerConfig();
        config._ServerInfo = serverInfo;
        config.Timeouts = timeouts;
        config.TimeTickBotLimit = timeTickBotLimit;
        config.LoadConfig(serverType);

        serverInfo = config._ServerInfo;
        timeouts = config.Timeouts;
        timeTickBotLimit = config.TimeTickBotLimit;
    }

    public virtual void LoadConfig(TypeServer serverType = TypeServer.GameServer)
    {
        try
        {
            string prefix = GetPrefixByServerType(serverType);
            string serverIniFileName = $"{prefix}.ini";
            string serverIniPath = File.Exists($"Config/{serverIniFileName}") ? $"Config/{serverIniFileName}" : serverIniFileName;
            if (!File.Exists(serverIniPath))
            {
                throw new exception($"[{GetType().Name}::LoadConfig][Error] Arquivo '{serverIniPath}' não encontrado.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.READER_INI, 5, 0x5200105)); 
            }

            using (var ini = new IniHandle(serverIniPath))
            {
                _ServerInfo = new ServerInfo
                {
                    version = ini.ReadString("SERVERINFO", "VERSION"),
                    version_client = ini.ReadString("SERVERINFO", "CLIENTVERSION"),
                    nome = ini.ReadString("SERVERINFO", "NAME", GetDefaultNameByServerType(serverType)),
                    uid = ini.ReadInt32("SERVERINFO", "GUID"),
                    port = ini.ReadInt32("SERVERINFO", "PORT"),
                    ip = ini.ReadString("SERVERINFO", "IP", "127.0.0.1"),
                    max_user = ini.ReadInt32("SERVERINFO", "MAXUSER", 2000),
                    propriedade = new Property(ini.ReadUInt32("SERVERINFO", "PROPERTY")),
                    packet_version = ini.ReadUInt32("SERVERINFO", "PACKETVERSION")
                };
                TimeTickBotLimit = ini.ReadInt32("OPTION", "ANTIBOTTTL", 1000);
                Timeouts = ConfigTimeOut.FromIni(ini); 
            }
            _smp.message_pool.getInstance().push($"[{GetType().Name}::LoadConfig][Sucess] Server[Type: {serverType}, Name: {_ServerInfo.nome}] Sucess!", type_msg.CL_FILE_LOG_AND_CONSOLE);
        }
        catch (exception ex)
        {
            _smp.message_pool.getInstance().push($"[{GetType().Name}::LoadConfig][ErrorSystem] " + ex.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE);
            SetDefaultFallback();
        }
        catch (Exception ex)
        {
            _smp.message_pool.getInstance().push($"[{GetType().Name}::LoadConfig][ErrorSystem] " + ex.Message, type_msg.CL_FILE_LOG_AND_CONSOLE);
            SetDefaultFallback();
        }
    }

    private void SetDefaultFallback()
    {
        Timeouts = ConfigTimeOut.Default;
        TimeTickBotLimit = 1000;
    }

    private static string GetDefaultNameByServerType(TypeServer type) => type switch
    {
        TypeServer.GameServer => "Pangya Game Server",
        TypeServer.MessengerServer => "Pangya Messenger Server",
        TypeServer.LoginServer => "Pangya Login Server",
        TypeServer.RankServer => "Pangya Rank Server",
        TypeServer.AuthServer => "Pangya Auth Server",
        _ => "Pangya Server"
    };

    private static string GetPrefixByServerType(TypeServer type) => type switch
    {
        TypeServer.GameServer => "GS",
        TypeServer.MessengerServer => "MS",
        TypeServer.LoginServer => "LS",
        TypeServer.RankServer => "RS",
        TypeServer.AuthServer => "AS",
        _ => "SV"
    };

    public static string GetLoadConfig(TypeServer serverType)
    {
        return GetPrefixByServerType(serverType) + ".ini";
    }

    public static IniHandle GetLoadConfigIni(TypeServer serverType)
    {
        string prefix = GetPrefixByServerType(serverType);
        string serverIniFileName = $"{prefix}.ini";
        string serverIniPath = File.Exists($"Config/{serverIniFileName}") ? $"Config/{serverIniFileName}" : serverIniFileName;
        if (!File.Exists(serverIniPath))
        {
            throw new exception($"[ServerConfig::GetLoadConfigIni][Error] Arquivo '{serverIniPath}' não encontrado.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.READER_INI, 5, 0x5200105)); 
        }

        return new IniHandle(serverIniPath);
    }
}
