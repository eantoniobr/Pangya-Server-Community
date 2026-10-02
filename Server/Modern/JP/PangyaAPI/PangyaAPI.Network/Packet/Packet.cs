using PangyaAPI.Utilities.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace PangyaAPI.Network
{
    public partial class Packet : IDisposable
    { 
        private MemoryStream _ms;
        public PangyaBinaryWriter Writer { get; private set; }
        public PangyaBinaryReader Reader { get; private set; }

        public int Type;
        public bool is_raw;
        private bool disposedValue;

        // Atalho para facilitar o acesso ao buffer do Stream
        /// <summary>
        /// obtem a mensagem decriptografada
        /// </summary>
        public byte[] Message => Reader == null ? Array.Empty<byte>() : Reader?.GetRemainingData();
        /// <summary>
        /// obtem o tamanho do pacote
        /// </summary>
        public int Size => (int)(Message.Length); 
        /// <summary>
        /// Obtem os bytes escritos
        /// </summary>
        public byte[] GetBytes => Writer.GetBytes;

        // Sincroniza o offset antigo com a posição do Stream
        public int offset
        {
            get => (int)(_ms == null ? 0 : _ms.Position);
            set { if (_ms != null) _ms.Position = value; }
        }
         
        public byte public_key { get; set; }
        public byte private_key { get; set; }

        public Packet(int _type = -1)
        {
            this.Type = _type;
            this.is_raw = true; 
            // Se buff for nulo, cria um novo com o tamanho especificado 
            Writer = new PangyaBinaryWriter(); 
            if (this.Type != -1)
            {
                this.WriteInt16(this.Type);
                this.is_raw = false;
            }
        }

        public Packet(byte[] buff)
        {
            this.Type = 0;
            this.is_raw = false; 
            _ms = new MemoryStream(buff, 0, buff.Length, true, true);
            Writer = new PangyaBinaryWriter();
            Reader = new PangyaBinaryReader(_ms); 
        }


        public void init_plain(int _type = -1)
        {
            this.Type = _type;
            this.is_raw = true; 
            Writer = new PangyaBinaryWriter(); 
            if (this.Type != -1)
            {
                this.WriteInt16((short)this.Type);
                this.is_raw = false;
            }
        }

        public byte[] GetBytesReader()
        {
            return Reader.GetRemainingData();
        }

        public void Dispose()
        {
            if (!disposedValue)
            {
                Writer?.Dispose();
                Reader?.Dispose();
                _ms?.Dispose();
                disposedValue = true;
            }
            GC.SuppressFinalize(this);
        }

    } 
} 
