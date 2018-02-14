using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL
{
    class Program
    {
        static void Main(string[] args)
        {
            AVLTree<int> aVLTree = new AVLTree<int>();
            aVLTree.AddRange(new int[]{5,4,1,3,10,2,30,20,60,25,15,18,13 });
            int debug = 0;
            aVLTree.root = new Node<int>(15);
            aVLTree.Insert(4);
            aVLTree.Insert(5);
            aVLTree.Insert(3);
            aVLTree.Delete(15);
            AVLTree<int> tree = new AVLTree<int>();
            //tree.
            /*
            Node<int> node = new Node<int>(1);
            node.Puta(node,4);
            node.Puta(node, 5);
            node.Puta(node, 6);
            node.Puta(node, 7);
            node.Puta(node, 50);
            node.Puta(node, 23);
            node.Puta(node, 71);
*/
            int debug0 = 1;
            Console.ReadLine();
        }
    }
}
