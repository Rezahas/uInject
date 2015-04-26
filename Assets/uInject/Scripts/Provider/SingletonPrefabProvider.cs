using UnityEngine;

namespace Ninject.Unity.Provider
{
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