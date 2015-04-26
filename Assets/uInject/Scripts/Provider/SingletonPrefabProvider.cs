using UnityEngine;

namespace Ninject.Unity.Provider
{
	/// <summary>
	/// Provider that instantiates a prefab once and returns it for every injection.
	/// </summary>
	public class SingletonPrefabProvider<T> : SingletonProvider<T> where T : MonoBehaviour
	{
		protected override T CreateInstance()
		{
			GameObject prefab = UnityKernel.INSTANCE.GetPrefab(Type);
			GameObject instance = (GameObject)GameObject.Instantiate(prefab);
			return instance.GetComponent<T>();
		}
	}
}