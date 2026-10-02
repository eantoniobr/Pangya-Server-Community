using PangyaAPI.Utilities;

namespace PangyaAPI.Network.Config
{
    public class ConfigTimeOut
    {
        /// <summary>
        /// Tempo máximo (segundos) que o cliente tem para enviar o primeiro
        /// pacote de handshake (CS 0x01) após conectar.
        /// Clientes que não enviarem nada nesse tempo são kickados.
        /// Padrão: 20 segundos.
        /// </summary>
        public int HandshakeSeconds { get; set; } = 20;

        /// <summary>
        /// Tempo máximo (segundos) sem receber NENHUM pacote após o login.
        /// O TTL periódico do Pangya (CS 0x01 a cada ~30s) reseta esse timer.
        /// Padrão: 180 segundos (3 minutos).
        /// </summary>
        public int IdleSeconds { get; set; } = 180;

        /// <summary>
        /// Timeout do socket para operações de envio (milissegundos).
        /// Se o kernel TCP não conseguir entregar em X ms, a conexão é abortada.
        /// Protege contra clientes que conectam mas param de ler.
        /// Padrão: 10000 ms (10 segundos).
        /// </summary>
        public int SendTimeoutMs { get; set; } = 10000;

        /// <summary>
        /// Intervalo (segundos) entre cada varredura de timeout no MonitorLoop.
        /// Valores menores = detecção mais rápida, mais CPU.
        /// Padrão: 10 segundos.
        /// </summary>
        public int CheckIntervalSeconds { get; set; } = 10;

        // Helpers para comparação
        public TimeSpan HandshakeTimeSpan => TimeSpan.FromSeconds(HandshakeSeconds);
        public TimeSpan IdleTimeSpan => TimeSpan.FromSeconds(IdleSeconds);
        public TimeSpan CheckInterval => TimeSpan.FromSeconds(CheckIntervalSeconds);

        public static ConfigTimeOut Default => new();

        public static ConfigTimeOut FromIni(IniHandle ini)
        {
            return new ConfigTimeOut
            {
                HandshakeSeconds = ini.ReadInt32("TIMEOUT", "HANDSHAKE", 20),
                IdleSeconds = ini.ReadInt32("TIMEOUT", "IDLE", 180),
                SendTimeoutMs = ini.ReadInt32("TIMEOUT", "SEND", 10000),
                CheckIntervalSeconds = ini.ReadInt32("TIMEOUT", "CHECK_INTERVAL", 10),
            };
        }

        public override string ToString() =>
            $"Handshake={HandshakeSeconds}s | Idle={IdleSeconds}s | Send={SendTimeoutMs}ms | Check={CheckIntervalSeconds}s";
    }
}