// ReSharper disable RedundantUsingDirective

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
// ReSharper restore RedundantUsingDirective

// *********************************************************
// ВНИМАНИЕ!
// Данный пример является иллюстрацией КАК НЕ НАДО писать код!
// *********************************************************

namespace BugsDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			#region Работа со списком из разных потоков

			var items = new List<int>();

			#region Неправильный подход

			// Вызываем потоко-небезопасный метод Add() из разных потоков без синхронизации
			Parallel.For(0, 1000000, i => items.Add(i));
			// Ожидаем здесь исключение т.к. список находится в испорченном состоянии
			items.Add(0);

			#endregion

			#region Правильный подход

			//Parallel.For(0, 1000000, i =>
			//	{
			//		lock(items)
			//		{
			//			items.Add(i);
			//		}
			//	});
			//items.Add(0);

			#endregion

			#endregion

			#region Неатомарная запись и чтение GUID

			//var obj = new ClassWithNonAtomicGuidAccess();
			////var obj = new ClassWithAtomicGuidAccess();
			//const int runTimes = 10000000;
			//Task setGuidOfZero = Task.Factory.StartNew(() => Parallel.For(0, runTimes, i => obj.SetValue(Guid.Empty)));
			//Task readAndPrintGuid = Task.Factory.StartNew(
			//	() => Parallel.For(0, runTimes, 
			//		i =>
			//			{
			//				Guid guid = obj.GetValue();
			//				byte[] bytes = guid.ToByteArray();
			//				for (int k=1; k<bytes.Length; k++)
			//				{
			//					if (bytes[k - 1] != bytes[k])
			//					{
			//						Console.WriteLine(guid);
			//					}
			//				}
			//			}
			//	)
			//);
			//Task setGuidOfFive = Task.Factory.StartNew(() => Parallel.For(0, runTimes, i => obj.SetValue(new Guid("{55555555-5555-5555-5555-555555555555}"))));
			//Task.WaitAll(setGuidOfZero, setGuidOfFive, readAndPrintGuid);

			#endregion
		}
	}
}
