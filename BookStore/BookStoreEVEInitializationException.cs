using System;
using System.Runtime.Serialization;

namespace BookStore
{
	/// <summary>
	/// This exception is thrown if a problem on DataLogic initialization progress.
	/// </summary>
	[Serializable]
	public class BookStoreEVEInitializationException : BookStoreEVEException
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		public BookStoreEVEInitializationException()
		{

		}

		/// <summary>
		/// Constructor for serializing.
		/// </summary>
		public BookStoreEVEInitializationException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="message">Exception message</param>
		public BookStoreEVEInitializationException(string message)
            : base(message)
        {

		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="message">Exception message</param>
		/// <param name="innerException">Inner exception</param>
		public BookStoreEVEInitializationException(string message, Exception innerException)
            : base(message, innerException)
        {

		}
	}
}
