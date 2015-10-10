using Ninject.Unity;

namespace Async.Test
{
	public class NonMonoTaskBinder : BinderMono
	{
		public override void Bind(Ninject.Syntax.IBindingRoot binding)
		{
			binding.Bind<NonMonoTask>().ToSelf().InTransientScope();
		}
	}
}