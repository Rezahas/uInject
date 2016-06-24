using Async;
using Ninject;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pools.Impl
{
	public class PoolManagerImpl : PoolManager
	{
		private Dictionary<GameObject, Pool> prefabPools;
		private Dictionary<Type, Pool> behaviourPools;
		private AsyncOperationFactory AOF;

		[Inject]
		public PoolManagerImpl(AsyncOperationFactory AOF)
		{
			this.AOF = AOF;
			prefabPools = new Dictionary<GameObject, Pool>();
			behaviourPools = new Dictionary<Type, Pool>();
		}

		public void AssurePool(GameObject prefab, int minSize)
		{
			if (!prefabPools.ContainsKey(prefab))
			{
				CreatePool(prefabPools, prefab, prefab);
			}
			SetSize(prefabPools[prefab], minSize);
		}

		public void AssurePool<T>(int minSize) where T : MonoBehaviour
		{
			AssurePool(typeof(T), minSize);
		}

		public Pool GetPool(GameObject prefab)
		{
			AssurePool(prefab, 1);
			return prefabPools[prefab];
		}

		public Pool GetPool<T>() where T : MonoBehaviour
		{
			Type type = typeof(T);
			AssurePool(type, 1);
			return behaviourPools[type];
		}

		private void AssurePool(Type type, int minSize)
		{
			if (!behaviourPools.ContainsKey(type))
			{
				GameObject prefab = new GameObject(type.Name);
				prefab.AddComponent(type);
				CreatePool(behaviourPools, type, prefab);
			}
			SetSize(behaviourPools[type], minSize);
		}

		private void CreatePool<T>(Dictionary<T, Pool> dic, T key, GameObject prefab)
		{
			Pool p = new PoolImpl(prefab, AOF);
			dic[key] = p;
		}

		private void SetSize(Pool pool, int minSize)
		{
			if (pool.Size < minSize)
			{
				pool.SetSize(minSize);
			}
		}
	}
}