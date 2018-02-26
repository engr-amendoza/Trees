using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mdza.cs.graphs.trees
{
    public class BST
    {
        public void Insert(int[] Data)
        {
            foreach(var data in Data)
            {
                Insert(data);
            }
        }
        public virtual void Insert(int Data)
        {
            if (Node.IsNull(Root))
            {
                Root = new Node(Data);
                return;
            }

            Insert(new Node(Data), Root);
        }

        protected void Insert(Node newNode, Node parent)
        {
            Node current = parent;
            int data = newNode.Data;

            if (!Node.IsNull(current))
            {
                if (data <= current.Data)
                {
                    if (Node.IsNull(current.Left))
                    {
                        current.Left = newNode;
                        return;
                    }
                    current = current.Left;
                }
                else
                {
                    if (Node.IsNull(current.Right))
                    {
                        current.Right = newNode;
                        return;
                    }
                    current = current.Right;
                }
                Insert(newNode, current);
            }
        }

        public bool Search(int Data)
        {
            return Node.IsNull(Search(Data, Root)) ? false : true;
        }

        public bool Delete(int Data)
        {
            return Delete(Data, Root);
        }
        
        public bool Delete(int data, Node parent)
        {
            Node _parent = parent;
            Node current = parent;

            // find node and track parent node
            while (!current.Data.Equals(data) && !Node.IsNull(current))
            {
                _parent = current;

                if (data <= _parent.Data)
                    current = _parent.Left;
                else
                    current = _parent.Right;  
            }

            // delete cases
            if (!Node.IsNull(current))
            {                 
                if (!HasChildren(current))
                {
                    if (!Node.IsNull(parent.Left) && parent.Left.Data.Equals(data))
                        _parent.Left = null;
                    else
                        _parent.Right = null;
                }
                else if (!HasLeft(current))
                {
                    current.Data = current.Right.Data;
                    current.Right = null;
                }
                else if (!HasRight(current))
                {
                    current.Data = current.Left.Data;
                    current.Left = null;
                }
                else
                {
                    Node successor = InOrderSuccessor(current);
                    int temp = successor.Data;
                    Delete(temp, current);
                    current.Data = temp;
                }
                return true;
            }
            

            return false;
        }
          
        private Node InOrderSuccessor(Node Node)
        {
            if (!HasChildren(Node) || Node.IsNull(Node.Right))
            {
                throw new Exception("Not implemented yet!");
            }
            else
            {
                Node current = Node.Right;
                while (current.Left != null)
                {
                    current = current.Left;
                }
                return current;
            }  
        }

        private Node Search(int Data, Node Node)
        {
            if (Node.Data.Equals(Data))
                return Node;
            else if (Node.IsNull(Node))
                return null;
            else if (Data <= Node.Data)
                return Search(Data, Node.Left);
            else
                return Search(Data, Node.Right);
        }

        #region Print

        public void InOrderPrint()
        {
            InOrder(Root);
            Console.WriteLine();
        }

        private void InOrder(Node node)
        {
            if (Node.IsNull(node))
                return;
            InOrder(node.Left);
            Print(node);
            InOrder(node.Right);
        }

        public void PreOrderPrint()
        {
            PreOrder(Root);
            Console.WriteLine();
        }

        private void PreOrder(Node node)
        {
            if (Node.IsNull(node))
                return;
            Print(node);
            PreOrder(node.Left);
            PreOrder(node.Right);
        }

        public void PostOrderPrint()
        {
            PostOrder(Root);
            Console.WriteLine();
        }

        private void PostOrder(Node node)
        {
            if (Node.IsNull(node))
                return;
            PostOrder(node.Left);
            PostOrder(node.Right);
            Print(node);
        }
 #endregion Print

        protected virtual void Print(Node node)
        {
            Console.Write(node.Data + " ");
        }

        private bool HasChildren(Node node)
        {
            return (HasLeft(node) || HasRight(node));
        }

        private bool HasLeft(Node node) { return !Node.IsNull(node.Left); }
        private bool HasRight(Node node) { return !Node.IsNull(node.Right); }


        public Node Root { protected set; get; }
    }
}
