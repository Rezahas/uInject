using UnityEngine;

namespace Ninject.Unity.Provider
{
	public class ScriptableObjectProvider<T> : SingletonProvider<T> where T : ScriptableObject
	{
		protected override T CreateInstance()
		{
			return (T)UnityKernel.INSTANCE.GetScriptableObject(Type);
		}
	}
}