using WordConnectionsViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordConnectionsViewer.GraphClasses;
using WordConnectionsViewer.GraphClasses.EdgeClases;
using WordConnectionsViewer.GraphClasses.NodeClases;
using WordConnectionsViewer.Settings;

namespace WordConnectionsViewer
{
    public partial class Form1 : Form
    {
        Graph graph;
        PointF mousePosBeforePanelClick = new PointF(0, 0);
        private string DefaultLoadedFile = " ";
        
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(string filePath)
        {
            InitializeComponent();
            DefaultLoadedFile = filePath;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Text = $"{typeof(Program).Assembly.GetName().Name}";//текст у вікні = назва проекту
            SettingsController.LoadParamsFromSettings(cb_fonts, cb_FontStyle, cb_profileName);//завантажити поточні налаштування 
            WorkspaceController.AddNewGraphToList(cb_graphList, GraphController.InitializeGraph(StringController.GetFileNameFromPath(DefaultLoadedFile), pb_MainGraphicPanel, GetNodeSettingsParams(), GetEdgeSettingsParams(), (int)nud_DPI.Value));
            ShowSettingsPanel(false);//приховати панель з налаштуваннями 
            InitializeSelectedIndexes();
            CheckDefaultFileLoad(DefaultLoadedFile);
        }
        private void InitializeSelectedIndexes()
        {
            cb_doubleClickAction.SelectedIndex = 0;
            tsCB_EdgeWeight.SelectedIndex = 0;
        }
        private void CheckDefaultFileLoad(string fileToLoad)
        {
            if (String.IsNullOrWhiteSpace(fileToLoad)) { return; }
            var exeption = GraphController.LoadDefaultFile(graph, fileToLoad);
            if (String.IsNullOrWhiteSpace(exeption)) { cb_jsonPathList.Items.Add(fileToLoad); cb_jsonPathList.SelectedIndex = 0; }
            else { MessageBox.Show(exeption); }
        }
        private void PictureBox_Colors_Click(object sender, EventArgs e)//виклик діалогу вибору кольорів, при натиску на відповідний pictureBox
        {
            var colorDialog = new ColorDialog();//створити діалог
            var pbox = ((PictureBox)sender);
            colorDialog.Color = pbox.BackColor;//вибрати поточний колір
            colorDialog.ShowDialog();//показати діалог
            pbox.BackColor = colorDialog.Color;//записати вибраний колір в вибраний pictureBox
        }
        private void ChangeStyleParams(object sender, EventArgs e)//завантажити поточні параметри згідно вибраних налаштувань
        {
            if (graph != null)//перевірка чи побудований граф
            {
                graph.graphStyle.edgeStyle = GetEdgeSettingsParams();//завантажити стиль для ребер
                GraphController.SetNodeStyle(graph, GetNodeSettingsParams());//завантажити стиль для вершин
                GraphController.DrawFullGraph(graph);//оновити відображення графа
            }
        }
        public NodeStyle GetNodeSettingsParams()//метод котрий повертає стиль вершини згідно поточних вказаних налаштувань
        {
            var nodeStyle = new NodeStyle(
                pb_nodeTextColor.BackColor,
                pb_nodeColor.BackColor,
                new Font(cb_fonts.Text,
                         (float)nud_FontSize.Value,
                         ((FontStyle)Enum.Parse(typeof(FontStyle), cb_FontStyle.Text, true))),
                        (float)nud_nodeSize.Value,
                        (int)nud_NodeSizeDifference.Value);
            return nodeStyle;
        }
        public EdgesStyle GetEdgeSettingsParams()//метод котрий повертає стиль ребра згідно поточних вказаних налаштувань
        {
            var edgeStyle = new EdgesStyle(new Color[] { pb_color1.BackColor, pb_color2.BackColor, pb_color3.BackColor, pb_color4.BackColor, });
            return edgeStyle;
        }
        private void Pb_MainGraphicPanel_MouseClick(object sender, MouseEventArgs e)//метод що шукає вершину згідно поточних координат миші
        {
            var nodeCatched = GraphController.SelectNodeByMousePos(graph, MousePosition);
            if (nodeCatched)//якщо знайдено ноду яка відповідає позиції миші, активується режим переміщення вершини
            {
                if (e.Button == MouseButtons.Left)
                {
                    graph.MoveNodeMode = true;
                    GraphController.GetSelectedNodeConnections(graph, lv_connections);
                    Cursor = Cursors.Hand;
                }

            }//в іншому випадку активується режим переміщення координат графа
            else
            {
                graph.MoveGraphMode = true;
                graph.selectedNode = null;
                mousePosBeforePanelClick = e.Location;
                Cursor = Cursors.SizeAll;

                //if (e.Button == MouseButtons.Left) { contextMenuStrip_GraphMenu.set contextMenuStrip_GraphMenu.Show(); }
            }
            if (e.Button == MouseButtons.Right) { NodeMenuController.ShowMenu(cms_NodeMenu, sender, e.Location, graph); }
        }
        private void MouseMoving(object sender, MouseEventArgs e)
        {
            if (graph.MoveNodeMode)
            {
                GraphController.MoveNode(graph, e.Location);
            }
        }
        private void MouseUped(object sender, MouseEventArgs e)
        {
            if (graph.MoveNodeMode)
            {
                GraphController.StopMoveMode(graph);
            }
            else if (graph.MoveGraphMode) { GraphController.MoveGraphToNewLocation(graph, mousePosBeforePanelClick, e.Location); }
            Cursor = Cursors.Arrow;
        }
        private void Button_Load_JSON_File_Click(object sender, EventArgs e)
        {
            FileLoader.LoadFilePathToComboBox(cb_jsonPathList);
        }
        private void File_DragDrop(object sender, DragEventArgs e)
        {
            FileLoader.DragDropFile(graph,cb_graphList,e,pb_MainGraphicPanel,GetNodeSettingsParams(),GetEdgeSettingsParams(),(int)nud_DPI.Value);
        }
        private void File_DragOver(object sender, DragEventArgs e)
        {
            FileLoader.DragOverFileChecking(e);
        }

