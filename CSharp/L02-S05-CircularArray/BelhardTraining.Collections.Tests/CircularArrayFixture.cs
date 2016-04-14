using System.Linq;
using NUnit.Framework;

namespace BelhardTraining.Collections.Tests
{
    [TestFixture]
    public class CircularArrayFixture
    {
        [Test]
        public void Count_IsZero_AfterNew()
        {
            var arr = new CircularArray<int>(5);
            Assert.AreEqual(0, arr.Count);
        }

        [Test]
        public void Count_IsZero_AfterClear()
        {
            var arr = new CircularArray<int>(3);
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);
            arr.Add(4);
            arr.Add(5);
            arr.Clear();

            Assert.AreEqual(0, arr.Count);
        }

        [Test]
        public void Indexer_IsCorrect()
        {
            CircularArray<int> arr = new CircularArray<int>(3);
            arr.Add(0);
            arr.Add(1);
            arr.Add(2);

            Assert.AreEqual(0, arr[0]);
            Assert.AreEqual(1, arr[1]);
            Assert.AreEqual(2, arr[2]);
        }

        [Test]
        public void Indexer_IsCorrect_WithOverlap()
        {
            CircularArray<int> arr = new CircularArray<int>(3);
            arr.Add(0);
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);

            Assert.AreEqual(1, arr[0]);
            Assert.AreEqual(2, arr[1]);
            Assert.AreEqual(3, arr[2]);
        }

        [Test]
        public void Indexer_IsCorrect_WithCirleOverlap()
        {
            CircularArray<int> arr = new CircularArray<int>(3);
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);
            arr.Add(4);
            arr.Add(5);
            arr.Add(6);

            Assert.AreEqual(4, arr[0]);
            Assert.AreEqual(5, arr[1]);
            Assert.AreEqual(6, arr[2]);
        }

        [Test]
        public void Y1()
        {
            int[] srcItems = Enumerable.Range(0, 10).ToArray();
            CircularArray<int> arr = new CircularArray<int>(srcItems.Length);
            foreach (int srcItem in srcItems)
            {
                arr.Add(srcItem);
            }

            int idx = 0;
            foreach (int item in arr)
            {
                Assert.AreEqual(srcItems[idx], item);
                idx++;
            }
        }

        [Test]
        public void Y2()
        {
            int[] srcItems = Enumerable.Range(0, 10).ToArray();
            CircularArray<int> arr = new CircularArray<int>(srcItems.Length / 2);
            foreach (int srcItem in srcItems)
            {
                arr.Add(srcItem);
            }

            int idx = srcItems.Length / 2;
            foreach (int item in arr)
            {
                Assert.AreEqual(srcItems[idx], item);
                idx++;
            }
        }
    }
}
