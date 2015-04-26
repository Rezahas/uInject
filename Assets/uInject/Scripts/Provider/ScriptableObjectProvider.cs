using Ninject.Activation;
using UnityEngine;

namespace Ninject.Unity.Provider
{
	/// <summary>
	/// Provider for ScriptableObjects.
	/// </summary>
	public class ScriptableObjectProvider<T> : Provider<T> where T : ScriptableObject
	{
		public override object Create(IContext context)
		{
			return UnityKernel.INSTANCE.GetScriptableObject(Type);
		}
	}
}