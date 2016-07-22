using UnityEngine;

namespace Asteroids.Impl
{
	public class NewGui : MonoBehaviour, Gui
	{
		public TimeLabel timeGui;

		public TimeGui TimeGui
		{
			get
			{
				return timeGui;
			}
		}
	}
}