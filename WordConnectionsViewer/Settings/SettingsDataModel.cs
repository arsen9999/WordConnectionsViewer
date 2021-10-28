using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace WordConnectionsViewer.Settings
{
    public class SettingsDataModel
    {
        public static readonly string NodeTagOpen = "<node_settings:"; 
        public static readonly string NodeTagClose = ":node_settings>";
        public static readonly string FilesTagOpen = "<files:";
        public static readonly string FilesTagClose = ":files>";
        public static readonly string EdgesTagOpen = "<edge_colors:";
        public static readonly string EdgesTagClose = ":edge_colors>";
        public static readonly string DefaultSettingsFolderName = "WordConnectionsViewer";
        public List<string> loadedFiles = new List<string>();
        public Color nodeColor;
        public Color nodeTextColor;
        public Font font;
        public Color[] edgeColors = new Color[4];
        public float nodeSize;
        public string profileName = "";

        public SettingsDataModel(string ProfileName, List<string> LoadedFiles,Color NodeColor, Color textColor,Font fnt,Color[] edgcolors,float nodesize)
        {
            profileName = ProfileName;//.Remove('');
            loadedFiles = LoadedFiles;
            nodeColor = NodeColor;
            nodeTextColor = textColor;
            font = fnt;
            edgeColors = edgcolors;
            nodeSize = nodesize;
        }
        public SettingsDataModel() { }
        public void SetAllSettingsFromList(List<string> file)
        {
            SetEdgeColors(file);
            SetLoadedFiles(file);
            SetMainSettings(file);
        }
        public Color GetColorFromString(string color)
        {
            var rgbaValues = color.Replace("(","").Replace(")", "").Split(',');
            return Color.FromArgb(Convert.ToInt32(rgbaValues[3]), Convert.ToInt32(rgbaValues[0]), Convert.ToInt32(rgbaValues[1]), Convert.ToInt32(rgbaValues[2]));
        }
        public void SetEdgeColors(string[] colors)
        {
            for(int i = 0; i<= 3; i++)
            {
                edgeColors[i] = GetColorFromString(colors[i]);
            }
        }
        public void SetEdgeColors(List<string> file)
        {
            int idFrom = file.IndexOf(EdgesTagOpen)+1;
            for (int i = 0; i <= 3; i++)
            {
                edgeColors[i] = GetColorFromString(file[i + idFrom]);
            }
        }
        public void SetLoadedFiles(List<string> file)
        {
            int idFrom = file.IndexOf(SettingsDataModel.FilesTagOpen)+1;
            int idTo = file.IndexOf(SettingsDataModel.FilesTagClose);
            for (int i = idFrom; i <= idTo; i++)
            {
                loadedFiles.Add(file[i]);
            }
        }
        public void SetMainSettings(List<string> file)
        {
            int idFrom = file.IndexOf(SettingsDataModel.NodeTagOpen)+1;
            nodeColor = GetColorFromString(file[0+idFrom]);
            nodeTextColor = GetColorFromString(file[1+idFrom]);
            var newFont = file[2 + idFrom].Split(';');
            var fSize = float.Parse(newFont[1]);
            var nSize = float.Parse(file[3 + idFrom]);
            font = new Font(newFont[0], fSize, ((FontStyle)Enum.Parse(typeof(FontStyle), newFont[2], true)));
            nodeSize = nSize;
        }
        public void SetLoadedFiles(string[] files)
        {
            foreach (var file in files)
            {
                loadedFiles.Add(file);
            }
        }
        public void SetMainSettings(string[] settings)
        {
            nodeColor = GetColorFromString(settings[0]);
            nodeTextColor = GetColorFromString(settings[1]);
            var newFont = settings[2].Split(';');
            var fSize = float.Parse(newFont[1]);
            var nSize = float.Parse(settings[3]);
            font = new Font(newFont[0], fSize, ((FontStyle)Enum.Parse(typeof(FontStyle), newFont[2], true)));
            nodeSize = nSize;
        }
        public string GetSettingsLikeText()
        {
            object settings = this;
            return settings.ToString();
        }
        public string[] GetLoadedFiles()
        {
            return loadedFiles.ToArray();
        }
        public string[] GetEdgeColors()
        {
            return new string[] { GetRGBAOfColor(edgeColors[0]), GetRGBAOfColor(edgeColors[1]), GetRGBAOfColor(edgeColors[2]), GetRGBAOfColor(edgeColors[3]), };
        }
        string GetRGBAOfColor(Color color)
        {
            return $"({color.R},{color.G},{color.B},{color.A})";
        }
        public string GetNodeColor()
        {
            return GetRGBAOfColor(nodeColor);
        }
        public string GetNodeTextColor()
        {
            return GetRGBAOfColor(nodeTextColor);
        }
        public string GetNodeSize()
        {
            return nodeSize.ToString();
        }
        public string[] GetFont()
        {
            return new string[] { font.Name, font.Size.ToString(), font.Style.ToString()};
        }

    }
}
