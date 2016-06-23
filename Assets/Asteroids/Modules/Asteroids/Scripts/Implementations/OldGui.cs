using UnityEngine;

namespace Asteroids.Impl
{
	public class OldGui : MonoBehaviour, Gui
	{
		public TimeGuiImpl timeGui;

		public TimeGui TimeGui
		{
			get
			{
				return timeGui;
			}
		}
	}
}