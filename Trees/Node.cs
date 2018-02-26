using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mdza.cs.graphs
{
    public class Node
    {
        public Node(int Data, Color Color)
        {
            this.Data = Data;
            this._Color = Color;
        }

        public Node(int Data)
        {
            this.Data = Data;
            this._Color = Node.Color.UNKNOWN;
        }

        public Node Left
        {
            get;
            set;
        }

        public Node Right
        {
            get;
            set;
        }

        public int Data
        {
            get;
            set;
        }

        public Color _Color
        {
            get;
            set;
        }

        public enum Color {RED, BLACK, UNKNOWN};

        public static bool IsNull(Node node)
        {
            return node == null;
        }
    }
}
