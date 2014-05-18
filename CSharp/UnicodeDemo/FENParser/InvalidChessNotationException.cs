using System;
using System.Runtime.Serialization;

namespace FENParser
{
	[Serializable]
	public class InvalidChessNotationException : Exception
	{
		public string Notation { get; private set; }

		public InvalidChessNotationException()
		{
		}

		public InvalidChessNotationException(string message, string notation)
			: this(message, notation, null)
		{
		}

		public InvalidChessNotationException(string message, string notation, Exception inner)
			: base(message, inner)
		{
			Notation = notation;
		}

		protected InvalidChessNotationException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			Notation = info.GetString("Notation");
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Notation", Notation);

			base.GetObjectData(info, context);
		}
	}
}
