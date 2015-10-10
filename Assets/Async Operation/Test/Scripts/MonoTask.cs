using Ninject;
using Ninject.Unity;
using System;
using System.Collections;
using UnityEngine;

namespace Async.Test
{
	public class MonoTask : DIMono
	{
		private float progress;
		private Action<float> progressFunction;

		[Inject]
		private AsyncOperationFactory AOF
		{
			get;
			set;
		}

		public Task<float> Foo()
		{
			Task<float> op = AOF.Create<float>(Result, out progressFunction);
			StartCoroutine(MyCoroutine());
			return op;
		}

		private float Result()
		{
			return UnityEngine.Random.Range(0f, 100f);
		}

		private IEnumerator MyCoroutine()
		{
			yield return new WaitForEndOfFrame();
			while (progress < 1)
			{
				progress += 0.1f;
				progressFunction(progress);
				yield return new WaitForSeconds(0.5f);
			}
		}
	}
}