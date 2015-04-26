using Ninject.Activation;

namespace Ninject.Unity.Provider
{
	/// <summary>
	/// Base class for Providers that always return the same instance.
	/// </summary>
	public abstract class SingletonProvider<T> : Provider<T>
	{
		private T instance;

		public SingletonProvider()
		{
			instance = CreateInstance();
		}

		public override sealed object Create(IContext context)
		{
			return instance;
		}

		protected abstract T CreateInstance();
	}
}