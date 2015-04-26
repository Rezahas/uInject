namespace uInject
{
	/// <summary>
	/// Base class for all MonoBehaviours that need injection. Make sure to add base.Awake() in case you override the Awake function, otherwise injection will not occur.
	/// </summary>
	public abstract class DIMono : AMono
	{
		protected override void Awake()
		{
			UnityKernel.INSTANCE.Inject(this);
		}
	}
}