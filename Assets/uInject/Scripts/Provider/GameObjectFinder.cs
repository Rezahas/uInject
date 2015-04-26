using UnityEngine;

namespace Ninject.Unity.Provider
{
	/// <summary>
	/// Provider that finds the object of Type T in the scene.
	/// </summary>
	public class GameObjectFinder<T> : SingletonProvider<T> where T : MonoBehaviour
	{
		protected override T CreateInstance()
		{
			return (T)GameObject.FindObjectOfType(typeof(T));
		}
	}
}