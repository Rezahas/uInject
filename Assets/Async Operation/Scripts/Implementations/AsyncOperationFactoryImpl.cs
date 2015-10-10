using Ninject;
using Ninject.Unity;
using System;
using System.Collections.Generic;

namespace Async.Impl
{
	public class AsyncOperationFactoryImpl : AsyncOperationFactory
	{
		public Task<EmptyResult> Create(out Action<float> progressFunction)
		{
			return Create<EmptyResult>(GetEmptyResult, out progressFunction);
		}

		public Task<T> Create<T>(Func<T> results, out Action<float> progressFunction)
		{
			AsyncOperationImpl<T> ao = new AsyncOperationImpl<T>(results);
			progressFunction = ao.SetProgress;
			return ao;
		}

		public Task<EmptyResult> Create(IEnumerable<Action> actions)
		{
			return Create<EmptyResult>(GetEmptyResult, actions);
		}

		public Task<T> Create<T>(Func<T> results, IEnumerable<Action> actions)
		{
			ManagedAsyncOperation<T> mao = new ManagedAsyncOperation<T>(actions, results);
			return mao;
		}

		private EmptyResult GetEmptyResult()
		{
			return new EmptyResult();
		}
	}
}