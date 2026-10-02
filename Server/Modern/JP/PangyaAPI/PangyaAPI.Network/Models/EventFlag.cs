using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PangyaAPI.Network.Models
{
    public class EventFlag
    {


        public EventFlag(ushort ul = 0)
        {
            usEventFlag = ul;
        }
        public ushort usEventFlag { get; set; }

        public bool pang_x_plus
        {
            get
            {
                return (usEventFlag & 2) != 0;
            }
            set
            {
                usEventFlag = (ushort)(value ? (usEventFlag | 2) : (usEventFlag & -3));
            }
        }

        public bool exp_x2
        {
            get
            {
                return (usEventFlag & 4) != 0;
            }
            set
            {
                usEventFlag = (ushort)(value ? (usEventFlag | 4) : (usEventFlag & -5));
            }
        }

        public bool angel_wing
        {
            get
            {
                return (usEventFlag & 8) != 0;
            }
            set
            {
                usEventFlag = (ushort)(value ? (usEventFlag | 8) : (usEventFlag & -9));
            }
        }

        public bool exp_x_plus
        {
            get
            {
                return (usEventFlag & 0x10) != 0;
            }
            set
            {
                usEventFlag = (ushort)(value ? (usEventFlag | 0x10) : (usEventFlag & -17));
            }
        }

        public bool unknown_0
        {
            get
            {
                return (usEventFlag & 0x20) != 0;
            }
            set
            {
                usEventFlag = (ushort)(value ? (usEventFlag | 0x20) : (usEventFlag & -33));
            }
        }

        public bool unknown_1
        {
            get
            {
                return (usEventFlag & 0x40) != 0;
            }
            set
            {
                usEventFlag = (ushort)(value ? (usEventFlag | 0x40) : (usEventFlag & -65));
            }
        }

        public bool unknown_2
        {
            get
            {
                return (usEventFlag & 0x100) != 0;
            }
            set
            {
                usEventFlag = (ushort)(value ? (usEventFlag | 0x100) : (usEventFlag & -257));
            }
        }

        public bool club_mastery_x_plus
        {
            get
            {
                return (usEventFlag & 0x80) != 0;
            }
            set
            {
                usEventFlag = (ushort)(value ? (usEventFlag | 0x80) : (usEventFlag & -129));
            }
        }

        public bool unknown_3
        {
            get
            {
                return (usEventFlag & 0x200) != 0;
            }
            set
            {
                usEventFlag = (ushort)(value ? (usEventFlag | 0x200) : (usEventFlag & -513));
            }
        }

        public bool unknown_4
        {
            get
            {
                return (usEventFlag & 0x400) != 0;
            }
            set
            {
                usEventFlag = (ushort)(value ? (usEventFlag | 0x400) : (usEventFlag & -1025));
            }
        }

        public bool unknown_5
        {
            get
            {
                return (usEventFlag & 0x800) != 0;
            }
            set
            {
                usEventFlag = (ushort)(value ? (usEventFlag | 0x800) : (usEventFlag & -2049));
            }
        }

        public bool unknown_6
        {
            get
            {
                return (usEventFlag & 0x1000) != 0;
            }
            set
            {
                usEventFlag = (ushort)(value ? (usEventFlag | 0x1000) : (usEventFlag & -4097));
            }
        }

        public bool unknown_7
        {
            get
            {
                return (usEventFlag & 0x2000) != 0;
            }
            set
            {
                usEventFlag = (ushort)(value ? (usEventFlag | 0x2000) : (usEventFlag & -8193));
            }
        }

        public bool unknown_8
        {
            get
            {
                return (usEventFlag & 0x4000) != 0;
            }
            set
            {
                usEventFlag = (ushort)(value ? (usEventFlag | 0x4000) : (usEventFlag & -16385));
            }
        }

        public bool unknown_9
        {
            get
            {
                return (usEventFlag & 0x8000) != 0;
            }
            set
            {
                usEventFlag = (ushort)(value ? (usEventFlag | 0x8000) : (usEventFlag & -32769));
            }
        }
    }

}
