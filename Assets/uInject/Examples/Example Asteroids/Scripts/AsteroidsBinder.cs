using Asteroids.Impl;
using uInject;
using uInject.Provider;

namespace Asteroids
{
	public class AsteroidsBinder : BinderMono
	{
		public bool useNewGui;

		public override void Bind(Ninject.Syntax.IBindingRoot binding)
		{
			binding.Bind<AsteroidSpawner>().ToProvider<PrefabProvider<AsteroidSpawnerImpl>>().InSingletonScope();
			binding.Bind<AsteroidFactory>().ToProvider<ScriptableObjectProvider<AsteroidFactoryImpl>>().InSingletonScope();
			binding.Bind<BeamFactory>().ToProvider<ScriptableObjectProvider<BeamFactoryImpl>>().InSingletonScope();
			if (!useNewGui)
			{
				binding.Bind<Gui>().ToProvider<PrefabProvider<OldGui>>().InSingletonScope();
			}
			else
			{
				binding.Bind<Gui>().ToProvider<PrefabProvider<NewGui>>().InSingletonScope();
			}
		}
	}
}