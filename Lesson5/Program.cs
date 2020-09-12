using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    class Program
    {
        static void Main (string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add(10);//                     10
            tree.Add(5);//                     /  \
            tree.Add(124);//                  5    124
            tree.Add(3);//                  /  \    
            tree.Add(4);//                 3   null 
            tree.Add(1);//                / \
            tree.Add(2);//               1   4
            //                          / \
            //                       null  2


            tree.Remove(124);
            tree.Remove(3);
        }
    }
}
