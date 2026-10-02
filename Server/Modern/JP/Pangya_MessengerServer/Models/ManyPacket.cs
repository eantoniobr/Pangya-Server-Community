using PangyaAPI.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Pangya_MessengerServer.Models
{
    public class ManyPacket
    {
        public ManyPacket(in ushort _size, in ushort _limit)
        {
            this.const_total = _size;
            this.const_limit = _limit;

            // Initialize data
            init();
        }

        public void init()
        {
            // Calcula Initial data

            paginas = (ushort)(const_total / const_limit);

            if ((const_total % const_limit) != 0)
            {
                ++paginas;
            }

            pag.pagina = 1;
            pag.total = const_total;
            pag.current = (const_total <= const_limit) ? const_total : const_limit;

            // Calcule Index
            calcIndex();
        }
        public void increse()
        {


            try
            {
                if (pag.total > 0)
                {
                    pag.pagina++;

                    if (pag.total <= const_limit)
                    {
                        pag.current = pag.total = 0;
                    }
                    else
                    {
                        pag.total -= const_limit;
                        pag.current = (pag.total <= const_limit) ? (ushort)pag.total : const_limit;
                    }

                    // Cacule Index
                    calcIndex();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public class Pagina
        {

            public byte pagina;
            public ushort total;
            public ushort current;

            public byte[] ToArray()
            {
                using (var p = new PangyaBinaryWriter())
                {
                    p.Write(pagina);
                    p.Write(total);
                    p.Write(current);
                    return p.GetBytes;
                }
            }
        }

        public class Index
        {
            public ushort start;
            public ushort end;
            public byte[] ToArray()
            {
                using (var p = new PangyaBinaryWriter())
                {
                    p.Write(start);
                    p.Write(end);
                    return p.GetBytes;
                }
            }
        }
        protected void calcIndex()
        {
            try
            {
                // Calcule Index
                index.start = (ushort)((pag.pagina - 1) * const_limit);
                index.end = (ushort)(index.start + ((pag.total <= const_limit) ? pag.total : const_limit));
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected readonly ushort const_total;
        public readonly ushort const_limit;
        public ushort paginas;
        public Pagina pag = new Pagina();
        public Index index = new Index();
    }
}
