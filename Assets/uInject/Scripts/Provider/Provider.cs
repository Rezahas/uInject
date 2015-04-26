using Ninject.Activation;
using System;

namespace Ninject.Unity.Provider
{
	/// <summary>
	/// Base class for Providers.
	/// </summary>
	/// <typeparam name="T">provided Type</typeparam>
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