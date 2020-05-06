using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utilities
{
    public static class JsonExtension
    {
        public static string ToJson<T>(this IEnumerable<T> arr)
        {
            var json = JArray.FromObject(arr).ToString();
            return json;
        }
    }
}
