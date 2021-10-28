using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WordConnectionsViewer.GraphClasses
{
    public static class ViewType
    {
        public static void BuildSpiral(Graph graph,bool isACustom,float[] spiralParams)
        {
            var nodes = graph.nodes;
            nodes.Sort((y, x) => x.weight.CompareTo(y.weight));//посортувати ноди за вагою
            PointF lastPos = new PointF(graph.graphCenter.X, graph.graphCenter.Y);//перше значення = центр графу
            foreach(var nd in nodes)
            {
                nd.SetLocation(0, 0);
            }

            List<PointF> points = new List<PointF>();
            if (isACustom) { points = GetSpiralPoints(new PointF(spiralParams[0], spiralParams[1]), spiralParams[2], spiralParams[3], spiralParams[4]); }
            else { points = GetSpiralPoints(lastPos, nodes.Count, 5.0f, graph.graphSize.Height, nodes.Count); }
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].Location = points[i];
            }
        }
        private static void PolarToCartesian(float r, float theta, out float x, out float y)
        {
            x = (float)(r * Math.Cos(theta));
            y = (float)(r * Math.Sin(theta));
        }
        private static List<PointF> GetSpiralPoints(PointF center, float A,float angle_offset, float max_r,int count)
        {
            // Get the points.
            List<PointF> points = new List<PointF>();
            int i = 0;
            const float dtheta = (float)(15 * Math.PI / 360);    // Five degrees.
            float step = dtheta * 2; 
            for (float theta = 0; ; theta += dtheta+step)
            {
                // Calculate r.
                float r = A * theta;//(theta * (count/2 - i));

                // Convert to Cartesian coordinates.
                float x, y;
                PolarToCartesian(r, theta + angle_offset, out x, out y);
                if (i < 6) { step = step + dtheta; };
                if (i > 4) { step = dtheta / 2; };
                // Center.
                x += center.X;
                y += center.Y;

                // Create the point.
                /*if (CheckNodesColision(graph, new PointF(x, y), nods[i].NodeSize))
                {
                    PolarToCartesian(r, theta + angle_offset + (nods[i].NodeSize.Width/2), out x, out y);
                }*/
                //if (!CheckNodesColision(graph, new PointF(x, y),nods[i].NodeSize))
                //{
                    points.Add(new PointF((float)x, (float)y));
                    i++;
                //}

                // If we have gone far enough, stop.
                
                if (i >=count) break;
            }
            return points;
        }
        private static List<PointF> GetSpiralPoints(PointF center, float A, float angle_offset, float max_r)
        {
            // Get the points.
            List<PointF> points = new List<PointF>();
            const float dtheta = (float)(5 * Math.PI / 180);    // Five degrees.
            for (float theta = 0; ; theta += dtheta)
            {
                // Calculate r.
                float r = A * theta;

                // Convert to Cartesian coordinates.
                float x, y;
                PolarToCartesian(r, theta + angle_offset, out x, out y);

                // Center.
                x += center.X;
                y += center.Y;

                // Create the point.
                points.Add(new PointF((float)x, (float)y));

                // If we have gone far enough, stop.
                if (r > max_r) break;
            }
            return points;
        }
        public static void BuildSquare(Graph graph)
        {
            if (graph.nodes.Count <=0) { return; }
            graph.nodes.Sort((y, x) => x.weight.CompareTo(y.weight));//посортувати ноди за вагою
            int oneSideValue = graph.nodes.Count / 4;
            int currentSide = 1;
            var nodes = graph.nodes;
            float step = 20.0f;
            nodes[0].SetLocation(graph.MinX,graph.MaxY);
            List<Node> upSide = new List<Node>();
            List<Node> rightSide = new List<Node>();
            List<Node> downSide = new List<Node>();
            List<Node> leftSide = new List<Node>();

            for (int i=0;i<nodes.Count;i++)
            {
                if (currentSide == 1)
                {
                    upSide.Add(nodes[i]);
                    nodes[i].Location.Y = graph.MinY;
                }
                if (currentSide == 2)
                {
                    rightSide.Add(nodes[i]);
                    nodes[i].Location.X = graph.MaxX;
                }
                if (currentSide == 3)
                {
                    downSide.Add(nodes[i]);
                    nodes[i].Location.Y = graph.MaxY;
                }
                if (currentSide == 4)
                {
                    leftSide.Add(nodes[i]);
                    nodes[i].Location.X = graph.MinX;
                }
                currentSide++;
                if (currentSide > 4) { currentSide = 1; }
            }

            step = graph.graphSize.Width / (upSide.Count + 1);
            upSide[0].Location.X = graph.MinX+upSide[0].NodeSize.Height;
            for(int i=1;i<upSide.Count;i++)
            {
                upSide[i].Location.X = upSide[i - 1].Location.X + step;
            }

            downSide[0].Location.X = graph.MaxX - downSide[0].NodeSize.Height;
            step = graph.graphSize.Width / (downSide.Count+1);
            for (int i = 1; i < downSide.Count; i++)
            {
                downSide[i].Location.X = downSide[i - 1].Location.X - step;
            }

            step = graph.graphSize.Height / (rightSide.Count + 1);
            rightSide[0].Location.Y = graph.MinY + rightSide[0].NodeSize.Height;
            for (int i = 1; i < rightSide.Count; i++)
            {
                rightSide[i].Location.Y = rightSide[i - 1].Location.Y  + step;
            }

            leftSide[0].Location.Y = graph.MaxY - leftSide[0].NodeSize.Height;
            step = graph.graphSize.Height / (leftSide.Count + 1);
            for (int i = 1; i < leftSide.Count; i++)
            {
                leftSide[i].Location.Y = leftSide[i - 1].Location.Y  - step;
            }
        }
    }
}
