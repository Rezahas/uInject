using UnityEngine;

namespace Pools
{
	public interface Pool
	{
		int Size
		{
			get;
		}

		void SetSize(int size);

		GameObject GetObject();

		void ReleaseObject(GameObject gameObject);

		bool Contains(GameObject gameObject);
	}
}