using System;
using System.Runtime.Serialization;

namespace ExceptionsDemo
{
	/*
	 * Правила
	 *		Имя класса должно заканчиваться на Exception
	 *		Наследуемся от подходящего Exception-класса
	 *		Помечаем класс атрибутом Serializable
	 *		Определяем три public-конструктора
	*/
	[Serializable]
	public class DeepThoughtException : Exception
	{
		public DeepThoughtException()
		{
		}

		public DeepThoughtException(string message) : base(message)
		{
		}

		public DeepThoughtException(string message, Exception innerException) : base(message, innerException)
		{
		}

	    protected DeepThoughtException(SerializationInfo info, StreamingContext context) : base(info, context)
	    {
	    }
	}
}
