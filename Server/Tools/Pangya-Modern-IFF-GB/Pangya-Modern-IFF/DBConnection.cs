using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace PangyaSuiteFiles
{
    public class DBConnection
    {
        private SqlConnection conn;
        private DataSet ds;
        private SqlDataAdapter da;
        public string erro = "";
        public string table = "";
        public string Query = "";
        private SqlParameter param;
        private SqlCommand cmd;
        private string myKey = (0x258ea6.ToString() + "ppo");
        private TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        private MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
        public DBConnection()
        {
            this.table = "Pangya_IFF";//nome da tabela
            this.conn = new SqlConnection();
            this.cmd = new SqlCommand();
            //exemplo: "Data Source=127.0.0.1/SQLEXPRESS, 1433;Network Library=DBMSSOCN;Initial Catalog=" + this.table + ";User ID = teste; Password= 12345";

            this.conn.ConnectionString = "Data Source=ip,porta_aqui;Network Library=DBMSSOCN;Initial Catalog=" + this.table + ";User ID = usuario_aqui; Password= senha_aqui";
        }

        public void addParametro(string par, SqlDbType tipo, string valor, ParameterDirection Direcao)
        {
            if (par.Length > 0)
            {
                this.param = new SqlParameter();
                this.param = this.cmd.Parameters.Add(new SqlParameter(par, tipo));
                this.param.Direction = Direcao;
                this.param.Value = valor;
            }
        }

        public bool Conectou()
        {
            bool obj2;
            try
            {
                this.conn.Open();
                obj2 = true;
            }
            catch (Exception exception1)
            {
                Exception ex = exception1;
                ProjectData.SetProjectError(ex);
                Exception local2 = ex;
                obj2 = false;
                ProjectData.ClearProjectError();
            }
            finally
            {
                this.conn.Close();
            }
            return obj2;
        }

        public DataTable DataReaderToDataTable(SqlDataReader rdrReader)
        {
            DataTable table;
            try
            {
                DataTable schemaTable = rdrReader.GetSchemaTable();
                DataTable table2 = new DataTable();
                int num2 = schemaTable.Rows.Count - 1;
                int i = 0;
                while (true)
                {
                    int num4 = num2;
                    if (i > num4)
                    {
                        while (true)
                        {
                            if (!rdrReader.Read())
                            {
                                rdrReader.Close();
                                table = table2;
                                break;
                            }
                            DataRow row2 = table2.NewRow();
                            int num3 = rdrReader.FieldCount - 1;
                            i = 0;
                            while (true)
                            {
                                num4 = num3;
                                if (i > num4)
                                {
                                    table2.Rows.Add(row2);
                                    break;
                                }
                                row2[i] = rdrReader.GetValue(i);
                                i++;
                            }
                        }
                        break;
                    }
                    DataRow row = schemaTable.Rows[i];
                    string columnName = Conversions.ToString(row["ColumnName"]);
                    DataColumn column = new DataColumn(columnName, (Type)row["DataType"]);
                    table2.Columns.Add(column);
                    i++;
                }
            }
            catch (Exception exception1)
            {
                Exception ex = exception1;
                ProjectData.SetProjectError(ex);
                Interaction.MsgBox(ex.Message, MsgBoxStyle.ApplicationModal, null);
                table = new DataTable();
                ProjectData.ClearProjectError();
            }
            return table;
        }

        private string dc(string texto)
        {
            this.des.Key = this.hashmd5.ComputeHash(Encoding.ASCII.GetBytes(this.myKey));
            this.des.Mode = CipherMode.ECB;
            ICryptoTransform transform = this.des.CreateDecryptor();
            byte[] inputBuffer = Convert.FromBase64String(texto);
            return Encoding.ASCII.GetString(transform.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length));
        }

        public int execCmd(string SP)
        {
            int num2;
            try
            {
                this.conn.Open();
                this.cmd.Connection = this.conn;
                this.cmd.CommandType = CommandType.StoredProcedure;
                this.cmd.CommandText = SP;
                num2 = Conversions.ToInteger(this.cmd.ExecuteScalar());
            }
            catch (Exception exception1)
            {
                Exception ex = exception1;
                ProjectData.SetProjectError(ex);
                Exception exception = ex;
                num2 = 0;
                this.erro = exception.Message;
                MessageBox.Show("Aconteceu um erro: " + exception.Message, "Erro");
                ProjectData.ClearProjectError();
            }
            finally
            {
                this.conn.Close();
            }
            return num2;
        }

        public object execSP(string SP)
        {
            object obj2;
            try
            {
                this.conn.Open();
                this.cmd.Connection = this.conn;
                this.cmd.CommandType = CommandType.StoredProcedure;
                this.cmd.CommandText = SP;
                SqlDataReader rdrReader = this.cmd.ExecuteReader();
                DataTable table = new DataTable();
                obj2 = this.DataReaderToDataTable(rdrReader);
            }
            catch (Exception exception1)
            {
                Exception ex = exception1;
                ProjectData.SetProjectError(ex);
                Exception exception = ex;
                MessageBox.Show("Aconteceu um erro: " + exception.Message, "Erro");
                obj2 = new DataTable();
                ProjectData.ClearProjectError();
            }
            finally
            {
                this.conn.Close();
            }
            return obj2;
        }

        public object executarQuery(string Tipo, string Parametros = "")
        {
            object obj2;
            try
            {
                this.conn.Open();
            }
            catch (Exception exception1)
            {
                Exception ex = exception1;
                ProjectData.SetProjectError(ex);
                Exception local2 = ex;
                obj2 = false;
                ProjectData.ClearProjectError();
                return obj2;
            }
            if (Tipo == "S")
            {
                try
                {
                    this.da = new SqlDataAdapter(this.Query, this.conn);
                    this.ds = new DataSet();
                    this.da.Fill(this.ds, this.table);
                    this.conn.Close();
                }
                catch (Exception exception6)
                {
                    Exception ex = exception6;
                    ProjectData.SetProjectError(ex);
                    Exception exception2 = ex;
                    this.erro = exception2.Message;
                    obj2 = false;
                    ProjectData.ClearProjectError();
                    return obj2;
                }
            }
            if (Tipo == "U")
            {
                try
                {
                    int recordsAffected = new SqlCommand(this.Query, this.conn).ExecuteReader().RecordsAffected;
                    this.conn.Close();
                    obj2 = recordsAffected;
                }
                catch (Exception exception7)
                {
                    Exception ex = exception7;
                    ProjectData.SetProjectError(ex);
                    Exception exception3 = ex;
                    this.erro = exception3.Message;
                    obj2 = false;
                    ProjectData.ClearProjectError();
                }
            }
            else if (Tipo == "I")
            {
                try
                {
                    int recordsAffected = new SqlCommand(this.Query, this.conn).ExecuteReader().RecordsAffected;
                    this.conn.Close();
                    obj2 = true;
                }
                catch (Exception exception8)
                {
                    Exception ex = exception8;
                    ProjectData.SetProjectError(ex);
                    Exception exception4 = ex;
                    this.erro = exception4.Message;
                    obj2 = false;
                    ProjectData.ClearProjectError();
                }
            }
            else if (Tipo != "D")
            {
                if (Tipo != "P")
                {
                }
                this.conn.Close();
                obj2 = this.ds.Tables[this.table];
            }
            else
            {
                try
                {
                    new SqlCommand(this.Query, this.conn).ExecuteReader();
                    this.conn.Close();
                    obj2 = true;
                }
                catch (Exception exception9)
                {
                    Exception ex = exception9;
                    ProjectData.SetProjectError(ex);
                    Exception exception5 = ex;
                    this.erro = exception5.Message;
                    obj2 = false;
                    ProjectData.ClearProjectError();
                }
            }
            return obj2;
        }

        private object SanatizeSqlString(string sValue) =>
            (sValue != "") ? sValue.Replace("'", "''").Replace("--", " ").Replace("/*", " ").Replace("*/", " ") : "";
    }
}
