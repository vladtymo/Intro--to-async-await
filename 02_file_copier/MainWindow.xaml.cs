using IOExtensions;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
        private ViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();

            viewModel = new ViewModel()
            {
                Source = "C:\\Users\\Vlad\\Downloads\\10GB.bin",
                Destination = "C:\\Users\\Vlad\\Desktop\\New folder"
            };

            this.DataContext = viewModel;
        }

        private async void CopyButtonClick(object sender, RoutedEventArgs e)
        {
            // TODO: add validations (File.Exists)

            string fileName = Path.GetFileName(viewModel.Source);
            string destFilePath = Path.Combine(viewModel.Destination, fileName); // folder\fileName

            // create copy process info
            CopyProcessInfo info = new CopyProcessInfo(fileName);

            // add item to the list
            viewModel.AddProcess(info);

            // Copy file from source to destination
            await CopyFileAsync(viewModel.Source, destFilePath, info);

            MessageBox.Show("Complete!");
        }

        private Task CopyFileAsync(string src, string dest, CopyProcessInfo info)
        {
            //return Task.Run(() =>
            //{
            //    // type 1 - using File class
            //    //File.Copy(src, dest, true);

            //    // type 2 - FileStream
            //    using var srcStream = new FileStream(src, FileMode.Open, FileAccess.Read);
            //    using var destStream = new FileStream(dest, FileMode.Create, FileAccess.Write);

            //    int bytes = 0;
            //    byte[] buffer = new byte[1024 * 8]; // 8KB
            //    do
            //    {
            //        bytes = srcStream.Read(buffer, 0, buffer.Length);
            //        destStream.Write(buffer, 0, bytes);
            //        Thread.Sleep(500);

            //        // % = recieved / total * 100
            //        float percent = destStream.Length / (srcStream.Length / 100);
            //        viewModel.Progress = percent;

            //    } while (bytes > 0);
            //});

            // type 3 - FileTransferManager
            return FileTransferManager.CopyWithProgressAsync(src, dest, (progress) =>
            {
                //viewModel.TotalProgress = progress.Percentage;

                info.Percentage = progress.Percentage;
                info.BytesPerSecond = progress.BytesPerSecond;   

            }, false);
        }

        private void OpenSourceClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            
            if (dialog.ShowDialog() == true)
            {
                viewModel.Source = dialog.FileName;
            }
        }
        private void OpenDestinationClick(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;

            if(dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                viewModel.Destination = dialog.FileName;
            }
        }
    }
}
