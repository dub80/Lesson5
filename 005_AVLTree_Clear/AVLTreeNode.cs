using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005_AVLTree_Clear
{
    // Класс AVLTreeNode реализует один узел АВЛ дерева 

    public class AVLTreeNode<TNode> : IComparable<TNode> where TNode : IComparable
    {
        
        AVLTreeNode<TNode> _left;   // левый  потомок
        AVLTreeNode<TNode> _right;  // правый потомок

        // значение текущего узла 

        public TNode Value
        {
            get;
            private set;
        }


        // конструктор
        public AVLTreeNode (TNode value, AVLTreeNode<TNode> parent)
        {
            Value = value;
            Parent = parent;
        }


        // Свойства 
        public AVLTreeNode<TNode> Left
        {
            get
            {
                return _left;
            }

            internal set
            {
                _left = value;

                if (_left != null)
                {
                    _left.Parent = this;  // установка указателя на родительский элемент
                }
            }
        }

        public AVLTreeNode<TNode> Right
        {
            get
            {
                return _right;
            }

            internal set
            {
                _right = value;

                if (_right != null)
                {
                    _right.Parent = this; // установка указателя на родительский элемент
                }
            }
        }

        // Указатель на родительский узел

        public AVLTreeNode<TNode> Parent
        {
            get;
            internal set;
        }

        

        // Возвращет 1, если значение экземпляра больше переданного значения,  
        // возвращает -1, когда значение экземпляра меньше переданого значения, 0 - когда они равны.     

        public int CompareTo (TNode other)
        {
            return Value.CompareTo(other);
        }

    }
}
