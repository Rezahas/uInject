namespace Asteroids
{
	public interface AsteroidSpawner
	{
		SpawnMode SpawnMode
		{
			get;
			set;
		}

		void StartSpawning(SpawnMode mode);

		void StopSpawning();
	}
}