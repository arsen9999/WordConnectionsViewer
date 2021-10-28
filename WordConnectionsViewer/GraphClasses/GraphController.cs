using WordConnectionsViewer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using WordConnectionsViewer.GraphClasses.EdgeClases;
using WordConnectionsViewer.GraphClasses.NodeClases;
using WordConnectionsViewer.GraphClasses.JsonReader;

namespace WordConnectionsViewer.GraphClasses
{
    public static class GraphController
    {
        #region Ініціалізація
        public static Graph InitializeGraph(string name, PictureBox pictureBox, Color nodeColor, Color textColor, Font font, float nodeSize, int nodeSizeDiff, Color[] EdgeColors, int dpi)
        {
            var graph = new Graph(StringController.GraphNameChecking(name));
            BasicGraphInitialization(graph, pictureBox);
            SetDPI(graph, dpi);
            SetEdgeStyle(graph, EdgeColors);
            SetNodeStyle(graph, nodeColor, textColor, font, nodeSize, nodeSizeDiff);
            return graph;
        }
        public static Graph InitializeGraph(string name, PictureBox pictureBox, NodeStyle node, EdgesStyle edge, int dpi)
        {
            var graph = new Graph(StringController.GraphNameChecking(name));
            BasicGraphInitialization(graph, pictureBox);
            SetDPI(graph, dpi);
            SetEdgeStyle(graph, edge);
            SetNodeStyle(graph, node);
            return graph;
        }
        
