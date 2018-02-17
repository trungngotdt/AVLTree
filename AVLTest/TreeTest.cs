using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AVL;

namespace AVLTest
{
    [TestFixture]
    public class TreeTest
    {
        AVLTree<int> tree;
        
        Node<int> item;//= new Node<int>(3);
        Node<int> item1;//= new Node<int>(1);
        Node<int> item2;//= new Node<int>(4);
        Node<int> item3;//= new Node<int>(-4);
        Node<int> item4;

        [SetUp]
        public void SetUp()
        {
            item = new Node<int>(7);
            item1 = new Node<int>(4);
            item2 = new Node<int>(5);
            item3 = new Node<int>(71);
            item4 = new Node<int>(50);
            tree = new AVLTree<int>();
            tree.root = new Node<int>(15, new Node<int>(6), new Node<int>(23));
            
            tree.Insert(item);
            tree.Insert(item2);
            tree.Insert(item3);
            tree.Insert(item4);
            tree.Insert(item1);
            tree.Insert(new Node<int>(1));
            tree.Insert(new Node<int>(77));
            tree.AddRange(new Node<int>[] {
                new Node<int>(76), new Node<int>(75), new Node<int>(74), new Node<int>(98), new Node<int>(99),
                new Node<int>(43),new Node<int>(44),new Node<int>(51),new Node<int>(59),new Node<int>(60)
            });
            tree.Insert(null);
        }

        [Test]
        public void HeightTest()
        {
            var rootHeight = tree.Height();
        }

        [Test]
        public void InsertAndContainsTest()
        {
            var treeString = new AVLTree<string>();
            var newTree = new AVLTree<int>(new Node<int>(1, new Node<int>(1), new Node<int>(0)));
            var newTree2 = new AVLTree<int>(new Node<int>(1, new Node<int>(2), new Node<int>(0)));
            treeString.Insert(new Node<string>("S"));
            var item1C = tree.Contains(item1);
            var item2C = tree.Contains(item3);
            var strC = treeString.Contains(new Node<string>("S"));

            var falseCon = tree.Contains(new Node<int>());
            var falseNull = tree.Contains(null);
            Assert.IsTrue(strC);
            Assert.IsTrue(item1C);
            Assert.IsTrue(item2C);
            Assert.IsFalse(falseCon);
            Assert.IsFalse(falseNull);
        }

        [Test]
        public void GetMaxNodeAndGetMinNodeTest()
        {
            var max = tree.GetMax();
            var min = tree.GetMin();
            Assert.AreEqual(99, max.Data);
            Assert.AreEqual(1, min.Data);
            Assert.AreEqual(null, tree.GetMax(null));// (new BSTree<string>()).GetMax());
            Assert.AreEqual(null, (new AVLTree<string>()).GetMin());
        }

        [Test]
        public void SuccessorAndPredecessorTest()
        {
            tree.AddRange(new Node<int>[] { item });
            var suc = tree.Successor();

            var pred = tree.Predecessor();
            Assert.AreEqual(tree.GetMin(tree.root.Right), suc);
            Assert.AreEqual(tree.GetMax(tree.root.Left), pred);
        }

        [Test]
        public void RemoveTest()
        {
            var result1 = tree.Remove(item);//Delete with no child
            var result2 = tree.Remove(item1);//Delete with one child (Left)
            var result7 = tree.Remove(new Node<int>(59));//Delete with one child (Right)
            var result3 = tree.Remove(item3);//Delete with  two chid
            var result4 = tree.Remove(null);//Delete with null paramater
            var result5 = tree.Remove(new Node<int>(1000));//Doesn't have element
            var result6 = tree.Remove(15);
            var BsTree = new AVLTree<int>(new Node<int>(1));
            var result8 = BsTree.Remove(new Node<int>(1));//Delete root

            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotNull(result3);
            Assert.NotNull(result4);
            Assert.NotNull(result5);
            Assert.NotNull(result6);
            Assert.Null(result8);
            Assert.IsFalse(tree.Contains(new Node<int>(7)));
            Assert.IsFalse(tree.Contains(new Node<int>(4)));
            Assert.IsFalse(tree.Contains(new Node<int>(59)));
            Assert.IsFalse(tree.Contains(new Node<int>(71)));
            Assert.IsFalse(tree.Contains(new Node<int>(15)));
        }

        [Test]
        public void FindParentTest()
        {
            var result = tree.FindParent(new Node<int>(43));
            var result1 = tree.FindParent(null);
            var result2 = tree.FindParent(new Node<int>(10000));
            Assert.AreEqual(item4.Data, result.Item1.Data);
            Assert.AreEqual(-1, result.Item2);
            Assert.IsNull(result1);
            Assert.IsNull(result2);
        }

        [Test]
        public void FindNodeTest()
        {
            Node<int> result = tree.FindNode(item);
            Node<int> result1 = tree.FindNode(null);
            Node<int> result2 = tree.FindNode(new Node<int>(10000));
            Assert.IsTrue(new Node<int>(7).CompareTo(result) == 0);
            Assert.IsNull(result1);
            Assert.IsNull(result2);

        }

        [Test]
        public void TraversalTest()
        {
            tree.LNR();
            tree.LRN();
            tree.RLN();
        }

    }
}
