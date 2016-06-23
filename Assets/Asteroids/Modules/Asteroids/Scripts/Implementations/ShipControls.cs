using UnityEngine;

namespace Asteroids.Impl
{
	public sealed class ShipControls : MonoBehaviour
	{
		public float speed;
		public float rotationSpeed;

		private void Update()
		{
			float h = Input.GetAxis("Horizontal");
			transform.Rotate(transform.forward, -h * rotationSpeed);
			float v = Input.GetAxis("Vertical");
			transform.position += transform.up * v * speed;
		}
	}
}