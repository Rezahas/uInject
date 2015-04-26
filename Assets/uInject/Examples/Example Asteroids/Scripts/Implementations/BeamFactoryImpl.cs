using UnityEngine;

namespace Asteroids.Impl
{
	public class BeamFactoryImpl : ScriptableObject, BeamFactory
	{
		public GameObject beamPrefab;

		public GameObject GetBeam()
		{
			return (GameObject)GameObject.Instantiate(beamPrefab);
		}
	}
}