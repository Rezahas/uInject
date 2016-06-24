using Ninject.Unity;

namespace Spawning
{
	public abstract class ASpawnerMono : DIMono, Spawner
	{
		public abstract void Spawn();
	}
}