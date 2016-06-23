using Ninject;
using Ninject.Unity;
using UnityEngine;

namespace Asteroids.Impl
{
	public sealed class GunZ : DIMono
	{
		public float speed;
		public float shotCooldown;
		public Transform muzzle;
		private float lastShot = -1;

		[Inject]
		private BeamFactory BeamFactory
		{
			get;
			set;
		}

		private void Update()
		{
			if (Input.GetAxis("Fire1") > 0 && lastShot + shotCooldown < Time.time)
			{
				lastShot = Time.time;
				GameObject beam = BeamFactory.GetBeam();
				beam.transform.position = muzzle.position;
				beam.transform.rotation = muzzle.rotation;
				Vector3 force = beam.transform.up * speed;
				beam.GetComponent<Rigidbody2D>().AddForce(force);
			}
		}
	}
}