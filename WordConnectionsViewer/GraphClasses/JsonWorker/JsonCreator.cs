using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;



namespace WordConnectionsViewer.GraphClasses.JsonReader
{
    public static class JsonCreator
    {
        public static void CreateJsonFromGraph(Graph graph, string path)
        {
            StreamWriter MainWriter = new StreamWriter($"{path}");
            MainWriter.WriteLine("{"); //записываем в файл
            MainWriter.WriteLine("    \"nodes\": ["); //записываем в файл
            for (int i = 0; i < graph.nodes.Count; i++)
            {
                MainWriter.Write(AddNode(graph.nodes[i].Text));
                if (i + 1 < graph.nodes.Count) { MainWriter.Write("," + Environment.NewLine); }
            }
            MainWriter.WriteLine("    ],"+Environment.NewLine+"    \"links\": [");
            for (int i = 0; i < graph.edges.Count; i++)
            {
                MainWriter.Write(AddEdge(graph,graph.edges[i]));

                if (i + 1 < graph.edges.Count) { MainWriter.Write("," + Environment.NewLine); }
            }
            MainWriter.WriteLine("    ]"+Environment.NewLine+"}");
            MainWriter.Close();
        }
        private static string AddNode(string text)
        {
            return "        {"+Environment.NewLine+"            \"name\": \"" + text +"\""+Environment.NewLine+"        }";
        }
        private static string AddEdge(Graph graph, Edge edge)
        {
            var sourceID = graph.nodes.IndexOf(edge.nodeFrom);
            var targetID = graph.nodes.IndexOf(edge.nodeTo);
            var weight = edge.weight;
            return "        {"+Environment.NewLine+""+ "            \"source\": " + sourceID + "," + Environment.NewLine + "            \"target\": " +targetID+","+Environment.NewLine+"            \"value\": " + weight + Environment.NewLine + "        }";
        }

    }
}
