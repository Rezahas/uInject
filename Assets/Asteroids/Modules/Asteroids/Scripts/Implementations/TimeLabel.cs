using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.Impl
{
	public class TimeLabel : AMono, TimeGui
	{
		public Text text;

		public float Time
		{
			get;
			set;
		}

		protected override void Update()
		{
			text.text = Time.ToString();
		}
	}
}