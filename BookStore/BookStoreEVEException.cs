using System;
using System.Runtime.Serialization;

namespace BookStore
{
	/// <summary>
	/// Base exception type for those are thrown by DataLogic system for DataLogic specific exceptions.
	/// </summary>
	[Serializable]
	public class BookStoreEVEException : Exception
	{
		/// <summary>
		/// Creates a new <see cref="DataLogicException"/> object.
		/// </summary>
		public BookStoreEVEException()
		{

		}

		/// <summary>
		/// Creates a new <see cref="DataLogicException"/> object.
		/// </summary>
		public BookStoreEVEException(SerializationInfo serializationInfo, StreamingContext context)
			: base(serializationInfo,context)
		{

		}

		// <summary>
		/// Creates a new <see cref="DataLogicException"/> object.
		/// </summary>
		/// <param name="message">Exception message</param>
		public BookStoreEVEException(string message)
			: base(message)
		{

		}


		/// <summary>
		/// Creates a new <see cref="DataLogicException"/> object.
		/// </summary>
		/// <param name="message">Exception message</param>
		/// <param name="innerException">Inner exception</param>
		public BookStoreEVEException(string message, Exception innerException)
            : base(message, innerException)
        {

		}
	}
}
