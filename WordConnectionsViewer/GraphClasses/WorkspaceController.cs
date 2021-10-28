using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WordConnectionsViewer.GraphClasses
{
    public static class WorkspaceController
    {
        private static List<Graph> graphList = new List<Graph>();
        public static int GetCount() { return graphList.Count; }
        public static string[] GetGraphsArray()
        {
            string[] graphArr = new string[graphList.Count];
            for (int i =0; i<graphList.Count;i++)
            {
                graphArr[i] = graphList[i].graphName;
            }
            return graphArr;
        }
        public static Graph GetGraphByNameFromList(string GraphName)
        {
            foreach(var graph in graphList)
            {
                if(graph.graphName == GraphName) { return graph; }
            }
            return null;
        }
        public static Graph ChangeSelectedGraph(ComboBox cbox)
        {
            foreach (var graph in graphList)
            {
                if (graph.graphName == cbox.Text) { return graph; }
            }
            return null;
        }
        public static void AddNewGraphToList(ComboBox cbox,Graph graph)
        {
            graphList.Add(graph);
            cbox.Items.Add(graphList[graphList.Count - 1].graphName);
            cbox.SelectedIndex = cbox.Items.Count - 1;
        }
        public static void AddNewGraphToList(ComboBox cbox, string name, PictureBox pictureBox, Color nodeColor, Color textColor, Font font, float nodeSize, int nodeSizeDiff, Color[] EdgeColors, int dpi)
        {
            graphList.Add(GraphController.InitializeGraph(name,pictureBox,nodeColor,textColor,font,nodeSize,nodeSizeDiff,EdgeColors,dpi));
            cbox.Items.Add(graphList[graphList.Count - 1]);
        }
        public static void RemoveGraphFromList(Graph graph)
        {
            graphList.Remove(graph);
        }
    }
}
