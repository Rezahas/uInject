using System.Collections;

namespace Async.Impl
{
	public sealed class CoroutineOperation : AOperationMono
	{
		public void Init(IEnumerator coroutine)
		{
			enabled = true;
			StartCoroutine(Coroutine(coroutine));
		}

		private IEnumerator Coroutine(IEnumerator nestedCoroutine)
		{
			yield return nestedCoroutine;
			Progress = 1;
		}
	}
}