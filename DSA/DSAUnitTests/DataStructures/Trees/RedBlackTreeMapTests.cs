﻿using System;
using NUnit.Framework;
using DSA.DataStructures.Trees;
using System.Diagnostics;

namespace DSAUnitTests.DataStructures.Trees
{
    [TestFixture]
    public class RedBlackTreeMapTests
    {
        [Test]
        public void AddingOneMillionInts()
        {
            var tree = new RedBlackTreeMap<int, int>();

            for (int i = 0; i < 1000000; i++)
            {
                tree.Add(i, i);
            }

            Assert.IsTrue(tree.Count == 1000000);
        }

        [Test]
        public void SortedElementsAfterAdding()
        {
            var tree = new RedBlackTreeMap<int, int>();

            int elementsCount = 100000;

            //Adding every seventh number, then every fifth number,
            //every third and at last all numbers
            for (int i = 7; i > 0; i -= 2)
            {
                int el = 0;
                while (el < elementsCount)
                {
                    if (!tree.ContainsKey(el)) tree.Add(el, el);
                    el += i;
                }

            }

            int last = -1;
            int count = 0;
            bool elementsAreSorted = true;
            foreach (var item in tree)
            {
                if (last > item.Key)
                {
                    elementsAreSorted = false;
                }
                last = item.Key;
                count++;
            }

            Assert.IsTrue(tree.Count == elementsCount
                            && elementsAreSorted
                            && count == elementsCount);
        }

        [Test]
        public void SortedElementsAfterAddingAndRemoving()
        {
            var tree = new RedBlackTreeMap<int, int>();

            int elementsCount = 100000;

            //Adding every seventh number, then every fifth number,
            //every third and at last all numbers
            for (int i = 7; i > 0; i -= 2)
            {
                int el = 0;
                while (el < elementsCount)
                {
                    if (!tree.ContainsKey(el)) tree.Add(el, el);
                    el += i;
                }

            }

            bool removedEverything = true;

            //Removing every second number
            for (int i = 0; i < elementsCount; i += 2)
            {
                if (!tree.Remove(i)) removedEverything = false;
            }


            int last = -1;
            int count = 0;
            bool elementsAreSorted = true;
            foreach (var item in tree)
            {
                if (last > item.Key)
                {
                    elementsAreSorted = false;
                }
                last = item.Key;
                count++;
            }

            Assert.IsTrue(tree.Count == count
                            && elementsAreSorted
                            && removedEverything);
        }

        [Test]
        public void RemoveAllExceptOne()
        {
            var tree = new RedBlackTreeMap<int, int>();

            int elementsCount = 100000;

            //Adding every seventh number, then every fifth number,
            //every third and at last all numbers
            for (int i = 7; i > 0; i -= 2)
            {
                int el = 0;
                while (el < elementsCount)
                {
                    if (!tree.ContainsKey(el)) tree.Add(el, el);
                    el += i;
                }

            }

            bool removedEverything = true;

            for (int i = 0; i < elementsCount - 1; i++)
            {
                if (!tree.Remove(i)) removedEverything = false;
            }

            Assert.IsTrue(tree.Count == 1
                            && removedEverything
                            && tree.Root.Value == elementsCount - 1
                            && tree.Root.Left == null
                            && tree.Root.Right == null);
        }

        [Test]
        public void RemoveRootEveryTimeUntilTreeElementsAreHalfed()
        {
            var tree = new RedBlackTreeMap<int, int>();

            int elementsCount = 100000;

            //Adding every seventh number, then every fifth number,
            //every third and at last all numbers
            for (int i = 7; i > 0; i -= 2)
            {
                int el = 0;
                while (el < elementsCount)
                {
                    if (!tree.ContainsKey(el))
                    {
                        tree.Add(el, el);
                    }
                    el += i;
                }

            }

            bool removedEverything = true;

            while (tree.Count > elementsCount / 2)
            {
                if (!tree.Remove(tree.Root.Value)) removedEverything = false;
            }

            int last = -1;
            int count = 0;
            bool elementsAreSorted = true;
            foreach (var item in tree)
            {
                if (last > item.Key)
                {
                    elementsAreSorted = false;
                }
                last = item.Key;
                count++;
            }

            Assert.IsTrue(tree.Count == count
                            && elementsAreSorted
                            && count == elementsCount / 2
                            && removedEverything);
        }

