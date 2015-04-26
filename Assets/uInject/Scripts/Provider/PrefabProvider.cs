using Ninject.Activation;
using UnityEngine;

namespace Ninject.Unity.Provider
{
	/// <summary>
	/// Provider that instantiates the associated Prefab for every injection.
	/// </summary>
	public class PrefabProvider<T> : Provider<T> where T : MonoBehaviour
	{
		public override object Create(IContext context)
		{
			GameObject prefab = UnityKernel.INSTANCE.GetPrefab(Type);
			GameObject instance = (GameObject)GameObject.Instantiate(prefab);
			return instance.GetComponent<T>();
		}
	}
}