using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.Impl
{
	public sealed class TimeLabel : MonoBehaviour, TimeGui
	{
		public Text text;

		public float Time
		{
			get;
			set;
		}

		private void Update()
		{
			text.text = Time.ToString();
		}
	}
}