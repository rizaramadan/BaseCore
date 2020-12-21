using System.Data;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public interface IDbConnectionFactory
    {
        string GetConnStr();
    }

    //inject using scoped using Db below
    public interface IDb
    {
        Task<IDbConnection> GetOpenConn();
    }

    public class Db : IDb
    {
        private readonly string _connStr;
        public Db(IDbConnectionFactory dbConnection) => _connStr = dbConnection.GetConnStr();

        public async Task<IDbConnection> GetOpenConn()
        {
            var conn = new NpgsqlConnection(_connStr);
            await conn.OpenAsync();
            return conn;
        }
    }

    //inject using transient using Db below
    public interface IPgCmd 
    {
        Task<NpgsqlCommand> GetCmd(string query);
    }

    public class PgCmd : IPgCmd
    {
        private readonly IDb _db;

        public PgCmd(IDb db) 
        {
            _db = db;
        }

        public async Task<NpgsqlCommand> GetCmd(string query)  
        {
            var conn = await _db.GetOpenConn();
            if (conn is NpgsqlConnection pgConn)
            {
                return new NpgsqlCommand(query, pgConn);
            }
            return null;
        }
    }
}
