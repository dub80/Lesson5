using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private BinaryTreeNode<T> _head;

        private int _count;
        public int Count { get { return _count; } }

        #region REMOVE

        public bool Remove (T value)
        {
            BinaryTreeNode<T> current;
            BinaryTreeNode<T> parent;

            // Поиск узла для удаления

            current = FindWithParent(value, out parent);

            if (current == null)
            {
                return false;
            }

            _count--;

            // Первый вариант: удаляемый узел не имеет правого потомка.     

            if (current.Right == null)
            {

                // Удаляем корень
                if (parent == null)
                {
                    _head = current.Left;
                }

                else
                {
                    int result = parent.CompareTo(current.Value);

                    if (result > 0)
                    {
                        // Если значение узла родителя больше чем значение удаляемого узла -                 
                        // сделать левого потомка текущего узла - левым потомком родительского узла.                 

                        parent.Left = current.Left;
                    }

                    else if (result < 0)
                    {

                        // Если значение родительского узла меньше чем значение удаляемого узла -                  
                        // сделать левого потомка текущего узла - правым потомком родительского узла.                 

                        parent.Right = current.Left;

                    }
                }
            }

            // Второй вариант: удаляемый узел имеет правого потомка, у которого нет левого потомка.

            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                // Удаляем корень 
                if (parent == null)
                {
                    _head = current.Right;
                }

                else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        // Если значение родительского узла больше чем значение удаляемого узла -                  
                        // сделать правого потомка текущего узла - левым потомком родительского узла. 

                        parent.Left = current.Right;
                    }
                    else if (result < 0)
                    {
                        // Если значение родительского узла меньше чем значение удаляемого узла -                  
                        // сделать правого потомка текущего узла - правым потомком родительского узла. 

                        parent.Right = current.Right;

                    }
                }
            }
            // Третий вариант: удаляемый узел имеет правого потомка, у которого есть левый потомок.

            else
            {

                BinaryTreeNode<T> leftmost = current.Right.Left;
                BinaryTreeNode<T> leftmostParent = current.Right;

                // поиск крайнего левого потомка 
                while (leftmost.Left != null)
                {
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }

                // Правое поддерево крайнего левого узла, становится левым поддеревом его родительского узла.         
                leftmostParent.Left = leftmost.Right;

                // Присваиваем крайнему левому узлу в качестве левого потомка - левый потомок удаляемого узла,
                // а в качестве правого потомка - правый потомок удаляемого узла. 

                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                if (parent == null)
                {
                    _head = leftmost;
                }

                else
                {
                    int result = parent.CompareTo(current.Value);

                    if (result > 0)
                    {

                        // Если значение родительского узла(parent), больше значения удаляемого узла (current) -                  
                        // сделать левого крайнего потомка удаляемого узла(leftmost)  - левым потомком его родителя(parent). 

                        parent.Left = leftmost;
                    }

                    else if (result < 0)
                    {

                        // Если значение родительского узла(parent), меньше значения удаляемого узла (current) -                  
                        // сделать левого крайнего потомка удаляемого узла(leftmost) - правым потомком его родителя(parent).

                        parent.Right = leftmost;
                    }
                }
            }

            return true;
        }


        #endregion

        #region Удаление дерева

        public void Clear ()
        {
            _head = null;
            _count = 0;
        }

        #endregion

        #region Add
        public void Add (T value)
        {
            // Первый случай: дерево пустое     

            if (_head == null)
            {
                _head = new BinaryTreeNode<T>(value);
            }

            // Второй случай: дерево не пустое, поэтому применяем рекурсивный алгоритм 
            //                для поиска места добавления узла        

            else
            {
                AddTo(_head, value);
            }
            _count++;
        }

        // Рекурсивный алгоритм 

        private void AddTo (BinaryTreeNode<T> node, T value)
        {
            // Первый случай: значение добавляемого узла меньше чем значение текущего. 

            if (value.CompareTo(node.Value) < 0)
            {
                // если левый потомок отсутствует - добавляем его          

                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>(value);
                }
                else
                {
                    // повторная итерация               
                    AddTo(node.Left, value);
                }
            }
            // Второй случай: значение добавляемого узла равно или больше текущего значения      
            else
            {
                // Если правый потомок отсутствует - добавлем его.          

                if (node.Right == null)
                {
                    node.Right = new BinaryTreeNode<T>(value);
                }
                else
                {
                    // повторная итерация

                    AddTo(node.Right, value);
                }
            }
        }

        #endregion

        #region Search
        public bool Contains (T value)
        {

            BinaryTreeNode<T> parent;
            return FindWithParent(value, out parent) != null;
        }

        // Метод FindWithParent возвращает первый найденный узел.
        // Если значение не найдено, метод возвращает null.
        // Так же возвращает родительский узел для найденного значения.

        private BinaryTreeNode<T> FindWithParent (T value, out BinaryTreeNode<T> parent)
        {
            // Поиск значения в дереве.     

            BinaryTreeNode<T> current = _head;
            parent = null;

            while (current != null)
            {
                int result = current.CompareTo(value);
                if (result > 0)
                {
                    // Если искомое значение меньше значение текущего узла - переходим к левому потомку.             

                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    // Если искомое значение больше значение текущего узла - переходим к правому потомку.

                    parent = current;
                    current = current.Right;
                }
                else
                {
                    // Искомый элемент найден             
                    break;
                }
            }
            return current;
        }

        #endregion

        #region InOrder
        public void InOrderTraversal ()
        {
            InOrderTraversal(_head);
        }

        private void InOrderTraversal (BinaryTreeNode<T> node)
        {
            if (node.Left != null)
                InOrderTraversal(node.Left);

            Console.WriteLine(node.Value);

            if (node.Right != null)
                InOrderTraversal(node.Right);
        }

        #endregion

        #region PostOrder

        public void PostOrderTraversal ()
        {
            PostOrderTraversal(_head);
        }

        private void PostOrderTraversal (BinaryTreeNode<T> node)
        {
            if (node.Left != null)
                PostOrderTraversal(node.Left);

            if (node.Right != null)
                PostOrderTraversal(node.Right);

            Console.WriteLine(node.Value);
        }

        #endregion

        #region PreOrder

        public void PreOrderTraversal ()
        {
            PreOrderTraversal(_head);
        }

        private void PreOrderTraversal (BinaryTreeNode<T> node)
        {
            Console.WriteLine(node.Value);

            if (node.Left != null)
                PreOrderTraversal(node.Left);

            if (node.Right != null)
                PreOrderTraversal(node.Right);
        }

        #endregion

        #region Нумератор

        public IEnumerator<T> GetEnumerator ()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
