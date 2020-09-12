using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_AVLTree_Balance
{
    class Program
    {
        static void Main (string[] args)
        {
            AVLTree<int> Oak = new AVLTree<int>();
                          //                             10                              10                                             
            Oak.Add(10);  //                            /   \                           /   \
            Oak.Add(3);   //                           /     \                         /     \
            Oak.Add(2);   //                          3      12      ====>            3       15
            Oak.Add(4);   //                         / \       \                     / \      / \
            Oak.Add(12);  //                        2   4      15                  2   4    12  25
            Oak.Add(15);  //                                  /   \                           \
            Oak.Add(11);  //                                14     25                          14
            Oak.Add(25);  //
            Oak.Add(14);  //

            Oak.Remove(11);

            foreach (var item in Oak)
            {
                Console.WriteLine(item);
            }

        }
    }
}
