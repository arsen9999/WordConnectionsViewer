using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WordConnectionsViewer.GraphClasses.NodeClases
{
    public static class NodeMenuController
    {
        static int edgeWeight = 1;
        static Node nodeFrom;
        public static void ShowMenu(ContextMenuStrip menu, object sender, Point location, Graph graph)
        {
            bool nodeSelected=false;
            if (graph.selectedNode != null) { nodeSelected = true; menu.Items[0].Text = graph.selectedNode.Text; }
            menu.Items[0].Visible = nodeSelected;
            menu.Items[1].Visible = !nodeSelected;
            menu.Items[2].Visible = nodeSelected;
            menu.Items[3].Visible = nodeSelected;
            menu.Show(((PictureBox)sender).PointToScreen(location));
        }
        public static void SetEdgeFrom(Node node)
        {
            if (node != null)
            {
                nodeFrom = node;
            }
        }
        public static void SetEdgeTo(Graph graph, Node node)
        {
            if (nodeFrom != null && node != null)
            {
                bool noConnectionsBefore = true;
                Edge edgeBefore = new Edge(1,node,node);
                foreach(var edge in node.edges) { 
                    if ((edge.nodeFrom == node && edge.nodeTo == nodeFrom)
                        ||(edge.nodeFrom == nodeFrom && edge.nodeTo == node)) {
                        edgeBefore = edge; noConnectionsBefore = false; } }
                if (noConnectionsBefore) { GraphController.AddEdge(graph, new Edge(edgeWeight, nodeFrom, node)); }
                else { edgeBefore.weight = edgeWeight; }
            }
        }
        public static void SetEdgeWeight(int weight)
        {
            if (weight > 0 && weight <= 4)
            {
                edgeWeight = weight;
            }
        }
    }
}
