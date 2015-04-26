using UnityEngine;

namespace Asteroids.Impl
{
	public class AsteroidFactoryImpl : ScriptableObject, AsteroidFactory
	{
		public GameObject[] asteroidPrefabs;

		public GameObject GetAsteroid(int size)
		{
			GameObject go = (GameObject)GameObject.Instantiate(asteroidPrefabs[size]);
			return go;
		}
	}
}