using Ninject.Activation;
using UnityEngine;

namespace Ninject.Unity.Provider
{
	/// <summary>
	/// Provider that finds the object of Type T in the scene.
	/// </summary>
	public class GameObjectFinder<T> : Provider<T> where T : MonoBehaviour
	{
		public override object Create(IContext context)
		{
			return (T)GameObject.FindObjectOfType(typeof(T));
		}
	}
}