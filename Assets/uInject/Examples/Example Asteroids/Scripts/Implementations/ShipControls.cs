using UnityEngine;

namespace Asteroids.Impl
{
	public class ShipControls : AMono
	{
		public float speed;
		public float rotationSpeed;

		protected override void Update()
		{
			float h = Input.GetAxis("Horizontal");
			transform.Rotate(transform.forward, -h * rotationSpeed);
			float v = Input.GetAxis("Vertical");
			transform.position += transform.up * v * speed;
		}
	}
}