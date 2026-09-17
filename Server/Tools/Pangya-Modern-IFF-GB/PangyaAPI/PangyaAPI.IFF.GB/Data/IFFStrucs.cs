using PangyaAPI.IFF.Definitions;
using PangyaAPI.IFF.StructModels;
using System;
using System.Runtime.InteropServices;
namespace PangyaAPI.IFF.Data
{
    #region Struct Ability.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Ability
    {
        public uint TypeID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] Effect_Active { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] Effect_Type { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public float[] Effect_Flag { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] Unknown_Object { get; set; }
        public uint Flag1 { get; set; }
        public uint Flag2 { get; set; }
    }
    #endregion

    #region Struct Part.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Part : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string MPet { get; set; }
        public uint EquipmentCategory { get; set; }// o tipo do item, 0, 2 normal, 8 e 9 UCC, 5 acho que é base ou commom Item
        public short PosMask { get; set; }
        public short HideMask { get; set; }
        public UInt32 Un2 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture1 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture2 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture3 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture4 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture5 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture6 { get; set; }
        public ushort Power { get; set; }
        public ushort Control { get; set; }
        public ushort Impact { get; set; }
        public ushort Spin { get; set; }
        public ushort Curve { get; set; }
        public ushort PowerSlot { get; set; }
        public ushort ControlSlot { get; set; }
        public ushort ImpactSlot { get; set; }
        public ushort SpinSlot { get; set; }
        public ushort CurveSlot { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
        public byte[] EquippableWith { get; set; }
        public uint SubPart1 { get; set; }
        public uint SubPart2 { get; set; }
        public ushort CardCharSlots { get; set; }
        public ushort CardCaddieSlots { get; set; }
        public uint Points { get; set; }
        public uint RentPang { get; set; }
        public UInt32 Un4 { get; set; }

    }
    #endregion

    #region Struct AuxPart.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class AuxPart : IFFCommon
    {
        public uint Quantity { get; set; }
        public uint Un1 { get; set; }
        public ushort Un2 { get; set; }
        public byte Power { get; set; }
        public byte Control { get; set; }
        public byte Impact { get; set; }
        public byte Spin { get; set; }
        public byte Curve { get; set; }
        public byte PowerSlot { get; set; }
        public byte ControlSlot { get; set; }
        public byte ImpactSlot { get; set; }
        public byte SpinSlot { get; set; }
        public byte CurveSlot { get; set; }
        public UInt16 Power_Drive { get; set; }
        public UInt16 Drop_Rate { get; set; }
        public UInt16 Power_Guage { get; set; }
        public UInt16 Pang_Rate { get; set; }
        public UInt16 Exp_Rate { get; set; }
        public UInt16 Unknown { get; set; }
        public UInt32 AuxPair { get; set; }
    }
    #endregion

    #region Struct Ball.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Ball : IFFCommon
    {
        public uint Unknown0 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Model;
        public uint Unknown2 { get; set; }
        public uint Unknown3 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BallSequence1;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BallSequence2;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BallSequence3;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BallSequence4;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BallSequence5;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BallSequence6;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BallSequence7;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BallFx1;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BallFx2;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BallFx3;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BallFx4;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BallFx5;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BallFx6;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BallFx7;
        public ushort Power { get; set; }
        public ushort Control { get; set; }
        public ushort Accuracy { get; set; }
        public ushort Spin { get; set; }
        public ushort Curve { get; set; }
        public ushort Unknown4 { get; set; }
    }
    #endregion

