using UnityEngine;

namespace Pools
{
	public sealed class PooledGameObject : MonoBehaviour
	{
		public const string RESET_STATE_METHOD_NAME = "ResetState";
		public bool returnOnDisable = true;
		private static long nextId;
		private Pool myPool;
		private long id;

		public void ReturnToPool()
		{
			Debug.Log(myPool.Contains(gameObject));
			if (!myPool.Contains(gameObject))
			{
				SendMessage(RESET_STATE_METHOD_NAME, SendMessageOptions.DontRequireReceiver);
				myPool.ReleaseObject(gameObject);
			}
		}

		public void SetPool(Pool pool)
		{
			myPool = pool;
		}

		public override bool Equals(object o)
		{
			return Equals(o as PooledGameObject);
		}

		public bool Equals(PooledGameObject other)
		{
			return other != null && id == other.id;
		}

		public override int GetHashCode()
		{
			return id.GetHashCode();
		}

		private void Awake()
		{
			id = nextId;
			nextId++;
		}

		private void OnDisable()
		{
			if (returnOnDisable)
			{
				ReturnToPool();
			}
		}
	}
}