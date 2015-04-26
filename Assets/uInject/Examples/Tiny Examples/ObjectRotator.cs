using Ninject;
using Ninject.Unity;
using UnityEngine;

namespace TinyExamples
{
	public class ObjectRotator : DIMono
	{
		public Vector3 axis;

		[Inject]
		private Rotatable Rotatable
		{
			get;
			set;
		}

		protected override void Update()
		{
			Rotatable.RotateAround(axis);
		}
	}
}