using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace _01_async_await
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        // async - allow method to use await keywords
        // await [task] - wait task without freezing
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //int value = GenerateValue();  // freez

            //Task<int> task = Task.Run(GenerateValue);

            //task.Wait();                  // freez
            //list.Items.Add(task.Result);  // freez

            //int value = await task;       // wait without freez    

            //int value = await GenerateValueAsync();   // wait and get result without freez

            // invoke after the task has completed
            //list.Items.Add(value);

            list.Items.Add(await GenerateValueAsync());

            //MessageBox.Show("Complete!");
        }

        private int GenerateValue()
        {
            Thread.Sleep(rnd.Next(5000));
            //MessageBox.Show("Generated!");
            return rnd.Next(1000);
        }
        private Task<int> GenerateValueAsync()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(rnd.Next(5000));
                //MessageBox.Show("Generated!");
                return rnd.Next(1000);
            });
        }
    }
}
