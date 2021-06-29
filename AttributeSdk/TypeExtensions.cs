using System;
using System.Collections.Generic;
using System.Linq;

namespace AttributeSdk {
	public static class TypeExtensions {
		public static T? GetAttribute<T>(this Type type) where T : Attribute
			=> type.GetAttributes<T>()
				.SingleOrDefault();

		public static IEnumerable<T> GetAttributes<T>(this Type type) where T : Attribute
			=> type.GetCustomAttributes(typeof(T), true)
				.Cast<T>();
	}
}
