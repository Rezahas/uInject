using UnityEngine;

namespace Asteroids.Impl
{
	public class DestroyOnTrigger : MonoBehaviour
	{
		private void OnTriggerEnter2D(Collider2D other)
		{
			GameObject.Destroy(gameObject);
		}
	}
}