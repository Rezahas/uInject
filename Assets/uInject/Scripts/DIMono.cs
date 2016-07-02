using UnityEngine;

namespace Ninject.Unity
{
	/// <summary>
	/// Base class for all MonoBehaviours that need injection. Make sure to add base.Awake() in case you override the Awake function, otherwise injection will not occur.
	/// </summary>
	public abstract class DIMono : MonoBehaviour
	{
		protected bool IsInjected
		{
			get;
			private set;
		}

		protected virtual void Awake()
		{
			UnityKernel.INSTANCE.Inject(this);
			IsInjected = true;
		}
	}
}