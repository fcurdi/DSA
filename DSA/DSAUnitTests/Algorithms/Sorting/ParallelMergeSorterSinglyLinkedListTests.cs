using System;
using NUnit.Framework;
using DSA.DataStructures.Lists;
using DSA.Algorithms.Sorting;
using System.Collections.Generic;

namespace DSAUnitTests.Algorithms.Sorting
{
    [TestFixture]
    public class ParallelMergeSorterSinglyLinkedListTests
    {
        [Test]
        public void SortingInAscendingOrderAndCheckingIfSorted()
        {
            var list = new SinglyLinkedList<int>();

            int minElement = -50000;
            int maxElement = 50000;

            int addedElements = 0;

            //Adding every seventh number, then every fifth number,
            //every third and at last all numbers
            //NOTE: some items are added more than once
            for (int i = 7; i > 0; i -= 2)
            {
                int el = minElement;
                while (el <= maxElement)
                {
                    list.AddLast(el);
                    addedElements++;
                    el += i;
                }
            }

            list.ParallelMergeSort();

            var last = int.MinValue;
            foreach (var item in list)
            {
                if (last > item) Assert.Fail();

                last = item;
            }
        }

        [Test]
        public void SortingInDescendingOrderAndCheckingIfSorted()
        {
            var list = new SinglyLinkedList<int>();

            int minElement = -50000;
            int maxElement = 50000;

            int addedElements = 0;

            //Adding every seventh number, then every fifth number,
            //every third and at last all numbers
            //NOTE: some items are added more than once
            for (int i = 7; i > 0; i -= 2)
            {
                int el = maxElement;
                while (el >= minElement)
                {
                    list.AddLast(el);
                    addedElements++;
                    el -= i;
                }
            }

            list.ParallelMergeSortDescending();

            var last = int.MaxValue;
            foreach (var item in list)
            {
                if (last < item) Assert.Fail();

                last = item;
            }
        }

        [Test]
        public void SortingInAscendingOrderUsingAComparisonAndCheckingIfSorted()
        {
            var list = new SinglyLinkedList<int>();

            int minElement = -50000;
            int maxElement = 50000;

            int addedElements = 0;

            //Adding every seventh number, then every fifth number,
            //every third and at last all numbers
            //NOTE: some items are added more than once
            for (int i = 7; i > 0; i -= 2)
            {
                int el = minElement;
                while (el <= maxElement)
                {
                    list.AddLast(el);
                    addedElements++;
                    el += i;
                }
            }

            list.ParallelMergeSort((x, y) => x.CompareTo(y));

            var last = int.MinValue;
            foreach (var item in list)
            {
                if (last > item) Assert.Fail();

                last = item;
            }
        }

        [Test]
        public void SortingInDescendingOrderUsingAComparisonAndCheckingIfSorted()
        {
            var list = new SinglyLinkedList<int>();

            int minElement = -50000;
            int maxElement = 50000;

            int addedElements = 0;

            //Adding every seventh number, then every fifth number,
            //every third and at last all numbers
            //NOTE: some items are added more than once
            for (int i = 7; i > 0; i -= 2)
            {
                int el = maxElement;
                while (el >= minElement)
                {
                    list.AddLast(el);
                    addedElements++;
                    el -= i;
                }
            }

            list.ParallelMergeSortDescending((x, y) => x.CompareTo(y));

            var last = int.MaxValue;
            foreach (var item in list)
            {
                if (last < item) Assert.Fail();

                last = item;
            }
        }

        [Test]
        public void SortingInAscendingOrderUsingACustomComparerAndCheckingIfSorted()
        {
            var list = new SinglyLinkedList<int>();

            int minElement = -50000;
            int maxElement = 50000;

            int addedElements = 0;

            //Adding every seventh number, then every fifth number,
            //every third and at last all numbers
            //NOTE: some items are added more than once
            for (int i = 7; i > 0; i -= 2)
            {
                int el = minElement;
                while (el <= maxElement)
                {
                    list.AddLast(el);
                    addedElements++;
                    el += i;
                }
            }

            list.ParallelMergeSort(Comparer<int>.Create((x, y) => x.CompareTo(y)));

            var last = int.MinValue;
            foreach (var item in list)
            {
                if (last > item) Assert.Fail();

                last = item;
            }
        }

        [Test]
        public void SortingInDescendingOrderUsingACustomComparerAndCheckingIfSorted()
        {
            var list = new SinglyLinkedList<int>();

            int minElement = -50000;
            int maxElement = 50000;

            int addedElements = 0;

            //Adding every seventh number, then every fifth number,
            //every third and at last all numbers
            //NOTE: some items are added more than once
            for (int i = 7; i > 0; i -= 2)
            {
                int el = maxElement;
                while (el >= minElement)
                {
                    list.AddLast(el);
                    addedElements++;
                    el -= i;
                }
            }

            list.ParallelMergeSortDescending(Comparer<int>.Create((x, y) => x.CompareTo(y)));

            var last = int.MaxValue;
            foreach (var item in list)
            {
                if (last < item) Assert.Fail();

                last = item;
            }
        }

        [Test]
        public void SortingARangeOfItemsInAscendingOrderAndCheckingIfSorted()
        {
            var list = new SinglyLinkedList<int>();

            int minElement = -50000;
            int maxElement = 50000;

            int addedElements = 0;

            //Adding every seventh number, then every fifth number,
            //every third and at last all numbers
            //NOTE: some items are added more than once
            for (int i = 7; i > 0; i -= 2)
            {
                int el = minElement;
                while (el <= maxElement)
                {
                    list.AddLast(el);
                    addedElements++;
                    el += i;
                }
            }

            int beginSortAt = addedElements / 3;
            int sortedCount = addedElements / 2;

            list.ParallelMergeSort(beginSortAt, sortedCount, null);

            var last = int.MinValue;
            var curNode = list.First;
            int curNodeIndex = 0;
            int traversedSortedNodes = 0;
            while (curNode.Next != null)
            {
                if (curNodeIndex++ >= beginSortAt)
                {
                    if (last > curNode.Value) Assert.Fail();
                    traversedSortedNodes++;
                }

                if (traversedSortedNodes == sortedCount)
                    break;

                curNode = curNode.Next;
            }
        }

        [Test]
        public void SortingARangeOfItemsInDescendingOrderAndCheckingIfSorted()
        {
            var list = new SinglyLinkedList<int>();

            int minElement = -50000;
            int maxElement = 50000;

            int addedElements = 0;

            //Adding every seventh number, then every fifth number,
            //every third and at last all numbers
            //NOTE: some items are added more than once
            for (int i = 7; i > 0; i -= 2)
            {
                int el = maxElement;
                while (el >= minElement)
                {
                    list.AddLast(el);
                    addedElements++;
                    el -= i;
                }
            }

            int beginSortAt = addedElements / 3;
            int sortedCount = addedElements / 2;

            list.ParallelMergeSortDescending(beginSortAt, sortedCount, null);

            var last = int.MaxValue;
            var curNode = list.First;
            int curNodeIndex = 0;
            int traversedSortedNodes = 0;
            while (curNode.Next != null)
            {
                if (curNodeIndex++ >= beginSortAt)
                {
                    if (last < curNode.Value) Assert.Fail();
                    traversedSortedNodes++;
                }

                if (traversedSortedNodes == sortedCount)
                    break;

                curNode = curNode.Next;
            }
        }
    }
}
