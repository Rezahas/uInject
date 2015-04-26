using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace uInject
{
	/// <summary>
	/// Implement this class to create the bindings specific to your application.
	/// </summary>
	[Serializable]
	public abstract class BinderMono : AMono
	{
		public PrefabBinding[] prefabBindings;
		public ScriptableObjectBinding[] scriptableObjectBindings;

		public abstract void Bind(IBindingRoot binding);

		public Dictionary<Type, GameObject> GetPrefabBindings()
		{
			return prefabBindings.ToDictionary(b => GetType(b.type), b => b.prefabs);
		}

		public Dictionary<Type, ScriptableObject> GetScriptableObjectBindings()
		{
			return scriptableObjectBindings.ToDictionary(b => GetType(b.type), b => b.scriptableObject);
		}

		protected override void Awake()
		{
#if UNITY_EDITOR
			CheckPrefabBindings();
#endif
		}

		private void CheckPrefabBindings()
		{
			foreach (PrefabBinding b in prefabBindings)
			{
				if (b.prefabs == null || string.IsNullOrEmpty(b.type))
				{
					Debug.LogWarning("There is a binding with either prefab or type not set. In Binder " + GetType());
				}
			}
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
			return null;
		}
	}
}