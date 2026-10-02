using System;
using System.Collections.Generic;
using System.Text;

namespace Pangya_RankingServer.Models
{ 
    public class KeyPosition : IEquatable<KeyPosition>, IComparable<KeyPosition>
    {
        public uint m_uid { get; set; }
        public uint m_position { get; set; }

        public KeyPosition(uint _ul = 0u)
        {
            m_uid = 0u;
            m_position = 0u;
        }

        public KeyPosition(uint _uid, uint _position)
        {
            m_uid = _uid;
            m_position = _position;
        }

        public void clear()
        {
            m_uid = 0u;
            m_position = 0u;
        }

        public bool Equals(KeyPosition other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;

            return m_position == other.m_position && m_uid == other.m_uid;
        }

        public override bool Equals(object obj) => Equals(obj as KeyPosition);

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 31 + m_uid.GetHashCode();
                hash = hash * 31 + m_position.GetHashCode();
                return hash;
            }
        }


        public int CompareTo(KeyPosition other)
        {
            if (ReferenceEquals(other, null)) return 1;

            int posComp = m_position.CompareTo(other.m_position);
            return posComp != 0 ? posComp : m_uid.CompareTo(other.m_uid);
        }

        public static bool operator ==(KeyPosition left, KeyPosition right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null)) return false;

            return left.Equals(right);
        }

        public static bool operator !=(KeyPosition left, KeyPosition right) => !(left == right);

        public static bool operator <(KeyPosition left, KeyPosition right) => left.CompareTo(right) < 0;

        public static bool operator >(KeyPosition left, KeyPosition right) => left.CompareTo(right) > 0;
    }

}
