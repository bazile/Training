using System;
using System.Runtime.Serialization;

namespace XmlSamples.Sample01
{
	[Serializable]
	internal class InvalidCustomerFileException : ApplicationException
	{
		public InvalidCustomerFileException()
		{
		}

		public InvalidCustomerFileException(string message) : base(message)
		{
		}

		public InvalidCustomerFileException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected InvalidCustomerFileException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
