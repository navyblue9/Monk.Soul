using Monk.Utils;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Monk.DbStore
{
    public partial class DbServices
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings[Keys.ConnectionStringKey].ToString();

        private static Dictionary<string, Func<KeyValueObj>> RowFilter = new Dictionary<string, Func<KeyValueObj>>()
        {
            {
                "all",()=> {
                     return new KeyValueObj(){ Key=" Del=@Del and Destroy=@Destroy " , Value=new { Del=0 , Destroy=0 }};
                }
            },
             {
                "admin",()=> {
                     return new KeyValueObj(){ Key=" Destroy=@Destroy " , Value=new { Destroy=0 }};
                }
            },
            {
                "root",()=> {
                     return new KeyValueObj(){ Key="" , Value=new { }};
                }
            }
        };

        private static string[] InsertColumnsFilter = new string[] { "SerialNo", "UpdateTime", "Default", "Del", "Destroy", "CreateTime" };
        private static string[] UpdateColumnsFilter = new string[] { "SerialNo", "CreateTime", "LogMemberID" };
    }
}