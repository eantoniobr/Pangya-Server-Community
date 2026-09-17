using PangyaAPI.IFF.JP.Models.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
namespace PangyaAPI.IFF.JP.Extensions
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class DBIFFCollection : List<DBIFF>
    {
        public void GenerateSqlFile(ref BackgroundWorker BW, string fileName)
        {
            BW.ReportProgress(0, "SQL WRITER");
            TextWriter textWriter;
            textWriter = new StreamWriter(fileName, append: false);
            textWriter.WriteLine("-- --- /Create By LuisMK :D --- --\r\n");
            textWriter.WriteLine("USE [pangya]");
            textWriter.WriteLine("GO\r\n");
            int num =0;
            foreach (var item in this)
            {
                num++;
                string text = item.NAME.Replace("'", "''");
                string text2 = item.ICON.Replace("'", "''");
                 double a = 100.0 * ((double)num / (double)Count);
                BW.ReportProgress((int)Math.Round(a), "SQL WRITER");
                if (!string.IsNullOrEmpty(text2))
                {
                    textWriter.WriteLine("-- --- /Start Pangya_Item_Typelist Update --- --");
                    textWriter.WriteLine("-- Item: {0}", text);
                    textWriter.WriteLine("IF EXISTS ( SELECT TYPEID FROM pangya.PANGYA_ITEM_TYPELIST WHERE TYPEID = {0})", item.TYPEID);
                    textWriter.WriteLine("BEGIN");
                    textWriter.WriteLine("    UPDATE pangya.PANGYA_ITEM_TYPELIST");
                    textWriter.WriteLine("    SET [NAME] = N'{0}'", text);
                    textWriter.WriteLine("    , [ICON] = N'{0}'", text2);
                    textWriter.WriteLine("    , [PRICE] = {0}", item.PRICE);
                    textWriter.WriteLine("    , [ISCASH] = {0}", item.ISCASH);
                    textWriter.WriteLine("    , [DESC] = N'{0}'", item.DESC);
                    textWriter.WriteLine("    , [TYPE] = N'{0}'", item.TYPE);
                    textWriter.WriteLine("    , [IS_SALABLE] = N'{0}'", item.IS_SALABLE);
                    textWriter.WriteLine("    , [IFF_TYPE] = N'{0}'", item.IFF_TYPE);
                    textWriter.WriteLine("    WHERE TYPEID = {0}", item.TYPEID);
                    textWriter.WriteLine("END");
                    textWriter.WriteLine("ELSE");
                    textWriter.WriteLine("BEGIN");
                    textWriter.WriteLine("    INSERT INTO pangya.PANGYA_ITEM_TYPELIST");
                    textWriter.WriteLine("    ([TYPEID] ,[NAME] ,[ICON] ,[PRICE] ,[ISCASH] ,[TYPE] ,[COM0] ,[COM1] ,[COM2] ,[COM3] ,[COM4] ,[CHAR_SERIALNO] ,[DESC] ,[TNAME] ,[IS_SALABLE], [IFF_TYPE])");
                    textWriter.WriteLine($"    VALUES (N'{item.TYPEID}',N'{text}',N'{text2}' ,N'{item.PRICE}',N'{item.ISCASH}',N'{item.TYPE}',N'{item.COM0}', N'{item.COM1}',N'{item.COM2}',N'{item.COM3}',N'{item.COM4}',N'{item.CHAR_SERIALNO}',N'{item.DESC}',N'{item.NAME.Replace("'", "''")}',N'{item.IS_SALABLE}', N'{item.IFF_TYPE}')");
                    textWriter.WriteLine("END");
                    textWriter.WriteLine("-- --- /End Pangya_Item_Typelist Update --- --\r\n");
                }
            }
            textWriter.WriteLine("GO");
            textWriter.Close();
        }

        private string GetDebuggerDisplay()
        {
            return "GenerationSQL";
        }
    }
    public class DBIFF
    {
        public uint TYPEID { get; set; }
        public string NAME { get; set; }
        public string ICON { get; set; }
        public uint PRICE { get; set; }
        public ushort ISCASH { get; set; }
        public uint TYPE { get; set; }
        public ushort COM0 { get; set; }
        public ushort COM1 { get; set; }
        public ushort COM2 { get; set; }
        public ushort COM3 { get; set; }
        public ushort COM4 { get; set; }
        public string CHAR_SERIALNO { get; set; }
        public string DESC { get; set; }
        public string TNAME { get; set; }
        public ushort IS_SALABLE { get; set; }    
        public uint IFF_TYPE { get; set; }
        // Construtor que inicializa a partir de um objeto Part e outros parâmetros
        public DBIFF(Part part, string Desc, string tname)
        {
            TYPEID = part.ID;
            NAME = part.Name;
            ICON = part.ShopIcon;
            PRICE = (uint)part.DiscountPrice > 0 ? part.Price - part.DiscountPrice : part.Price;
            ISCASH = (ushort)part.GetTypeCash();
            TYPE = (uint)part.type_item;
            COM0 = part.Stats.Power;
            COM1 = part.Stats.Control;
            COM2 = part.Stats.Impact;
            COM3 = part.Stats.Spin;
            COM4 = part.Stats.Curve;
            CHAR_SERIALNO = "0"; // Atribuindo um valor padrão para CHAR_SERIALNO
            DESC = Desc;
            TNAME = tname;
            IS_SALABLE = (ushort)part.GetTypeCashDB(); // Ajuste conforme o tipo de retorno esperado
            IFF_TYPE = 2;
        }
        public DBIFF(ClubSet part, string Desc, string tname)
        {
            TYPEID = part.ID;
            NAME = part.Name;
            ICON = part.ShopIcon;
            PRICE = (uint)part.DiscountPrice > 0 ? part.Price - part.DiscountPrice : part.Price;
            ISCASH = (ushort)part.GetTypeCash();
            TYPE = 3;//taco
            COM0 = part.Stats.Power;
            COM1 = part.Stats.Control;
            COM2 = part.Stats.Impact;
            COM3 = part.Stats.Spin;
            COM4 = part.Stats.Curve;
            CHAR_SERIALNO = "0"; // Atribuindo um valor padrão para CHAR_SERIALNO
            DESC = Desc;
            TNAME = tname;
            IS_SALABLE = (ushort)part.GetTypeCashDB(); // Ajuste conforme o tipo de retorno esperado
            IFF_TYPE = (uint)PangyaAPI.IFF.JP.Models.Flags.IFF_GROUP.CLUBSET;
        }
        public DBIFF(Item part, string Desc, string tname)
        {
            TYPEID = part.ID;
            NAME = part.Name;
            ICON = part.ShopIcon;
            PRICE = (uint)part.DiscountPrice > 0 ? part.Price - part.DiscountPrice : part.Price;
            ISCASH = (ushort)part.GetTypeCash();
            TYPE = 3;//taco
            COM0 = part.Stats.Power;
            COM1 = part.Stats.Control;
            COM2 = part.Stats.Impact;
            COM3 = part.Stats.Spin;
            COM4 = part.Stats.Curve;
            CHAR_SERIALNO = "0"; // Atribuindo um valor padrão para CHAR_SERIALNO
            DESC = Desc;
            TNAME = tname;
            IS_SALABLE = (ushort)part.GetTypeCashDB(); // Ajuste conforme o tipo de retorno esperado
            IFF_TYPE = (uint)PangyaAPI.IFF.JP.Models.Flags.IFF_GROUP.ITEM;
        }
        public DBIFF(Caddie part, string Desc, string tname)
        {
            TYPEID = part.ID;
            NAME = part.Name;
            ICON = part.ShopIcon;
            PRICE = (uint)part.DiscountPrice > 0 ? part.Price - part.DiscountPrice : part.Price;
            ISCASH = (ushort)part.GetTypeCash();
            TYPE = 3;//taco
            COM0 = part.Stats.Power;
            COM1 = part.Stats.Control;
            COM2 = part.Stats.Impact;
            COM3 = part.Stats.Spin;
            COM4 = part.Stats.Curve;
            CHAR_SERIALNO = "0"; // Atribuindo um valor padrão para CHAR_SERIALNO
            DESC = Desc;
            TNAME = tname;
            IS_SALABLE = (ushort)part.GetTypeCashDB(); // Ajuste conforme o tipo de retorno esperado
            IFF_TYPE = (uint)PangyaAPI.IFF.JP.Models.Flags.IFF_GROUP.CADDIE;
        }
        public DBIFF(CaddieItem part, string Desc, string tname)
        {
            TYPEID = part.ID;
            NAME = part.Name;
            ICON = part.ShopIcon;
            PRICE = (uint)part.DiscountPrice > 0 ? part.Price - part.DiscountPrice : part.Price;
            ISCASH = (ushort)part.GetTypeCash();
            TYPE = 3;//taco          
            CHAR_SERIALNO = "0"; // Atribuindo um valor padrão para CHAR_SERIALNO
            DESC = Desc;
            TNAME = tname;
            IS_SALABLE = (ushort)part.GetTypeCashDB(); // Ajuste conforme o tipo de retorno esperado
            IFF_TYPE = (uint)PangyaAPI.IFF.JP.Models.Flags.IFF_GROUP.CAD_ITEM;
        }
        public DBIFF(Card part, string Desc, string tname)
        {
            TYPEID = part.ID;
            NAME = part.Name;
            ICON = part.ShopIcon;
            PRICE = (uint)part.DiscountPrice > 0 ? part.Price - part.DiscountPrice : part.Price;
            ISCASH = (ushort)part.GetTypeCash();
            TYPE = 3;//taco
            COM0 = part.Power;
            COM1 = part.Control;
            COM2 = part.Impact;
            COM3 = part.Spin;
            COM4 = part.Curve;
            CHAR_SERIALNO = "0"; // Atribuindo um valor padrão para CHAR_SERIALNO
            DESC = Desc;
            TNAME = tname;
            IS_SALABLE = (ushort)part.GetTypeCashDB(); // Ajuste conforme o tipo de retorno esperado
            IFF_TYPE = (uint)PangyaAPI.IFF.JP.Models.Flags.IFF_GROUP.CARD;
        }

        public DBIFF(HairStyle part, string Desc, string tname)
        {
            TYPEID = part.ID;
            NAME = part.Name;
            ICON = part.ShopIcon;
            PRICE = (uint)part.DiscountPrice > 0 ? part.Price - part.DiscountPrice : part.Price;
            ISCASH = (ushort)part.GetTypeCash();
            TYPE = 3;//taco
          
            CHAR_SERIALNO = "0"; // Atribuindo um valor padrão para CHAR_SERIALNO
            DESC = Desc;
            TNAME = tname;
            IS_SALABLE = (ushort)part.GetTypeCashDB(); // Ajuste conforme o tipo de retorno esperado
            IFF_TYPE = (uint)PangyaAPI.IFF.JP.Models.Flags.IFF_GROUP.HAIR_STYLE;
        }

        public DBIFF(AuxPart part, string Desc, string tname)
        {
            TYPEID = part.ID;
            NAME = part.Name;
            ICON = part.ShopIcon;
            PRICE = (uint)part.DiscountPrice > 0 ? part.Price - part.DiscountPrice : part.Price;
            ISCASH = (ushort)part.GetTypeCash();
            TYPE = 3;//taco
            COM0 = part.Power;
            COM1 = part.Control;
            COM2 = part.Impact;
            COM3 = part.Spin;
            COM4 = part.Curve;
            CHAR_SERIALNO = "0"; // Atribuindo um valor padrão para CHAR_SERIALNO
            DESC = Desc;
            TNAME = tname;
            IS_SALABLE = (ushort)part.GetTypeCashDB(); // Ajuste conforme o tipo de retorno esperado
            IFF_TYPE = (uint)PangyaAPI.IFF.JP.Models.Flags.IFF_GROUP.AUX_PART;
        }
        public DBIFF(Ball part, string Desc, string tname)
        {
            TYPEID = part.ID;
            NAME = part.Name;
            ICON = part.ShopIcon;
            PRICE = (uint)part.DiscountPrice > 0 ? part.Price - part.DiscountPrice : part.Price;
            ISCASH = (ushort)part.GetTypeCash();
            TYPE = 3;//taco
            COM0 = part.Stats.Power;
            COM1 = part.Stats.Control;
            COM2 = part.Stats.Impact;
            COM3 = part.Stats.Spin;
            COM4 = part.Stats.Curve;
            CHAR_SERIALNO = "0"; // Atribuindo um valor padrão para CHAR_SERIALNO
            DESC = Desc;
            TNAME = tname;
            IS_SALABLE = (ushort)part.GetTypeCashDB(); // Ajuste conforme o tipo de retorno esperado
            IFF_TYPE = (uint)PangyaAPI.IFF.JP.Models.Flags.IFF_GROUP.BALL;
        }
        public DBIFF(Mascot part, string Desc, string tname)
        {
            TYPEID = part.ID;
            NAME = part.Name;
            ICON = part.ShopIcon;
            PRICE = (uint)part.DiscountPrice > 0 ? part.Price - part.DiscountPrice : part.Price;
            ISCASH = (ushort)part.GetTypeCash();
            TYPE = 3;//taco
            COM0 = part.Power;
            COM1 = part.Control;
            COM2 = part.Impact;
            COM3 = part.Spin;
            COM4 = part.Curve;
            CHAR_SERIALNO = "0"; // Atribuindo um valor padrão para CHAR_SERIALNO
            DESC = Desc;
            TNAME = tname;
            IS_SALABLE = (ushort)part.GetTypeCashDB(); // Ajuste conforme o tipo de retorno esperado
            IFF_TYPE = (uint)PangyaAPI.IFF.JP.Models.Flags.IFF_GROUP.MASCOT;
        }

        public DBIFF(SetItem part, string Desc, string tname)
        {
            TYPEID = part.ID;
            NAME = part.Name;
            ICON = part.ShopIcon;
            PRICE = (uint)part.DiscountPrice > 0 ? part.Price - part.DiscountPrice : part.Price;
            ISCASH = (ushort)part.GetTypeCash();
            TYPE = 3;//taco        
            CHAR_SERIALNO = "0"; // Atribuindo um valor padrão para CHAR_SERIALNO
            DESC = Desc;
            TNAME = tname;
            IS_SALABLE = (ushort)part.GetTypeCashDB(); // Ajuste conforme o tipo de retorno esperado
            IFF_TYPE = (uint)PangyaAPI.IFF.JP.Models.Flags.IFF_GROUP.SET_ITEM;
        }
        public DBIFF(Skin part, string Desc, string tname)
        {
            TYPEID = part.ID;
            NAME = part.Name;
            ICON = part.ShopIcon;
            PRICE = (uint)part.DiscountPrice > 0 ? part.Price - part.DiscountPrice : part.Price;
            ISCASH = (ushort)part.GetTypeCash();
            TYPE = 3;//taco        
            CHAR_SERIALNO = "0"; // Atribuindo um valor padrão para CHAR_SERIALNO
            DESC = Desc;
            TNAME = tname;
            IS_SALABLE = (ushort)part.GetTypeCashDB(); // Ajuste conforme o tipo de retorno esperado
            IFF_TYPE = (uint)PangyaAPI.IFF.JP.Models.Flags.IFF_GROUP.SKIN;
        }
    }

}