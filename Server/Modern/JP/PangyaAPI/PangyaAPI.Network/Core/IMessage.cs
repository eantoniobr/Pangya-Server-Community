using System;
using System.Collections.Generic;
using System.Text;

namespace PangyaAPI.Network.Core
{
    public interface IMessage//vou usar no futuro, seria para fazer a leitura e escrita de pacotes, mas por enquanto nao tem nada implementado
    {
        byte[] ToArray();
        void ToRead(Packet p);
    }
}
