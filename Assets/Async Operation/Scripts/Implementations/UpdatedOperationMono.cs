using System;
using System.Collections.Generic;
using System.Linq;

namespace Async.Impl
{
	public sealed class UpdatedOperation : AOperationMono
	{
		private Action[] actions;
		private int currentAction;

		public void Init(IEnumerable<Action> actions)
		{
			this.actions = actions.ToArray();
			currentAction = 0;
			enabled = true;
		}

		protected override void CleanupOperation()
		{
			base.CleanupOperation();
			actions = null;
			currentAction = 0;
		}

		private void Update()
		{
			actions[currentAction]();
			currentAction++;
			Progress = (float)currentAction / actions.Length;
		}
	}
}