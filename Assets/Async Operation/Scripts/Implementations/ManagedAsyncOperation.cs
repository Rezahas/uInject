using Ninject;
using Ninject.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Async.Impl
{
	public sealed class ManagedAsyncOperation<T> : Task<T>
	{
		public event Action<Task> OnProgressChanged = delegate { };

		public event Action<Task, T> OnDone = delegate { };

		private Func<T> results;
		private ManagedAsyncOperation monoBehaviour;

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

		public ManagedAsyncOperation(IEnumerable<Action> actions, Func<T> results)
		{
			this.results = results;
			monoBehaviour = UnityKernel.INSTANCE.Get<ManagedAsyncOperation>();
			monoBehaviour.Init(actions);
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
			monoBehaviour = null;
		}
	}

	public sealed class ManagedAsyncOperation : AMono
	{
		public event Action OnProgressChanged = delegate { };

		public event Action OnDone = delegate { };

		private Action[] actions;
		private int currentAction;

		public float Progress
		{
			get;
			private set;
		}

		public bool IsDone
		{
			get
			{
				return Progress >= 1;
			}
		}

		public void Init(IEnumerable<Action> actions)
		{
			this.actions = actions.ToArray();
			currentAction = 0;
			enabled = true;
		}

		protected override void Awake()
		{
			base.Awake();
			GameObject.DontDestroyOnLoad(gameObject);
			enabled = false;
		}

		protected override void Update()
		{
			base.Update();
			actions[currentAction]();
			currentAction++;
			Progress = (float)currentAction / actions.Length;
			OnProgressChanged();
			if (IsDone)
			{
				OnDone();
				enabled = false;
				OnProgressChanged = null;
				OnDone = null;
				GameObject.Destroy(gameObject);
			}
		}
	}
}