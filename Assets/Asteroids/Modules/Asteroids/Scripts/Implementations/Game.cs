using Ninject;
using Ninject.Unity;
using UnityEngine;

namespace Asteroids.Impl
{
	public class Game : DIMono
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

		protected override void Start()
		{
			AsteroidSpawner.StartSpawning(SpawnMode.EASY);
		}

		protected override void Update()
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