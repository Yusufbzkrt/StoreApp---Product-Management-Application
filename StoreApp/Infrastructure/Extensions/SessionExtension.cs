using Microsoft.AspNetCore.Rewrite;
using System;
using System.Text.Json;

namespace StoreApp.Infrastructure.Extensions
{
	public static class SessionExtension //extension metodlarını genelde static yaparak ilerleriz
	{

		//ISession nesnesine JSON formatında veri kaydetmek için kullanılır.
		public static void SetJson(this ISession session, string key, object value)//SetJson uzantı metodu, ISession nesnesine JSON formatında veri kaydetmeyi sağlar. 
		{
			session.SetString(key, JsonSerializer.Serialize(value));
		}


		//ISession nesnesine belirli bir türdeki nesneleri JSON formatında kaydetmek için kullanılır.
		public static void SetJson<T>(this ISession session, string key, T value) 
		{
			session.SetString(key, JsonSerializer.Serialize(value));
		}


		//ISession nesnesinden JSON formatında saklanmış veriyi almak için kullanılır.
		public static T? GetJson<T>(this ISession session, string key) 
		{
			var data = session.GetString(key);
			return data is null ? default(T) : JsonSerializer.Deserialize<T>(data);
		}
	}
}









