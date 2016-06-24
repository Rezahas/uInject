using Ninject.Unity;
using Pools.Impl;

namespace Pools
{
	public class PoolBinder : BinderMono
	{
		public override void Bind(Ninject.Syntax.IBindingRoot binding)
		{
			binding.Bind<PoolManager>().To<PoolManagerImpl>().InSingletonScope();
			binding.Bind<Pool>().To<PoolImpl>();
		}
	}
}