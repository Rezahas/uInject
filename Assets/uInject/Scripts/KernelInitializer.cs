using Ninject;

namespace Ninject.Unity
{
	/// <summary>
	/// Initializes the UnityKernel. Create a sub class and override GetSettings() to change the settings used by the UnityKernel.
	/// Make sure that this is the first entry in your Script Execution Order.
	/// </summary>
	public class KernelInitializer : AMono
	{
		protected virtual INinjectSettings GetSettings()
		{
			return new StandardSettings();
		}

		protected override void Awake()
		{
			new UnityKernel(GetComponentsInChildren<BinderMono>(), GetSettings());
		}
	}
}