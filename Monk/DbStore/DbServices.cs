using System;
using SqlSugar;

namespace Monk.DbStore
{
    public partial class DbServices : IDisposable
    {
        protected SqlSugarClient _db;
        public DbServices()
        {
            var db = new SqlSugarClient(ConnectionString);
            db.SetFilterFilterParas(RowFilter);
            db.CurrentFilterKey = "all";
            this._db = db;
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