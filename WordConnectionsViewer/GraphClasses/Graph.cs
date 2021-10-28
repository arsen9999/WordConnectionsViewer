using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WordConnectionsViewer.GraphClasses;
namespace WordConnectionsViewer.GraphClasses
{
    public class Graph
    {
        public List<Node> nodes = new List<Node>();
        public List<Edge> edges = new List<Edge>();
        public Node selectedNode;
        public string graphName = " ";
        public SizeF graphSize;
        public PointF graphCenter;
        public float MaxX = 0;
        public float MinX = 0;
        public float MaxY = 0;
        public float MinY = 0;
        public GraphStyle graphStyle = new GraphStyle();
        public PictureBox localPic;
        public Graphics graphics;
        public Image localImage;
        public bool IsADrawed = false;
        public bool MoveNodeMode = false;
        public bool MoveGraphMode = false;
        public Graph(string Name)
        {
            graphName = Name;
        }
    }
}
