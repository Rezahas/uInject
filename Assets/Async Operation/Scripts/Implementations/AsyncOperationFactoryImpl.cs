using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Async.Impl
{
	public class AsyncOperationFactoryImpl : AsyncOperationFactory
	{
		private const int INITIAL_POOL_SIZE = 10;
		private Stack<CoroutineOperation> coroutinePool;
		private Stack<UpdatedOperation> updatePool;
		private Transform parent;

		public int PoolSize
		{
			get
			{
				return coroutinePool.Count + updatePool.Count;
			}
		}

		public AsyncOperationFactoryImpl()
		{
			parent = new GameObject("Async Operation Factory").transform;
			GameObject.DontDestroyOnLoad(parent.gameObject);
			InitCoroutinePool();
			CreateUpdatedPool();
		}

		public Task<EmptyResult> Create(out Action<float> progressFunction)
		{
			return Create<EmptyResult>(GetEmptyResult, out progressFunction);
		}

		public Task<T> Create<T>(Func<T> results, out Action<float> progressFunction)
		{
			UnmanagedOperation<T> ao = new UnmanagedOperation<T>(results);
			progressFunction = ao.SetProgress;
			return ao;
		}

		public Task<EmptyResult> Create(IEnumerator coroutine)
		{
			return Create<EmptyResult>(GetEmptyResult, coroutine);
		}

		public Task<T> Create<T>(Func<T> results, IEnumerator coroutine)
		{
			CoroutineOperation op = GetCoroutineOperation();
			op.Init(coroutine);
			new OperationReturner<CoroutineOperation>(coroutinePool, op);
			return new ManagedAsyncOperation<T>(op, results);
		}

		public Task<EmptyResult> Create(IEnumerable<Action> actions)
		{
			return Create<EmptyResult>(GetEmptyResult, actions);
		}

		public Task<T> Create<T>(Func<T> results, IEnumerable<Action> actions)
		{
			UpdatedOperation op = GetUpdatedOperation();
			op.Init(actions);
			new OperationReturner<UpdatedOperation>(updatePool, op);
			return new ManagedAsyncOperation<T>(op, results);
		}

		public void SetPoolSize(int size)
		{
			while (size > coroutinePool.Count)
			{
				CreateCoroutineGO();
			}
			while (size > updatePool.Count)
			{
				CreateUpdatedGO();
			}
			while (size < coroutinePool.Count)
			{
				GameObject.Destroy(coroutinePool.Pop());
			}
			while (size < updatePool.Count)
			{
				GameObject.Destroy(updatePool.Pop());
			}
		}

		private void Op_OnDone()
		{
			throw new NotImplementedException();
		}

		private void CreateUpdatedPool()
		{
			updatePool = new Stack<UpdatedOperation>();
			for (int i = 0; i < INITIAL_POOL_SIZE; i++)
			{
				CreateUpdatedGO();
			}
		}

		private void InitCoroutinePool()
		{
			coroutinePool = new Stack<CoroutineOperation>();
			for (int i = 0; i < INITIAL_POOL_SIZE; i++)
			{
				CreateCoroutineGO();
			}
		}

		private CoroutineOperation GetCoroutineOperation()
		{
			if (coroutinePool.Count == 0)
			{
				CreateCoroutineGO();
			}
			return coroutinePool.Pop();
		}

		private void CreateCoroutineGO()
		{
			GameObject go = new GameObject("Coroutine Operation");
			go.transform.SetParent(parent);
			coroutinePool.Push(go.AddComponent<CoroutineOperation>());
		}

		private UpdatedOperation GetUpdatedOperation()
		{
			if (coroutinePool.Count == 0)
			{
				CreateUpdatedGO();
			}
			return updatePool.Pop();
		}

		private void CreateUpdatedGO()
		{
			GameObject go = new GameObject("Updated Operation");
			go.transform.SetParent(parent);
			updatePool.Push(go.AddComponent<UpdatedOperation>());
		}

		private EmptyResult GetEmptyResult()
		{
			return new EmptyResult();
		}

		private class OperationReturner<T> where T : AOperationMono
		{
			private Stack<T> pool;
			private T operation;

			public OperationReturner(Stack<T> pool, T operation)
			{
				this.pool = pool;
				this.operation = operation;
				operation.OnDone += Operation_OnDone;
			}

			private void Operation_OnDone()
			{
				operation.OnDone -= Operation_OnDone;
				pool.Push(operation);
			}
		}
	}
}