        private void Button_SaveGraphToPNG(object sender, EventArgs e)
        {
            GraphController.SaveGraphImage(pb_MainGraphicPanel, cb_jsonPathList.Text);
        }
        private void Button_SaveProfile(object sender, EventArgs e)
        {
            var pathlist = new List<string>();
            foreach (var item in cb_jsonPathList.Items)
            {
                pathlist.Add(item.ToString());
            }
            SettingsController.CreateSettingsProfileInOneFile(cb_profileName.Text, pathlist, pb_nodeColor.BackColor, pb_nodeTextColor.BackColor, graph.graphStyle.nodeStyle.GetFont(), graph.graphStyle.edgeStyle.GetAllColors(), (float)nud_nodeSize.Value);
            SettingsController.LoadProfiles(cb_profileName);
        }
        private void ProfileChanged(object sender, EventArgs e)
        {
            LoadProfile(((ComboBox)sender).Text);
        }
        void LoadProfile(string profileName)
        {
            SettingsDataModel profile = SettingsController.ReadFileWithSettingsFromOneFile(profileName);
            if (profile == null) { return; }
            cb_fonts.Text = profile.font.Name;
            cb_FontStyle.Text = profile.font.Style.ToString();
            nud_FontSize.Value = (decimal)profile.font.Size;
            nud_nodeSize.Value = (decimal)profile.nodeSize;
            cb_jsonPathList.Items.Clear();
            cb_jsonPathList.Items.AddRange(profile.loadedFiles.ToArray());
            pb_nodeColor.BackColor = profile.nodeColor;
            pb_nodeTextColor.BackColor = profile.nodeTextColor;
            pb_color1.BackColor = profile.edgeColors[0];
            pb_color2.BackColor = profile.edgeColors[1];
            pb_color3.BackColor = profile.edgeColors[2];
            pb_color4.BackColor = profile.edgeColors[3];
            if (graph != null)
            {
                try { GraphController.DrawFullGraph(graph); } catch { }
            }
        }
        private void ProfileName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadProfile(((ComboBox)sender).Text);
            }
        }
        private void Cb_viewType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (graph != null)
            {
                try
                {
                    switch (((ComboBox)sender).SelectedIndex)
                    {
                        case 0:
                            ViewType.BuildRandomPoints(graph);
                            GraphController.DrawFullGraph(graph);
                            break;

                        case 1:
                            ViewType.BuildSpiral(graph, new float[4] { (float)nud_float_a.Value, (float)nud_float_angle_offset.Value, (float)nud_pi.Value, (float)nud_pi_mtp.Value });
                            GraphController.DrawFullGraph(graph);
                            break;

                        case 2:
                            ViewType.BuildSquare(graph);
                            GraphController.DrawFullGraph(graph);
                            break;

                        default: break;
                    }
                }
                catch (Exception ee) { MessageBox.Show(ee.Message); }
            }
        }
        private void Pb_MainGraphicPanel_SizeChanged(object sender, EventArgs e)
        {
            if (graph != null)
            {
                GraphController.ChangeGraphSize(graph, pb_MainGraphicPanel);
                GraphController.DrawFullGraph(graph);
            }
        }
        public void ShowSettingsPanel(bool show)
        {
            if (show)
            {
                tlp_MainTable.RowStyles[1].Height = 106;
            }
            else
            {
                tabControl_Settings.SelectedTab = tabPage_HideSettings;
                tlp_MainTable.RowStyles[1].Height = 30;
            }
        }
        private void TabControl_Settings_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSettingsPanel(!(((TabControl)sender).SelectedTab == tabPage_HideSettings));
        }
        private void SpiralParams_ValueChanged(object sender, EventArgs e)
        {
            if (cb_viewType.SelectedIndex != 1) { cb_viewType.SelectedIndex = 1; }
            try
            {
                ViewType.BuildSpiral(graph, new float[4] { (float)nud_float_a.Value, (float)nud_float_angle_offset.Value, (float)nud_pi.Value, (float)nud_pi_mtp.Value });
                GraphController.DrawFullGraph(graph);
            }
            catch (Exception ee) { MessageBox.Show(ee.Message); }
        }
        private void NudCenter_ValuesChanged(object sender, EventArgs e)
        {
            GraphController.SetGraphCenterPosition(graph, new PointF((float)nud_center_x.Value, (float)nud_center_y.Value));
        }
        private void Pb_MainGraphicPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (graph == null) { return; }
            if (GraphController.SelectNodeByMousePos(graph, MousePosition))
            {
                GraphController.MouseDoubleClickAction(graph,cb_doubleClickAction.SelectedIndex);
            }
        }

        private void ShowAllNodes(object sender, MouseEventArgs e)
        {
            GraphController.ShowAllNodes(graph);
        }

        private void Tb_NodeName_KeyPress(object sender, KeyPressEventArgs e)
        {
            char symb = e.KeyChar;
            if (!Char.IsLetterOrDigit(symb) && e.KeyChar != Convert.ToChar("\b") && e.KeyChar != ((char)Keys.Enter))
            {
                e.Handled = true;
            }
            if (e.KeyChar == ((char)Keys.Enter))
            {
                string text = " ";
                if (sender is ToolStripTextBox) { text = tsTB_NodeText.Text; }
                GraphController.EditNode(graph, graph.selectedNode, text);
                cms_NodeMenu.Hide();
            }

        }

        private void TsMI_AddNode_Click(object sender, EventArgs e)
        {
            GraphController.AddNodeToGraph(graph, pb_MainGraphicPanel.PointToClient(Cursor.Position));
            GraphController.DrawFullGraph(graph);
        }



        private void TsMI_RemoveNode_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"Warning! The selected node \"{graph.selectedNode.Text}\" will be deleted without the possibility of recovery."
                                             + "\nAre you sure you want to continue? ", "Confirm the action!",
                                            MessageBoxButtons.OKCancel,
                                            MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                GraphController.RemoveSelectedNodeFromGraph(graph);
                GraphController.DrawFullGraph(graph);
            }
        }

        private void TsMI_ShowHiddenNodes_Click(object sender, EventArgs e)
        {
            GraphController.ShowAllNodes(graph);
        }

        private void Nud_DPI_ValueChanged(object sender, EventArgs e)
        {
            GraphController.SetDPI(graph,(int)((NumericUpDown)sender).Value);
            GraphController.DrawFullGraph(graph);
        }

        private void TsMI_EdgeFrom_Click(object sender, EventArgs e)
        {
            if (graph.selectedNode != null)
            {
                NodeMenuController.SetEdgeFrom(graph.selectedNode);
            }
        }

        private void TsMI_EdgeTo_Click(object sender, EventArgs e)
        {
            if (graph.selectedNode != null)
            {
                NodeMenuController.SetEdgeTo(graph, graph.selectedNode);
                GraphController.RecalculateNodesSizeByWeight(graph);
                GraphController.DrawFullGraph(graph);
            }
        }

        private void TsCB_EdgeWeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            NodeMenuController.SetEdgeWeight(((ToolStripComboBox)sender).SelectedIndex+1);
            cms_NodeMenu.Hide();
        }

        #region Multigraph
        private void Cb_graphList_SelectedIndexChanged(object sender, EventArgs e)
        {
            graph = WorkspaceController.GetGraphByNameFromList(cb_graphList.Text);
            if (graph != null) { GraphController.DrawFullGraph(graph); }
        }

        #endregion

        private void Btn_CreateNewGraph_Click(object sender, EventArgs e)
        {
            graph = GraphController.InitializeGraph(cb_graphList.Text, pb_MainGraphicPanel, GetNodeSettingsParams(), GetEdgeSettingsParams(), (int)nud_DPI.Value);
                WorkspaceController.AddNewGraphToList(cb_graphList,graph);
        }

        private void Btn_ExportJson_Click(object sender, EventArgs e)
        {
            try
            {
                GraphController.SaveGraphJsonFile(graph, cb_graphList.Text);
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Btn_AddFileToGraph_Click(object sender, EventArgs e)
        {
            GraphController.LoadJsonFile(graph,cb_jsonPathList.Text);
        }
    }
}
