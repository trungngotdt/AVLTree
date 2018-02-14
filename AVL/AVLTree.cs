using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL
{
    public class AVLTree<T> : IComparable
        where T : IComparable
    {
        public Node<T> root;


        /// <summary>
        /// Adds the elements of the specified collection to the AVL
        /// </summary>
        /// <param name="node"></param>
        public void AddRange(Node<T>[] node)
        {
            foreach (var item in node)
            {
                Insert(item.Data);
            }
        }



        /// <summary>
        /// Adds the elements of the specified collection to the AVL
        /// </summary>
        /// <param name="node"></param>
        public void AddRange(T[] data)
        {
            foreach (var item in data)
            {
                Insert(item);
            }
        }
        /// <summary>
        /// Find inorder predecessor of a node
        /// </summary>
        /// <returns></returns>
        public object Predecessor()
        {
            return GetMax(root.Left);
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Find inorder successor of a node
        /// </summary>
        /// <returns></returns>
        public object Successor()
        {
            return GetMin(root.Right);
            //throw new NotImplementedException();
        }


        /// <summary>
        /// Find height of node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int Height(Node<T> node)
        {
            if (node == null) return -1;
            var leftH = Height(node.Left);
            var rightH = Height(node.Right);
            return Math.Max(leftH, rightH) + 1;
        }

        /// <summary>
        /// Find height of node root
        /// </summary>
        /// <returns></returns>
        public int Height()
        {
            return Height(root);
        }


        /// <summary>
        ///Return a minimum value in AVL
        /// </summary>
        /// <returns></returns>
        public Node<T> GetMin(Node<T> node)
        {
            var temp = node;
            if (node.Left == null)
            {
                return node;
            }
            while (true)
            {
                if (temp.Left == null)
                {
                    return temp;
                }
                else if (temp.Left != null)
                {
                    temp = temp.Left;
                }
            }
        }

        /// <summary>
        /// Return a maximum value in AVL
        /// </summary>
        /// <returns></returns>
        public T GetMax(Node<T> node)
        {
            var temp = node;
            if (node.Right == null)
            {
                return node.Data;
            }
            while (true)
            {
                if (temp.Right == null)
                {
                    return temp.Data;
                }
                else if (temp.Right != null)
                {
                    temp = temp.Right;
                }
            }
        }


        /// <summary>
        ///Return a minimum value in AVL tree
        /// </summary>
        /// <returns></returns>
        public Node<T> GetMin()
        {
            var temp = root;
            if (root.Left == null)
            {
                return root;
            }
            while (true)
            {
                if (temp.Left == null)
                {
                    return temp;
                }
                else if (temp.Left != null)
                {
                    temp = temp.Left;
                }
            }
        }


        /// <summary>
        /// Determines whether an element is in the AVL
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool Contains(Node<T> node)
        {
            Node<T> temp = root;
            if (node == null)
            {
                return false;
            }
            while (temp != null)
            {
                if (temp.CompareTo(node) == 0)
                {
                    return true;
                }
                if (temp > node)
                {
                    temp = temp.Left;
                }
                else
                {
                    temp = temp.Right;
                }
            }
            return false;
        }

        /// <summary>
        /// Searches for the element that matches the conditions defined by the specified
        /// </summary>
        /// <param name="node"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public Node<T> FindNode(Node<T> node, T data)
        {

            Node<T> temp = root;
            if (node == null)
            {
                return null;
            }
            while (temp != null)
            {
                if (temp.CompareTo(node) == 0)
                {
                    return temp;
                }
                if (temp > node)
                {
                    temp = temp.Left;
                }
                else
                {
                    temp = temp.Right;
                }
            }
            return null;

        }

        /// <summary>
        /// Searches for an parent of element that matches the conditions defined by the specified
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Tuple<Node<T>, int> FindParent(Node<T> node)
        {
            int check = 0;
            if (node == null)
            {
                return null;
            }
            Node<T> temp = root;
            Node<T> parent = null;
            while (temp != null)
            {
                if (temp.CompareTo(node) == 0)
                {
                    return new Tuple<Node<T>, int>(parent, check);// temp;
                }
                if (temp > node)
                {
                    parent = temp;
                    check = -1;
                    temp = temp.Left;
                }
                else
                {
                    parent = temp;
                    check = 1;
                    temp = temp.Right;

                }
            }
            return null;
        }

        /// <summary>
        /// Return a maximum value in AVL tree
        /// </summary>
        /// <returns></returns>
        public T GetMax()
        {
            var temp = root;
            if (root.Right == null)
            {
                return root.Data;
            }
            while (true)
            {
                if (temp.Right == null)
                {
                    return temp.Data;
                }
                else if (temp.Right != null)
                {
                    temp = temp.Right;
                }
            }
        }

        public void Insert(T key)
        {
            root = new Node<T>(Insert(root, key));
        }

        private Node<T> Insert(Node<T> x, T key)
        {
            if (x == null)
                return new Node<T>(key, 0);
            int cmp = key.CompareTo(x.Data);
            if (cmp < 0)
                x.Left = Insert(x.Left, key);
            else if (cmp > 0)
                x.Right = Insert(x.Right, key);
            else
                x.Data = key;
            x = Balance(x);
            /*x.size = 1 + size(x.left) + size(x.right);*/
            x.HeightNode = Height(x);
            return x;
        }

        private Node<T> DeleteMin(Node<T> x)
        {
            if (x.Left == null)
                return x.Right;
            x.Left = DeleteMin(x.Left);
            //x.size = size(x.left) + size(x.right) + 1;
            x.HeightNode = 1 + Math.Max(Height(x.Left), Height(x.Right));
            return x;
        }

        public Node<T> DeleteMin()
        {
            return DeleteMin(root);
        }


        public Node<T> Delete(T key)
        {
            var x = Delete(root, key);
            return x;
        }


        private Node<T> Delete(Node<T> x, T key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.Data);
            if (cmp < 0)
                x.Left = Delete(x.Left, key);
            else if (cmp > 0)
                x.Right = Delete(x.Right, key);
            else
            {
                if (x.Right == null)
                    return x.Left;
                if (x.Left == null)
                    return x.Right;
                Node<T> t = x;
                x = GetMin(t.Right);
                x.Right = DeleteMin(t.Right);
                x.Left = t.Left;
            }
            x = Balance(x);
            //x.size = size(x.left) + size(x.right) + 1;
            return x;
        }

        /// <summary>
        /// Keep tree's balance
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private Node<T> Balance(Node<T> x)
        {
            if (CheckBalance(x) < -1)
            {
                if (CheckBalance(x.Right) > 0)
                {
                    x.Right = RotateRight(x.Right);
                }
                x = RotateLeft(x);
            }
            else if (CheckBalance(x) > 1)
            {
                if (CheckBalance(x.Left) < 0)
                {
                    x.Left = RotateLeft(x.Left);
                }
                x = RotateRight(x);

            }
            return x;
        }
        private int CheckBalance(Node<T> x)
        {
            return Height(x.Left) - Height(x.Right);
        }

        private Node<T> RotateLeft(Node<T> x)
        {
            Node<T> y = x.Right;
            Node<T> T2 = y.Left;

            // Perform rotation
            y.Left = x;
            x.Right = T2;

            /*Node<T> y = x.right;
            x.right = y.left;
            y.left = x;*/
            //y.size = x.size;
            //x.size = 1 + size(x.left) + size(x.right);
            y.HeightNode = 1 + Math.Max(Height(y.Left), Height(y.Right));
            y.HeightNode = 1 + Math.Max(Height(y.Left), Height(y.Right));
            return y;
        }

        private Node<T> RotateRight(Node<T> y)
        {
            Node<T> x = y.Left;
            Node<T> T2 = x.Right;

            // Perform rotation
            x.Right = y;
            y.Left = T2;
            /*Node<T> y = x.left;
            x.left = y.right;
            y.right = x;*/
            /*y.size = x.size;
            x.size = 1 + size(x.left) + size(x.right)
            ;*/
            x.HeightNode = 1 + Math.Max(Height(x.Left), Height(x.Right));
            x.HeightNode = 1 + Math.Max(Height(x.Left), Height(x.Right));

            return x;
        }


        public int CompareTo(object obj)
        {
            try
            {
                Node<T> node = obj as Node<T>;
                return root.Data.CompareTo(node.Data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
