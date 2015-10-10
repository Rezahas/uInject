using System;

namespace Async
{
	public interface Task
	{
		/// <summary>
		/// Value between 0 and 1. (RO)
		/// </summary>
		float Progress
		{
			get;
		}

		bool IsDone
		{
			get;
		}
	}

	public interface Task<T> : Task
	{
		event Action<Task> OnProgressChanged;

		event Action<Task, T> OnDone;
	}
}