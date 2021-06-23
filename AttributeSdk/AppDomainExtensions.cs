using System;
using System.Collections.Generic;

namespace AttributeSdk {
	public static class AppDomainExtensions {
		public static IEnumerable<(Type type, T attribute)> EnumerateTypesWithAttribute<T>(this AppDomain appDomain) where T : Attribute {
			return appDomain.GetAssemblies().EnumerateTypesWithAttribute<T>();
		}
	}
}