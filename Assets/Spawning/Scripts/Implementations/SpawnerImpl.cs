using Ninject;
using Pools;
using UnityEngine;

namespace Spawning.Impl
{
	public sealed class SpawnerImpl : ASpawnerMono
	{
		public GameObject prefab;
		private Pool pool;

		[Inject]
		private PoolManager PoolManager
		{
			set
			{
				pool = value.GetPool(prefab);
			}
		}

		public override void Spawn()
		{
			GameObject go = pool.GetObject();
			go.transform.position = transform.position;
		}
	}
}