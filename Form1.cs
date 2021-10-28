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
        public Form1()
        {
            InitializeComponent();
        }
        //TODO: фільтри для відображення нод
        //TODO: можливість відключати залежність розміру ноди від її ваги
        //TODO: добавити метод RecalculateWeight щоб при зміні параметру NodeSize, змінювати розмір ноди
        //TODO: параметр visible, для кожної ноди, щоб приховати лишнє
        //TODO: перевірити швидкість роботи алгоритму, якщо використовувати додаткові фільтри
        private void Form1_Load(object sender, EventArgs e)
        {
            Text = $"{typeof(Program).Assembly.GetName().Name}";
            SettingsController.LoadParamsFromSettings(cb_fonts,cb_FontStyle,cb_profileName);
            graph = GraphController.InitializeGraph(pb_MainGraphicPanel, GetNodeSettingsParams(), GetEdgeSettingsParams());
            ShowSettingsPanel(false);
        }

        private void PictureBox_Colors_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            colorDialog.Color = ((PictureBox)sender).BackColor;
            colorDialog.ShowDialog();
            ((PictureBox)sender).BackColor = colorDialog.Color;
        }
        private void ChangeNodePreviewParams(object sender, EventArgs e)
        {
            //ChangeNodePreviewParams();
            if (graph != null)
            {
                graph.graphStyle.edgeStyle = GetEdgeSettingsParams();
                GraphController.SetNodeStyle(graph, GetNodeSettingsParams());
                GraphController.DrawFullGraph(graph);
            }
        }
        
        public NodeStyle GetNodeSettingsParams()
        {
            var nodeStyle = new NodeStyle(
                pb_nodeTextColor.BackColor,
                pb_nodeColor.BackColor,
                new Font(cb_fonts.Text,
                         (float)nud_FontSize.Value, 
                         ((FontStyle)Enum.Parse(typeof(FontStyle),
                         cb_FontStyle.Text, true))),
                (float)nud_nodeSize.Value);
            return nodeStyle;
        }
        public EdgesStyle GetEdgeSettingsParams()
        {
            var edgeStyle = new EdgesStyle(new Color[] { pb_color1.BackColor, pb_color2.BackColor, pb_color3.BackColor, pb_color4.BackColor, });
            return edgeStyle;
        }

        private void SelectNode(object sender, MouseEventArgs e)
        {
            var nodeCatched = GraphController.SelectNodeByMousePos(graph,MousePosition);
            if (nodeCatched)
            {
                graph.MoveNodeMode = true;
                GraphController.GetSelectedNodeConnections(graph, lv_connections);
                Cursor = Cursors.Hand;
            }
            else { graph.MoveGraphMode = true; mousePosBeforePanelClick = e.Location; Cursor = Cursors.SizeAll; }
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
            else if(graph.MoveGraphMode) { GraphController.MoveGraphToNewLocation(graph,mousePosBeforePanelClick,e.Location); }
            Cursor = Cursors.Arrow;
        }
        
        private void Button_Load_JSON_File_Click(object sender, EventArgs e)
        {
            try
            {
                SettingsController.LoadFilePathToComboBox(cb_jsonPathList);
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void JSON_SelectedPathChanged(object sender, EventArgs e)
        {
            try
            {
                GraphController.LoadNewGraphFromFile(graph, ((ComboBox)sender).Text);
            }
            catch (Exception ex) { MessageBox.Show($"Помилка!\n{ex.Message}"); }
        }

        private void File_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            try
            {
                SettingsController.LoadFilePathToComboBox(cb_jsonPathList, files);
            }
            catch(Exception ex) { MessageBox.Show($"Помилка!\n{ex.Message}"); }
        }

        private void File_DragOver(object sender, DragEventArgs e)
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

        private void Button_SaveGraphToPNG(object sender, EventArgs e)
        {
            GraphController.SaveGraphImage(pb_MainGraphicPanel,cb_jsonPathList.Text);
        }

        private void Button_SaveProfile(object sender, EventArgs e)
        {
            var pathlist = new List<string>();
            foreach (var item in cb_jsonPathList.Items)
            {
                pathlist.Add(item.ToString());
            }
            SettingsController.CreateSettingsProfile(cb_profileName.Text,pathlist,pb_nodeColor.BackColor,pb_nodeTextColor.BackColor,graph.graphStyle.nodeStyle.GetFont(),graph.graphStyle.edgeStyle.GetAllColors(),(float)nud_nodeSize.Value);
            SettingsController.LoadProfiles(cb_profileName);
        }

        private void ProfileChanged(object sender, EventArgs e)
        {
            LoadProfile(((ComboBox)sender).Text);
        }
        void LoadProfile(string profileName)
        {
            SettingsDataModel profile;
            try
            {
                profile = SettingsController.ReadFileWithSettings(profileName);
            }
            catch (Exception ex) { MessageBox.Show($"Помилка при завантажені профілю\n{ex.Message}"); return; }

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
                try
                {
                    GraphController.DrawFullGraph(graph);
                }
                catch { }
            }
        }
        private void profileName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadProfile(((ComboBox)sender).Text);
            }
        }

        private void cb_viewType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (graph != null)
            {
                if (((ComboBox)sender).SelectedIndex == 1)
                {
                    ViewType.BuildSpiral(graph,(tabControl_Settings.SelectedTab==tabPage1),new int[5] = {  });
                    GraphController.DrawFullGraph(graph);
                }
                if (((ComboBox)sender).SelectedIndex == 2)
                {
                    ViewType.BuildSquare(graph);
                    GraphController.DrawFullGraph(graph);
                }
            }
        }

        private void pb_MainGraphicPanel_SizeChanged(object sender, EventArgs e)
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

        private void tabControl_Settings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((TabControl)sender).SelectedTab == tabPage_HideSettings)
            {
                ShowSettingsPanel(false);
            }
            else
            {
                ShowSettingsPanel(true);
            }
        }
    }
}
