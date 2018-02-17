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
            aVLTree.Insert(1);
            aVLTree.Insert(new Node<int>(12));
            aVLTree.AddRange(new int[]{5,4,1,3,10,2,30,20,60,25,15,18,13 });
            
            int debug0 = 1;
            Console.ReadLine();
        }
    }
}
