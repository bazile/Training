using System;
using System.Runtime.Serialization;

namespace XmlSamples.Sample01
{
	[Serializable]
	internal class CustomerLoadFailedException : ApplicationException
	{
		public CustomerLoadFailedException()
		{
		}

		public CustomerLoadFailedException(string message) : base(message)
		{
		}

		public CustomerLoadFailedException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected CustomerLoadFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
