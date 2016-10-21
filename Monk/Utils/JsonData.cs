using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Monk.Utils
{
    public class JsonData<T> where T : new()
    {
        public string status { get; set; }
        public string info { get; set; }
        public string selector { get; set; }
        public T data { get; set; }
    }

    public static class JsonDataExtention
    {
        public static void SetClientData<T>(this JsonData<T> clientResult, string status, string info, T data = default(T), string selector = null) where T : new()
        {
            clientResult.status = status;
            clientResult.info = info;
            clientResult.data = data;
            clientResult.selector = selector;
        }
    }
}