using UnityEngine;

namespace Asteroids
{
	public interface AsteroidFactory
	{
		GameObject GetAsteroid(int size);
	}
}