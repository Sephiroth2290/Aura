using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;
using Aura;

namespace Aura
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class WindowSettings : Window
    {
        public WindowSettings()
        {
            InitializeComponent();
            string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
        }



        private void settings_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();  //Allows you to drag and move the window from anywhere.
        }
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".exe";
            dlg.Filter = "Executable files (*.exe)|*.exe";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                DAPath.Text = filename;
            }
        }

        private void btnBrowse_Directory_Click(object sender, RoutedEventArgs e)
        {
            var openFolder = new CommonOpenFileDialog();
            openFolder.AllowNonFileSystemItems = true;
            openFolder.Multiselect = false;
            openFolder.IsFolderPicker = true;
            openFolder.Title = "Select your Dark Ages Folder";

            if (openFolder.ShowDialog() != CommonFileDialogResult.Ok)
            {
                MessageBox.Show("No Folder selected");
                return;
            }

            // get all the directories in selected directory
            var dirs = openFolder.FileNames.ToArray();
            DAFolder.Text = openFolder.FileName;

        }

        private void settingsSave_Click(object sender, RoutedEventArgs e)
        {
            Settings.Save();
            Close();
        }

        private void settingsCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
