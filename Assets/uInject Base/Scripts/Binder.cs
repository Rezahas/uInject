using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Ninject.Unity
{
	public class Binder : ScriptableObject
	{
		public ClassBinding[] bindings;
		public PrefabBinding[] prefabBindings;
		public ScriptableObjectBinding[] scriptableObjectBindings;

		public Dictionary<Type, GameObject> GetPrefabBindings()
		{
#if UNITY_EDITOR
			CheckPrefabBindings();
#endif
			return prefabBindings.ToDictionary(b => GetType(b.type), b => b.prefab);
		}

		public Dictionary<Type, ScriptableObject> GetScriptableObjectBindings()
		{
#if UNITY_EDITOR
			CheckScriptableObjectBindings();
#endif
			return scriptableObjectBindings.ToDictionary(b => GetType(b.type), b => b.scriptableObject);
		}

		public void Bind(IBindingRoot binding)
		{
		}

		private Type GetType(string name)
		{
			foreach (Type t in Assembly.GetExecutingAssembly().GetTypes())
			{
				if (t.Name.Equals(name))
				{
					return t;
				}
			}
			Debug.LogError("Could not find Type " + name + ". Make sure you didn't misspell the name.");
			return null;
		}

		private void CheckPrefabBindings()
		{
			List<string> types = new List<string>();
			foreach (PrefabBinding b in prefabBindings)
			{
				if (b.prefab == null || string.IsNullOrEmpty(b.type))
				{
					Debug.LogWarning("There is a binding with either prefab or type not set. In Binder " + GetType());
					break;
				}
				if (types.Contains(b.type))
				{
					Debug.LogError("You have associated the Type " + b.type + " with more than one Prefab, this is not allowed. In Binder " + GetType());
					break;
				}
				types.Add(b.type);
			}
		}

		private void CheckScriptableObjectBindings()
		{
			List<string> types = new List<string>();
			foreach (ScriptableObjectBinding b in scriptableObjectBindings)
			{
				if (b.scriptableObject == null || string.IsNullOrEmpty(b.type))
				{
					Debug.LogWarning("There is a binding with either scriptableObject or type not set. In Binder " + GetType());
					break;
				}
				if (types.Contains(b.type))
				{
					Debug.LogError("You have associated a Type " + b.type + " with more than one ScriptableObject, this is not allowed. In Binder " + GetType());
					break;
				}
				types.Add(b.type);
			}
		}
	}
}