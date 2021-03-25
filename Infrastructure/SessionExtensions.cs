using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//add
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Assignment9.Infrastructure
{
    //Tool to convert Cart object to Json (string) file & then back bc cant't store carts in a session)
    public static class SessionExtensions
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}
