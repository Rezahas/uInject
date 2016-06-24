using System;

namespace Async.Impl
{
	public sealed class ManagedAsyncOperation<T> : Task<T>
	{
		private Func<T> results;

		private AOperationMono monoBehaviour;

		public float Progress
		{
			get
			{
				return monoBehaviour.Progress;
			}
		}

		public bool IsDone
		{
			get
			{
				return monoBehaviour.IsDone;
			}
		}

		public event Action<Task> OnProgressChanged = delegate { };

		public event Action<Task, T> OnDone = delegate { };

		public ManagedAsyncOperation(AOperationMono monoBehaviour, Func<T> results)
		{
			this.results = results;
			this.monoBehaviour = monoBehaviour;
			monoBehaviour.OnProgressChanged += ProgressChanged;
			monoBehaviour.OnDone += Done;
		}

		private void ProgressChanged()
		{
			OnProgressChanged(this);
		}

		private void Done()
		{
			OnDone(this, results());
			monoBehaviour.OnProgressChanged -= ProgressChanged;
			monoBehaviour.OnDone -= Done;
			monoBehaviour = null;
		}
	}
}