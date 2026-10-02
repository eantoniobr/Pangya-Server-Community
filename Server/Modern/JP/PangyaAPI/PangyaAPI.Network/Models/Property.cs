using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PangyaAPI.Network.Models
{
    public class Property
    { 
        public uint ulProperty { get; set; }

        public bool normal => ulProperty == 0;

        public bool special
        {
            get
            {
                return (ulProperty & 1) != 0;
            }
            set
            {
                ulProperty = (value ? (ulProperty | 1) : (ulProperty & 0xFFFFFFFEu));
            }
        }

        public bool small_play
        {
            get
            {
                return (ulProperty & 2) != 0;
            }
            set
            {
                ulProperty = (value ? (ulProperty | 2) : (ulProperty & 0xFFFFFFFDu));
            }
        }

        public bool ladder
        {
            get
            {
                return (ulProperty & 4) != 0;
            }
            set
            {
                ulProperty = (value ? (ulProperty | 4) : (ulProperty & 0xFFFFFFFBu));
            }
        }

        public bool adult
        {
            get
            {
                return (ulProperty & 8) != 0;
            }
            set
            {
                ulProperty = (value ? (ulProperty | 8) : (ulProperty & 0xFFFFFFF7u));
            }
        }

        public bool mantle
        {
            get
            {
                return (ulProperty & 0x10) != 0;
            }
            set
            {
                ulProperty = (value ? (ulProperty | 0x10) : (ulProperty & 0xFFFFFFEFu));
            }
        }

        public bool skins
        {
            get
            {
                return (ulProperty & 0x20) != 0;
            }
            set
            {
                ulProperty = (value ? (ulProperty | 0x20) : (ulProperty & 0xFFFFFFDFu));
            }
        }

        public bool only_rookie
        {
            get
            {
                return (ulProperty & 0x40) != 0;
            }
            set
            {
                ulProperty = (value ? (ulProperty | 0x40) : (ulProperty & 0xFFFFFFBFu));
            }
        }

        public bool natural
        {
            get
            {
                return (ulProperty & 0x80) != 0;
            }
            set
            {
                ulProperty = (value ? (ulProperty | 0x80) : (ulProperty & 0xFFFFFF7Fu));
            }
        }

        public bool championship
        {
            get
            {
                return (ulProperty & 0x100) != 0;
            }
            set
            {
                ulProperty = (value ? (ulProperty | 0x100) : (ulProperty & 0xFFFFFEFFu));
            }
        }

        public bool azul
        {
            get
            {
                return (ulProperty & 0x200) != 0;
            }
            set
            {
                ulProperty = (value ? (ulProperty | 0x200) : (ulProperty & 0xFFFFFDFFu));
            }
        }

        public bool verde
        {
            get
            {
                return (ulProperty & 0x400) != 0;
            }
            set
            {
                ulProperty = (value ? (ulProperty | 0x400) : (ulProperty & 0xFFFFFBFFu));
            }
        }

        public bool grand_prix
        {
            get
            {
                return (ulProperty & 0x800) != 0;
            }
            set
            {
                ulProperty = (value ? (ulProperty | 0x800) : (ulProperty & 0xFFFFF7FFu));
            }
        }

        public bool relay
        {
            get
            {
                return (ulProperty & 0x1000) != 0;
            }
            set
            {
                ulProperty = (value ? (ulProperty | 0x1000) : (ulProperty & 0xFFFFEFFFu));
            }
        }

        public bool rookie_beginner_only
        {
            get
            {
                return (ulProperty & 0x80000000u) != 0;
            }
            set
            {
                ulProperty = (value ? (ulProperty | 0x80000000u) : (ulProperty & 0x7FFFFFFF));
            }
        }

        public Property(uint _ul = 0u)
        {
            ulProperty = _ul;
        }
    }

}
