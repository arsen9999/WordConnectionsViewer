using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WordConnectionsViewer;
using WordConnectionsViewer.GraphClasses;

namespace WordConnectionsViewer
{
    public static class FileReader
    {
        public static JsonFileDataModel ParseFile(string filePath)
        {
            var file = File.ReadAllLines(filePath);
            var FileData = new JsonFileDataModel();
            bool nodes = true;
            for (int i = 0; i<file.Length-1;i++)
            {
                if (file[i].Length > 1)//zabraty
                {
                    if (nodes)
                    {            
                        
                        if(file[i].IndexOf("\"links\":") != -1) { 
                            nodes = false; }
                        if (file[i].IndexOf("\"name\":") != -1)
                        {
                            var nodeName = file[i].Substring(21, file[i].Length - 22);
                            //var randomLocation = new PointF(rnd.Next((int)graph.MinX, (int)graph.MaxX), rnd.Next((int)graph.MinY, (int)graph.MaxY));
                            FileData.NodesList.Add(new Node(nodeName, new PointF(0f,0f), 1, 0, 0));
                            //i = i + 2;
                        }
                    }
                    else
                    {
                        if (file[i].IndexOf("\"source\":") != -1)
                        {
                            int source = Convert.ToInt32(file[i].Substring(22, file[i].Length - 23));
                            int destination = Convert.ToInt32(file[i+1].Substring(22, file[i+1].Length - 23));
                            int value = Convert.ToInt32(file[i+2].Substring(21, file[i+2].Length - 21));
                            FileData.EdgesList.Add(new []{ source, destination, value});
                            if(i + 5 < file.Length) { i += 4; }
                        }
                    }

                }
            }
            return FileData;
        }
        public static bool CheckFilereadability(string filePath)
        {
            if (ParseFile(filePath).NodesList.Count != 0) { return true; } else { return false; }
        }

        public static string[] OpenFile()
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Json files (*.json)|*.json",
                Multiselect = true,
                RestoreDirectory = true

            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileNames.Length > 0) { return ofd.FileNames; }
            }
            return null;
         }
       
    }
}
