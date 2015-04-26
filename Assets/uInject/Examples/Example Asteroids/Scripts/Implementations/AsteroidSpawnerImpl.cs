using Ninject;
using System.Linq;
using UnityEngine;

namespace Asteroids.Impl
{
	public class AsteroidSpawnerImpl : AMono, AsteroidSpawner
	{
		public int minInertia, maxInertia;
		public float[] easySpawnFrequency;
		public float[] mediumSpawnFrequency;
		public float[] difficultSpawnFrequency;
		private float[] spawnFrequency;
		private SpawnMode spawnMode;
		private Vector3[] spawnPositions;

		public SpawnMode SpawnMode
		{
			get
			{
				return spawnMode;
			}
			set
			{
				spawnMode = value;
				switch (value)
				{
					case SpawnMode.EASY:
						spawnFrequency = easySpawnFrequency;
						break;

					case SpawnMode.MEDIUM:
						spawnFrequency = mediumSpawnFrequency;
						break;

					case SpawnMode.DIFFICULT:
						spawnFrequency = difficultSpawnFrequency;
						break;
				}
			}
		}

		[Inject]
		private AsteroidFactory AsteroidFactory
		{
			get;
			set;
		}

		public void StartSpawning(SpawnMode mode)
		{
			SpawnMode = mode;
			enabled = true;
		}

		public void StopSpawning()
		{
			enabled = false;
		}

		protected override void Awake()
		{
			enabled = false;
			spawnPositions = GetComponentsInChildren<Transform>().Except(new Transform[] { transform }).Select(t => t.position).ToArray();
		}

		protected override void Update()
		{
			for (int i = 0; i < spawnFrequency.Length; i++)
			{
				float r = Random.Range(0f, 1f);
				if (r < spawnFrequency[i])
				{
					SpawnAsteroid(i);
				}
			}
		}

		private void SpawnAsteroid(int i)
		{
			GameObject go = AsteroidFactory.GetAsteroid(i);
			go.transform.position = GetSpawnPosition();
			go.rigidbody2D.AddForce(GetSpawnInertia(go.transform.position));
		}

		private Vector3 GetSpawnPosition()
		{
			int r = Random.Range(0, spawnPositions.Length);
			return spawnPositions[r];
		}

		private Vector3 GetSpawnInertia(Vector3 position)
		{
			float xRand = Random.Range(0f, 1f);
			float yRand = Random.Range(0f, 1f);
			float force = Random.Range(minInertia, maxInertia);
			if (position.x > 0)
			{
				xRand *= -1;
			}
			if (position.y > 0)
			{
				yRand *= -1;
			}
			Vector3 i = new Vector3(xRand, yRand, 0) * force;
			return i;
		}
	}
}