using Microsoft.Win32;
using restart_app.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace restart_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // Set filter for file extension and default file extension 
            openFileDialog.DefaultExt = ".exe";
            openFileDialog.Filter = "EXE Files (*.exe)|*.exe";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = openFileDialog.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = openFileDialog.FileName;
                listBox.Items.Add(filename);
            }
        }

        private void run_Click(object sender, RoutedEventArgs e)
        {
            foreach(string item in listBox.Items){
                Process myProcess = Process.Start(item);
                if (!myProcess.HasExited)
                {
                    System.Threading.Thread.Sleep(70000);
                    myProcess.CloseMainWindow();
                    //myProcess.Close();
                    myProcess.WaitForExit();
                    myProcess = Process.Start(item);
                    System.Threading.Thread.Sleep(70000);
                }
                myProcess.CloseMainWindow();
                myProcess.Close();
            }
        }
    }
}
