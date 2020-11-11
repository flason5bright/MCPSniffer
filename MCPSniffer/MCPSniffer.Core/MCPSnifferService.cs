using System;
using System.Collections.Generic;

namespace MCPSniffer.Core
{
	public static class MCPSnifferService
	{
		static Dictionary<Type, object> Services = new Dictionary<Type, object>();
		public static void Register<T>(T service)
		{
			Services.Add(typeof(T), service);
		}

		public static T GetService<T>()
		{
			object service;
			if (Services.TryGetValue(typeof(T), out service))
				return (T)service;

			return default(T);
		}

	}
}