        [Test]
        public void BalancingCheckWithRootRotation()
        {
            var tree = new RedBlackTreeMap<int, int>();

            tree.Add(1, 1);
            tree.Add(2, 2);
            tree.Add(3, 3);

            /*
            After balance the tree should look like this:
                  2
                 / \
                1   3
            */

            Assert.IsTrue(tree.Root.Value == 2
                            && tree.Root.Left.Value == 1
                            && tree.Root.Right.Value == 3);

        }

        [Test]
        public void AddingAfterClearingTree()
        {
            var tree = new RedBlackTreeMap<int, int>();

            int elementsCount = 100000;

            //Adding every seventh number, then every fifth number,
            //every third and at last all numbers
            for (int i = 7; i > 0; i -= 2)
            {
                int el = 0;
                while (el < elementsCount)
                {
                    if (!tree.ContainsKey(el))
                    {
                        tree.Add(el, el);
                    }
                    el += i;
                }

            }

            if (tree.Count != elementsCount) Assert.Fail();

            tree.Clear();

            if (tree.Count != 0) Assert.Fail();

            //Adding every seventh number, then every fifth number,
            //every third and at last all numbers
            for (int i = 7; i > 0; i -= 2)
            {
                int el = 0;
                while (el < elementsCount)
                {
                    if (!tree.ContainsKey(el))
                    {
                        tree.Add(el, el);
                    }
                    el += i;
                }

            }

            int last = -1;
            int count = 0;
            bool elementsAreSorted = true;
            foreach (var item in tree)
            {
                if (last > item.Key)
                {
                    elementsAreSorted = false;

                }
                last = item.Key;
                count++;
            }

            Assert.IsTrue(tree.Count == elementsCount
                            && elementsAreSorted
                            && count == elementsCount);
        }

        [Test]
        public void AddingAfterRemovingAllElements()
        {
            var tree = new RedBlackTreeMap<int, int>();

            int elementsCount = 100000;

            //Adding every seventh number, then every fifth number,
            //every third and at last all numbers
            for (int i = 7; i > 0; i -= 2)
            {
                int el = 0;
                while (el < elementsCount)
                {
                    if (!tree.ContainsKey(el))
                    {
                        tree.Add(el, el);
                    }
                    el += i;
                }

            }

            if (tree.Count != elementsCount) Assert.Fail();

            //Removing every seventh number, then every fifth number,
            //every third and at last all numbers
            for (int i = 7; i > 0; i -= 2)
            {
                int el = 0;
                while (el < elementsCount)
                {
                    tree.Remove(el);
                    el += i;
                }

            }

            if (tree.Count != 0) Assert.Fail();

            //Adding every seventh number, then every fifth number,
            //every third and at last all numbers
            for (int i = 7; i > 0; i -= 2)
            {
                int el = 0;
                while (el < elementsCount)
                {
                    if (!tree.ContainsKey(el))
                    {
                        tree.Add(el, el);
                    }
                    el += i;
                }

            }

            int last = -1;
            int count = 0;
            bool elementsAreSorted = true;
            foreach (var item in tree)
            {
                if (last > item.Key)
                {
                    elementsAreSorted = false;

                }
                last = item.Key;
                count++;
            }

            Assert.IsTrue(tree.Count == elementsCount
                            && elementsAreSorted
                            && count == elementsCount);
        }

