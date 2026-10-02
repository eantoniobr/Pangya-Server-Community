using System;
using System.Collections.Generic;
using System.Text;

namespace PangyaAPI.Network.Models
{

    public class IDStateBlockFlag
    {
        private ulong _ull_IDState;

        public int block_time;

        public ulong ull_IDState
        {
            get
            {
                return _ull_IDState;
            }
            set
            {
                _ull_IDState = value;
            }
        }

        public bool L_BLOCK_TEMPORARY
        {
            get
            {
                return (_ull_IDState & 1) == 1;
            }
            set
            {
                _ull_IDState = (value ? (_ull_IDState | 1) : (_ull_IDState & 0xFFFFFFFFFFFFFFFEuL));
            }
        }

        public bool L_BLOCK_FOREVER
        {
            get
            {
                return (_ull_IDState & 2) == 2;
            }
            set
            {
                _ull_IDState = (value ? (_ull_IDState | 2) : (_ull_IDState & 0xFFFFFFFFFFFFFFFDuL));
            }
        }

        public bool L_BLOCK_LOUNGE
        {
            get
            {
                return (_ull_IDState & 4) == 4;
            }
            set
            {
                _ull_IDState = (value ? (_ull_IDState | 4) : (_ull_IDState & 0xFFFFFFFFFFFFFFFBuL));
            }
        }

        public bool L_BLOCK_SHOP_LOUNGE
        {
            get
            {
                return (_ull_IDState & 8) == 8;
            }
            set
            {
                _ull_IDState = (value ? (_ull_IDState | 8) : (_ull_IDState & 0xFFFFFFFFFFFFFFF7uL));
            }
        }

        public bool L_BLOCK_GIFT_SHOP
        {
            get
            {
                return (_ull_IDState & 0x10) == 16;
            }
            set
            {
                _ull_IDState = (value ? (_ull_IDState | 0x10) : (_ull_IDState & 0xFFFFFFFFFFFFFFEFuL));
            }
        }

        public bool L_BLOCK_PAPEL_SHOP
        {
            get
            {
                return (_ull_IDState & 0x20) == 32;
            }
            set
            {
                _ull_IDState = (value ? (_ull_IDState | 0x20) : (_ull_IDState & 0xFFFFFFFFFFFFFFDFuL));
            }
        }

        public bool L_BLOCK_SCRATCHY
        {
            get
            {
                return (_ull_IDState & 0x40) == 64;
            }
            set
            {
                _ull_IDState = (value ? (_ull_IDState | 0x40) : (_ull_IDState & 0xFFFFFFFFFFFFFFBFuL));
            }
        }

        public bool L_BLOCK_TICKER
        {
            get
            {
                return (_ull_IDState & 0x80) == 128;
            }
            set
            {
                _ull_IDState = (value ? (_ull_IDState | 0x80) : (_ull_IDState & 0xFFFFFFFFFFFFFF7FuL));
            }
        }

        public bool L_BLOCK_MEMORIAL_SHOP
        {
            get
            {
                return (_ull_IDState & 0x100) == 256;
            }
            set
            {
                _ull_IDState = (value ? (_ull_IDState | 0x100) : (_ull_IDState & 0xFFFFFFFFFFFFFEFFuL));
            }
        }

        public bool L_BLOCK_ALL_IP
        {
            get
            {
                return (_ull_IDState & 0x200) == 512;
            }
            set
            {
                _ull_IDState = (value ? (_ull_IDState | 0x200) : (_ull_IDState & 0xFFFFFFFFFFFFFDFFuL));
            }
        }

        public bool L_BLOCK_MAC_ADDRESS
        {
            get
            {
                return (_ull_IDState & 0x400) == 1024;
            }
            set
            {
                _ull_IDState = (value ? (_ull_IDState | 0x400) : (_ull_IDState & 0xFFFFFFFFFFFFFBFFuL));
            }
        }

        public IDStateBlockFlag(ulong _ul)
        {
            _ull_IDState = _ul;
        }
    }

}
