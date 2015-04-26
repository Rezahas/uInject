﻿using Ninject.Activation;

namespace Ninject.Unity.Provider
{
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