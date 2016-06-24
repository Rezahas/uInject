using System;
using UnityEngine;

namespace Async.Impl
{
	public abstract class AOperationMono : MonoBehaviour
	{
		private float progress;

		public float Progress
		{
			get
			{
				return progress;
			}
			protected set
			{
				if (progress != value)
				{
					progress = value;
					OnProgressChanged();
					if (IsDone)
					{
						OnDone();
						CleanupOperation();
					}
				}
			}
		}

		public bool IsDone
		{
			get
			{
				return progress >= 1;
			}
		}

		public event Action OnProgressChanged = delegate { };

		public event Action OnDone = delegate { };

		protected virtual void Awake()
		{
			enabled = false;
		}

		protected virtual void CleanupOperation()
		{
			enabled = false;
			OnProgressChanged = null;
			OnDone = null;
		}
	}
}