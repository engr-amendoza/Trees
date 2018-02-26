using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mdza.cs.graphs.trees
{
    public class TreeHelper
    {
        public TreeHelper(Node node, Node root)
        {
            Assign(null, null, null);
            Run(node, root);
        }

        public Node Uncle
        {
            private set;
            get;
        }

        public Node Parent
        {
            private set;
            get;
        }

        public Node GrandParent
        {
            private set;
            get;
        }

        private void Assign(Node grandParent, Node parent, Node uncle)
        {
            this.GrandParent = grandParent;
            this.Parent = parent;
            this.Uncle = uncle;
        }

        private void Run(int data, Node root)
        {
            if (Node.IsNull(root) || root.Data.Equals(data))
                return;

            if (data <= root.Data)
            {
                if (Node.IsNull(Parent))
                {
                    Parent = root;
                    Run(data, root.Left);
                }
                else
                {
                    GrandParent = Parent;
                    Parent = root;
                    Uncle =  (Parent.Data <= GrandParent.Data) ? GrandParent.Right : GrandParent.Left;
                    Run(data, root.Left);
                }
            }

            else if (data > root.Data)
            {
                if (Node.IsNull(Parent))
                {
                    Parent = root;
                    Run(data, root.Right);
                }
                else
                {
                    GrandParent = Parent;
                    Parent = root;
                    Uncle = (Parent.Data <= GrandParent.Data) ? GrandParent.Right : GrandParent.Left;
                    Run(data, root.Right);
                }
            }
        }

        private void Run(Node target, Node root)
        {
            int data = target.Data;
            Run(data, root);
        }


        // second attempt
        /*
        private void Run(Node target, Node root)
        {
            Node grandparent = null;
            Node parent = null;
            Node uncle = null;
            Node child = root;

            int data = target.Data;

            while (true)
            {
                // not found
                if (Node.IsNull(child))
                {
                    grandparent = null;
                    parent = null;
                    uncle = null;
                    break;
                }

                // assign parent & uncle
                if (data <= child.Data)
                {
                    if (!Node.IsNull(parent) && data <= parent.Data)
                    {
                        grandparent = null;
                    }
                    else if (!Node.IsNull(parent) && data > parent.Data))
                    {
                        grandparent = null;
                    }


                }
                else
                {
                    grandparent = parent;
                    uncle = (Node.IsNull(grandparent)) ? null : grandparent.Left;
                    parent = child;
                    child = child.Right;
                }

                if (data.Equals(child.Data))
                    break;
            }

            Assign(grandparent, parent, uncle);
        }
        */
        /*
        private void Run(Node target, Node root)
        {
            Node grandparent = root;
            Node parent = grandparent;
            Node uncle = null;
            Node child = null;

            int data = target.Data;
            bool found = false;

            while (!found)
            {
                // assign parent & uncle
                if (data <= grandparent.Data)
                {
                    parent = grandparent.Left;
                    uncle = grandparent.Right;
                }

                else
                {
                    parent = grandparent.Right;
                    uncle = grandparent.Left;
                }

                // assign child
                if (!Node.IsNull(parent) && data <= parent.Data)
                    child = parent.Left;
                else
                    child = parent.Left;

                // check if value found
                if (Node.IsNull(child) || data.Equals(child.Data))
                    found = true;
                else
                {
                    grandparent = parent;
                }
            }

            Assign(grandparent, parent, uncle);
        }
        */
        /*
        private void Run(Node Target, Node Root)
        {
            Node grandparent = Root;
            Node parent = grandparent;
            Node uncle = null;
            Node child = null;

            int data = Target.Data;
            bool found = false;

            while (!found)
            {
                if (data <= grandparent.Data)
                {
                    parent = grandparent.Left;
                    child = parent.Left;

                    if (Node.IsNull(child))
                    {
                        Assign(grandparent, parent, uncle);
                        return;// null;
                    }

                    if (child.Data.Equals(data))
                    {
                        uncle = grandparent.Right;
                        Assign(grandparent, parent, uncle);
                        found = true;
                    }

                    child = parent.Right;

                    if (Node.IsNull(child))
                    {
                        Assign(grandparent, parent, uncle);
                        return;// null;
                    }

                    if (child.Data.Equals(data))
                    {
                        uncle = grandparent.Left;
                        Assign(grandparent, parent, uncle);
                        found = true;
                    }
                }

                else
                {
                    parent = grandparent.Right;
                    child = parent.Left;

                    if (child.Data.Equals(data))
                    {
                        uncle = grandparent.Right;
                        Assign(grandparent, parent, uncle);
                        found = true;
                    }

                    child = parent.Right;
                    if (child.Data.Equals(data))
                    {
                        uncle = grandparent.Left;
                        Assign(grandparent, parent, uncle);
                        found = true;
                    }
                }

                grandparent = parent;
            }

            return;// uncle;
        }*/
    }
}
