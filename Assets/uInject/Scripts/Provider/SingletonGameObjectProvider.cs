using System;
using UnityEngine;

namespace uInject.Provider
{
	public class SingletonGameObjectProvider<T> : SingletonProvider<T> where T : MonoBehaviour
	{
		protected override T CreateInstance()
		{
			GameObject go = new GameObject(Type.Name, new Type[] { Type });
			return go.GetComponent<T>();
		}
	}
}