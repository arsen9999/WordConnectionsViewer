using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using WordConnectionsViewer.GraphClasses.EdgeClases;
using WordConnectionsViewer.GraphClasses.NodeClases;

namespace WordConnectionsViewer.GraphClasses
{
    public static class FileLoader
    {
        public static void LoadFilePathToComboBox(ComboBox cbox)
        {
            try
            {
                LoadToComboBox(cbox, FileReader.OpenFile());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public static void DragDropFile(Graph graph, ComboBox cb_graphList, DragEventArgs e, PictureBox pb_graphicPanel, NodeStyle nodesStyle, EdgesStyle edgesStyle, int dpi)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            try
            {
                Graph tempGraph = null;
                var result = MessageBox.Show($"Add nodes from selected {files.Length} files to current graph \"{graph.graphName}\"?\n Click No to create new Graph to every file", "Confirm the action!",
                                            MessageBoxButtons.YesNoCancel,
                                            MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    tempGraph = graph;
                }
                foreach (var fileToLoad in files)
                {
                    if (!FileReader.CheckFilereadability(fileToLoad)) { MessageBox.Show($"The program cannot read this file:\n\"{fileToLoad}\" "); }
                    else
                    {
                        if (result == DialogResult.No)
                        {
                            var graphName = StringController.GetFileNameFromPath(fileToLoad);
                            WorkspaceController.AddNewGraphToList(cb_graphList, GraphController.InitializeGraph(graphName, pb_graphicPanel, nodesStyle, edgesStyle, dpi));
                            tempGraph = WorkspaceController.GetGraphByNameFromList(graphName);
                        }
                    }
                    GraphController.LoadJsonFile(tempGraph, fileToLoad);
                }
                //SettingsController.LoadFilePathToComboBox(cb_jsonPathList, files);
                GraphController.DrawFullGraph(tempGraph);
            }
            catch (Exception ex) { MessageBox.Show($"Помилка!\n{ex.Message}"); }
        }
        static void LoadToComboBox(ComboBox cbox, string[] newItems)
        {
            var filtredFiles = RepetedFileFilter(cbox, newItems);
            if (filtredFiles == null) { return; }
            if (filtredFiles.Length == 0)
            {
                MessageBox.Show("Помилка!\nДанний файл вже завантажено в програму");
                return;
            }
            if (filtredFiles.Length > 1)
            {
                cbox.Items.Clear();
                foreach (var item in filtredFiles)
                {
                    if (item.Contains(".json"))
                    {
                        if (!FileReader.CheckFilereadability(item)) { MessageBox.Show($"The program cannot read this file:\n\"{item}\" "); }
                        else
                        {
                            cbox.Items.Add(item);
                        }
                    }
                }
                cbox.SelectedIndex = 0;
            }
            else if (filtredFiles.Length == 1)
            {
                if (!FileReader.CheckFilereadability(filtredFiles[0])) { MessageBox.Show($"The program cannot read this file:\n\"{filtredFiles[0]}\" "); }
                else
                {
                    cbox.Items.Add(filtredFiles[0]);
                    cbox.SelectedItem = filtredFiles[0];
                }
            }
        }
        public static void LoadFilePathToComboBox(ComboBox cbox, string[] newItems)
        {
            LoadToComboBox(cbox, newItems);
        }
        public static string[] RepetedFileFilter(ComboBox cb, string[] files)
        {
            var filtredFiles = new List<string>();
            if (files == null) { return null; }
            foreach (var file in files)
            {
                if (file.Contains(".json"))
                {
                    if (cb.Items.Count == 0) { filtredFiles.Add(file); }
                    else
                    {
                        foreach (var oldfile in cb.Items)
                        {
                            if (oldfile.ToString() != file) { filtredFiles.Add(file); }
                        }
                    }
                }
            }
            return filtredFiles.ToArray();
        }
        public static void DragOverFileChecking(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                bool isAJSON = false;
                foreach (var file in files)
                {
                    if (file.Contains(".json")) isAJSON = true;
                }
                if (isAJSON) { e.Effect = DragDropEffects.Copy; }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
