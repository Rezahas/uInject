using UnityEngine;

namespace Asteroids.Impl
{
	public class TimeGuiImpl : MonoBehaviour, TimeGui
	{
		public float Time
		{
			get;
			set;
		}

		private void OnGUI()
		{
			GUI.Label(new Rect(10, 10, 100, 20), Time.ToString());
		}
	}
}