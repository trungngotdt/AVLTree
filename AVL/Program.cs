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
            aVLTree.root = new Node<int>(15);
            aVLTree.Puta(4);
            aVLTree.Puta(5);
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
