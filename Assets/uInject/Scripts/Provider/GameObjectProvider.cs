using Ninject.Activation;
using System;
using UnityEngine;

namespace Ninject.Unity.Provider
{
	/// <summary>
	/// Provider that creates a new GameObject with MonoBehaviour T for every injection.
	/// </summary>
	public class GameObjectProvider<T> : Provider<T> where T : MonoBehaviour
	{
		public override object Create(IContext context)
		{
			GameObject go = new GameObject(Type.Name, new Type[] { Type });
			return go.GetComponent<T>();
		}
	}
}