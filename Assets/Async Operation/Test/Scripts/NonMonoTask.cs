using Ninject;
using System;
using UnityEngine;

namespace Async.Test
{
	public class NonMonoTask
	{
		private AsyncOperationFactory AOF;

		[Inject]
		public NonMonoTask(AsyncOperationFactory aof)
		{
			AOF = aof;
		}

		public Task<float> Foo()
		{
			Action[] actions = new Action[] { Action1, Action2, Action3 };
			return AOF.Create<float>(Result, actions);
		}

		private float Result()
		{
			return UnityEngine.Random.Range(0f, 100f);
		}

		private void Action1()
		{
			//Debug.Log("Action1");
		}

		private void Action2()
		{
			//Debug.Log("Action2");
		}

		private void Action3()
		{
			//Debug.Log("Action3");
		}
	}
}