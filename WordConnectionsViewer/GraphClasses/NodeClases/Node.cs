using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using WordConnectionsViewer.GraphClasses.NodeClases;

namespace WordConnectionsViewer.GraphClasses
{
    public class Node
    {
        public int weight = 0;
        public int edgesCount;
        public string Text = "";
        public PointF Location;
        public SizeF NodeSize;
        public bool visible = true;
        public List<Edge> edges = new List<Edge>();
        public Node(string text,PointF location,float nodeSize,int Weight,int EdgesCount)
        {
            weight = Weight;
            edgesCount = EdgesCount;
            Text = text;
            Location = location;
            NodeSize = new SizeF(nodeSize,nodeSize);
        }
        public Node(Node node)
        {
            weight = node.weight;
            edgesCount = node.edgesCount;
            Text = node.Text;
            Location = node.Location;
            NodeSize = node.NodeSize;
        }
        public void SetLocation(float posX,float posY)
        {
            Location = new PointF(posX, posY);
        }
        public void SetLocation(PointF pointF)
        {
            Location = pointF;
        }
        public void AddWeight(Graph graph,int wght)
        {
            if (wght > 0)
            {
                weight += wght;
                if (weight > 1)
                {
                    NodeSize = graph.graphStyle.nodeStyle.NodeSize + ((weight * graph.graphStyle.nodeStyle.NodeSize)/ graph.graphStyle.nodeStyle.NodeSizeDifference);
                }
            }
            else if (wght == 0) { NodeSize = graph.graphStyle.nodeStyle.NodeSize; }
        }
        public void SetWeight(Graph graph, int wght)
        {
            if (wght > 0)
            {
                weight = wght;
                NodeSize = graph.graphStyle.nodeStyle.NodeSize + ((weight * graph.graphStyle.nodeStyle.NodeSize) / graph.graphStyle.nodeStyle.NodeSizeDifference);
            }
        }
    }
}