        private static void BasicGraphInitialization(Graph graph, PictureBox pictureBox)
        {
            graph.localPic = pictureBox;
            graph.graphics = pictureBox.CreateGraphics();
            if (graph.localImage == null)
            {
                Bitmap bmp = new Bitmap(graph.localPic.Width, graph.localPic.Width);
                bmp.SetResolution(graph.graphStyle.dpi, graph.graphStyle.dpi);
                Graphics gr = Graphics.FromImage(bmp);
                gr.Clear(graph.localPic.BackColor);
            }
            graph.graphSize = new SizeF(pictureBox.Width - 25, pictureBox.Height - 25);
            graph.graphCenter = new PointF(0 + (pictureBox.Width / 2), 0 + (pictureBox.Height / 2));
            graph.MinX = (graph.graphCenter.X - pictureBox.Width / 2) + 25;
            graph.MaxX = (graph.graphCenter.X + pictureBox.Width / 2) - 25;
            graph.MinY = (graph.graphCenter.Y - pictureBox.Height / 2) + 25;
            graph.MaxY = (graph.graphCenter.Y + pictureBox.Height / 2) - 25;
        }
        public static string LoadDefaultFile(Graph graph, string file)
        {
            if (!String.IsNullOrWhiteSpace(file))
            {
                try
                {
                    LoadNewGraphFromJsonFile(graph, file);
                }
                catch (Exception ex) { return ex.Message; }
            }
            return null;
        }
        public static void LoadJsonFile(Graph graph, string path)
        {
            GraphController.LoadNewGraphFromJsonFile(graph, path);
        }
        #endregion
        public static void SaveGraphImage(PictureBox pbox, string graphFilePath)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            var name = StringController.GetFileNameFromPath(graphFilePath);
            sfd.FileName = $"{name}_" + DateTime.Now.ToString().Replace(':', '-');
            sfd.DefaultExt = "jpg";
            sfd.Filter = "Image files (*.jpg)|*.jpg|All files(*.*) | *.* ";
            if (sfd.ShowDialog() == DialogResult.OK)
                pbox.Image.Save(sfd.FileName);
        }
        public static void SaveGraphJsonFile(Graph graph, string graphJsonFileName)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            var name = graphJsonFileName;
            sfd.FileName = $"{name}_" + DateTime.Now.ToString().Replace(':', '-');
            sfd.DefaultExt = "json";
            sfd.Filter = "Json files (*.json)|*.json";
            if (sfd.ShowDialog() == DialogResult.OK)
                JsonCreator.CreateJsonFromGraph(graph,sfd.FileName);
        }
        static void SetEdgeStyle(Graph graph, Color[] colors)
        {
            graph.graphStyle.edgeStyle = new EdgesStyle(colors);
        }
        public static void MouseDoubleClickAction(Graph graph,int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    graph.selectedNode.visible = false;
                    break;
                case 1:
                    foreach (var edge in graph.selectedNode.edges)
                    {
                        //можна вибирати gr або graphicPanel,
                        //якщо gr то не буде мигати, але і відображатися буде після того як мишка перестане рухатися,
                        //якщо graphicPanel, то буде плавно малюватися поки рухається мишка, але в той же час буде мигати
                        edge.nodeFrom.visible = false;
                        edge.nodeTo.visible = false;
                    }
                    graph.selectedNode.visible = false;
                    break;
                case 2:
                    foreach (var node in graph.nodes) { node.visible = false; }
                    foreach (var edge in graph.selectedNode.edges)
                    {
                        edge.nodeFrom.visible = true;
                        edge.nodeTo.visible = true;
                    }
                    graph.selectedNode.visible = true;
                    break;
            }
        }
        static void SetEdgeStyle(Graph graph, EdgesStyle edgestyle)
        {
            graph.graphStyle.edgeStyle = edgestyle;
        }
        static void SetNodeStyle(Graph graph, Color textColor, Color backColor, Font textFont, float nodeSize, int nodeSizeDiff)
        {
            graph.graphStyle.nodeStyle = new NodeStyle(textColor, backColor, textFont, nodeSize, nodeSizeDiff);
        }
        public static void SetNodeStyle(Graph graph, NodeStyle nodestyle)
        {
            graph.graphStyle.nodeStyle = nodestyle;
            RecalculateNodesSizeByWeight(graph);
        }
        public static void AddNode(Graph graph, Node node)
        {
            graph.nodes.Add(node);
        }
        public static void AddNode(Graph graph, string nodeName)
        {
            Random rnd = new Random();

            var randomLocation = new PointF(rnd.Next((int)graph.MinX, (int)graph.MaxX), rnd.Next((int)graph.MinY, (int)graph.MaxY));

            graph.nodes.Add(new Node(nodeName, randomLocation, graph.graphStyle.nodeStyle.NodeSize.Width, 0, 0));
        }
        public static void AddEdge(Graph graph, Edge edge)
        {
            if (edge.nodeFrom == edge.nodeTo) { return; }
            foreach (var node in graph.nodes)
            {
                foreach (var edg in node.edges)
                {
                    if ((edg.nodeTo == edge.nodeFrom) && (edge.nodeTo == edg.nodeFrom))
                    {
                        return;
                    }
                }
            }
            if (edge.nodeFrom != null && edge.nodeTo != null)
            {
                edge.nodeFrom.weight += edge.weight; edge.nodeFrom.edges.Add(edge); edge.nodeFrom.AddWeight(graph, edge.weight);
                edge.nodeTo.weight += edge.weight; edge.nodeTo.edges.Add(edge); edge.nodeTo.AddWeight(graph, edge.weight);
            }
            graph.edges.Add(edge);
        }
        public static void RecalculateNodesSizeByWeight(Graph graph)
        {
            foreach (var node in graph.nodes)
            {
                if (node.weight > 0)
                {
                    node.NodeSize = graph.graphStyle.nodeStyle.NodeSize + ((node.weight * graph.graphStyle.nodeStyle.NodeSize) / graph.graphStyle.nodeStyle.NodeSizeDifference);
                }
                if (node.weight == 0) { node.NodeSize = graph.graphStyle.nodeStyle.NodeSize; }
            }
        }
        public static void AddNodeToGraph(Graph graph, Point nodePosition)
        {
            graph.nodes.Add(new Node($"NewNode{graph.nodes.Count}", nodePosition, graph.graphStyle.nodeStyle.NodeSize.Width, 0, 0));
        }
        public static void ShowAllNodes(Graph graph)
        {
            foreach (var node in graph.nodes)
            {
                node.visible = true;
            }
            GraphController.DrawFullGraph(graph);
        }
        public static void SetDPI(Graph graph, int value)
        {
            graph.graphStyle.dpi = value;
        }
        public static void RemoveSelectedNodeFromGraph(Graph graph)
        {
            RemoveNodeWithEdgesFromGraph(graph, graph.selectedNode);
        }
        public static void RemoveNodeWithEdgesFromGraph(Graph graph, Node node)
        {
            foreach (var edge in node.edges)
            {
                if (edge.nodeTo == node)
                {
                    edge.nodeFrom.edges.Remove(edge);
                }
                else if (edge.nodeFrom == node)
                {
                    edge.nodeTo.edges.Remove(edge);
                }
            }
            //node.edges.Clear();
            foreach (var nodeEdge in node.edges) { graph.edges.Remove(nodeEdge); }
            graph.nodes.Remove(node);
        }
        public static void DrawEdge(Graph graph, Edge edge)
        {
            graph.graphics.DrawLine(graph.graphStyle.edgeStyle.GetPenByWeight(edge.weight), edge.nodeFrom.Location, edge.nodeTo.Location);
        }
        public static void EditNode(Graph graph, Node node, string text)
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                node.Text = text;
                DrawFullGraph(graph);
            }
        }
        public static void DrawEdge(Graph graph, Edge edge, Graphics graphics)
        {
            graphics.DrawLine(graph.graphStyle.edgeStyle.GetPenByWeight(edge.weight), edge.nodeFrom.Location, edge.nodeTo.Location);
        }
        public static void DrawNode(Graph graph, Node node, Graphics graphics)
        {
            try
            {
                var pen = graph.graphStyle.nodeStyle.GetPen();
                pen.Width = node.NodeSize.Width;
                var location = ConvertToDrawCenter(node.Location, node.NodeSize);
                graphics.DrawEllipse(pen, location.X, location.Y, node.NodeSize.Width, node.NodeSize.Height);
                graphics.DrawString(node.Text/*+$"\n(X:{node.Location.X}; Y:{node.Location.Y})"*/, graph.graphStyle.nodeStyle.GetFont(), graph.graphStyle.nodeStyle.GetBrush(), node.Location, graph.graphStyle.nodeStyle.stringParam);
            }
            catch { }
        }
        public static void DrawNode(Graph graph, Node node)
        {
            try
            {
                var pen = graph.graphStyle.nodeStyle.GetPen();
                pen.Width = node.NodeSize.Width;
                var location = ConvertToDrawCenter(node.Location, node.NodeSize);
                graph.graphics.DrawEllipse(pen, location.X, location.Y, node.NodeSize.Width, node.NodeSize.Height);
                graph.graphics.DrawString(node.Text, graph.graphStyle.nodeStyle.GetFont(), graph.graphStyle.nodeStyle.GetBrush(), node.Location, graph.graphStyle.nodeStyle.stringParam);
            }
            catch { }
        }
        public static bool SelectNodeByMousePos(Graph graph, Point MousePos)
        {
            graph.selectedNode = SearchNode(graph, MousePos);
            StartMoveMode(graph);
            if (graph.selectedNode != null) { return true; }
            return false;
        }
        public static void SetGraphCenterPosition(Graph graph, PointF pos)
        {
            graph.graphCenter = pos;
            DrawFullGraph(graph);
        }
        public static void GetSelectedNodeConnections(Graph graph, ListBox lv)
        {
            lv.Items.Clear();
            if (graph.selectedNode == null) { return; }
            ((GroupBox)lv.Parent).Text = $"({graph.selectedNode.weight / 2}) {graph.selectedNode.Text}";
            foreach (var edge in graph.selectedNode.edges)
            {
                if (edge.nodeFrom == graph.selectedNode)
                {
                    lv.Items.Add($"[{edge.weight}] {edge.nodeTo.Text}");
                }
                else { lv.Items.Add($"[{edge.weight}] {edge.nodeFrom.Text}"); }
            }
        }
        public static void MoveNode(Graph graph, Point mousePos)
        {
            if (graph.MoveNodeMode)
            {
                graph.selectedNode.SetLocation(mousePos);
                DrawSelectedNodeWithStaticBackground(graph);
            }
        }
        public static void GetDataFromJsonToGraph(Graph graph, string path)
        {
            try
            {
                JsonFileDataModel JsonData = FileReader.ParseFile(path);
                if (JsonData.NodesList.Count == 0) { throw new ArgumentException($"The program cannot read this file:\n\"{path}\""); }
                int nodesCount = graph.nodes.Count;
                graph.nodes.AddRange(JsonData.NodesList);
                //graph.edges.Clear();
                foreach (var edge in JsonData.EdgesList)
                {
                    /////////-граф---------вага-------------звідки-------------куди
                    AddEdge(graph, new Edge(edge[2], graph.nodes[nodesCount+edge[0]], graph.nodes[nodesCount + edge[1]]));
                }
                
            }
            catch (Exception ee) { MessageBox.Show(ee.Message);  }
        }
        public static void LoadNewGraphFromJsonFile(Graph graph, string filePath)
        {
            try
            {
                GetDataFromJsonToGraph(graph, filePath);
                ViewType.BuildRandomPoints(graph);
                RecalculateNodesSizeByWeight(graph);
                DrawFullGraph(graph);
            }catch(Exception ex) { MessageBox.Show($"Error!\n{ex.Message}"); }
        }
        public static void RemoveGraph(Graph graph)
        {
            graph.nodes.Clear();
            graph.edges.Clear();
            DrawFullGraph(graph);
        }
        public static void StartMoveMode(Graph graph)
        {
            if (graph.selectedNode != null)
            {
                graph.MoveNodeMode = true;
                DrawGraphWithoutSelectedNodes(graph, graph.localPic);
            }
        }
        public static void StopMoveMode(Graph graph)
        {
            graph.MoveNodeMode = false;
            DrawFullGraph(graph);
        }
        public static void MoveGraphToNewLocation(Graph graph, PointF lastMousePos, PointF newMousePos)
        {
            float x = (lastMousePos.X - newMousePos.X) * (-1);
            float y = (lastMousePos.Y - newMousePos.Y) * (-1);
            foreach (var node in graph.nodes)
            {
                node.Location.X += x;
                node.Location.Y += y;
            }
            DrawFullGraph(graph);
        }
        public static void DrawFullGraph(Graph graph)
        {
            var panel = graph.localPic;
            //graph.edges.Sort((x, y) => x.weight.CompareTo(y.weight));
            Bitmap bm = new Bitmap(panel.Width, panel.Height);
            bm.SetResolution(graph.graphStyle.dpi, graph.graphStyle.dpi);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                if (graph.edges.Count > 0)
                {
                    foreach (var edge in graph.edges)
                    {
                        if (edge.nodeFrom.visible && edge.nodeTo.visible)
                            DrawEdge(graph, edge, gr);
                    }
                }
                if (graph.nodes.Count > 0)
                {
                    foreach (var node in graph.nodes)
                    {
                        if (node.visible)
                            DrawNode(graph, node, gr);
                    }
                }
            }
            panel.Image = bm;

        }
        private static Node SearchNode(Graph graph, Point mPos)
        {
            var MousePos = graph.localPic.PointToClient(mPos);
            foreach (var node in graph.nodes)
            {
                if (node.visible)
                {
                    var halfSize = node.NodeSize.Width / 2;
                    var maxX = MousePos.X + halfSize;
                    var minX = MousePos.X - halfSize;
                    if ((node.Location.X < maxX) && (node.Location.X > minX))
                    {
                        var maxY = MousePos.Y + halfSize;
                        var minY = MousePos.Y - halfSize;
                        if ((node.Location.Y < maxY) && (node.Location.Y > minY))
                        {
                            return node;
                        }
                    }
                }
            }
            return null;
        }
        public static void DrawSelectedNodeWithStaticBackground(Graph graph)
        {
            //var graphicPanel = graph.localPic.CreateGraphics();
            graph.localPic.Refresh();
            graph.edges.Sort((x, y) => x.weight.CompareTo(y.weight));
            Bitmap bm = new Bitmap(graph.localImage);//graph.localPic.Width, graph.localPic.Width);
            bm.SetResolution(graph.graphStyle.dpi, graph.graphStyle.dpi);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                foreach (var edge in graph.selectedNode.edges)
                {
                    //можна вибирати gr або graphicPanel,
                    //якщо gr то не буде мигати, але і відображатися буде після того як мишка перестане рухатися,
                    //якщо graphicPanel, то буде плавно малюватися поки рухається мишка, але в той же час буде мигати
                    if (edge.nodeFrom.visible && edge.nodeTo.visible)
                    {
                        DrawEdge(graph, edge, gr);
                        DrawNode(graph, edge.nodeFrom, gr);
                        DrawNode(graph, edge.nodeTo, gr);
                    }
                }
                DrawNode(graph, graph.selectedNode, gr);
            }
            graph.localPic.Image = bm;
            //DrawNode(graph, graph.selectedNode);

        }
        public static void DrawGraphWithoutSelectedNodes(Graph graph, PictureBox panel)
        {
            Bitmap bm = new Bitmap(panel.Width, panel.Height);
            bm.SetResolution(graph.graphStyle.dpi, graph.graphStyle.dpi);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                if (graph.edges.Count > 0)
                {
                    foreach (var edge in graph.edges)
                    {
                        if (graph.selectedNode.edges.IndexOf(edge) == -1)
                        {
                            if (edge.nodeFrom.visible && edge.nodeTo.visible)
                                DrawEdge(graph, edge, gr);
                        }
                    }
                }
                if (graph.nodes.Count > 0)
                {
                    foreach (var node in graph.nodes)
                    {
                        if (node != graph.selectedNode)
                        {
                            if (node.visible)
                                DrawNode(graph, node, gr);
                        }
                    }
                }
            }
            panel.Image = bm;
            graph.localImage = bm;
        }
        private static PointF ConvertToDrawCenter(PointF nodeCenter, SizeF size)
        {
            var drawCenter = nodeCenter;
            drawCenter.X -= size.Width / 2;
            drawCenter.Y -= size.Width / 2;
            return drawCenter;
        }
        public static void ChangeGraphSize(Graph graph, PictureBox pictureBox)
        {
            graph.graphSize = new SizeF(pictureBox.Width - 25, pictureBox.Height - 25);
            graph.graphCenter = new PointF(0 + (pictureBox.Width / 2), 0 + (pictureBox.Height / 2));
            graph.MinX = (graph.graphCenter.X - pictureBox.Width / 2) + 25;
            graph.MaxX = (graph.graphCenter.X + pictureBox.Width / 2) - 25;
            graph.MinY = (graph.graphCenter.Y - pictureBox.Height / 2) + 25;
            graph.MaxY = (graph.graphCenter.Y + pictureBox.Height / 2) - 25;
        }
    }
}
