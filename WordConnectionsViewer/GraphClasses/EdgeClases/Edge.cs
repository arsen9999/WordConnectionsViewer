using System;
using System.Collections.Generic;
using System.Text;

namespace WordConnectionsViewer.GraphClasses
{
    public class Edge
    {
        public int weight;
        //public int index;
        public Node nodeFrom;
        public Node nodeTo;
        public Edge(int Weight,Node From, Node To)
        {
            weight = Weight;
            nodeFrom = From;
            nodeTo = To;
        }
        public Edge(Edge edge)
        {
            weight = edge.weight;
            nodeFrom = edge.nodeFrom;
            nodeTo = edge.nodeTo;
        }
    }
}
