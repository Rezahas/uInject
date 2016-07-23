using UnityEngine;

namespace TinyExamples
{
	public class RotatableImpl : MonoBehaviour, Rotatable
	{
		public void RotateAround(Vector3 vector)
		{
			transform.Rotate(vector);
		}
	}
}