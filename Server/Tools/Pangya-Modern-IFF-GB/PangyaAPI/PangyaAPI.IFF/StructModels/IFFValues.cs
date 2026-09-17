using PangyaAPI.IFF.Models;
using PangyaAPI.IFF.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PangyaAPI.IFF.StructModels
{
    [Serializable, StructLayout(LayoutKind.Sequential)]
    public class IFFValues
    {
        public CharacterType CharacterType;
        public ushort Character_Raw;
        public ushort Group;
        public ushort Type;
        public ushort Pos;
        public ushort Serial;
    }
    [Serializable, StructLayout(LayoutKind.Sequential)]
  public  struct _stFlagShop
    {
        /// <summary>
        /// cp ou pang
        /// </summary>
        public bool is_cash;
        /// <summary>
        /// IsReserve
        /// </summary>
        public bool can_send_mail_and_personal_shop;

        public bool can_dup;
        /// <summary>
        /// IsSpecial
        /// </summary>
        public bool special;
        /// <summary>
        /// IsNew
        /// </summary>
        public bool block_mail_and_personal_shop;
        /// <summary>
        /// é vendive ou IsHot
        /// </summary>
        public bool is_saleable;   // Pang(Only Purchase, CP Gift and Purchase) (is_saleable e is_giftable vira flag de só Purchase CP ou Pang)
        public bool is_giftable;   // CP só pode ser presenteado (is_saleable e is_giftable vira flag de só Purchase CP ou Pang)
        public bool only_display;  // Apenas Display no shop
        public bool hide_shop;
        public bool IsHide()
        {
            return (is_cash == false & can_send_mail_and_personal_shop == false
                   & can_dup == false & special == false & block_mail_and_personal_shop == false
                   & is_saleable == false & is_giftable == false & only_display == false);
        }
    }
}
