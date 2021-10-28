using WordConnectionsViewer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WordConnectionsViewer.Settings
{
    public static class SettingsController
    {
        public static void LoadParamsFromSettings(ComboBox cboxFont, ComboBox cboxStyle,ComboBox cboxProfiles)
        {
            LoadSystemFontsInComboBox(cboxFont);
            LoadSystemsFontStylesInComboBox(cboxStyle);
            LoadProfiles(cboxProfiles);
        }

        public static void LoadProfiles(ComboBox cbox)
        {
            cbox.Items.Clear();
            var MyDocsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string[] subdirectoryEntries = Directory.GetDirectories(MyDocsPath+ "\\WordConnectionsViewer\\");
            foreach(var dir in subdirectoryEntries)
            {
                cbox.Items.Add(dir.Substring(dir.LastIndexOf("\\")+1));
            }
        }
        public static void CreateSettingsProfile(string Name, List<string> selectedFiles, Color node, Color text, Font font, Color[] edgecolors, float nodesize)
        {
            var settings = new SettingsDataModel(Name, selectedFiles, node, text, font, edgecolors, nodesize);
            //
            try
            {
                //string[] OldConecctions = File.ReadAllLines(path + "//LastIpConnections.txt", Encoding.UTF8);//прочитати файл в масив

                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var subFolderPath = Path.Combine(path, $"WordConnectionsViewer\\{ settings.profileName }");
                DirectoryInfo di = Directory.CreateDirectory(subFolderPath);
                FileStream MainSettings = new FileStream($"{subFolderPath}\\MainSettingsData.txt", FileMode.Create); //создаем файловый поток
                StreamWriter MainWriter = new StreamWriter(MainSettings); //создаем «потоковый писатель» и связываем его с файловым потоком 
                MainWriter.WriteLine(settings.GetNodeColor()); //записываем в файл
                MainWriter.WriteLine(settings.GetNodeTextColor()); //записываем в файл
                MainWriter.WriteLine($"{settings.GetFont()[0]};{settings.GetFont()[1]};{settings.GetFont()[2]}"); //записываем в файл
                MainWriter.WriteLine(settings.GetNodeSize()); //записываем в файл
                MainWriter.Close(); //закриваєм потік. Не закрив потік, в файл ничего не запишем
                FileStream loadedFiles = new FileStream($"{subFolderPath}\\LoadedFiles.txt", FileMode.Create); //создаем файловый поток
                StreamWriter LoadedFilesWriter = new StreamWriter(loadedFiles); //создаем «потоковый писатель» и связываем его с файловым потоком 
                foreach (var file in settings.GetLoadedFiles())
                {
                    LoadedFilesWriter.WriteLine(file); //записываем в файл
                }
                LoadedFilesWriter.Close(); //закриваєм потік. Не закрив потік, в файл ничего не запишем

                FileStream edgeColors = new FileStream($"{subFolderPath}\\EdgeColors.txt", FileMode.Create); //создаем файловый поток
                StreamWriter edgeColorsWriter = new StreamWriter(edgeColors); //создаем «потоковый писатель» и связываем его с файловым потоком 
                foreach (var color in settings.GetEdgeColors())
                {
                    edgeColorsWriter.WriteLine(color); //запис в файл
                }
                edgeColorsWriter.Close(); //закриваєм потік. Не закрив потік, в файл ничего не запишем

            }
            catch {  }
        }
        public static void CreateSettingsProfileInOneFile(string Name, List<string> selectedFiles, Color node, Color text, Font font, Color[] edgecolors, float nodesize)
        {
            var settings = new SettingsDataModel(Name, selectedFiles, node, text, font, edgecolors, nodesize);
            //
            try
            {
                //string[] OldConecctions = File.ReadAllLines(path + "//LastIpConnections.txt", Encoding.UTF8);//прочитати файл в масив

                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var subFolderPath = Path.Combine(path, $"{SettingsDataModel.DefaultSettingsFolderName}\\");//{ settings.profileName }");
                //DirectoryInfo di = Directory.CreateDirectory(subFolderPath);
                FileStream MainSettings = new FileStream($"{subFolderPath}\\{ settings.profileName }.txt", FileMode.Create); //создаем файловый поток
                StreamWriter MainWriter = new StreamWriter(MainSettings); //создаем «потоковый писатель» и связываем его с файловым потоком 
                MainWriter.WriteLine(SettingsDataModel.NodeTagOpen);
                MainWriter.WriteLine(settings.GetNodeColor()); //записываем в файл
                MainWriter.WriteLine(settings.GetNodeTextColor()); //записываем в файл
                MainWriter.WriteLine($"{settings.GetFont()[0]};{settings.GetFont()[1]};{settings.GetFont()[2]}"); //записываем в файл
                MainWriter.WriteLine(settings.GetNodeSize()); //записываем в файл
                MainWriter.WriteLine(SettingsDataModel.NodeTagClose);
                //MainWriter.Close(); //закриваєм потік. Не закрив потік, в файл ничего не запишем
                //FileStream loadedFiles = new FileStream($"{subFolderPath}\\LoadedFiles.txt", FileMode.Create); //создаем файловый поток
                //StreamWriter LoadedFilesWriter = new StreamWriter(loadedFiles); //создаем «потоковый писатель» и связываем его с файловым потоком 
                MainWriter.WriteLine(SettingsDataModel.FilesTagOpen);
                foreach (var file in settings.GetLoadedFiles())
                {
                    MainWriter.WriteLine(file); //записываем в файл
                }
                MainWriter.WriteLine(SettingsDataModel.FilesTagClose);
                //MainWriter.Close(); //закриваєм потік. Не закрив потік, в файл ничего не запишем

                //FileStream edgeColors = new FileStream($"{subFolderPath}\\EdgeColors.txt", FileMode.Create); //создаем файловый поток
                //StreamWriter edgeColorsWriter = new StreamWriter(edgeColors); //создаем «потоковый писатель» и связываем его с файловым потоком 
                MainWriter.WriteLine(SettingsDataModel.EdgesTagOpen);
                foreach (var color in settings.GetEdgeColors())
                {
                    MainWriter.WriteLine(color); //запис в файл
                }
                MainWriter.WriteLine(SettingsDataModel.EdgesTagClose);
                MainWriter.Close(); //закриваєм потік. Не закрив потік, в файл ничего не запишем

            }
            catch { }
        }
        public static SettingsDataModel ReadFileWithSettings(string profileName)
        {
            try
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var subFolderPath = Path.Combine(path, $"WordConnectionsViewer\\{ profileName }");
                string[] MainSettings = File.ReadAllLines(subFolderPath + "\\MainSettingsData.txt", Encoding.UTF8);//прочитати файл в масив
                string[] LoadedFiles = File.ReadAllLines(subFolderPath + "\\LoadedFiles.txt", Encoding.UTF8);//прочитати файл в масив
                string[] EdgeColors = File.ReadAllLines(subFolderPath + "\\EdgeColors.txt", Encoding.UTF8);//прочитати файл в масив
                var settings = new SettingsDataModel();
                settings.SetEdgeColors(EdgeColors);
                settings.SetLoadedFiles(LoadedFiles);
                settings.SetMainSettings(MainSettings);
                return settings;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return null; }
        }
        public static SettingsDataModel ReadFileWithSettingsFromOneFile(string profileName)
        {
            try
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var subFolderPath = Path.Combine(path, $"{SettingsDataModel.DefaultSettingsFolderName}\\{ profileName }.txt");
                string[] MainSettingsFile = File.ReadAllLines(subFolderPath, Encoding.UTF8);//прочитати файл в масив
                var file = new List<string>(MainSettingsFile);
                var settings = new SettingsDataModel();
                settings.SetAllSettingsFromList(file);
                return settings;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return null; }
        }
        static void LoadSystemFontsInComboBox(ComboBox cbox)
        {
            foreach (var font in System.Drawing.FontFamily.Families)
            {
                cbox.Items.Add(font.Name);
                if(font.Name == "Calibri") { cbox.SelectedIndex = cbox.Items.Count - 1; }
            }
            if (cbox.SelectedIndex == 0)
            {
                Random rnd = new Random();
                cbox.SelectedIndex = rnd.Next(0,cbox.Items.Count);
            }
        }
        
        
        
        static void LoadSystemsFontStylesInComboBox(ComboBox cbox)
        {
            var fontStyles = Enum.GetValues(typeof(System.Drawing.FontStyle)).Cast<System.Drawing.FontStyle>().ToList();
            foreach (var fontstyle in fontStyles)
            {
                cbox.Items.Add(fontstyle.ToString());
            }
            cbox.SelectedIndex = 0;
        }
    }
}
