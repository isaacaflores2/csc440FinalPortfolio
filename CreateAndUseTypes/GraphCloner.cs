using System;
using System.Collections.Generic;
using System.Text;

namespace CreateAndUseTypes
{
    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node() { }
        public Node(int _val, IList<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }

    }
   
    class GraphCloner
    {
        //P17: Clone Graph
        //Source: https://leetcode.com

        
        public Node CloneGraph(Node node)
        {
            var clones = new Dictionary<int, Node>();
            var clone = Clone(node, clones);
            
            return clone;
        }

        private Node Clone(Node node, Dictionary<int, Node> clones)
        {
            var clone = new Node();
            clone.val = node.val;
            clone.neighbors = new List<Node>();

            if (!clones.TryAdd(clone.val, clone))
                return clone;

            foreach(var neighbor in node.neighbors)
            {
                Node clonedNeighbor;

                if(clones.TryGetValue(neighbor.val, out clonedNeighbor))
                {
                    clone.neighbors.Add(clonedNeighbor);
                }
                else
                {
                    clonedNeighbor = Clone(neighbor, clones);
                    clone.neighbors.Add(clonedNeighbor);                    
                }
            }

            return clone;
        }
    }
}
