using UnityEngine;

namespace Ninject.Unity.Provider
{
	public class GameObjectFinder<T> : SingletonProvider<T> where T : MonoBehaviour
	{
		protected override T CreateInstance()
		{
			return (T)GameObject.FindObjectOfType(typeof(T));
		}
	}
}