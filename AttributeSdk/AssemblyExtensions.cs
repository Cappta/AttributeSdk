using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AttributeSdk {
	public static class AssemblyExtensions {
		public static IEnumerable<(Type type, T attribute)> EnumerateTypesWithAttribute<T>(this IEnumerable<Assembly> assemblies) where T : Attribute {
			foreach(var assembly in assemblies) {
				foreach(var tuple in assembly.EnumerateTypesWithAttribute<T>()) {
					yield return tuple;
				}
			}
		}

		public static IEnumerable<(Type type, T attribute)> EnumerateTypesWithAttribute<T>(this Assembly assembly) where T : Attribute {
			var assemblyTypes = default(Type[]);
			try { assemblyTypes = assembly.GetTypes(); } catch { }
			if(assemblyTypes is null) { yield break; }

			foreach(var type in assemblyTypes) {
				var attribute = type.GetAttribute<T>();

				if(attribute is null) { continue; }

				yield return (type, attribute);
			}
		}

		public static IEnumerable<(Type type, T[] attributes)> EnumerateTypesWithAttributes<T>(this IEnumerable<Assembly> assemblies) where T : Attribute {
			foreach(var assembly in assemblies) {
				foreach(var tuple in assembly.EnumerateTypesWithAttributes<T>()) {
					yield return tuple;
				}
			}
		}

		public static IEnumerable<(Type type, T[] attributes)> EnumerateTypesWithAttributes<T>(this Assembly assembly) where T : Attribute {
			var assemblyTypes = default(Type[]);
			try { assemblyTypes = assembly.GetTypes(); } catch { }
			if(assemblyTypes is null) { yield break; }

			foreach(var type in assemblyTypes) {
				var attributes = type.GetAttributes<T>().ToArray();

				if(attributes.Any() == false) { continue; }

				yield return (type, attributes);
			}
		}
	}
}