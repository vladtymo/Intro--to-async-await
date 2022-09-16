using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace _02_file_copier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Source { get; set; }
        public string Destination { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            srcTextBox.Text = Source = "C:\\Users\\Vlad\\Desktop\\GitHubDesktopSetup-x64.exe";
            destTextBox.Text = Destination = "C:\\Users\\Vlad\\Desktop\\New folder";
        }

        private void CopyButtonClick(object sender, RoutedEventArgs e)
        {
            // Copy file from source to destination

            string fileName = Path.GetFileName(Source);
            string destFilePath = Path.Combine(Destination, fileName);

            // type 1 - using File class

            // C:\Users\Vlad\Desktop\New folder\GitHubDesktopSetup-x64.exe
            File.Copy(Source, destFilePath, true);

            MessageBox.Show("Complete!");
        }

        private void OpenSourceClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            
            if (dialog.ShowDialog() == true)
            {
                Source = dialog.FileName;
                srcTextBox.Text = Source;
            }
        }
        private void OpenDestinationClick(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;

            if(dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Destination = dialog.FileName;
                destTextBox.Text = Destination;
            }
        }
    }
}
