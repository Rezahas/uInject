using Ninject.Activation;
using System;

namespace uInject.Provider
{
	public abstract class Provider<T> : IProvider<T>
	{
		public Type Type
		{
			get
			{
				return typeof(T);
			}
		}

		public abstract object Create(IContext context);
	}
}