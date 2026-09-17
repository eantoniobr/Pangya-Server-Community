using Microsoft.VisualBasic.CompilerServices;
using PangyaAPI.IFF.Definitions;
using PangyaAPI.IFF.StructModels;
using System;
using System.Runtime.CompilerServices;
using static System.Math;
namespace PangyaAPI.IFF.Extensions
{
    public static class IFFHandleExtension
    {
        public static IFFGROUP GetItemGroup(uint TypeId)
        {
            uint result;
            result = (uint)Math.Round((TypeId & 0xFC000000) / Math.Pow(2.0, 26.0));
            return (IFFGROUP)result;
        }

        public static uint GetItemSubGroupIdentify22(uint _typeid)
        {
            return (uint)((_typeid & ~0xFC000000) >> 22);		// esse retorno os grupos divididos em 0x40 0x80 0xC0, 0x100, 0x140
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static CardTypeFlag GetCardType(uint TypeID)
        {
            if (Round((TypeID & 0xFF000000) / Pow(2.0, 24.0)) == 0x7C)
            { return (CardTypeFlag)Round((TypeID & 0x00FF0000) / Pow(2.0, 16.0)); }

            if (Round((TypeID & 0xFF000000) / Pow(2.0, 24.0)) == 0x7D)
            {
                if (Round((TypeID & 0x00FF0000) / Pow(2.0, 16.0)) == 0x40)
                { }
            }
            return CardTypeFlag.NPC;
        }

        public static uint GetCharacter(uint TypeID)
        {
            var Character = ((uint)((TypeID & 0x3fc0000) / Pow(2.0, 18.0)));
            return Character;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static byte GetAuxType(uint ID)
        {
            byte result;

            result = (byte)Round((ID & 0x001F0000) / Pow(2.0, 16.0));

            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static uint GetCaddieTypeIDBySkinID(uint SkinTypeID)
        {
            uint result;
            uint CaddieTypeID;
            CaddieTypeID = (uint)Round(a: ((SkinTypeID & 0x0FFF0000) >> 16) / 32);
            result = (CaddieTypeID + 0x1C000000) + ((SkinTypeID & 0x000F0000) >> 16);
            return result;
        }

        public static bool CardCheckPosition(this uint TypeID, uint Slot)
        {
            bool result = true;

            switch (Slot)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    {
                        if (!(GetCardType(TypeID) == CardTypeFlag.Normal))
                        {
                            result = false;
                        }

                    }
                    break;
                case 5:
                case 6:
                case 7:
                case 8:
                    {
                        if (!(GetCardType(TypeID) == CardTypeFlag.Caddie))
                        {
                            result = false;
                        }

                    }
                    break;
                case 9:
                case 10:
                    {
                        if (!(GetCardType(TypeID) == CardTypeFlag.NPC))
                        {
                            result = false;
                        }
                    }
                    break;
            }

            return result;
        }


        public static uint TypeItem(uint TypeID)
        {
             return (uint)((int)((TypeID & 0x3fc0000) / Math.Pow(2.0, 18.0)));
        }

        public static IFFValues GetTypeIDValues(uint TypeID)
        {
            var values = new IFFValues
            {
                CharacterType = (CharacterType)(uint)((int)((TypeID & 0x3fc0000) / Math.Pow(2.0, 18.0))),
                Character_Raw = (ushort)(((double)(TypeID & 0x3fc0000)) / Math.Pow(2.0, 18.0)),
                Group = (ushort)(((double)(TypeID & 0xfc000000)) / Math.Pow(2.0, 26.0)),
                Type = (ushort)(((double)(TypeID & 0x1f0000)) / Math.Pow(2.0, 16.0)),
                Pos = (ushort)((TypeID & 0x3e003) / Math.Pow(2.0, 13.0)),
                Serial = (ushort)(TypeID & 0xff),
            };
            return values;
        }

      public static uint GenerateNewTypeID(uint iffType, int characterId, int int_0, int group, int type, int serial)
        {
            if (group - 1 < 0)
            {
                group = 0;
            }
            return (uint)Convert.ToUInt64((iffType * Math.Pow(2.0, 26.0)) + (characterId * Math.Pow(2.0, 18.0)) + (int_0 * Math.Pow(2.0, 13.0)) + (group * Math.Pow(2.0, 11.0)) + (type * Math.Pow(2.0, 9.0)) + serial);
        }

        public static uint GenerateNewTypeID(uint charSerial, uint Pos, uint Group, uint Type, uint serial)
        {
            uint num = 0;
            if (Group - 1 < 0)
            {
                Group = 0;
            }
            try
            {
                num = Conversions.ToUInteger(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(2.0 * Math.Pow(2.0, 26.0), Operators.MultiplyObject(charSerial, Math.Pow(2.0, 18.0))), Operators.MultiplyObject(Pos, Math.Pow(2.0, 13.0))), Operators.MultiplyObject(Group, Math.Pow(2.0, 11.0))), Operators.MultiplyObject(Type, Math.Pow(2.0, 9.0))), serial));
            }
            catch (Exception exception1)
            {
                Exception ex = exception1;
                ProjectData.SetProjectError(ex);
                Exception local2 = ex;
                num = 0;
                ProjectData.ClearProjectError();
            }
            return num;
        }
        public static bool IsSelfDesign(uint TypeId)
        {
            switch (TypeId)
            {
                case 134258720:
                case 134242351:
                case 134258721:
                case 134242355:
                case 134496433:
                case 134496434:
                case 134512665:
                case 134496344:
                case 134512666:
                case 134496345:
                case 134783001:
                case 134758439:
                case 134783002:
                case 134758443:
                case 135020720:
                case 135020721:
                case 135045144:
                case 135020604:
                case 135045145:
                case 135020607:
                case 135299109:
                case 135282744:
                case 135299110:
                case 135282745:
                case 135545021:
                case 135545022:
                case 135569438:
                case 135544912:
                case 135569439:
                case 135544915:
                case 135807173:
                case 135807174:
                case 135823379:
                case 135807066:
                case 135823380:
                case 135807067:
                case 136093719:
                case 136069163:
                case 136093720:
                case 136069166:
                case 136331407:
                case 136331408:
                case 136355843:
                case 136331271:
                case 136355844:
                case 136331272:
                case 136593549:
                case 136593550:
                case 136617986:
                case 136593410:
                case 136617987:
                case 136593411:
                case 136880144:
                case 136855586:
                case 136880145:
                case 136855587:
                case 136855588:
                case 136855589:
                case 137379868:
                case 137379869:
                case 137404426:
                case 137379865:
                case 137404427:
                case 137379866:
                case 137904143:
                case 137904144:
                case 137928708:
                case 137904140:
                case 137928709:
                case 137904141:
                    return true;
                default:
                    return false;
            }
        }
    }
}
