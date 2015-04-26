namespace Asteroids.Impl
{
	public class OldGui : AMono, Gui
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