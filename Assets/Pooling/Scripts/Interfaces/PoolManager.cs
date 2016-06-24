using UnityEngine;

namespace Pools
{
	public interface PoolManager
	{
		void AssurePool(GameObject prefab, int minSize);

		void AssurePool<T>(int minSize) where T : MonoBehaviour;

		Pool GetPool(GameObject prefab);

		Pool GetPool<T>() where T : MonoBehaviour;
	}
}