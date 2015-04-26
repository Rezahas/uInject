using uInject;
using uInject.Provider;

namespace TinyExamples
{
	public class FindInSceneBinder : BinderMono
	{
		public override void Bind(Ninject.Syntax.IBindingRoot binding)
		{
			binding.Bind<Rotatable>().ToProvider<GameObjectFinder<RotatableImpl>>().InSingletonScope();
		}
	}
}