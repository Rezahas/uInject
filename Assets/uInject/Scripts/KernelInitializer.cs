using System.Linq;
using UnityEngine;

namespace Ninject.Unity
{
	/// <summary>
	/// Initializes the UnityKernel. Create a sub class and override GetSettings() to change the settings used by the UnityKernel.
	/// Make sure that this is the first entry in your Script Execution Order.
	/// </summary>
	public class KernelInitializer : MonoBehaviour
	{
		public BinderMono[] binderPrefabs;

		protected virtual INinjectSettings GetSettings()
		{
			return new StandardSettings();
		}

		protected virtual void Awake()
		{
			BinderMono[] objs = binderPrefabs.SelectMany(p => Instantiate(p).GetComponents<BinderMono>()).ToArray();
			new UnityKernel(objs, GetSettings());
			foreach (BinderMono bm in objs)
			{
				Destroy(bm.gameObject);
			}
		}
	}
}