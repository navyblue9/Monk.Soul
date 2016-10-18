using SqlSugar;
using System;
using System.Configuration;
using System.Collections.Generic;
using Monk.Utils;

namespace Monk.DbStore
{
    public class DbServices : IDisposable
    {
        protected SqlSugarClient _db;
        public DbServices()
        {
            var db = new SqlSugarClient(ConfigurationManager.ConnectionStrings[Keys.ConnectionStringKey].ToString());
            db.SetFilterFilterParas(new Dictionary<string, Func<KeyValueObj>>()
            {
                {
                    "all",()=> {
                         return new KeyValueObj(){ Key=" Del=@Del and Destroy=@Destroy " , Value=new{ Del=0,Destroy=0}};
                    }
                },
                 {
                    "admin",()=> {
                         return new KeyValueObj(){ Key=" Destroy=@Destroy " , Value=new{Destroy=0}};
                    }
                },
                {
                    "root",()=> {
                         return new KeyValueObj(){ Key="" , Value=new{ }};
                    }
                }
            });
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