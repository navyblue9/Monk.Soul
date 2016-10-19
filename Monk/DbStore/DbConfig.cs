using Monk.Utils;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Monk.DbStore
{
    public partial class DbServices
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[Keys.ConnectionStringKey].ToString();
            }
        }
        public static Dictionary<string, Func<KeyValueObj>> RowFilter
        {
            get
            {
                return new Dictionary<string, Func<KeyValueObj>>()
                {
                    {
                        "all",()=> {
                             return new KeyValueObj(){ Key=" Del=@Del and Destroy=@Destroy " , Value=new{ Del=0 , Destroy=0 }};
                        }
                    },
                     {
                        "admin",()=> {
                             return new KeyValueObj(){ Key=" Destroy=@Destroy " , Value=new{ Destroy=0 }};
                        }
                    },
                    {
                        "root",()=> {
                             return new KeyValueObj(){ Key="" , Value=new{ }};
                        }
                    }
                };
            }
        }
    }
}