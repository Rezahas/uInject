using Random = UnityEngine.Random;

namespace Spawning.Impl
{
	public sealed class CompositeSpawner : ASpawnerMono
	{
		public enum Mode
		{
			RANDOM, RANDOM_WEIGHTED, SEQUENTIAL
		}

		public SpawnerComposite[] composites;
		public Mode spawnMode;
		private int sequentialIndex;
		private float totalWeight;

		public override void Spawn()
		{
			switch (spawnMode)
			{
				case Mode.RANDOM:
					int index = Random.Range(0, composites.Length);
					Spawn(index);
					break;

				case Mode.RANDOM_WEIGHTED:
					float rnd = Random.Range(0, totalWeight);
					bool spawned = false;
					for (int i = 0; i < composites.Length && !spawned; i++)
					{
						if (rnd < composites[i].weight)
						{
							Spawn(i);
							spawned = true;
						}
						else
						{
							rnd -= composites[i].weight;
						}
					}
					break;

				case Mode.SEQUENTIAL:
					Spawn(sequentialIndex);
					sequentialIndex++;
					if (sequentialIndex == composites.Length)
					{
						sequentialIndex = 0;
					}
					break;
			}
		}

		private void Start()
		{
			for (int i = 0; i < composites.Length; i++)
			{
				totalWeight += composites[i].weight;
			}
		}

		private void Spawn(int index)
		{
			composites[index].spawner.Spawn();
		}
	}
}