using Ninject;
using Ninject.Unity;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable

namespace Async.Test
{
	public sealed class NonMonoTaskTest : MonoBehaviour
	{
		private Task<float> op;
		private List<Task> ops;

		private void Start()
		{
			ops = new List<Task>();
			op = UnityKernel.INSTANCE.Get<NonMonoTask>().Foo();
			op.OnProgressChanged += OnProgressChanged;
			op.OnDone += OnDone;
		}

		private void OnProgressChanged(Task op)
		{
			Debug.Log(op.Progress);
		}

		private void OnDone(Task op, float results)
		{
			Debug.Log("Done");
			this.op = null;
			Debug.Log(results);
		}

		//protected override void Update()
		//{
		//	base.Update();
		//	for (int i = 0; i < 5; i++)
		//	{
		//		ops.Add(UnityKernel.INSTANCE.Get<NonMonoTask>().Foo());
		//	}
		//	foreach (AsyncOperation o in ops.ToArray())
		//	{
		//		if (o.IsDone)
		//		{
		//			ops.Remove(o);
		//		}
		//	}
		//}
	}
}

#pragma warning restore