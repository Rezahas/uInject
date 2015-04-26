using uInject;
using uInject.Provider;

namespace TinyExamples
{
	public class FromPrefabBinder : BinderMono
	{
		public override void Bind(Ninject.Syntax.IBindingRoot binding)
		{
			binding.Bind<Rotatable>().ToProvider<PrefabProvider<RotatableImpl>>().InSingletonScope();
		}
	}
}