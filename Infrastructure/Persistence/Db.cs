using System.Data;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace Infrastructure.Persistence
{
    //inject using scoped using Db below
    public interface IDb
    {
        IDbConnection GetConn();
    }

    public class Db : IDb
    {
        private readonly string _connStr;
        public Db(string connString) => _connStr = connString;

        public IDbConnection GetConn() => new NpgsqlConnection(_connStr);
    }

    //inject using transient using Db below
    public interface IPgCmd 
    {
        NpgsqlCommand GetCmd(string query);
    }

    public class DbCmd : IPgCmd
    {
        private readonly NpgsqlConnection _conn;

        public DbCmd(IDb db) 
        {
            var conn = db.GetConn();
            if (conn is NpgsqlConnection pgConn)
                _conn = pgConn;
            else
                throw new NpgsqlException("DbCmd need npgsql connection");
        }

        public NpgsqlCommand GetCmd(string query)  =>  new NpgsqlCommand(query, _conn);
    }
}
