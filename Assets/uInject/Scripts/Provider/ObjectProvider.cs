using Ninject.Activation;

namespace uInject.Provider
{
	public class ObjectProvider<T> : Provider<T> where T : new()
	{
		public override object Create(IContext context)
		{
			return new T();
		}
	}
}