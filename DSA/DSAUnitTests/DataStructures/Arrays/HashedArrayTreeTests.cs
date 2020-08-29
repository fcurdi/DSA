using System;
using NUnit.Framework;
using DSA.DataStructures.Arrays;
using System.Linq;

namespace DSAUnitTests.DataStructures.Arrays
{
    [TestFixture]
    public class HashedArrayTreeTests
    {
        [Test]
        public void AddingItemsOneByOne()
        {
            var arr = new HashedArrayTree<int>();

            int itemCount = 1000;

            for (int i = 0; i < itemCount; i++)
            {
                arr.Add(i);
            }

            int trueCount = 0;
            int previousItem = int.MinValue;

            foreach (var item in arr)
            {
                if (previousItem > item) Assert.Fail();
                previousItem = item;
                trueCount++;
            }

            Assert.IsTrue(arr.Count == itemCount
                            && arr.Count == trueCount);
        }

        [Test]
        public void AddingRangeOfItems()
        {
            var arr = new HashedArrayTree<int>();

            int itemCount = 1000;

            for (int i = 0; i < itemCount; i++)
            {
                arr.Add(i);
            }

            if (arr.Count != itemCount) Assert.Fail();

            var arr2 = new HashedArrayTree<int>();

            arr2.AddRange(arr);

            int trueCount = 0;
            int previousItem = int.MinValue;

            foreach (var item in arr2)
            {
                if (previousItem > item) Assert.Fail();
                previousItem = item;
                trueCount++;
            }

            Assert.IsTrue(arr.Count == itemCount
                            && arr2.Count == itemCount
                            && arr2.Count == trueCount);
        }

        [Test]
        public void InitializingArrayListWithCollection()
        {
            var arr = new HashedArrayTree<int>();

            int itemCount = 1000;

            for (int i = 0; i < itemCount; i++)
            {
                arr.Add(i);
            }

            var arr2 = new HashedArrayTree<int>(arr);

            int trueCount = 0;
            int previousItem = int.MinValue;

            foreach (var item in arr2)
            {
                if (previousItem > item) Assert.Fail();
                previousItem = item;
                trueCount++;
            }

            Assert.IsTrue(arr.Count == itemCount
                            && arr2.Count == itemCount
                            && arr2.Count == trueCount);
        }

        [Test]
        public void RemovingAllExceptOne()
        {
            var arr = new HashedArrayTree<int>();

            int itemCount = 1000;

            for (int i = 0; i < itemCount; i++)
            {
                arr.Add(i);
            }

            for (int i = 0; i < itemCount - 1; i++)
            {
                if (!arr.Remove(i)) Assert.Fail(i.ToString());
            }

            int trueCount = 0;


            foreach (var item in arr)
            {
                trueCount++;
            }

            Assert.IsTrue(arr.Count == 1
                            && trueCount == 1
                            && arr[0] == itemCount - 1);
        }

        [Test]
        public void RemovingAllItemsAndAddingAgain()
        {
            var arr = new HashedArrayTree<int>();

            int itemCount = 1000;

            for (int i = 0; i < itemCount; i++)
            {
                arr.Add(i);
            }

            for (int i = 0; i < itemCount; i++)
            {
                if (!arr.Remove(i)) Assert.Fail();
            }

            bool countWasZero = arr.Count == 0;

            for (int i = 0; i < itemCount; i++)
            {
                arr.Add(i);
            }

            int trueCount = 0;
            int previousItem = int.MinValue;

            foreach (var item in arr)
            {
                if (previousItem > item) Assert.Fail();
                previousItem = item;
                trueCount++;
            }

            Assert.IsTrue(arr.Count == itemCount
                            && arr.Count == trueCount
                            && countWasZero);
        }

        [Test]
        public void RemoveRangeOfItems()
        {
            var arr = new HashedArrayTree<int>();

            int itemCount = 1000;

            for (int i = 0; i < itemCount; i++)
            {
                arr.Add(i);
            }

            arr.RemoveRange(0, itemCount - 1);

            int trueCount = 0;

            foreach (var item in arr)
            {
                trueCount++;
            }

            Assert.IsTrue(arr.Count == 1
                            && arr.Count == trueCount
                            && arr[0] == itemCount - 1);
        }

