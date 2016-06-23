using Ninject;
using Ninject.Unity;
using UnityEngine;

namespace Asteroids.Impl
{
	public sealed class Game : DIMono
	{
		public float switchToMediumTime;
		public float switchToDifficultTime;

		[Inject]
		private AsteroidSpawner AsteroidSpawner
		{
			get;
			set;
		}

		[Inject]
		private Gui Gui
		{
			get;
			set;
		}

		private void Start()
		{
			AsteroidSpawner.StartSpawning(SpawnMode.EASY);
		}

		private void Update()
		{
			float t = Time.time;
			Gui.TimeGui.Time = t;
			if (AsteroidSpawner.SpawnMode == SpawnMode.MEDIUM && t > switchToDifficultTime)
			{
				AsteroidSpawner.SpawnMode = SpawnMode.DIFFICULT;
			}
			else if (AsteroidSpawner.SpawnMode == SpawnMode.EASY && t > switchToMediumTime)
			{
				AsteroidSpawner.SpawnMode = SpawnMode.MEDIUM;
			}
		}
	}
}