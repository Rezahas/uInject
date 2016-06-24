using Async.Impl;
using Ninject.Unity;
using Ninject.Unity.Provider;

namespace Async
{
	public class AsyncBinder : BinderMono
	{
		public override void Bind(Ninject.Syntax.IBindingRoot binding)
		{
			binding.Bind<AsyncOperationFactory>().To<AsyncOperationFactoryImpl>().InSingletonScope();
		}
	}
}