    #region Struct Caddie.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Caddie : IFFCommon
    {
        public uint Salary { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x27 + 1)]
        public string MPet;
        public ushort Power { get; set; }
        public ushort Control { get; set; }
        public ushort Impact { get; set; }
        public ushort Spin { get; set; }
        public ushort Curve { get; set; }
        public UInt16 Un4 { get; set; }
    }
    #endregion

    #region Struct CaddieItem.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class CaddieItem : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string MPet;

        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string TexTure;
        public UInt16 Price1 { get; set; }
        public UInt16 Price15 { get; set; }
        public UInt16 PriceUN { get; set; }
        public UInt16 Price30 { get; set; }
        public UInt32 Un4 { get; set; }
    }
    #endregion

    #region Struct CadieMagicBox.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class CadieMagicBox
    {
        public uint MagicID { get; set; }
        public uint Enabled { get; set; }
        public uint Sector { get; set; }
        public CadieBoxEnum BoxType { get; set; }
        public uint Level { get; set; }
        public uint Un1 { get; set; }
        public uint TypeID { get; set; }
        public uint Quatity { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public UInt32[] TradeID;
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public UInt32[] TradeQuantity;
        public UInt32 BoxID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Name;
        [field: MarshalAs(UnmanagedType.Struct)]
        public IFFTime DateStart;
        [field: MarshalAs(UnmanagedType.Struct)]
        public IFFTime EndTime;
    }
    #endregion

    #region Struct Card.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Card : IFFCommon
    {
        public byte Rarity { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string MPet { get; set; }
        public ushort PowerSlot { get; set; }
        public ushort ControlSlot { get; set; }
        public ushort AccuracySlot { get; set; }
        public ushort SpinSlot { get; set; }
        public ushort CurveSlot { get; set; }
        public CardEffectFlag Effect { get; set; }
        public UInt16 EffectValue { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string AdditionalTexture1;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string AdditionalTexture2;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string AdditionalTexture3;
        public UInt16 EffectTime { get; set; }
        public UInt16 Volumn { get; set; }
        public UInt32 Position { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] Unk;
    }
    #endregion

    #region Struct Character.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Character : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string MPet;// = new char[0x27 + 1];
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture1;// = new char[0x27 + 1];
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture2;//{ get; set; }// = new char[0x27 + 1];
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture3;//  = new char[0x27 + 1];
        public ushort Power { get; set; }
        public ushort Control { get; set; }
        public ushort Impact { get; set; }
        public ushort Spin { get; set; }
        public ushort Curve { get; set; }
        public byte PowerSlot { get; set; }
        public byte ControlSlot { get; set; }
        public byte ImpactSlot { get; set; }
        public byte SpinSlot { get; set; }
        public byte CurveSlot { get; set; }
        public byte Un1 { get; set; }
        public float MasteryProb { get; set; }
        public byte Stat1 { get; set; }
        public byte Stat2 { get; set; }
        public byte Stat3 { get; set; }
        public byte Stat4 { get; set; }
        public byte Stat5 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture4;// = new char[0x27 + 1];
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Un2;// = new char[0x2 + 1];
    }
    #endregion

    #region Struct ClubSet.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class ClubSet : IFFCommon
    {
        public uint Wood { get; set; }
        public uint Iron { get; set; }
        public uint Wedge { get; set; }
        public uint Putter { get; set; }
        public ushort Power { get; set; }
        public ushort Control { get; set; }
        public ushort Impact { get; set; }
        public ushort Spin { get; set; }
        public ushort Curve { get; set; }
        public ushort PowerSlot { get; set; }
        public ushort ControlSlot { get; set; }
        public ushort ImpactSlot { get; set; }
        public ushort SpinSlot { get; set; }
        public ushort CurveSlot { get; set; }
        public uint ClubType { get; set; }
        public uint ClubSPoint { get; set; }
        public uint RecoveryLimit { get; set; }
        public float RateWorkshop { get; set; }
        public uint Rank_WorkShop { get; set; }
        public ushort Transafer { get; set; }
        public ushort Flag1 { get; set; }
        public uint Unknown7 { get; set; }
        public uint Real_TypeID { get; set; }
    }
    #endregion

    #region Struct Club.iff

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Club : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string MPet { get; set; }
        public ushort ClubType { get; set; }
        public ushort Power { get; set; }
        public ushort Control { get; set; }
        public ushort Impact { get; set; }
        public ushort Spin { get; set; }
        public ushort Curve { get; set; }

    }
    #endregion

    #region Struct CutinInformation.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class CutinInformation
    {
        public UInt32 Enable { get; set; }
        public UInt32 TypeID { get; set; }

        public UInt32 Seq { get; set; }
        public UInt32 Sector { get; set; }

        public UInt32 Num1 { get; set; }
        public UInt32 Num2 { get; set; }
        public UInt32 NumImg1 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string IMG1;
        public UInt32 NumImg2 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string IMG2;//{ get; set; }
        public UInt32 NumImg3 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string IMG3;
        public UInt32 Time { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 41)]
        public byte[] UN;
        public UInt32 Num4 { get; set; }
    }
    #endregion

    #region Struct Desc.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Desc
    {
        public uint TypeID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
        public string Description { get; set; }
    }
    #endregion

    #region Struct GrandPrixData.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class GrandPrixData
    {
        public uint Enable { get; set; }
        public uint TypeID { get; set; }
        public uint TrueTypeID { get; set; }
        public uint TypeGP { get; set; }
        public ushort TimeHole { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 65 + 1)]
        public string Name;
        public uint TicketTypeID { get; set; }
        public uint Quantity { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 39 + 1)]
        public string Image;//[39 + 1];
        public byte Unknown1 { get; set; }
        public byte Natural { get; set; }
        public byte ShortBase { get; set; }
        public byte HoleSize { get; set; }
        public uint Artifact { get; set; }
        public uint Map { get; set; }
        public uint Mode { get; set; }
        public byte TotalHole { get; set; }
        public byte MinLevel { get; set; }
        public byte MaxLevel { get; set; }
        public byte Unknown2 { get; set; }
        public uint Condition1 { get; set; }
        public uint Condition2 { get; set; }
        public int ScoreBotMax { get; set; }
        public int ScoreBotMed { get; set; }
        public int ScoreBotMin { get; set; }
        public uint Diffucult { get; set; }
        public uint PangReward { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 4 + 1)]
        public uint[] RewardTypeID;
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 4 + 1)]
        public uint[] RewardQuantity;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
        public string Unknown3;//= new char[11 + 1];                                           
        [field: MarshalAs(UnmanagedType.Struct)]
        public IFFTime DateActive;
        public ushort Hour_Open { get; set; }
        public ushort Min_Open { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
        public string Unknown4;//= new char[11 + 1];
        public ushort Hour_Program { get; set; }
        public ushort Min_Program { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
        public string Unknown5;//= new char[11 + 1];
        public ushort Hour_End { get; set; }
        public ushort Min_End { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public string Unknown6;//= new char[7 + 1];
        public uint TypeIDGPLock { get; set; }
        public uint Lock { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 516)]
        public string Info;
        public string GetName()
        {
            return Name;
        }

        public bool IsNovice
        {
            get { return (this.Hour_Open == 0) && (this.Min_Open == 0) && (this.Hour_End == 0) && (this.Min_End == 0); }
        }
    }
    #endregion

    #region Struct GrandPrixRankReward.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]

    public class GrandPrixRankReward
    {
        public uint Enable { get; set; }
        public uint TypeID { get; set; }
        public uint Rank { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public uint[] RewardTypeID;
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public uint[] Quantity;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string Unknown;
        public uint Trophy { get; set; }
    }
    #endregion

    #region Struct GrandPrixSpecialHole.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class GrandPrixSpecialHole
    {
        public UInt32 Enable { get; set; }
        public UInt32 TypeID { get; set; }
        public UInt32 HolePOS { get; set; }
        public UInt32 Map { get; set; }
        public UInt32 Hole { get; set; }
    }
    #endregion

    #region Struct HairStyle.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class HairStyle : IFFCommon
    {
        public byte HairColor { get; set; }
        public CharTypeByHairColor CharType { get; set; }
        public ushort Blank { get; set; }
    }
    #endregion

    #region Struct Item.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Item : IFFCommon
    {
        public UInt32 ItemType { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]

        public string Texture;
        public ushort Power { get; set; }
        public ushort Control { get; set; }
        public ushort Accuracy { get; set; }
        public ushort Spin { get; set; }
        public ushort Curve { get; set; }
        public ushort Unkown { get; set; }
    }
    #endregion

    #region Struct LevelUpItem.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class LevelUpPrizeItem
    {
         public byte Active { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string Name { get; set; }
        public ushort Level { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] TypeID;
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] Quantity;
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] Time;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 132)]
        public string Description { get; set; }
    }
    #endregion

    #region Struct Mascot.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Mascot : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string MPet { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture2;
        public ushort Price1 { get; set; }
        public ushort Price7 { get; set; }
        public ushort UN0 { get; set; }
        public ushort Price30 { get; set; }
        public byte Power { get; set; }
        public byte Control { get; set; }
        public byte Impact { get; set; }
        public byte Spin { get; set; }
        public byte Curve { get; set; }
        public byte PowerSlot { get; set; }
        public byte ControlSlot { get; set; }
        public byte ImpactSlot { get; set; }
        public byte SpinSlot { get; set; }
        public byte CurveSlot { get; set; }
        public uint Effect1 { get; set; }
        public uint Effect2 { get; set; }
        public uint Effect3 { get; set; }
        public ushort GetDay()
        {
            return 7;
        }
    }
    #endregion

    #region Struct MemorialShopCoinItem.sff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class MemorialShopCoinItem
    {
        public uint Enable { get; set; }
        public uint TypeID { get; set; }
        public FilterCoinType CoinType { get; set; }//0 normal
        public uint Probabilities { get; set; }
        public uint Number { get; set; }
        public uint NumberMax { get; set; }
        public FilterType ItemType { get; set; }
        public uint Sex { get; set; }//Count??
        public uint Value_1 { get; set; }
        public uint Item { get; set; }
        public uint CharacterType { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 19)]
        public byte[] UN;
    }
    #endregion

    #region Struct MemorialRareItem.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class MemorialShopRareItem
    {
        public uint Enabled { get; set; }
        public uint Number { get; set; }
        public uint Count { get; set; }
        public uint TypeID { get; set; }
        public uint Probabilities { get; set; }
        public MemorialRareType RareType { get; set; }// Tipo Raro, EX: -1 - 0 normal, 1 - 2 raro, 3 - 4 Super raro
        public FilterType ItemType { get; set; }
        public uint Sex { get; set; }
        public uint Value_1 { get; set; }
        public uint Item { get; set; }
        public uint CharacterType { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public byte[] UN;

        public FilterType GetItemType(string type)
        {
            switch (type)
            {
                case "SPRING":
                    return FilterType.SPRING;
                case "SUMMER":
                    return FilterType.SUMMER;
                case "FALL":
                    return FilterType.FALL;

                case "WINTER":
                    return FilterType.WINTER;
                case "CLUBSET":
                    return FilterType.CLUBSET;
                case "SETITEM":
                    return FilterType.SETITEM;
                case "EAR":
                    return FilterType.EAR;
                case "WING":
                    return FilterType.WING;
                case "LUVA":
                    return FilterType.LUVA;
                case "RING_R":
                    return FilterType.RING_R;
                case "RING_L":
                    return FilterType.RING_L;
                case "CADDIE":
                    return FilterType.CADDIE;
                case "MASCOT":
                    return FilterType.MASCOT;
                case "SUMMER_HOLYDAY":
                    return FilterType.SUMMER_HOLYDAY;
                case "XMAS":
                    return FilterType.XMAS;
                case "HALLOWEEN":
                    return FilterType.HALLOWEEN;
                case "MAN":
                    return FilterType.MAN;
                case "WOMAN":
                    return FilterType.WOMAN;
                case "NURI":
                    return FilterType.NURI;
                case "HANA":
                    return FilterType.HANA;
                case "AZER":
                    return FilterType.AZER;
                case "CECI":
                    return FilterType.CECI;
                case "MAX":
                    return FilterType.MAX;
                case "KOOH":
                    return FilterType.KOOH;
                case "ARIN":
                    return FilterType.ARIN;
                case "KAZ":
                    return FilterType.KAZ;
                case "LUCIA":
                    return FilterType.LUCIA;
                case "NELL":
                    return FilterType.NELL;
                case "SPIKA":
                    return FilterType.SPIKA;
                case "NURI_R":
                    return FilterType.NURI_R;
                case "HANA_R":
                    return FilterType.HANA_R;
                case "AZER_R":
                    return FilterType.AZER_R;
                case "CECI_R":
                    return FilterType.CECI_R;
                default:
                    break;
            }
            return 0;
        }

        public MemorialRareType GetMemorialRareType(string type)
        {
            switch (type)
            {
                case "Default":
                    return MemorialRareType.Default;
                case "Normal":
                    return MemorialRareType.Normal;
                case "NRare":
                    return MemorialRareType.NRare;
                case "NRare2":
                    return MemorialRareType.NRare2;
                case "SR1":
                    return MemorialRareType.SR1;
                case "SR2":
                    return MemorialRareType.SR2;
                default:
                    break;
            }
            return 0;
        }

    }
    #endregion

    #region Struct SetItem.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SetItem : IFFCommon
    {
        public uint Total { get; set; }

        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public uint[] Item_TypeID { get; set; }

        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public ushort[] Item_Qty { get; set; }

        public ushort Power { get; set; }
        public ushort Control { get; set; }
        public ushort Impact { get; set; }
        public ushort Spin { get; set; }
        public ushort Curve { get; set; }
        public ushort Un { get; set; }
    }
    #endregion

    #region Struct Skin.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Skin : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string MPet;
        public uint PriceUnk { get; set; }
        public uint Price7 { get; set; }
        public uint Price30 { get; set; }
    }
    #endregion

    #region Struct Achievement.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Achievement : IFFCommon
    {
        public uint TypeID_Quest_Index { get; set; }
        public uint Achievement_Type { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string QuestName { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string QuestName1 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string QuestName2 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string QuestName3 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string QuestName4 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string QuestName5 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string QuestName6 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string QuestName7 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string QuestName8 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string QuestName9 { get; set; }
        public short S_Unknown { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public uint[] Quest_TypeID { get; set; }
        public uint T_Unknown { get; set; }
    }
    #endregion

    #region Struct QuestStuff.iff

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class QuestStuff : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public uint[] Counter_Item_TypeID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public uint[] Counter_Item_Qtnd { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] Reward_Item_TypeID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] Reward_Item_Qtnd { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] Reward_Item_Time { get; set; }
    }

    #endregion

    #region Struct QuestItem.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class QuestItem : IFFCommon
    {
        public uint Unknown { get; set; }
        public uint Quest_Type { get; set; }
        public uint Quest_Counter { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public uint[] Quest_TypeID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] Reward_Item_TypeID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] Reward_Item_Qtnd { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] Reward_Item_Time { get; set; }
        public uint Unknown1 { get; set; }

    }
    #endregion    

    #region Struct Ability.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class NameClass : IFFCommon
    { }
    #endregion

    #region Struct Ability.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SetEffectTable
    { 
    public uint ID { get; set; }
        public uint[] Effect { get; set; }
        public uint[] Type { get; set; }
        public uint[] TypeID { get; set;}
        public string Active { get; set; }
    }
    #endregion

}
