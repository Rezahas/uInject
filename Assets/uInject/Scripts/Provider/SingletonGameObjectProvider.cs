using System;
using UnityEngine;

namespace Ninject.Unity.Provider
{
	/// <summary>
	/// Provider that creates one GameObject with the MonoBehaviour T attached and returns it for every injection.
	/// </summary>
	public class SingletonGameObjectProvider<T> : SingletonProvider<T> where T : MonoBehaviour
	{
		protected override T CreateInstance()
		{
			GameObject go = new GameObject(Type.Name, new Type[] { Type });
			return go.GetComponent<T>();
		}
	}
}