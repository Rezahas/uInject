using Ninject.Activation;

namespace Ninject.Unity.Provider
{
	public class ObjectProvider<T> : Provider<T> where T : new()
	{
		public override object Create(IContext context)
		{
			return new T();
		}
	}
}