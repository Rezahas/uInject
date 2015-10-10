using UnityEngine;

#pragma warning disable

namespace Async.Test
{
	public class MonoTaskTest : MonoBehaviour
	{
		private Task<float> op;

		private void Start()
		{
			op = GetComponent<MonoTask>().Foo();
			op.OnProgressChanged += OnProgressChanged;
			op.OnDone += OnDone;
		}

		private void OnProgressChanged(Task op)
		{
			Debug.Log(op.Progress);
		}

		private void OnDone(Task op, float result)
		{
			Debug.Log("Done");
			this.op = null;
			Debug.Log(result);
		}

		//private void Update()
		//{
		//	Debug.Log(op.Progress + " " + op.IsDone);
		//}
	}
}

#pragma warning restore