using SqlSugar;
using System;
using System.Configuration;
using Monk.Utils;

namespace Monk.DbStore
{
    public class DbServices : IDisposable
    {
        protected SqlSugarClient _db;
        public DbServices()
        {
            this._db = new SqlSugarClient(ConfigurationManager.ConnectionStrings[Keys.ConnectionStringKey].ToString());
        }

        public void Command(Action operate)
        {
            operate();
        }

        public void Command(Action<SqlSugarClient> operate)
        {
            operate(this._db); operate = null;
        }

        public void Command<OutSourcing>(Action<SqlSugarClient, OutSourcing> operate) where OutSourcing : class, new()
        {
            operate(this._db, new OutSourcing()); operate = null;
        }

        public void Dispose()
        {
            if (this._db != null) this._db.Dispose();
        }
    }
}