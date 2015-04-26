using UnityEngine;

namespace uInject.Provider
{
	public class ScriptableObjectProvider<T> : SingletonProvider<T> where T : ScriptableObject
	{
		protected override T CreateInstance()
		{
			return (T)UnityKernel.INSTANCE.GetScriptableObject(Type);
		}
	}
}