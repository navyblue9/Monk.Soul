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
            // 注入全局颗粒化权限控制
            db.SetFilterFilterParas(RowFilter);
            db.DisableInsertColumns = InsertColumnsFilter;
            db.DisableUpdateColumns = UpdateColumnsFilter;
            db.CurrentFilterKey = "all";
            this._db = db;
        }

        public void Command(Action<SqlSugarClient> operate)
        {
            operate(this._db); operate = null;
        }

        public void Dispose()
        {
            if (this._db != null) this._db.Dispose();
        }
    }
}