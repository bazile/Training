using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BelhardTraining.RecentListDemo.Tests
{
	/// <summary>
	/// Unit-тесты для класса RecentList&gt;T&lt;
	/// </summary>
	/// <remarks>
	/// Тесты написаны на основе MS Test Framework
	/// Для запуска тестов используйте меню Test -> Run
	/// </remarks>
	[TestClass]
	public class RecentListFixture
	{
		[TestMethod]
		[Description("Constructor")]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ConstructorThrowsArgumentOutOfRangeException_WhenZeroIsPassed()
		{
			var list = new RecentList<string>(0);
			Assert.IsNotNull(list);
		}

		[TestMethod]
		[Description("Constructor")]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ConstructorThrowsArgumentOutOfRangeException_WhenNegativeNumberIsPassed()
		{
			var list = new RecentList<string>(-10);
			Assert.IsNotNull(list);
		}

		[TestMethod]
		[Description("Count property")]
		public void CountIsZero_ForNewList()
		{
			var list = new RecentList<string>(10);
			Assert.AreEqual(0, list.Count);
		}

		[TestMethod]
		[Description("Capacity property")]
		public void CapacityIsNonZero_ForNewList()
		{
			var list = new RecentList<string>(10);
			Assert.AreEqual(10, list.Capacity);
		}

		[TestMethod]
		[Description("Count property")]
		public void CountIsZero_AfterClear()
		{
			var list = new RecentList<int>(10) { 1, 2, 3, 4 };
			list.Clear();
			Assert.AreEqual(0, list.Count);
		}

		[TestMethod]
		[Description("Indexer")]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ThrowsArgumentOutOfRangeException_WhenListIsEmpty()
		{
			var list = new RecentList<int>(10);
			int first = list[0];
			Console.WriteLine(first);
		}

		[TestMethod]
		[Description("Add method")]
		public void AddMovesElementToBeginning()
		{
			var list = new RecentList<int>(5);
			list.Add(1);
			list.Add(2);
			// Добавляем уже существующий элемент.
			// "1" и "2" должны поменяться местами
			list.Add(1);

			Assert.AreEqual(2, list.Count);
			Assert.AreEqual(1, list[0]);
			Assert.AreEqual(2, list[1]);
		}

		[TestMethod]
		[Description("Add method")]
		public void AddDeletesLastElement()
		{
			var list = new RecentList<int>(3);
			list.Add(1);
			list.Add(2);
			list.Add(3);
			// Закончилось место в списке.
			// Элемент "1" должен быть удален.
			list.Add(4);

			Assert.AreEqual(3, list.Count);
			Assert.AreEqual(4, list[0]);
			Assert.AreEqual(3, list[1]);
			Assert.AreEqual(2, list[2]);
		}

		[TestMethod]
		[Description("Add method")]
		public void AddDoesNotMoveFirstElement()
		{
			var list = new RecentList<int>(3);
			list.Add(1);
			list.Add(2);
			list.Add(3);
			// Повторно добавляем элемент "3" который уже в начале списка.
			// Порядок элементов не должен измениться
			list.Add(3);

			Assert.AreEqual(3, list.Count);
			Assert.AreEqual(3, list[0]);
			Assert.AreEqual(2, list[1]);
			Assert.AreEqual(1, list[2]);
		}

		[TestMethod]
		[Description("Remove method")]
		public void CanRemoveFromEmptyList()
		{
			var list = new RecentList<int>(10);
			bool removed = list.Remove(int.MaxValue);

			Assert.IsFalse(removed);
			Assert.AreEqual(0, list.Count);
		}

		[TestMethod]
		[Description("Remove method")]
		public void CanRemoveNonExistingInt32Element()
		{
			var list = new RecentList<int>(10) { 1, 2, 3, 4, 5 };
			int oldCount = list.Count;

			bool removed = list.Remove(1024);

			Assert.IsFalse(removed);
			Assert.AreEqual(oldCount, list.Count);
		}

		[TestMethod]
		[Description("Remove method")]
		public void CanRemoveNonExistingStringElement()
		{
			var list = new RecentList<string>(10) { "Neo", "Morpheus", "Trinity", "Agent Smith", "Oracle" };
			int oldCount = list.Count;

			bool removed = list.Remove("There is no spoon");

			Assert.IsFalse(removed);
			Assert.AreEqual(oldCount, list.Count);
		}

		[TestMethod]
		[Description("Remove method")]
		public void CanRemoveFirstInt32Element()
		{
			var list = new RecentList<int>(5) {1, 2, 3, 4, 5};
			int oldCount = list.Count;

			bool removed = list.Remove(5);

			Assert.IsTrue(removed);
			Assert.AreEqual(oldCount - 1, list.Count);

			// TODO: Use SequenceEqual
			int[] temp = new[] { 1, 2, 3, 4 }.Reverse().ToArray();
			for (int i = 0; i < temp.Length; i++)
			{
				Assert.AreEqual(temp[i], list[i]);
			}
		}

		[TestMethod]
		[Description("Remove method")]
		public void CanRemoveLastInt32Element()
		{
			var list = new RecentList<int>(5) { 1, 2, 3, 4, 5 };
			int oldCount = list.Count;

			bool removed = list.Remove(1);

			Assert.IsTrue(removed);
			Assert.AreEqual(oldCount - 1, list.Count);

			// TODO: Use SequenceEqual
			int[] temp = new[] { 2, 3, 4, 5 }.Reverse().ToArray();
			for (int i = 0; i < temp.Length; i++)
			{
				Assert.AreEqual(temp[i], list[i]);
			}
		}

		[TestMethod]
		[Description("Remove method")]
		public void CanRemoveMiddleInt32Element()
		{
			var list = new RecentList<int>(5) { 1, 2, 3, 4, 5 };
			int oldCount = list.Count;

			bool removed = list.Remove(3);

			Assert.IsTrue(removed);
			Assert.AreEqual(oldCount - 1, list.Count);

			// TODO: Use SequenceEqual
			int[] temp = new[] { 1, 2, 4, 5 }.Reverse().ToArray();
			for (int i = 0; i < temp.Length; i++)
			{
				Assert.AreEqual(temp[i], list[i]);
			}
		}

		[TestMethod]
		[Description("Remove method")]
		public void CanRemoveFirstStringElement()
		{
			var list = new RecentList<string>(10) { "Neo", "Morpheus", "Trinity", "Agent Smith", "Oracle" };
			int oldCount = list.Count;

			bool removed = list.Remove("Oracle");

			Assert.IsTrue(removed);
			Assert.AreEqual(oldCount-1, list.Count);

			// TODO: Use SequenceEqual
			string[] temp = new[] { "Neo", "Morpheus", "Trinity", "Agent Smith" }.Reverse().ToArray();
			for (int i = 0; i < temp.Length; i++)
			{
				Assert.AreEqual(temp[i], list[i]);
			}
		}

		[TestMethod]
		[Description("Remove method")]
		public void CanRemoveLastStringElement()
		{
			var list = new RecentList<string>(10) { "Neo", "Morpheus", "Trinity", "Agent Smith", "Oracle" };
			int oldCount = list.Count;

			bool removed = list.Remove("Neo");

			Assert.IsTrue(removed);
			Assert.AreEqual(oldCount - 1, list.Count);

			// TODO: Use SequenceEqual
			string[] temp = new[] { "Morpheus", "Trinity", "Agent Smith", "Oracle" }.Reverse().ToArray();
			for (int i = 0; i < temp.Length; i++)
			{
				Assert.AreEqual(temp[i], list[i]);
			}
		}

		[TestMethod]
		[Description("Remove method")]
		public void CanRemoveMiddleStringElement()
		{
			var list = new RecentList<string>(10) { "Neo", "Morpheus", "Trinity", "Agent Smith", "Oracle" };
			int oldCount = list.Count;

			bool removed = list.Remove("Trinity");

			Assert.IsTrue(removed);
			Assert.AreEqual(oldCount - 1, list.Count);

			// TODO: Use SequenceEqual
			string[] temp = new[] { "Neo", "Morpheus", "Agent Smith", "Oracle" }.Reverse().ToArray();
			Assert.IsTrue(temp.SequenceEqual(list));
			//for (int i = 0; i < temp.Length; i++)
			//{
			//    Assert.AreEqual(temp[i], list[i]);
			//}
		}

		[TestMethod]
		[Description("Contains method")]
		public void ContainsReturnsTrueForInt32Elements()
		{
			int[] values = new[] { int.MinValue, -100, 0, 100, int.MaxValue };
			var list = new RecentList<int>(10);
			foreach (int s in values)
			{
				list.Add(s);
			}

			foreach (int s in values)
			{
				Assert.IsTrue(list.Contains(s));
			}
		}

		[TestMethod]
		[Description("Contains method")]
		public void ContainsReturnsTrueForStringElements()
		{
			string[] values = new[] {"Neo", "Morpheus", "Trinity", "Agent Smith", "Oracle"};
			var list = new RecentList<string>(10);
			foreach (string s in values)
			{
				list.Add(s);
			}

			foreach (string s in values)
			{
				Assert.IsTrue(list.Contains(s));
			}
		}

		[TestMethod]
		[Description("Enumeration")]
		[ExpectedException(typeof(InvalidOperationException))]
		public void MoveNextThrowsInvalidOperationException_AfterListIsChanged()
		{
			var list = new RecentList<string>(10) { "Neo", "Morpheus", "Trinity", "Agent Smith", "Oracle" };
			var enumerator = list.GetEnumerator();

			list.Add("Merovingian");
			enumerator.MoveNext();
		}

		[TestMethod]
		[Description("SyncRoot property")]
		public void SyncRootIsNotNull()
		{
			var list = new RecentList<int>(10);
			Assert.IsNotNull(((ICollection)list).SyncRoot);
		}

		[TestMethod]
		[Description("SyncRoot property")]
		public void SyncRootsAreDifferent()
		{
			var list1 = new RecentList<int>(10);
			var list2 = new RecentList<int>(10);
			Assert.IsFalse(ReferenceEquals(
				((ICollection)list1).SyncRoot, 
				((ICollection)list2).SyncRoot
			));
		}

		[TestMethod]
		[Description("IsReadOnly property")]
		public void IsReadOnly_IsFalse()
		{
			var list = new RecentList<int>(10);
			Assert.IsFalse(list.IsReadOnly);
		}

		[TestMethod]
		[Description("Serialization")]
		public void CanSerializeAndDeserialize()
		{
			var list = new RecentList<int>(10);
			list.Add(3);
			list.Add(2);
			list.Add(1);

			var memStream = new MemoryStream();
			var binaryFormatter = new BinaryFormatter();
			binaryFormatter.Serialize(memStream, list);
			memStream.Position = 0;
			var listCopy = (RecentList<int>)binaryFormatter.Deserialize(memStream);
			memStream.Dispose();

			Assert.IsNotNull(listCopy);
			Assert.AreEqual(list.Count, listCopy.Count);
			Assert.AreEqual(list.Capacity, listCopy.Capacity);
			var iter1 = list.GetEnumerator();
			var iter2 = listCopy.GetEnumerator();
			for (;;)
			{
				bool hasNext1 = iter1.MoveNext();
				bool hasNext2 = iter2.MoveNext();
				Assert.AreEqual(hasNext1, hasNext2);

				if (!hasNext1 && !hasNext2) break;

				Assert.AreEqual(iter1.Current, iter2.Current);
			}
		}
	}
}
