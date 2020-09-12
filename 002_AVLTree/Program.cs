using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_AVLTree
{
    class Program
    {
        static void Main (string[] args)
        {
            AVLTree<int> Oak = new AVLTree<int>();

                          //                             10                                                             
            Oak.Add(10);  //                            /   \                
            Oak.Add(3);   //                           /     \               
            Oak.Add(2);   //                          3      12     
            Oak.Add(4);   //                         / \     / \         
            Oak.Add(12);  //                        2   4  11   15             
            Oak.Add(15);  //                                                    
            Oak.Add(11);  //                                       

            foreach (var item in Oak)
            {
                Console.WriteLine(item);
            }
        }
    }
}
