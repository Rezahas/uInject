using Ninject.Unity;

namespace Spawning
{
	public abstract class ASpawner : DIMono, Spawner
	{
		public abstract void Spawn();
	}
}