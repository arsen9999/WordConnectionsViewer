using System;
using System.Collections.Generic;
using System.Text;

namespace WordConnectionsViewer.GraphClasses
{
    public static class StringController
    {
        public static string GetFileNameFromPath(string filePath)
        {
            try
            {
                var fileName = filePath.Substring(filePath.LastIndexOf('\\') + 1).Replace(".json", "");
                return fileName;
            }
            catch { return filePath; }
        }
        public static string GraphNameChecking(string name)
        {
            if (String.IsNullOrWhiteSpace(name)) { name = "Default"; }
            if (!CheckUniqGraphName(name, WorkspaceController.GetGraphsArray())) { name += WorkspaceController.GetCount(); }
            return name;
        }
        public static bool CheckUniqGraphName(string Name, string[] namesArray)
        {
            foreach (var name in namesArray)
            {
                if (name == Name) { return false; }
            }
            return true;
        }
    }
}
