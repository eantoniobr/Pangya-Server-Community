namespace PangyaAPI.Network.Flags
{
    public enum CloseReason : int
    {
        // --- Estados Indeterminados ---
        Unknown = -1,

        // --- Fluxo Normal ---
        /// <summary> O jogador saiu voluntariamente (botão sair/fechar jogo). </summary>
        Normal = 0,

        // --- Timeouts (Problemas de Conexão/Inatividade) ---
        /// <summary> Conectou mas não enviou o pacote de login/handshake a tempo. </summary>
        HandshakeTimeOut = 1,

        /// <summary> Jogador ficou muito tempo sem enviar pacotes (AFK). </summary>
        IdleTimeOut = 2,

        // --- Segurança e Protocolo ---
        /// <summary> O parser detectou bytes inválidos ou pacotes malformados. </summary>
        PacketProtocolError = 3,

        /// <summary> Tentativa de enviar um pacote sem estar autenticado ou sem permissão. </summary>
        PacketProtocolNoAuthorized = 4,

        /// <summary> Conexão rejeitada (Servidor cheio ou IP bloqueado). </summary>
        Rejected = 5,

        // --- Ações Administrativas e Anti-Cheat ---
        /// <summary> Desconectado manualmente por um Administrador/GM. </summary>
        Kicked = 6,

        /// <summary> Expulso automaticamente pelo sistema de segurança (PY_Guard). </summary>
        Cheating = 7,

        /// <summary> Ocorreu um erro crítico no socket ou falha de hardware. </summary>
        SocketError = 8
    }
}