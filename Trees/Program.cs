using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mdza.cs.graphs.trees;
namespace mdza.cs.graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = { 6, 3, 2, 10, 9, 4, 5 };
            //BST_Tester(data);
            RBT_Tester(data);
            Console.Read();
        }

        public static void BST_Tester(int [] data)
        {
            BST tree = new BST();

            tree.Insert(data);

            //tree.InOrderPrint();
            //tree.PreOrderPrint();
            //tree.PostOrderPrint();

            Node root = tree.Root;
            new TreeHelper(new Node(10), root);
            new TreeHelper(new Node(9), root);
            new TreeHelper(new Node(6), root);
            new TreeHelper(new Node(5), root);
            ;
            /*
            tree.Delete(5);
            tree.InOrderPrint();

            tree.Delete(10);
            tree.InOrderPrint();

            tree.Delete(3);
            tree.InOrderPrint();
            */
        }

        public static void RBT_Tester(int[] data)
        {
            BST tree = new RBT();

            tree.Insert(data);

            //tree.InOrderPrint();
            //tree.PreOrderPrint();
            //tree.PostOrderPrint();

            tree.Delete(5);
            tree.InOrderPrint();

            tree.Delete(10);
            tree.InOrderPrint();

            tree.Delete(3);
            tree.InOrderPrint();
        }
    }
}
