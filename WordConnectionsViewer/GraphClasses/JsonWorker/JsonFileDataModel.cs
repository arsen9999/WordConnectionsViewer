using System;
using System.Collections.Generic;
using System.Text;
using WordConnectionsViewer.GraphClasses;

namespace WordConnectionsViewer
{
    public class JsonFileDataModel
    {
        public List<Node> NodesList = new List<Node>();
        public List<int[]> EdgesList = new List<int[]>();
    }
}
