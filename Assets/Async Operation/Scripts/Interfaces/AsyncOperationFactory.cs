using System;
using System.Collections.Generic;

namespace Async
{
	public interface AsyncOperationFactory
	{
		/// <summary>
		/// Creates an AsyncOperation that is managed by the caller. All it does is share information about the progress of the operation.
		/// </summary>
		/// <param name="progressFunction">Function that sets the current progress of the operation. Value 1 or above will be considered as "done".</param>
		/// <returns>The AsyncOperation object encapsulating the operation.</returns>
		Task<EmptyResult> Create(out Action<float> progressFunction);

		/// <summary>
		/// Creates an AsyncOperation that returns the result of the results function upon completion.
		/// </summary>
		/// <typeparam name="T">Type that is returned upon completion.</typeparam>
		/// <param name="results">Function that returns the results upon completion.</param>
		/// <param name="progressFunction">Function that sets the current progress of the operation. Value 1 or above will be considered as "done".</param>
		/// <returns>The AsyncOperation object encapsulating the operation.</returns>
		Task<T> Create<T>(Func<T> results, out Action<float> progressFunction);

		/// <summary>
		/// Creates an AsyncOperation that is managed internally. All given actions will be called once in the given order.
		/// </summary>
		/// <param name="actions">Actions the operation will call.</param>
		/// <returns>The AsyncOperation object encapsulating the operation.</returns>
		Task<EmptyResult> Create(IEnumerable<Action> actions);

		/// <summary>
		/// Creates an AsyncOperation that returns the result of the results function upon completion.
		/// </summary>
		/// <typeparam name="T">Type that is returned upon completion.</typeparam>
		/// <param name="results">Function that returns the results upon completion.</param>
		/// <param name="progressFunction">Function that sets the current progress of the operation. Value 1 or above will be considered as "done".</param>
		/// <returns>The AsyncOperation object encapsulating the operation.</returns>
		Task<T> Create<T>(Func<T> results, IEnumerable<Action> actions);
	}
}