using System;
using System.Collections.Generic;
using System.Linq;

namespace AttributeSdk {
	public static class AppDomainExtensions {
		public static IEnumerable<(Type type, T attribute)> EnumerateTypesWithAttribute<T>(this AppDomain appDomain) where T : Attribute
			=> appDomain.GetAssemblies().SelectMany(_ => _.EnumerateTypesWithAttribute<T>());

		public static IEnumerable<(Type type, T[] attributes)> EnumerateTypesWithAttributes<T>(this AppDomain appDomain) where T : Attribute
			=> appDomain.GetAssemblies().SelectMany(_ => _.EnumerateTypesWithAttributes<T>());
	}
}
