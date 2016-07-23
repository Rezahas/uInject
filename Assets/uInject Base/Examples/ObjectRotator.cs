using Ninject;
using Ninject.Unity;
using UnityEngine;

namespace TinyExamples
{
	public sealed class ObjectRotator : DIMono
	{
		public Vector3 axis;

		[Inject]
		private Rotatable Rotatable
		{
			get;
			set;
		}

		private void Update()
		{
			Rotatable.RotateAround(axis);
		}
	}
}