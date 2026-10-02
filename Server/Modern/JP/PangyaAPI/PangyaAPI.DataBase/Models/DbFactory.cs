using PangyaAPI.DataBase.Engine;
using PangyaAPI.DataBase.Models; 
namespace PangyaAPI.DataBase.Models
{
    public static class DbFactory
    { 
        public static Connector Create(DatabaseContext ctx)
        {
            if (ctx == null || string.IsNullOrEmpty(ctx.engine))
                throw new ArgumentNullException(nameof(ctx), "ctx_db ou engine não informado");

            switch (ctx.engine.ToUpper())
            {
                case "MSSQL":
                case "SQLSERVER":
                    {
                        return new MSSQL(ctx);
                    }
                case "MYSQL":
                    return new MYSQL(ctx);

                //case "POSTGRESQL":
                //case "PGSQL":
                //    return new postgresql(ctx);

                default:
                    throw new NotSupportedException($"Engine '{ctx.engine}' não suportada");
            }
        }
    }
}
