using Ninject;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace uInject
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
			return prefabDictionary[type];
		}

		public ScriptableObject GetScriptableObject(Type type)
		{
			return scriptableObjectDictionary[type];
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