        [Test]
        public void CheckIfNodeIsInvalidatedAfterClearingAndAfterRemoval()
        {
            var tree = new RedBlackTreeMap<int, int>();

            tree.Add(2, 2);
            tree.Add(1, 1);
            tree.Add(3, 3);

            // Tree looks like this:
            //   2
            //  / \
            // 1   3

            var node1 = tree.Root.Left;
            var node2 = tree.Root;
            var node3 = tree.Root.Right;

            tree.Remove(2);
            if (node2.Left != null || node2.Right != null) Assert.Fail("2");

            tree.Remove(3);
            if (node3.Left != null || node3.Right != null) Assert.Fail("3");

            tree.Remove(1);
            if (node1.Left != null || node1.Right != null) Assert.Fail("1");

            tree.Add(2, 2);
            tree.Add(1, 1);
            tree.Add(3, 3);

            node1 = tree.Root.Left;
            node2 = tree.Root;
            node3 = tree.Root.Right;

            tree.Clear();

            Assert.IsTrue(node1.Left == null && node1.Right == null
                            && node2.Left == null && node2.Right == null
                            && node3.Left == null && node3.Right == null
                            && tree.Root == null
                            && tree.Count == 0);
        }

        [Test]
        public void AddingElementsWithIndexer()
        {
            var tree = new RedBlackTreeMap<int, int>();

            int elementsCount = 100000;

            //Adding every seventh number, then every fifth number,
            //every third and at last all numbers
            for (int i = 7; i > 0; i -= 2)
            {
                int el = 0;
                while (el < elementsCount)
                {
                    if (!tree.ContainsKey(el))
                    {
                        tree[el] = el;
                    }
                    el += i;
                }

            }

            int last = -1;
            int count = 0;
            bool elementsAreSorted = true;
            foreach (var item in tree)
            {
                if (last > item.Key)
                {
                    elementsAreSorted = false;

                }
                last = item.Key;
                count++;
            }

            Assert.IsTrue(tree.Count == elementsCount
                            && elementsAreSorted
                            && count == elementsCount);
        }

        [Test]
        public void UpdatingElementsWithIndexerUsingTryGetValueMethodToGetValue()
        {
            var tree = new RedBlackTreeMap<int, int>();

            int elementsCount = 100000;

            //Adding every seventh number, then every fifth number,
            //every third and at last all numbers
            for (int i = 7; i > 0; i -= 2)
            {
                int el = 0;
                while (el < elementsCount)
                {
                    if (!tree.ContainsKey(el)) tree.Add(el, el);
                    el += i;
                }

            }

            bool removedEverything = true;

            //Removing every second number
            for (int i = 0; i < elementsCount; i += 2)
            {
                if (!tree.Remove(i)) removedEverything = false;
            }

            // Make all values negative
            for (int i = 0; i < elementsCount; i++)
            {
                int value;
                if (tree.TryGetValue(i, out value))
                {
                    tree[value] = -value;
                }
            }

            int last = -1;
            int count = 0;
            bool elementsAreSorted = true;
            foreach (var item in tree)
            {
                if (item.Value > 0) Assert.Fail();
                if (last > item.Key)
                {
                    elementsAreSorted = false;
                }
                last = item.Key;
                count++;
            }

            Trace.WriteLine(tree.Count);

            Assert.IsTrue(tree.Count == count
                            && elementsAreSorted
                            && removedEverything);
        }

        [Test]
        public void ContatinsValueBeforeAndAfterUpdatingValue()
        {
            var tree = new RedBlackTreeMap<int, int>();

            int elementsCount = 1000;

            //Adding every seventh number, then every fifth number,
            //every third and at last all numbers
            for (int i = 7; i > 0; i -= 2)
            {
                int el = 0;
                while (el < elementsCount)
                {
                    if (!tree.ContainsKey(el)) tree.Add(el, el);
                    el += i;
                }

            }

            // Check if values are contained, make them negative and check again. Skip zero...
            for (int i = 1; i < elementsCount; i++)
            {
                if (!tree.ContainsValue(i)) Assert.Fail();
                tree[i] = -i;
                if (tree.ContainsValue(i)) Assert.Fail();
                if (!tree.ContainsValue(-i)) Assert.Fail();
            }

            int last = -1;
            int count = 0;
            bool elementsAreSorted = true;
            foreach (var item in tree)
            {
                if (last > item.Key)
                {
                    elementsAreSorted = false;
                }
                last = item.Key;
                count++;
            }

            Trace.WriteLine(tree.Count);

            Assert.IsTrue(tree.Count == elementsCount
                            && elementsAreSorted
                            && count == elementsCount);
        }
    }
}