        [Test]
        public void InsertAllItemsAtTheBeginningAndCheckForReversedOrder()
        {
            var arr = new HashedArrayTree<int>();

            int itemCount = 1000;

            for (int i = 0; i < itemCount; i++)
            {
                arr.Insert(0, i);
            }

            var arr2 = new HashedArrayTree<int>(arr.Reverse());

            bool areReversed = true;

            for (int i = 0; i < itemCount; i++)
            {
                if (arr[i] != arr2[itemCount - 1 - i])
                {
                    areReversed = false;
                    break;
                }
            }

            Assert.IsTrue(arr.Count == itemCount
                            && arr2.Count == itemCount
                            && areReversed);
        }

        [Test]
        public void RemoveAtZeroUntilOneItemIsLeft()
        {
            var arr = new HashedArrayTree<int>();

            int itemCount = 1000;

            for (int i = 0; i < itemCount; i++)
            {
                arr.Add(i);
            }

            for (int i = 1; i < itemCount; i++)
            {
                arr.RemoveAt(0);
            }

            int trueCount = 0;

            foreach (var item in arr)
            {
                trueCount++;
            }

            Assert.IsTrue(arr.Count == 1
                            && arr.Count == trueCount
                            && arr[0] == itemCount - 1);
        }

        [Test]
        public void IndexOfAndLastIndexOfTest()
        {
            var arr = new HashedArrayTree<int>();

            int itemCount = 1000;

            for (int i = 0; i < itemCount; i++)
            {
                arr.Add(i);
                arr.Insert(0, i);
            }

            bool allInPlace = true;

            for (int i = 0; i < itemCount; i++)
            {
                int first = arr.IndexOf(i);
                int last = arr.LastIndexOf(i);

                if (last - first - 1 - 2 * i != 0)
                {
                    allInPlace = false;
                    break;
                }
            }

            Assert.IsTrue(arr.Count == itemCount * 2
                            && allInPlace);
        }

        [Test]
        public void CheckIfContainedBeforeAndAfterRemoval()
        {
            var arr = new HashedArrayTree<int>();

            int itemCount = 1000;

            for (int i = 0; i < itemCount; i++)
            {
                if (arr.Contains(i)) Assert.Fail();
                arr.Add(i);
                if (!arr.Contains(i)) Assert.Fail();
            }

            for (int i = 0; i < itemCount; i++)
            {
                if (!arr.Contains(i)) Assert.Fail();
                arr.Remove(i);
                if (arr.Contains(i)) Assert.Fail();
            }

            Assert.IsTrue(arr.Count == 0);
        }

        [Test]
        public void AddingAfterClearingCollection()
        {
            var arr = new HashedArrayTree<int>();

            int itemCount = 1000;

            for (int i = 0; i < itemCount; i++)
            {
                arr.Add(i);
            }

            arr.Clear();

            for (int i = 0; i < itemCount; i++)
            {
                arr.Add(i);
            }

            bool everythingIntact = true;

            for (int i = 0; i < itemCount; i++)
            {
                if (arr[i] != i)
                {
                    everythingIntact = false;
                    break;
                }
            }

            Assert.IsTrue(arr.Count == itemCount
                            && everythingIntact);
        }

        [Test]
        public void InsertingRangeOfItemsAtTheMiddle()
        {
            var arr = new HashedArrayTree<int>();

            int itemCount = 1000;

            for (int i = 0; i < itemCount; i++)
            {
                arr.Add(i);
            }

            var arr2 = new HashedArrayTree<int>(arr);

            arr.InsertRange(itemCount / 2, arr2);

            for (int i = 0; i < itemCount / 2; i++)
            {
                if (arr[i] != i) Assert.Fail();
            }

            for (int i = itemCount / 2; i < itemCount + itemCount / 2; i++)
            {
                if (arr[i] != i - itemCount / 2) Assert.Fail();
            }

            for (int i = itemCount + itemCount / 2; i < itemCount * 2; i++)
            {
                if (arr[i] != i - itemCount) Assert.Fail();
            }

            Assert.IsTrue(arr.Count == itemCount * 2);
        }
    }
}
