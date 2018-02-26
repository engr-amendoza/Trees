using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mdza.cs.graphs.trees
{
    public class RBT : BST
    {
        public override void Insert(int data)
        {
            if (Node.IsNull(Root))
            {
                Root = new Node(data);
                EnsureRootProperty();
                return;
            }

            Node newNode = new Node(data, Node.Color.RED);
            Insert(newNode, Root);
            FixViolations(newNode);
        }

        private void FixViolations(Node node)
        {
            TreeHelper helper = new TreeHelper(node, Root);
            Node uncle = helper.Uncle;
            Node parent = helper.Parent;
            Node grandparent = helper.GrandParent;

            if (Node.IsNull(grandparent))
                return;

            if (Node.IsNull(uncle) || IsBlack(uncle))
                EnsureBlackProperty(grandparent, parent, uncle, node);
            else
                EnsureRedProperty(grandparent, parent, uncle);
        }

        private void EnsureBlackProperty(Node grandparent, Node parent, Node uncle, Node node)
        {
            if (IsRightTriangle(grandparent, parent, uncle, node))
            {
                RotateRight(node, parent);
                FixViolations(node);
            }
            else if (IsLeftTriangle(grandparent, parent, uncle, node))
            {
                RotateLeft(node, parent);
                FixViolations(node);
            }
            else if (IsRightLine(grandparent, parent, uncle, node))
            {
                RotateLeft(node, parent);
                FixViolations(node);
                InvertColor(parent);
                InvertColor(grandparent);

                EnsureRootProperty();
                InvertChildren(parent);
            }
            else if (IsLeftLine(grandparent, parent, uncle, node))
            {
                RotateRight(node, parent);
                FixViolations(node);
                InvertColor(parent);
                InvertColor(grandparent);

                EnsureRootProperty();
                InvertChildren(parent);
            }
        }

        private void InvertColor(Node node)
        {
            node._Color = (IsBlack(node)) ? Node.Color.RED : Node.Color.BLACK;
        }

        private void EnsureRootProperty()
        {
            Root._Color = Node.Color.BLACK;
        }

        private void EnsureRedProperty(Node grandparent, Node parent, Node uncle)
        {
            grandparent._Color = Node.Color.RED;
            parent._Color = Node.Color.BLACK;
            uncle._Color = Node.Color.BLACK;

            EnsureRootProperty();
        }

        private void InvertChildren(Node parent)
        {
            Node.Color color = (IsBlack(parent)) ? Node.Color.RED : Node.Color.BLACK;
            parent.Left._Color = color;
            parent.Right._Color = color;
        }

        private bool IsLeftTriangle(Node grandparent, Node parent, Node uncle, Node child)
        {
            Node _uncle = grandparent.Right;
            Node _parent = grandparent.Left;
            Node _child = parent.Right;
            return (_uncle == uncle && _parent == parent && _child == child) ? true : false;
        }

        private bool IsRightTriangle(Node grandparent, Node parent, Node uncle, Node child)
        {
            Node _uncle = grandparent.Left;
            Node _parent = grandparent.Right;
            Node _child = parent.Left;
            return (_uncle == uncle && _parent == parent && _child == child) ? true : false;
        }

        private bool IsLeftLine(Node grandparent, Node parent, Node uncle, Node child)
        {
            Node _uncle = grandparent.Right;
            Node _parent = grandparent.Left;
            Node _child = parent.Left;
            return (_uncle == uncle && _parent == parent && _child == child) ? true : false;
        }

        private bool IsRightLine(Node grandparent, Node parent, Node uncle, Node child)
        {
            Node _uncle = grandparent.Left;
            Node _parent = grandparent.Right;
            Node _child = parent.Right;
            return (_uncle == uncle && _parent == parent && _child == child) ? true : false;
        }

        private bool IsBlack(Node node)
        {
            return (node._Color == Node.Color.BLACK) ? true : false;
        }

        private void RotateRight(Node source, Node destination)
        {
            Node destinatonParent = new TreeHelper(destination, Root).Parent;

            if(!Node.IsNull(destinatonParent))
            {
                if (destinatonParent.Left == destination)
                    destinatonParent.Left = source;
                else
                    destinatonParent.Right = source;
            }

            if (Root == destination)
                Root = source;

            destination.Left = source.Right;
            source.Right = destination;

        }

        private void RotateLeft(Node source, Node destination)
        {
            Node destinatonParent = new TreeHelper(destination, Root).Parent;

            if (!Node.IsNull(destinatonParent))
            {
                if (!Node.IsNull(destinatonParent) && destinatonParent.Left == destination)
                    destinatonParent.Left = source;
                else
                    destinatonParent.Right = source;
            }

            if (Root == destination)
                Root = source;

            destination.Right = source.Left;
            source.Left = destination;
        }

        protected override void Print(Node node)
        {
            Console.Write(node.Data + "" + node._Color);
        }
    }
}
