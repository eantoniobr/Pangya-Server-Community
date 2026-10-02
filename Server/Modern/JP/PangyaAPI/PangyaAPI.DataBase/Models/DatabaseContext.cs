using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Runtime.InteropServices;
namespace PangyaAPI.DataBase.Models
{
    public class DatabaseContext
    {
        public string engine;
        public string ip;
        public string db_name;
        public string user;
        public string pass;
        public uint port;
        public bool cmd_log;
        public OdbcCommand hEnv;
        public OdbcConnection hDbc;
        public OdbcStmt hStmt;

        public void Init()
        {
            hEnv = new OdbcCommand();
            hDbc = new OdbcConnection();
            hStmt = new OdbcStmt();
        }

        // Método para criar a string de conexão com base no tipo de banco de dados
        public string CreateStrConnection()
        {
            bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            switch (engine.ToUpper())
            {
                case "MSSQL":
                    {
                        if (isWindows)
                        {
                            return $"DSN={ip};DATABASE={db_name};UID={user};PWD={pass};";
                        }

                        else
                        {
                            return
                                "Driver={ODBC Driver 18 for SQL Server};" +
                                $"Server={ip},{port};Database={db_name};Uid={user};Pwd={pass};" +
                                "Encrypt=No;"
                                + "TrustServerCertificate=Yes;";
                        }
                    }
                case "MYSQL":
                    {
                        if (isWindows)
                        {
                            return $"DSN={ip};DATABASE={db_name};UID={user};PWD={pass};";
                        }

                        else
                        {
                            return
                                "Driver={MySQL ODBC 8.0 Unicode Driver};" +
                                $"Server={ip},{port};Database={db_name};User={user};Password={pass};" +
                                "OPTION=3;";
                        }
                    }
                case "POSTGRESQL":
                    return $"Driver={{PostgreSQL Unicode}};Server={ip};Port={port};" +
                           $"Database={db_name};Uid={user};Pwd={pass};" +
                           $"MaxVarcharSize=255;Pooling=true;";
                default:
                    throw new Exception($"Engine '{engine}' não é suportado via ODBC.");
            }
        }
    }

}
