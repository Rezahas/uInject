using UnityEngine;

namespace Asteroids.Impl
{
	public class DestroyOnTrigger : AMono
	{
		private void OnTriggerEnter2D(Collider2D other)
		{
			GameObject.Destroy(gameObject);
		}
	}
}