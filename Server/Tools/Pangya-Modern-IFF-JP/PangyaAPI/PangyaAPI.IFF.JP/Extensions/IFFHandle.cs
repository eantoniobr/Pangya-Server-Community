using PangyaAPI.IFF.JP.Models;
using PangyaAPI.IFF.JP.Models.Data;
using PangyaAPI.IFF.JP.Models.Flags;
using PangyaAPI.IFF.JP.Models.General;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace PangyaAPI.IFF.JP.Extensions
{
    public class IFFHandle
    {
        public IFFFile<Part> Part { get; set; }
        public IFFFile<Item> Item { get; set; }
        public IFFFile<SetItem> SetItem { get; set; }
        public IFFFile<Mascot> Mascot { get; set; }
        public IFFFile<Achievement> Achievement { get; set; }
        public IFFFile<CounterItem> CounterItem { get; set; }
        public IFFFile<QuestStuff> QuestStuff { get; set; }
        public IFFFile<QuestItem> QuestItem { get; set; }
        public IFFFile<AuxPart> AuxPart { get; set; }
        public IFFFile<Ball> Ball { get; set; }
        public IFFFile<Caddie> Caddie { get; set; }
        public IFFFile<CaddieItem> CaddieItem { get; set; }
        public IFFFile<Card> Card { get; set; }
        public IFFFile<Character> Character { get; set; }
        public IFFFile<Club> Club { get; set; }
        public IFFFile<ClubSet> ClubSet { get; set; }
        public IFFFile<ClubSetWorkShopLevelUpProb> ClubWorkShopNextLevelProb { get; set; }
        public IFFFile<ClubSetWorkShopRankUpExp> ClubWorkShopRankExperience { get; set; }
        public IFFFile<ClubSetWorkShopLevelUpLimit> ClubWorkShopNextLevelLimit { get; set; }
        public IFFFile<Course> _Course { get; set; }
        public IFFFile<CutinInformation> CutinInfo { get; set; }
        public IFFFile<Enchant> _Enchant { get; set; }
        public IFFFile<Furniture> _Furniture { get; set; }
        public IFFFile<HairStyle> _HairStyle { get; set; }
        public IFFFile<Match> _Match { get; set; }
        public IFFFile<Skin> _Skins { get; set; }
        public IFFFile<Ability> ItemAbility { get; set; }
        public IFFFile<Desc> Desc { get; set; }
        public IFFFile<GrandPrixAIOptionalData> _GrandPrixAIOptionalData { get; set; }
        public IFFFile<GrandPrixConditionEquip> _GrandPrixConditionEquip { get; set; }
        public IFFFile<GrandPrixData> _GrandPrixData { get; set; }
        public IFFFile<MemorialShopCoinItem> MemorialShopCoinItem { get; set; }
        public IFFFile<ArtifactManaInfo> _ArtifactManaInfo { get; set; }
        public IFFFile<ErrorCodeInfo> ErrorCodeInfo { get; set; }
        public IFFFile<HoleCupDropItem> _HoleCupDropItem { get; set; }
        public IFFFile<LevelUpPrizeItem> _LevelUpPrizeItem { get; set; }
        public IFFFile<NonVisibleItemTable> _NonVisibleItemTable { get; set; }
        public IFFFile<PointShop> _PointShop { get; set; }
        public IFFFile<ShopLimitItem> _ShopLimitItem { get; set; }
        public IFFFile<SpecialPrizeItem> _SpecialPrizeItem { get; set; }
        public IFFFile<SubscriptionItemTable> m_subscription_item_table { get; set; }
        public IFFFile<SetEffectTable> _SetEffectTable { get; set; }
        public IFFFile<TikiPointTable> m_tiki_point_table { get; set; }
        public IFFFile<TikiRecipe> m_tiki_recipe { get; set; }
        public IFFFile<TikiSpecialTable> m_tiki_special_table { get; set; }
        public IFFFile<TimeLimitItem> m_time_limit_item { get; set; }
        public IFFFile<AddonPart> m_addon_part { get; set; }
        public IFFFile<CadieMagicBox> CadieMagicBox { get; set; }
        public IFFFile<CadieMagicBoxRandom> CadieMagicBoxRandom { get; set; }
        public IFFFile<CharacterMastery> CharacterMastery { get; set; }
        public IFFFile<GrandPrixRankReward> _GrandPrixRankReward { get; set; }
        public IFFFile<GrandPrixSpecialHole> _GrandPrixSpecialHole { get; set; }
        public IFFFile<MemorialShopRareItem> MemorialShopRareItem { get; set; }
        public IFFFile<CaddieVoiceTable> _CaddieVoiceTable { get; set; }
        public IFFFile<FurnitureAbility> _FurnitureAbility { get; set; }
        public IFFFile<TwinsItemTable> _TwinsItemTable { get; set; }
        string PATH_PANGYA_IFF = "data/pangya_jp.iff";
        public bool IsLoaded = false;
        ZipFileEx Zip { get; set; }
       
        public IFFHandle()
        {
            Zip = new ZipFileEx();
        }
        
        public IFFHandle(string data, bool one_file)
        {
            if (one_file)
            {
                var load = File.ReadAllBytes(data);

                string fileNameWithoutExtension = Path.GetFileName(data);

                switch (fileNameWithoutExtension)
                {
                    case "Character.iff":
                        Character = new IFFFile<Character>();
                        Character.Load(load);
                        break;
                    case "Achievement.iff":
                        Achievement = new IFFFile<Achievement>();
                        Achievement.Load(load);
                        break;
                    case "QuestItem.iff":
                        QuestItem = new IFFFile<QuestItem>();
                        QuestItem.Load(load);
                        break;
                    case "QuestStuff.iff":
                        QuestStuff = new IFFFile<QuestStuff>();
                        QuestStuff.Load(load);
                        break;
                    case "Part.iff":
                        Part = new IFFFile<Part>();
                        Part.Load(load);
                        break;
                    case "Card.iff":
                        Card = new IFFFile<Card>();
                        Card.Load(load);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                PATH_PANGYA_IFF = data;
                IsLoaded = false;
                Zip = new ZipFileEx(data);
                Init();
            }
        }

        ~IFFHandle()
        {
            IsLoaded = false;
        }

        private IFFFile<T> MakeUnzipLoad<T>(string iffName) where T : new()
        {
            var mapIFF = new IFFFile<T>();

            try
            {
                if (!File.Exists(PATH_PANGYA_IFF))
                    throw new NotSupportedException("Falha ao ler arquivo");

                if(Zip == null || !Zip.IsLoad)
                    Zip = new ZipFileEx(PATH_PANGYA_IFF);

                mapIFF.Load(Zip.GetEntryBytes(iffName));
                mapIFF.SetIffName(iffName);
                return mapIFF;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Trace Debugging {ex.Message}");
                return mapIFF;
            }
        }

        public void Init()
        {
            try
            {
                if (IsLoaded)
                    reset();

               _PointShop = load_point_shop();
                m_addon_part = load_addon_part();
                ErrorCodeInfo = load_error_code_info();
                ClubWorkShopNextLevelLimit = load_club_set_work_shop_level_up_limit();
                ClubWorkShopNextLevelProb = load_club_set_work_shop_level_up_prob();
                ClubWorkShopRankExperience = load_club_set_work_shop_rank_up_exp();
                Achievement = load_achievement();
                Item = load_item();
                Mascot = load_mascot();
                AuxPart = load_aux_part();
                Ball = load_ball();
                Caddie = load_caddie();
                CaddieItem = load_caddie_item();
                CadieMagicBox = load_cadie_magic_box();
                CadieMagicBoxRandom = load_cadie_magic_box_random();
                Card = load_card();
                Character = load_character();
                Club = load_club();
                ClubSet = load_club_set();
                _Course = load_course();
                _Enchant = load_enchant();
                _Furniture = load_furniture();
                _HairStyle = load_hair_style();
                _Match = load_match();
                _Skins = load_skin();
                ItemAbility = load_ability();
                Desc = load_desc();
                _GrandPrixData = load_grand_prix_data();
                _GrandPrixAIOptionalData = load_grand_prix_ai(); ;
                _GrandPrixRankReward = load_grand_prix_rank_reward();
                _GrandPrixSpecialHole = load_grand_prix_special_hole();
                MemorialShopCoinItem = load_memorial_shop_coin_item();
                MemorialShopRareItem = load_memorial_shop_rare_item();
                _FurnitureAbility = load_furniture_ability();
                _LevelUpPrizeItem = load_level_up_prize_item();
                CounterItem = load_counter_item();
                _SetEffectTable = load_set_effect_table();
                m_tiki_point_table = load_tiki_point_table();
                m_tiki_recipe = load_tiki_recipe();
                m_tiki_special_table = load_tiki_special_table();
                QuestItem = load_quest_item();
                QuestStuff = load_quest_stuff();
                SetItem = load_set_item();
                Part = load_part();
                IsLoaded = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void reset()
        {
            m_addon_part.Clear();//_addon_part();
            ErrorCodeInfo.Clear();//_error_code_info();
            ClubWorkShopNextLevelLimit.Clear();//_club_set_work_shop_level_up_limit();
            ClubWorkShopNextLevelProb.Clear();//_club_set_work_shop_level_up_prob();
            ClubWorkShopRankExperience.Clear();//_club_set_work_shop_rank_up_exp();
            Achievement.Clear();//_achievement();
            Item.Clear();//_item();
            Mascot.Clear();//_mascot();
            AuxPart.Clear();//_aux_part();
            Ball.Clear();//_ball();
            Caddie.Clear();//_caddie();
            CaddieItem.Clear();//_caddie_item();     
            CadieMagicBox.Clear();//_cadie_magic_box(); 
            CadieMagicBoxRandom.Clear();//_cadie_magic_box_random();  
            Card.Clear();//_card();      
            Character.Clear();//_character();
            Club.Clear();//_club();
            ClubSet.Clear();//_club_set();
            _Course.Clear();//_course();
            _Enchant.Clear();//_enchant();
            _Furniture.Clear();//_furniture();
            _HairStyle.Clear();//_hair_style();
            _Match.Clear();//_match();
            _Skins.Clear();//_skin();
            ItemAbility.Clear();//_ability();     
            Desc.Clear();//_desc();      
            _GrandPrixData.Clear();//_grand_prix_data();    
            _GrandPrixRankReward.Clear();//_grand_prix_rank_reward();
            _GrandPrixSpecialHole.Clear();//_grand_prix_special_hole();
            MemorialShopCoinItem.Clear();//_memorial_shop_coin_item();
            MemorialShopRareItem.Clear();//_memorial_shop_rare_item();    
            _FurnitureAbility.Clear();//_furniture_ability();
            _LevelUpPrizeItem.Clear();//_level_up_prize_item();
            CounterItem.Clear();//_counter_item();
            _SetEffectTable.Clear();//_set_effect_table();
            m_tiki_point_table.Clear();//_tiki_point_table();
            m_tiki_recipe.Clear();//_tiki_recipe();
            m_tiki_special_table.Clear();//_tiki_special_table();       
            QuestItem.Clear();//_quest_item();            
            QuestStuff.Clear();//_quest_stuff();        
            SetItem.Clear();//_set_item(); 
            Part.Clear();//_part();   
        }

        public void Reload()
        {
            reset();
            IsLoaded = false;
            Init();
        }

        public void Reload(string data)
        {
            reset();
            PATH_PANGYA_IFF = data;
            IsLoaded = false;
            Zip = new ZipFileEx(data);
            Init();
        }
        
        private IFFFile<Achievement> load_achievement()
        {
            return MakeUnzipLoad<Achievement>("Achievement.iff");
        }

        private IFFFile<QuestItem> load_quest_item()
        {
            return MakeUnzipLoad<QuestItem>("QuestItem.iff");
        }

        private IFFFile<QuestStuff> load_quest_stuff()
        {
            return MakeUnzipLoad<QuestStuff>("QuestStuff.iff");
        }

        private IFFFile<CounterItem> load_counter_item()
        {
            return MakeUnzipLoad<CounterItem>("CounterItem.iff");
        }

        private IFFFile<Item> load_item()
        {
            return MakeUnzipLoad<Item>("Item.iff");
        }

        private IFFFile<Part> load_part()
        {
            return MakeUnzipLoad<Part>("Part.iff");
        }

        private IFFFile<AuxPart> load_aux_part()
        {
            return MakeUnzipLoad<AuxPart>("AuxPart.iff");
        }

        private IFFFile<Ball> load_ball()
        {
            return MakeUnzipLoad<Ball>("Ball.iff");
        }

        private IFFFile<Caddie> load_caddie()
        {
            return MakeUnzipLoad<Caddie>("Caddie.iff");
        }

        private IFFFile<CaddieItem> load_caddie_item()
        {
            return MakeUnzipLoad<CaddieItem>("CaddieItem.iff");
        }

        private IFFFile<CadieMagicBox> load_cadie_magic_box()
        {
            return MakeUnzipLoad<CadieMagicBox>("CadieMagicBox.iff");
        }

        private IFFFile<CadieMagicBoxRandom> load_cadie_magic_box_random()
        {
            return MakeUnzipLoad<CadieMagicBoxRandom>("CadieMagicBoxRandom.iff");
        }

        private IFFFile<Card> load_card()
        {
            return MakeUnzipLoad<Card>("Card.iff");
        }

        private IFFFile<Character> load_character()
        {
            return MakeUnzipLoad<Character>("Character.iff");
        }

        private IFFFile<CharacterMastery> load_character_mastery()
        {
            return MakeUnzipLoad<CharacterMastery>("CharacterMastery.iff");
        }

        private IFFFile<Club> load_club()
        {
            return MakeUnzipLoad<Club>("Club.iff");
        }

        private IFFFile<ClubSet> load_club_set()
        {
            return MakeUnzipLoad<ClubSet>("ClubSet.iff");
        }

        private IFFFile<ClubSetWorkShopLevelUpLimit> load_club_set_work_shop_level_up_limit()
        {
            return MakeUnzipLoad<ClubSetWorkShopLevelUpLimit>("ClubSetWorkShopLevelUpLimit.iff");
        }

        private IFFFile<ClubSetWorkShopLevelUpProb> load_club_set_work_shop_level_up_prob()
        {
            return MakeUnzipLoad<ClubSetWorkShopLevelUpProb>("ClubSetWorkShopLevelUpProb.iff");
        }

        private IFFFile<ClubSetWorkShopRankUpExp> load_club_set_work_shop_rank_up_exp()
        {
            return MakeUnzipLoad<ClubSetWorkShopRankUpExp>("ClubSetWorkShopRankUpExp.iff");
        }

        private IFFFile<Course> load_course()
        {
            return MakeUnzipLoad<Course>("Course.iff");
        }

        private IFFFile<CutinInformation> load_cutin_infomation()
        {
            return MakeUnzipLoad<CutinInformation>("CutinInfomation.iff");
        }

        private IFFFile<Enchant> load_enchant()
        {
            return MakeUnzipLoad<Enchant>("Enchant.iff");
        }

        private IFFFile<Furniture> load_furniture()
        {
            return MakeUnzipLoad<Furniture>("Furniture.iff");
        }

        private IFFFile<HairStyle> load_hair_style()
        {
            return MakeUnzipLoad<HairStyle>("HairStyle.iff");
        }

        private IFFFile<Match> load_match()
        {
            return MakeUnzipLoad<Match>("Match.iff");
        }

        private IFFFile<Skin> load_skin()
        {
            return MakeUnzipLoad<Skin>("Skin.iff");
        }

        private IFFFile<Ability> load_ability()
        {
            return MakeUnzipLoad<Ability>("Ability.iff");
        }

        private IFFFile<Desc> load_desc()
        {
            return MakeUnzipLoad<Desc>("Desc.iff");
        }

        private IFFFile<GrandPrixAIOptionalData> load_grand_prix_ai_optional_data()
        {
            return MakeUnzipLoad<GrandPrixAIOptionalData>("GrandPrixAIOptionalData.sff");
        }

        private IFFFile<GrandPrixConditionEquip> load_grand_prix_condition_equip()
        {
            return MakeUnzipLoad<GrandPrixConditionEquip>("GrandPrixConditionEquip.iff");
        }

        private IFFFile<GrandPrixData> load_grand_prix_data()
        {
            return MakeUnzipLoad<GrandPrixData>("GrandPrixData.iff");
        }

        private IFFFile<GrandPrixAIOptionalData> load_grand_prix_ai()
        {
            return MakeUnzipLoad<GrandPrixAIOptionalData>("GrandPrixAIOptionalData.sff");
        }

        private IFFFile<GrandPrixRankReward> load_grand_prix_rank_reward()
        {
            return MakeUnzipLoad<GrandPrixRankReward>("GrandPrixRankReward.iff");
        }

        private IFFFile<GrandPrixSpecialHole> load_grand_prix_special_hole()
        {
            return MakeUnzipLoad<GrandPrixSpecialHole>("GrandPrixSpecialHole.iff");
        }

        private IFFFile<MemorialShopCoinItem> load_memorial_shop_coin_item()
        {
            return MakeUnzipLoad<MemorialShopCoinItem>("MemorialShopCoinItem.sff");
        }

        private IFFFile<MemorialShopRareItem> load_memorial_shop_rare_item()
        {
            return MakeUnzipLoad<MemorialShopRareItem>("MemorialShopRareItem.iff");
        }
        private IFFFile<PointShop> load_point_shop()
        {
            return MakeUnzipLoad<PointShop>("PointShop.iff");
        }

        private IFFFile<AddonPart> load_addon_part()
        {
            return MakeUnzipLoad<AddonPart>("AddonPart.iff");
        }

        private IFFFile<ArtifactManaInfo> load_artifact_mana_info()
        {
            return MakeUnzipLoad<ArtifactManaInfo>("ArtifactManaInfo.iff");
        }

        private IFFFile<CaddieVoiceTable> load_caddie_voice_table()
        {
            return MakeUnzipLoad<CaddieVoiceTable>("CaddieVoiceTable.iff");
        }

        private IFFFile<ErrorCodeInfo> load_error_code_info()
        {
            return MakeUnzipLoad<ErrorCodeInfo>("ErrorCodeInfo.iff");
        }

        private IFFFile<FurnitureAbility> load_furniture_ability()
        {
            return MakeUnzipLoad<FurnitureAbility>("FurnitureAbility.iff");
        }

        private IFFFile<HoleCupDropItem> load_hole_cup_drop_item()
        {
            return MakeUnzipLoad<HoleCupDropItem>("HoleCupDropItem.iff");
        }

        private IFFFile<LevelUpPrizeItem> load_level_up_prize_item()
        {
            return MakeUnzipLoad<LevelUpPrizeItem>("LevelUpPrizeItem.iff");
        }

        private IFFFile<NonVisibleItemTable> load_non_visible_item_table()
        {
            return MakeUnzipLoad<NonVisibleItemTable>("NonVisibleItemTable.iff");
        }

        private IFFFile<ShopLimitItem> load_shop_limit_item()
        {
            return MakeUnzipLoad<ShopLimitItem>("ShopLimitItem.iff");
        }

        private IFFFile<SpecialPrizeItem> load_special_prize_item()
        {
            return MakeUnzipLoad<SpecialPrizeItem>("SpecialPrizeItem.iff");
        }

        private IFFFile<SubscriptionItemTable> load_subscription_item_table()
        {
            return MakeUnzipLoad<SubscriptionItemTable>("SubscriptionItemTable.iff");
        }

        private IFFFile<SetEffectTable> load_set_effect_table()
        {
            return MakeUnzipLoad<SetEffectTable>("SetEffectTable.iff");
        }

        private IFFFile<TikiPointTable> load_tiki_point_table()
        {
            return MakeUnzipLoad<TikiPointTable>("TikiPointTable.iff");
        }

        private IFFFile<TikiRecipe> load_tiki_recipe()
        {
            return MakeUnzipLoad<TikiRecipe>("TikiRecipe.iff");
        }

        private IFFFile<TikiSpecialTable> load_tiki_special_table()
        {
            return MakeUnzipLoad<TikiSpecialTable>("TikiSpecialTable.iff");
        }

        private IFFFile<TimeLimitItem> load_time_limit_item()
        {
            return MakeUnzipLoad<TimeLimitItem>("TimeLimitItem.iff");
        }

        private IFFFile<TwinsItemTable> load_twins_item_table()
        {
            return MakeUnzipLoad<TwinsItemTable>("TwinsItemTable.iff");
        }

        private IFFFile<SetItem> load_set_item()
        {
            return MakeUnzipLoad<SetItem>("SetItem.iff");
        }

        private IFFFile<Mascot> load_mascot()
        {
            return MakeUnzipLoad<Mascot>("Mascot.iff");
        }

        private T MAKE_FIND_MAP_IFF<T>(IFFFile<T> _iff, uint ID)
        {
            if (!IsLoaded)
            {
                Console.WriteLine("[IFF::Find][Error] IFF not loaded");
                return default;
            }

            try
            {
                return _iff.GetItem(ID);
            }
            catch (Exception e)
            {
                Console.WriteLine("[IFF::Find][ErrorSystem] " + e.Message);
            }

            return (T)Activator.CreateInstance(typeof(T));
        }


        public AuxPart findAuxPart(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(AuxPart, _typeid);
        }

        public Ball findBall(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(Ball, _typeid);
        }

        public Caddie findCaddie(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(Caddie, _typeid);
        }

        public CaddieItem findCaddieItem(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(CaddieItem, _typeid);
        }

        public CadieMagicBox findCadieMagicBox(uint _seq)
        {
            return MAKE_FIND_MAP_IFF(CadieMagicBox, _seq);
        }

        public Card findCard(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(Card, _typeid);
        }

        public Character findCharacter(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(Character, _typeid);
        }

        public Club findClub(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(Club, _typeid);
        }

        public ClubSet findClubSet(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(ClubSet, _typeid);
        }

        public Achievement findAchievement(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(Achievement, _typeid);
        }


        // Find
        public Part findPart(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(Part, _typeid);
        }

        public Item findItem(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(Item, _typeid);
        }

        public Mascot findMascot(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(Mascot, _typeid);
        }

        public QuestItem findQuestItem(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(QuestItem, _typeid);
        }

        public QuestStuff findQuestStuff(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(QuestStuff, _typeid);
        }

        public SetItem findSetItem(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(SetItem, _typeid);
        }


        public Course findCourse(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(_Course, _typeid);
        }

        public Enchant findEnchant(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(_Enchant, _typeid);
        }

        public Furniture findFurniture(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(_Furniture, _typeid);
        }

        public HairStyle findHairStyle(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(_HairStyle, _typeid);
        }

        public Match findMatch(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(_Match, _typeid);
        }

        public Skin findSkin(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(_Skins, _typeid);
        }

        public Ability findAbility(uint _typeid)
        {
            var ability = ItemAbility.FirstOrDefault(c => c.ID == _typeid);
            return ability;
        }



        public Ability FindAbility(uint iD)
        {
            return ItemAbility.FirstOrDefault(c => c.ID == iD);
        }

        public Desc FindDesc(uint _typeid)
        {
            return Desc.FirstOrDefault(c=> c.ID == _typeid);
        }

        public GrandPrixData findGrandPrixData(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(_GrandPrixData, _typeid);
        }

        public List<GrandPrixRankReward> FindGrandPrixRankReward(uint _typeid)
        {
            return _GrandPrixRankReward.Where(c => c.ID == _typeid).ToList();
        }

        public MemorialShopCoinItem findMemorialShopCoinItem(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(MemorialShopCoinItem, _typeid);
        }

        public LevelUpPrizeItem findLevelUpPrizeItem(uint _level)
        {
            return MAKE_FIND_MAP_IFF(_LevelUpPrizeItem, _level);
        }

        public SetEffectTable findSetEffectTable(uint _id)
        {
            return MAKE_FIND_MAP_IFF(_SetEffectTable, _id);
        }

        public TikiPointTable findTikiPointTable(uint _id)
        {
            return MAKE_FIND_MAP_IFF(m_tiki_point_table, _id);
        }

        public TikiRecipe findTikiRecipe(uint _id)
        {
            return MAKE_FIND_MAP_IFF(m_tiki_recipe, _id);
        }

        public CadieMagicBoxRandom findCadieMagicBoxRandom(uint _id)
        {
            return MAKE_FIND_MAP_IFF(CadieMagicBoxRandom, _id);
        }

        public MemorialShopRareItem findMemorialShopRareItem(uint _gacha_num)
        {
            return MAKE_FIND_MAP_IFF(MemorialShopRareItem, _gacha_num);
        }

        public CounterItem findCounterItem(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(CounterItem, _typeid);
        }

        public bool ItemEquipavel(uint _typeid)
        {
            return Convert.ToBoolean(((_typeid & 0xFE000000) >> 25) & 3);
        }

        public bool IsBuyItem(uint _typeid)
        {

            var commom = FindCommonItem(_typeid);

            if (commom != null)
                return (commom.Active && commom.Shop.flag_shop.IsSale);

            return false;
        }


        public T findItem<T>(uint _typeid)
        {
            T commom = default;

            try
            {
                switch ((IFF_GROUP)getItemGroupIdentify(_typeid))
                {
                    case IFF_GROUP.CHARACTER:
                        commom = (T)Activator.CreateInstance(findCharacter(_typeid).GetType());
                        break;
                    case IFF_GROUP.PART:
                        commom = (T)Activator.CreateInstance(findPart(_typeid).GetType());
                        break;
                    case IFF_GROUP.CLUB:
                        commom = (T)Activator.CreateInstance(findClub(_typeid).GetType());
                        break;
                    case IFF_GROUP.CLUBSET:
                        commom = (T)Activator.CreateInstance(findClubSet(_typeid).GetType());
                        break;
                    case IFF_GROUP.BALL:
                        commom = (T)Activator.CreateInstance(findBall(_typeid).GetType());
                        break;
                    case IFF_GROUP.ITEM:
                        commom = (T)Activator.CreateInstance(findItem(_typeid).GetType());
                        break;
                    case IFF_GROUP.CADDIE:
                        commom = (T)Activator.CreateInstance(findCaddie(_typeid).GetType());
                        break;
                    case IFF_GROUP.CAD_ITEM:
                        commom = (T)Activator.CreateInstance(findCaddieItem(_typeid).GetType());
                        break;
                    case IFF_GROUP.SET_ITEM:
                        commom = (T)Activator.CreateInstance(findSetItem(_typeid).GetType());
                        break;
                    case IFF_GROUP.COURSE:
                        commom = (T)Activator.CreateInstance(findCourse(_typeid).GetType());
                        break;
                    case IFF_GROUP.SKIN:
                        commom = (T)Activator.CreateInstance(findSkin(_typeid).GetType());
                        break;
                    case IFF_GROUP.HAIR_STYLE:
                        commom = (T)Activator.CreateInstance(findHairStyle(_typeid).GetType());
                        break;
                    case IFF_GROUP.MASCOT:
                        commom = (T)Activator.CreateInstance(findMascot(_typeid).GetType());
                        break;
                    case IFF_GROUP.FURNITURE:
                        commom = (T)Activator.CreateInstance(findFurniture(_typeid).GetType());
                        break;
                    case IFF_GROUP.ACHIEVEMENT:
                        commom = (T)Activator.CreateInstance(findAchievement(_typeid).GetType());
                        break;
                    case IFF_GROUP.COUNTER_ITEM:
                        commom = (T)Activator.CreateInstance(findCounterItem(_typeid).GetType());
                        break;
                    case IFF_GROUP.AUX_PART:
                        commom = (T)Activator.CreateInstance(findAuxPart(_typeid).GetType());
                        break;
                    case IFF_GROUP.QUEST_STUFF:
                        commom = (T)Activator.CreateInstance(findQuestStuff(_typeid).GetType());
                        break;
                    case IFF_GROUP.QUEST_ITEM:
                        commom = (T)Activator.CreateInstance(findQuestItem(_typeid).GetType());
                        break;
                    case IFF_GROUP.CARD:
                        commom = (T)Activator.CreateInstance(findCard(_typeid).GetType());
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return commom;
        }

        public IFFCommon FindCommonItem(uint _typeid)
        {
            IFFCommon commom = new IFFCommon();

            try
            {
                switch ((IFF_GROUP)getItemGroupIdentify(_typeid))
                {
                    case IFF_GROUP.CHARACTER:
                        commom = Character.GetItemCommon(_typeid);
                        break;
                    case IFF_GROUP.PART:
                        commom = Part.GetItemCommon(_typeid);
                        break;
                    case IFF_GROUP.CLUB:
                        commom = Club.GetItemCommon(_typeid);
                        break;
                    case IFF_GROUP.CLUBSET:
                        commom = ClubSet.GetItemCommon(_typeid);
                        break;
                    case IFF_GROUP.BALL:
                        commom = Ball.GetItemCommon(_typeid);
                        break;
                    case IFF_GROUP.ITEM:
                        commom = Item.GetItemCommon(_typeid);
                        break;
                    case IFF_GROUP.CADDIE:
                        commom = Caddie.GetItemCommon(_typeid);
                        break;
                    case IFF_GROUP.CAD_ITEM:
                        commom = CaddieItem.GetItemCommon(_typeid);
                        break;
                    case IFF_GROUP.SET_ITEM:
                        commom = SetItem.GetItemCommon(_typeid);
                        break;
                    case IFF_GROUP.COURSE:
                        commom = _Course.GetItemCommon(_typeid);
                        break;
                    case IFF_GROUP.SKIN:
                        commom = _Skins.GetItemCommon(_typeid);
                        break;
                    case IFF_GROUP.HAIR_STYLE:
                        commom = _HairStyle.GetItemCommon(_typeid);
                        break;
                    case IFF_GROUP.MASCOT:
                        commom = Mascot.GetItemCommon(_typeid);
                        break;
                    case IFF_GROUP.FURNITURE:
                        commom = _Furniture.GetItemCommon(_typeid);
                        break;
                    case IFF_GROUP.ACHIEVEMENT:
                        commom = Achievement.GetItemCommon(_typeid);
                        break;
                    case IFF_GROUP.COUNTER_ITEM:
                        //  commom = findCounterItem(_typeid);
                        break;
                    case IFF_GROUP.AUX_PART:
                        commom = AuxPart.GetItemCommon(_typeid);
                        break;
                    case IFF_GROUP.QUEST_STUFF:
                        commom = QuestStuff.GetItemCommon(_typeid);
                        break;
                    case IFF_GROUP.QUEST_ITEM:
                        commom = QuestItem.GetItemCommon(_typeid);
                        break;
                    case IFF_GROUP.CARD:
                        commom = Card.GetItemCommon(_typeid);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (commom == null || string.IsNullOrEmpty(commom.Name))
            {
                if (commom == null)
                    commom = new IFFCommon();

                commom.Name = "Name Unknown";
                commom.ShopIcon = "none";
            }
            return commom;
        }
        public string GetItemName(uint typeid)
        {
            var common = FindCommonItem(typeid);
            if (common != null)
            {
                return common.Name;
            }
            return "";
        }


        public bool ItemDef(uint _typeid, uint typeid)
        {
            var Character = (CharacterType)_typeid;

            switch (Character)
            {
                case CharacterType.NURI:
                    _typeid = 67108864;
                    break;
                case CharacterType.HANA:
                    _typeid = 67108865;
                    break;
                case CharacterType.AZER:
                    _typeid = 67108866;
                    break;
                case CharacterType.CECILIA:
                    _typeid = 67108867;
                    break;
                case CharacterType.MAX:
                    _typeid = 67108868;
                    break;
                case CharacterType.KOOH:
                    _typeid = 67108869;
                    break;
                case CharacterType.ARIN:
                    _typeid = 67108870;
                    break;
                case CharacterType.KAZ:
                    _typeid = 67108871;
                    break;
                case CharacterType.LUCIA:
                    _typeid = 67108872;
                    break;
                case CharacterType.NELL:
                    _typeid = 67108873;
                    break;
                case CharacterType.SPIKA:
                    typeid = 67108874;
                    break;
                case CharacterType.NURI_R:
                    _typeid = 67108875;
                    break;
                case CharacterType.HANA_R:
                    _typeid = 67108876;
                    break;
                case CharacterType.AZER_R:
                    _typeid = 67108877;
                    break;
                case CharacterType.CECILIA_R:
                    _typeid = 67108878;
                    break;
                default:
                    break;
            }
            bool check_ = false;
            for (int i = 0; i < 24; ++i)
            {
#pragma warning disable CS0675 // Bit a bit ou operador usado em um operando de assinatura estendida
                var part_typeid = (((_typeid << 5/*CharIdentify*/) | i) << 13/*PartNum*/) | 0x8000400;
#pragma warning restore CS0675 // Bit a bit ou operador usado em um operando de assinatura estendida

                var item = findPart((uint)part_typeid);
                if (item.ID > 0)
                {
                    part_typeid = findPart((uint)part_typeid).ID;
                    check_ = part_typeid == typeid;
                    if (check_)
                    {
                        break;
                    }
                }
            }
            return check_;
        }

        public bool IsGiftItem(uint _typeid)
        {
            var commom = FindCommonItem(_typeid);

            // É saleable ou giftable nunca os 2 juntos por que é a flag composta Somente Purchase(compra)
            // então faço o xor nas 2 flag se der o valor de 1 é por que ela é um item que pode presentear
            // Ex: 1 + 1 = 2 Não é
            // Ex: 1 + 0 = 1 OK
            // Ex: 0 + 1 = 1 OK
            // Ex: 0 + 0 = 0 Não é
            if (commom != null)
                return (commom.Active && commom.Shop.flag_shop.IsCash
                    && (commom.Shop.flag_shop.IsSale ^ commom.Shop.flag_shop.IsGift));

            return false;
        }

        public bool IsOnlyDisplay(uint _typeid)
        {
            var commom = FindCommonItem(_typeid);

            if (commom != null)
                return (commom.Active && commom.Shop.flag_shop.IsDisplay);

            return false;
        }

        public bool IsOnlyPurchase(uint _typeid)
        {
            var commom = FindCommonItem(_typeid);

            if (commom != null)
                return (commom.Active && commom.Shop.flag_shop.IsSale
                    && commom.Shop.flag_shop.IsGift);

            return false;
        }

        public bool IsOnlyGift(uint _typeid)
        {
            var commom = FindCommonItem(_typeid);

            if (commom != null)
                return (commom.Active && commom.Shop.flag_shop.IsCash
                    && commom.Shop.flag_shop.IsGift && commom.Shop.flag_shop.IsSale);

            return false;
        }


        public uint getItemGroupIdentify(uint _typeid)
        {
            return (uint)((_typeid & 0xFC000000) >> 26);
        }


        public uint getItemSubGroupIdentify24(uint _typeid)
        {
            return (uint)((_typeid & ~0xFC000000) >> 24);       // aqui é >> 24, mas deixei 25 por causa do item equipável e o passivo, mas posso mudar depois isso
        }

        public uint getItemSubGroupIdentify22(uint _typeid)
        {
            return (uint)((_typeid & ~0xFC000000) >> 22);       // esse retorno os grupos divididos em 0x40 0x80 0xC0, 0x100, 0x140
        }

        public uint getItemSubGroupIdentify21(uint _typeid)
        {
            return (uint)((_typeid & ~0xFC000000) >> 21);       // esse retorno os grupos divididos em 0x20 0x40 0x60, 0x80, 0xA0, 0xC0, 0xE0, 0x100
        }

        public uint setItemSubGroupIdentify21(uint group, uint nextId)
        {
            // Verifica se o valor do grupo está dentro do intervalo válido
            if (group > 0x3F) // 0x3F é 63 em decimal, o limite para 6 bits
            {
                throw new ArgumentOutOfRangeException(nameof(group), "O valor do grupo está fora do intervalo permitido.");
            }

            // Define a baseTypeId, mantendo o valor fixo dos bits mais significativos
            uint baseTypeId = 622829568 & 0xFC000000;

            // Incrementa o próximo identificador específico
            uint specificId = nextId++;

            // Cria o novo Index combinando o identificador específico e o grupo
            uint newTypeId = baseTypeId | ((specificId & 0xFFFFF) | ((group << 21) & 0x03FFFFE0));

            return newTypeId;
        }

        public uint getItemCharIdentify(uint _typeid)
        {
            return (uint)((_typeid & 0x03FF0000) >> 18);
        }

        public uint getItemCharPartNumber(uint _typeid)
        {
            return (uint)((_typeid & 0x0003FF00) >> 13);
        }

        public uint getItemCharTypeNumber(uint _typeid)
        {
            return (uint)((_typeid & 0x00001FFF) >> 8);
        }

        public uint getItemIdentify(uint _typeid)
        {
            return (uint)(_typeid & 0x000000FF);
        }

        public uint getItemTitleNum(uint _typeid)
        {
            var restul = (_typeid & 0x3FFFFF);  
            return restul;
        }


        public uint getItemSkin(uint _typeid)
        {
            var restul = (_typeid & 0x3C00000u);
            if (restul == 0)
            {
                return 0;
            }
            
            if (restul == 4194304)
            {
                return 1;
            }

            if (restul == 8388608)
            {
                return 2;
            }

            if (restul == 12582912)
            {
                return 3;
            }

            if (restul == 20971520)
            {
                return 4;
            }
            
            if (restul == 25165824)
            {
                restul = 5;
            }
            return restul;
        }


        public uint getMatchTypeIdentity(uint _typeid)
        {
            return (uint)((_typeid & ~0xFC000000) >> 16);
        }

        public uint getCaddieItemType(uint _typeid)
        {
            return (uint)((_typeid & 0x0000FF00) >> 13);
        }

        public uint getCaddieIdentify(uint _typeid)
        {
            return (uint)(((_typeid & 0x0FFF0000) >> 21)/*Caddie Base*/ + ((_typeid & 0x000F0000) >> 16)/*Caddie Type, N, R, S e etc*/);
        }

        // Acho que eu fiz para usar no enchant de up stat de taqueira e character
        public uint getEnchantSlotStat(uint _typeid)
        {
            return (uint)((_typeid & 0x03FF0000) >> 20);
        }       

        public uint setItemAuxPartNumber(byte type, uint group, uint nextId)
        {
            // Define uma baseTypeId para o grupo, mantendo bits mais significativos
            uint baseTypeId = 0;
            if (type == 0)
                baseTypeId = 1879113857 & 0xFFFF0000; 
            else
                baseTypeId = 1881210884 & 0xFFFF0000;
            // Incrementa o próximo identificador específico
            uint specificId = nextId;

            // Cria o novo Index combinando o identificador específico e o grupo
            // Adiciona os bits de `group` e `specificId` ao baseTypeId
            uint newTypeId = baseTypeId | (specificId & 0x0000FFFF) | ((group << 16) & 0x00FF0000);

            return newTypeId;
        }
 
        public uint getItemAuxPartNumber(uint _typeid)
        {
            return (uint)((_typeid & 0x0003FF00) >> 16);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public byte GetAuxType(uint ID)
        {
            byte result;

            result = (byte)System.Math.Round((ID & 0x001F0000) / System.Math.Pow(2.0, 16.0));

            return result;
        }


        public CardTypeFlag GetCardType(uint TypeID)
        {
            // Aplicar a máscara e dividir pelo divisor
            double value = (TypeID & 0x00FF0000) / 65536.0;

            // Converter para o tipo CardTypeFlag
            return (CardTypeFlag)(int)(value + 0.5);
        }


        public bool CardCheckPosition(uint TypeID, uint Slot)
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
                default:
                    if (!(GetCardType(TypeID) == CardTypeFlag.Special))
                    {
                        result = false;
                    }
                    break;
            }

            return result;
        }

        public uint getGrandPrixAba(uint _typeid)
        {
            return (uint)((_typeid & 0x00FFFFFF) >> 19);
        }

        public uint getGrandPrixType(uint _typeid)
        {
            return (uint)((_typeid & 0x0000FF00) >> 8);
        }

        public bool isGrandPrixEvent(uint _typeid)
        {
            return (uint)((_typeid & 0x3000000) >> 24) == 3u;
        }

        public bool isGrandPrixNormal(uint _typeid)
        {
            return (uint)((_typeid & 0x3000000) >> 24) == 0u;
        }

        public bool IsExist(uint _typeid)
        {
            return FindCommonItem(_typeid) != null;
        }
        public bool ExistIcon(uint _typeid)
        {
            var _base = FindCommonItem(_typeid);
            if (_base == null)
            {
                return false;
            }
            return !string.IsNullOrEmpty(_base.ShopIcon);
        }



        public bool IsSelfDesign(uint TypeId)
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
        public bool IsCanOverlapped(uint _typeid)
        {

            switch ((IFF_GROUP)getItemGroupIdentify(_typeid))
            {
                case IFF_GROUP.CHARACTER:
                case IFF_GROUP.COURSE:
                case IFF_GROUP.MATCH:
                case IFF_GROUP.ENCHANT:
                case IFF_GROUP.HAIR_STYLE:
                case IFF_GROUP.ACHIEVEMENT:
                case IFF_GROUP.QUEST_STUFF:
                case IFF_GROUP.QUEST_ITEM:
                default:
                    return false;

                case IFF_GROUP.CLUBSET:
                    {
                        var cadItem = findClubSet(_typeid);

                        if (cadItem != null && cadItem.Shop.flag_shop.time_shop.active)
                            return true;    // Caddie item pode, se for de tempo para aumentar o tempo dele

                        break;
                    }
                case IFF_GROUP.FURNITURE:
                    {
                        var cadItem = findFurniture(_typeid);

                        if (cadItem != null && cadItem.Shop.flag_shop.time_shop.active)
                            return true;    // Caddie item pode, se for de tempo para aumentar o tempo dele

                        break;
                    }
                case IFF_GROUP.SKIN:
                    {
                        var cadItem = findSkin(_typeid);

                        if (cadItem != null && cadItem.Shop.flag_shop.time_shop.active)
                            return true;    // Caddie item pode, se for de tempo para aumentar o tempo dele

                        break;
                    }
                case IFF_GROUP.CAD_ITEM:
                    {
                        var cadItem = findCaddieItem(_typeid);

                        if (cadItem != null && cadItem.Shop.flag_shop.time_shop.active)
                            return true;    // Caddie item pode, se for de tempo para aumentar o tempo dele

                        break;
                    }
                case IFF_GROUP.MASCOT:
                    {
                        var mascot = findMascot(_typeid);

                        if (mascot != null && mascot.Shop.flag_shop.time_shop.active)
                            return true;

                        break;
                    }
                case IFF_GROUP.PART:
                    {
                        var part = findPart(_typeid);

                        // Libera os parts para Duplicatas se ele estiver liberado para vender no personal shop
                        if (part != null && (part.type_item == PART_TYPE.UCC_DRAW_ONLY || part.type_item == PART_TYPE.UCC_COPY_ONLY
                            || part.Shop.flag_shop.IsDuplication || part.Shop.flag_shop.can_send_mail_and_personal_shop || part.tiki.Type_TikiShop > 1))
                            return true;

                        break;
                    }
                case IFF_GROUP.ITEM:  // Libera todos item para dub se tiver abilitado no shop 
                case IFF_GROUP.BALL:
                case IFF_GROUP.CARD:
                    return true;
                case IFF_GROUP.CADDIE:
                    if (_typeid == 0x1C000001 || _typeid == 0x1C000002 || _typeid == 0x1C000003 || _typeid == 0x1C000007)
                        return true;
                    break;
                case IFF_GROUP.SET_ITEM:
                    {
                        var tipo_set_item = (SET_ITEM_SUB_TYPE)getItemSubGroupIdentify21(_typeid);

                        if (tipo_set_item == SET_ITEM_SUB_TYPE.BALL
                            || tipo_set_item == SET_ITEM_SUB_TYPE.CHARACTER_SET_DUP_AND_ITEM_PASSIVE_AND_ACTIVE
                            || tipo_set_item == SET_ITEM_SUB_TYPE.CARD || tipo_set_item == SET_ITEM_SUB_TYPE.CHARACTER_SET_NEW)   //olhar um codigo melhor depois
                            return true;

                        break;
                    }
                case IFF_GROUP.AUX_PART:
                    {
                        var auxPart = findAuxPart(_typeid);

                        if (auxPart != null && auxPart.Power/*Qntd*/ > 0)
                            return Convert.ToBoolean(_typeid & ~0x1F0000);

                        break;
                    }   // Fim AuxPart
            }   // Fim Case

            return false;
        }
        public bool IsItemEquipable(uint _typeid)
        {
            var item = findItem(_typeid);

            if (item != null)
                return (getItemSubGroupIdentify24(_typeid) >> 1) == 0;  // Equiável, aqui depois tenho que mudar se mudar lá em cima, para (func() >> 1) == 0

            return false;
        }

        public bool IsTitle(uint _typeid)
        {

            if ((IFF_GROUP)getItemGroupIdentify(_typeid) == IFF_GROUP.SKIN)
            {
                if ((_typeid & 0x3C00000u) != 0x1800000u)
                    return false;   // Não é um title

                return true;
            }

            return false;   // Não é uma skin(bg, frame, sticker, slot, cutin, title)
        }

        public IFFFile<Achievement> getAchievement()
        {
            return Achievement;
        }

        public IFFFile<QuestItem> getQuestItem()
        {
            return QuestItem;
        }
        public IFFFile<Item> getItem()
        {
            return Item;
        }

        public IFFFile<Card> getCard()
        {
            return Card;
        }

        public IFFFile<Skin> getSkin()
        {
            return _Skins;
        }

        public IFFFile<AuxPart> getAuxPart()
        {
            return AuxPart;
        }

        public IFFFile<Ball> getBall()
        {
            return Ball;
        }

        public IFFFile<Character> getCharacter()
        {
            return Character;
        }

        public IFFFile<Caddie> getCaddie()
        {
            return Caddie;
        }

        public IFFFile<CaddieItem> getCaddieItem()
        {
            return CaddieItem;
        }

        public IFFFile<CadieMagicBox> getCadieMagicBox()
        {
            return CadieMagicBox;
        }

        public IFFFile<ClubSet> getClubSet()
        {
            return ClubSet;
        }

        public IFFFile<HairStyle> getHairStyle()
        {
            return _HairStyle;
        }

        public IFFFile<Part> getPart()
        {
            return Part;
        }

        public IFFFile<Mascot> getMascot()
        {
            return Mascot;
        }

        public IFFFile<SetItem> getSetItem()
        {
            return SetItem;
        }

        public IFFFile<Desc> getDesc()
        {
            return Desc;
        }

        public IFFFile<LevelUpPrizeItem> getLevelUpPrizeItem()
        {
            return _LevelUpPrizeItem;
        }

        public IFFFile<MemorialShopCoinItem> getMemorialShopCoinItem()
        {
            return MemorialShopCoinItem;
        }

        public IFFFile<MemorialShopRareItem> getMemorialShopRareItem()
        {
            return MemorialShopRareItem;
        }

        public IFFFile<Course> getCourse()
        {
            return _Course;
        }

        public IFFFile<GrandPrixData> getGrandPrixData()
        {
            return _GrandPrixData;
        }

        public IFFFile<Ability> getAbility()
        {
            return ItemAbility;
        }

        public IFFFile<SetEffectTable> getSetEffectTable()
        {
            return _SetEffectTable;
        }

        public IFFFile<QuestStuff> getQuestStuff()
        {
            return QuestStuff;
        }

        public IFFFile<Club> getClub()
        {
            return Club;
        }

        public IFFFile<Enchant> getEnchant()
        {
            return _Enchant;
        }

        public IFFFile<Furniture> getFurniture()
        {
            return _Furniture;
        }

        public IFFFile<Match> getMatch()
        {
            return _Match;
        }

        public IFFFile<TikiPointTable> getTikiPointTable()
        {
            return m_tiki_point_table;
        }

        public IFFFile<TikiRecipe> getTikiRecipe()
        {
            return m_tiki_recipe;
        }

        public IFFFile<TikiSpecialTable> getTikiSpecialTable()
        {
            return m_tiki_special_table;
        }

        public IFFFile<CadieMagicBoxRandom> getCadieMagicBoxRandom()
        {
            return CadieMagicBoxRandom;
        }

        public IFFFile<GrandPrixRankReward> getGrandPrixRankReward()
        {
            return _GrandPrixRankReward;
        }

        public IFFFile<GrandPrixSpecialHole> getGrandPrixSpecialHole()
        {
            return _GrandPrixSpecialHole;
        }

        public IFFFile<FurnitureAbility> getFurnitureAbility()
        {
            return _FurnitureAbility;
        }
        public List<ClubSet> findClubSetOriginal(uint _typeid)
        {

            List<ClubSet> v_clubset = new List<ClubSet>();
            ClubSet clubset = null;

            // Invalid Typeid
            if (_typeid == 0)
                return v_clubset;

            if ((clubset = findClubSet(_typeid)) != null)
            {

                foreach (var el in ClubSet)
                {

                    // Text pangya é o logo da taqueira, como as especiais tem seu proprio logo
                    // então o número do logo vai ser a taqueira base das taqueira que transforma
                    if (el.text_pangya == clubset.text_pangya)
                        v_clubset.Add(el);
                }
            }

            return v_clubset;
        }

        public void UpdateIFF()
        {
            Zip = new ZipFileEx(PATH_PANGYA_IFF);  //atualizado
            var count_update = 0;

            UpdateField(Part, "Part.iff", ref count_update);
            UpdateField(Item, "Item.iff", ref count_update);
            UpdateField(SetItem, "SetItem.iff", ref count_update);
            UpdateField(Mascot, "Mascot.iff", ref count_update);
            UpdateField(Achievement, "Achievement.iff", ref count_update);
            UpdateField(CounterItem, "CounterItem.iff", ref count_update);
            UpdateField(QuestStuff, "QuestStuff.iff", ref count_update);
            UpdateField(QuestItem, "QuestItem.iff", ref count_update);
            UpdateField(AuxPart, "AuxPart.iff", ref count_update);
            UpdateField(Ball, "Ball.iff", ref count_update);
            UpdateField(Caddie, "Caddie.iff", ref count_update);
            UpdateField(CaddieItem, "CaddieItem.iff", ref count_update);
            UpdateField(Card, "Card.iff", ref count_update);
            UpdateField(Character, "Character.iff", ref count_update);
            UpdateField(Club, "Club.iff", ref count_update);
            UpdateField(ClubSet, "ClubSet.iff", ref count_update);
            UpdateField(ClubWorkShopNextLevelProb, "ClubSetWorkShopLevelUpProb.iff", ref count_update);
            UpdateField(ClubWorkShopRankExperience, "ClubSetWorkShopRankUpExp.iff", ref count_update);
            UpdateField(_Course, "Course.iff", ref count_update);
            UpdateField(CutinInfo, "CutinInformation.iff", ref count_update);
            UpdateField(_Enchant, "Enchant.iff", ref count_update);
            UpdateField(_Furniture, "Furniture.iff", ref count_update);
            UpdateField(_HairStyle, "HairStyle.iff", ref count_update);
            UpdateField(_Match, "Match.iff", ref count_update);
            UpdateField(_Skins, "Skin.iff", ref count_update);
            UpdateField(ItemAbility, "Ability.iff", ref count_update);
            UpdateField(Desc, "Desc.iff", ref count_update);
            UpdateField(_GrandPrixAIOptionalData, "GrandPrixAIOptionalData.iff", ref count_update);
            UpdateField(_GrandPrixConditionEquip, "GrandPrixConditionEquip.iff", ref count_update);
            UpdateField(_GrandPrixData, "GrandPrixData.iff", ref count_update);
            UpdateField(MemorialShopCoinItem, "MemorialShopCoinItem.sff", ref count_update);
            UpdateField(_ArtifactManaInfo, "ArtifactManaInfo.iff", ref count_update);
            UpdateField(ErrorCodeInfo, "ErrorCodeInfo.iff", ref count_update);
            UpdateField(_HoleCupDropItem, "HoleCupDropItem.iff", ref count_update);
            UpdateField(_LevelUpPrizeItem, "LevelUpPrizeItem.iff", ref count_update);
            UpdateField(_NonVisibleItemTable, "NonVisibleItemTable.iff", ref count_update);
            UpdateField(_PointShop, "PointShop.iff", ref count_update);
            UpdateField(_ShopLimitItem, "ShopLimitItem.iff", ref count_update);
            UpdateField(_SpecialPrizeItem, "SpecialPrizeItem.iff", ref count_update);
            UpdateField(m_subscription_item_table, "SubscriptionItemTable.iff", ref count_update);
            UpdateField(_SetEffectTable, "SetEffectTable.iff", ref count_update);
            UpdateField(m_tiki_point_table, "TikiPointTable.iff", ref count_update);
            UpdateField(m_tiki_recipe, "TikiRecipe.iff", ref count_update);
            UpdateField(m_tiki_special_table, "TikiSpecialTable.iff", ref count_update);
            UpdateField(m_time_limit_item, "TimeLimitItem.iff", ref count_update);
            UpdateField(m_addon_part, "AddonPart.iff", ref count_update);
            UpdateField(CadieMagicBox, "CadieMagicBox.iff", ref count_update);
            UpdateField(CadieMagicBoxRandom, "CadieMagicBoxRandom.iff", ref count_update);
            UpdateField(CharacterMastery, "CharacterMastery.iff", ref count_update);
            UpdateField(ClubWorkShopNextLevelLimit, "ClubSetWorkShopLevelUpLimit.iff", ref count_update);
            UpdateField(_GrandPrixRankReward, "GrandPrixRankReward.iff", ref count_update);
            UpdateField(_GrandPrixSpecialHole, "GrandPrixSpecialHole.iff", ref count_update);
            UpdateField(MemorialShopRareItem, "MemorialShopRareItem.iff", ref count_update);
            UpdateField(_CaddieVoiceTable, "CaddieVoiceTable.iff", ref count_update);
            UpdateField(_FurnitureAbility, "FurnitureAbility.iff", ref count_update);
            UpdateField(_TwinsItemTable, "TwinsItemTable.iff", ref count_update);

            if (count_update > 0)
            {
                try
                {
                    Zip.Save(PATH_PANGYA_IFF);
                }
                catch (Exception e)
                {
                   // MessageBox.Show("Error: " + e.Message, "PangyaAPI.IFF.JP");
                }
            }
        }


        public void UpdateType<T>(IFFFile<T> type)
        {
            // Obtém o tipo da classe que chama o método (SuaClasse)
            Type tipoClasse = this.GetType();

            // Obtém todos os campos públicos da classe
            FieldInfo[] campos = tipoClasse.GetFields(BindingFlags.Public | BindingFlags.Instance);

            // Percorre todos os campos públicos da classe
            foreach (FieldInfo campo in campos)
            {
                // Verifica se o tipo do campo é IFFFile<T> e se o tipo genérico corresponde ao tipo fornecido
                if (campo.FieldType.IsGenericType && campo.FieldType.GetGenericTypeDefinition() == typeof(IFFFile<>))
                {
                    Type[] argumentosGenericos = campo.FieldType.GetGenericArguments();
                    if (argumentosGenericos.Length == 1 && argumentosGenericos[0] == typeof(T))
                    {
                        // Define o valor do campo como o tipo passado
                        campo.SetValue(this, type);
                        return; // Termina o método após encontrar o campo correspondente
                    }
                }
            }
        }


        void UpdateField<T>(IFFFile<T> field, string iffFilePath, ref int count_update)
        {
            if (field != null && field.Update)
            {
                UpdateIFF(iffFilePath, field.GetStream());
                count_update++;
                field.Update = false;
            }
        }

        void UpdateIFF(string file, Stream stream)
        {
            Zip.Update(file, stream);
        }

        public void Log(string v)
        {
            File.WriteAllText($"IF_{DateTime.Now.Millisecond}.Log", v);
        }


        public void GenerationCopy()
        {
            string sourceFilePath = PATH_PANGYA_IFF;
            string backupFolder = Path.Combine(Path.GetDirectoryName(sourceFilePath), "Backup");

            // Verifica se a pasta "Backup" já existe
            if (!Directory.Exists(backupFolder))
            {
                // Cria a pasta "Backup" se não existir
                Directory.CreateDirectory(backupFolder);
            }

            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(sourceFilePath);
            string fileExtension = Path.GetExtension(sourceFilePath);

            string currentDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            string newFileName = $"{fileNameWithoutExtension}_{currentDate}{fileExtension}";
            string destinationFilePath = Path.Combine(backupFolder, newFileName);

            File.Copy(sourceFilePath, destinationFilePath);
        }

        public List<pangya_new_memorial_coin> GetMemorial()
        {
            var m_coin = new List<pangya_new_memorial_coin>();

            foreach (var el in MemorialShopCoinItem)
            {
                var c = new pangya_new_memorial_coin
                {
                    coin_tipo = (int)el.CoinType,
                    coin_typeid = (int)el.ID,
                    coin_probabilidade = (int)el.Probabilities,
                };
                foreach (var el2 in MemorialShopRareItem)
                {

                    if (!el.gacha_range.empty() && !el.gacha_range.isBetweenGacha(el2.gacha.Number))
                        continue;

                    if (el.emptyFilter())
                    {
                        var ci = new pangya_new_memorial_rare_item
                        {
                            item_tipo = (int)el2.RareType,
                            item_typeid = (int)el2.ID,
                            item_probabilidade = (int)el2.Probabilities,
                            item_gacha_number = (int)el2.gacha.Number,
                            item_qntd = 1,
                            item_dup = 0
                        };
                        c.item.Add(ci);
                    }
                    else
                    {
                        for (var i = 0u; i < 10; ++i)
                        {

                            if (el.hasFilter(el2.getFilter()[i]))
                            {

                                var ci = new pangya_new_memorial_rare_item
                                {
                                    item_tipo = (int)el2.RareType,
                                    item_typeid = (int)el2.ID,
                                    item_probabilidade = (int)el2.Probabilities,
                                    item_gacha_number = (int)el2.gacha.Number,
                                    item_qntd = 1,
                                    item_dup = 0
                                };
                                c.item.Add(ci);

                                break;  // Sai do Loop de Filters
                            }
                        }   // Fim do loop de Filters
                    }
                }   // Fim do loop de Rare Item
                m_coin.Add(c);
            }
            return m_coin;// Fim do loop de Coin Item
        }
    }
    public class pangya_new_memorial_coin
    {
        public int coin_tipo;
        public int coin_typeid;
        public int coin_probabilidade;
        public List<pangya_new_memorial_rare_item> item = new List<pangya_new_memorial_rare_item>();
    }
    public class pangya_new_memorial_rare_item
    {
        public int item_tipo;
        public int item_typeid;
        public int item_probabilidade;
        public int item_gacha_number;
        public int item_qntd;
        public int item_dup;
    }
}
