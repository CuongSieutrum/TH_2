using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace TH_BUOI2.Helpers
{
	public static class SessionExtensions
	{
		public static void SetObjectAsJson(this ISession session, string key, object value)
		{
			var serializedValue = JsonConvert.SerializeObject(value);
			session.SetString(key, serializedValue);
		}

		public static T GetObjectFromJson<T>(this ISession session, string key)
		{
			var value = session.GetString(key);
			return value == null ? default : JsonConvert.DeserializeObject<T>(value);
		}
	}
}
