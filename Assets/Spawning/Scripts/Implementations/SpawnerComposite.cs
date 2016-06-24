using System;

namespace Spawning.Impl
{
	[Serializable]
	public class SpawnerComposite
	{
		public ASpawnerMono spawner;
		public float weight;
	}
}