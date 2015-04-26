using Ninject;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ninject.Unity
{
	/// <summary>
	/// Responsible for injections. No direct interaction should be necessary (exception: Providers).
	/// </summary>
	public class UnityKernel : StandardKernel
	{
		private IDictionary<Type, GameObject> prefabDictionary;
		private IDictionary<Type, ScriptableObject> scriptableObjectDictionary;

		public static UnityKernel INSTANCE
		{
			get;
			private set;
		}

		public UnityKernel(BinderMono[] binderMonos)
			: this(binderMonos, new StandardSettings())
		{
		}

		public UnityKernel(BinderMono[] binderMonos, INinjectSettings settings)
			: base(settings)
		{
			if (SetInstance())
			{
				GetPrefabBindings(binderMonos);
				GetScriptableObjectBindings(binderMonos);
				foreach (BinderMono bm in binderMonos)
				{
					bm.Bind(this);
				}
				Debug.Log("Initialized DI Kernel");
			}
		}

		public GameObject GetPrefab(Type type)
		{
			if (prefabDictionary.ContainsKey(type))
			{
				return prefabDictionary[type];
			}
			else
			{
				Debug.LogError("Could not find a Prefab associated with the Type " + type + ". Make sure a prefab is associated with the Type in one of your BinderMono implementations.");
				return null;
			}
		}

		public ScriptableObject GetScriptableObject(Type type)
		{
			if (scriptableObjectDictionary.ContainsKey(type))
			{
				return scriptableObjectDictionary[type];
			}
			else
			{
				Debug.LogError("Could not find a ScriptableObject associated with the Type " + type + ". Make sure a ScriptableObject is associated with the Type in one of your BinderMono implementations.");
				return null;
			}
		}

		private void GetPrefabBindings(BinderMono[] binders)
		{
			prefabDictionary = new Dictionary<Type, GameObject>();
			foreach (BinderMono binder in binders)
			{
				foreach (var binding in binder.GetPrefabBindings())
				{
					prefabDictionary.Add(binding.Key, binding.Value);
				}
			}
		}

		private void GetScriptableObjectBindings(BinderMono[] binders)
		{
			scriptableObjectDictionary = new Dictionary<Type, ScriptableObject>();
			foreach (BinderMono binder in binders)
			{
				foreach (var binding in binder.GetScriptableObjectBindings())
				{
					scriptableObjectDictionary.Add(binding.Key, binding.Value);
				}
			}
		}

		private bool SetInstance()
		{
			if (INSTANCE == null)
			{
				INSTANCE = this;
				return true;
			}
			else
			{
				Debug.LogError("Tried to initialize multiple instances UnityKernel.");
				return false;
			}
		}
	}
}