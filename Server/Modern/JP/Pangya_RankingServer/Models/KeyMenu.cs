using Pangya_RankingServer.Flags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pangya_RankingServer.Models
{
    public class KeyMenu : IEquatable<KeyMenu>, IComparable<KeyMenu>
    {
        public RankMenuFlags m_menu { get; set; }
        public byte m_item { get; set; }

        public KeyMenu(uint _ul = 0u)
        {
            m_menu = RankMenuFlags.RM_OVERALL;
            m_item = 0;
        }

        public KeyMenu(RankMenuFlags _menu, byte _item)
        {
            m_menu = _menu;
            m_item = _item;
        }

        public void clear()
        {
            m_menu = RankMenuFlags.RM_OVERALL;
            m_item = 0;
        }

        public bool Equals(KeyMenu other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;

            return m_menu == other.m_menu && m_item == other.m_item;
        }

        public override bool Equals(object obj) => Equals(obj as KeyMenu);

        public override int GetHashCode()
        {
            unchecked // permite overflow sem exception
            {
                int hash = 17;
                hash = hash * 31 + m_menu.GetHashCode();
                hash = hash * 31 + m_item.GetHashCode();
                return hash;
            }
        }


        public int CompareTo(KeyMenu other)
        {
            if (ReferenceEquals(other, null)) return 1;

            int menuComp = m_menu.CompareTo(other.m_menu);
            return menuComp != 0 ? menuComp : m_item.CompareTo(other.m_item);
        }

        public static bool operator ==(KeyMenu left, KeyMenu right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null)) return false;

            return left.Equals(right);
        }

        public static bool operator !=(KeyMenu left, KeyMenu right) => !(left == right);

        public static bool operator <(KeyMenu left, KeyMenu right) => left.CompareTo(right) < 0;

        public static bool operator >(KeyMenu left, KeyMenu right) => left.CompareTo(right) > 0;
    }

}
