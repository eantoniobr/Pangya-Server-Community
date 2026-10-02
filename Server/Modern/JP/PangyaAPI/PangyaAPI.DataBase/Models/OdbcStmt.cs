using System;
using System.Collections.Generic;
using System.Text;

namespace PangyaAPI.DataBase.Models
{ 
    public sealed class OdbcStmt : IDisposable
    {
        private bool disposedValue;

        public List<string> Columns { get; } = new List<string>();
        public List<object[]> Rows { get; } = new List<object[]>();

        public void Clear()
        {
            Columns.Clear();
            Rows.Clear();
        }
        public void Dispose()
        { Dispose(true); }
        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Clear();
                }

                // TODO: liberar recursos não gerenciados (objetos não gerenciados) e substituir o finalizador
                // TODO: definir campos grandes como nulos
                disposedValue = true;
            }
        }

        void IDisposable.Dispose()
        {
            // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
