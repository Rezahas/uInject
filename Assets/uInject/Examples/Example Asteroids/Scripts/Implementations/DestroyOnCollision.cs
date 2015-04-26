using UnityEngine;

namespace Asteroids.Impl
{
	public class DestroyOnCollision : MonoBehaviour
	{
		private void OnCollisionEnter2D(Collision2D collision)
		{
			GameObject.Destroy(gameObject);
		}
	}
}