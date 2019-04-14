﻿using JetBrains.Annotations;
using System;
using System.Threading;

namespace BookStore
{
	/// <summary>
	/// This class can be used to provide an action when
	/// Dipose method is called.
	/// </summary>
	class DisposeAction : IDisposable
	{
		public static readonly DisposeAction Empty = new DisposeAction(null);
		private Action action;


		/// <summary>
		/// Creates a new <see cref="DisposeAction"/> object.
		/// </summary>
		/// <param name="action">Action to be executed when this object is disposed.</param>
		public DisposeAction([CanBeNull] Action action)
		{
			this.action = action;
		}

		public void Dispose()
		{
			// Interlocked prevents multiple execution of the action.
			var exchangeAction = Interlocked.Exchange(ref action, null);
			exchangeAction?.Invoke();
		}
	}
}
