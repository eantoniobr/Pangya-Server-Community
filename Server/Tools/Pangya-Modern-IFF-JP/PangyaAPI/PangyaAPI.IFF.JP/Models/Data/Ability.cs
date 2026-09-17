using PangyaAPI.IFF.JP.Extensions;
using PangyaAPI.IFF.JP.Models.Flags;
using System;
using System.Runtime.InteropServices;
namespace PangyaAPI.IFF.JP.Models.Data
{
    #region Struct Ability.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Ability : ICloneable
    {
        public uint ID { get; set; }
        public Effect Efeito { get; set; } = new Effect();
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        private byte[] Unknown { get; set; } = new byte[32];
        public uint Flag1 { get; set; }
        public uint Flag2 { get; set; }
        public Ability()
        {
            Efeito = new Effect
            {
                EffectOrNo = new uint[3],
                Type = new uint[3],
                Rate = new float[3]
            };

            // Read Unknown array
            Unknown = new byte[32];

            // Read Flag1 and Flag2
            Flag1 = 0;
            Flag2 = 0;
        }

        public Ability(ref PangyaBinaryReader reader)
        {
            // Read Index
            ID = reader.ReadUInt32();

            // Read Effect
            Efeito = new Effect
            {
                EffectOrNo = new uint[3]
                {
                    reader.ReadUInt32(),
                    reader.ReadUInt32(),
                    reader.ReadUInt32()
                },
                Type = new uint[3]
                {
                    reader.ReadUInt32(),
                    reader.ReadUInt32(),
                    reader.ReadUInt32()
                },
                Rate = new float[3]
                {
                    reader.ReadSingle(),
                    reader.ReadSingle(),
                    reader.ReadSingle()
                }
            };

            // Read Unknown array
            Unknown = reader.ReadBytes(32);

            // Read Flag1 and Flag2
            Flag1 = reader.ReadUInt32();
            Flag2 = reader.ReadUInt32();
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public class Effect
        {
            [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public uint[] EffectOrNo { get; set; } // Activation during the shot (I think)
            [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public uint[] Type { get; set; }
            [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public float[] Rate { get; set; }
            public int getEffect(int idx)
            {
                return (int)EffectOrNo[idx];
            }

            public void setEffect(int idx, uint value)
            {
                EffectOrNo[idx] = value;
            }

            public int getTypeEffect(int idx)
            {
                return (int)Type[idx];
            }

            public void setTypeEffect(int idx, uint value)
            {
                Type[idx] = value;
            }

            public float getRate(int idx)
            {
                return Rate[idx];
            }

            public void setRate(int idx, uint value)
            {
                Rate[idx] = value;
            }
        
        public Effect Clone()
        {
        var clone = (Effect)MemberwiseClone();
        clone.EffectOrNo = this.EffectOrNo != null ? (uint[])this.EffectOrNo.Clone() : null;
        clone.Rate = this.Rate != null ? (float[])this.Rate.Clone() : null;
        return clone;
        }
}

        object ICloneable.Clone()
        {
            return Clone();
        }

        public Ability Clone()
        {
        var clone = (Ability)MemberwiseClone();
        clone.Efeito = this.Efeito?.Clone();
        clone.Unknown = this.Unknown != null ? (byte[])this.Unknown.Clone() : null;
        return clone;
        }
}
    #endregion
}
