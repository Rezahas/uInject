using UnityEngine;

namespace TinyExamples
{
	public class RotatableImpl : AMono, Rotatable
	{
		public void RotateAround(Vector3 vector)
		{
			transform.Rotate(vector);
		}
	}
}