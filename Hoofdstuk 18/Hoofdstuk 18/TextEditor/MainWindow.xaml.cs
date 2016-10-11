using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace TextEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentFile = "";
        private string initialDir;

        public MainWindow()
        {
            InitializeComponent();

            initialDir = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
        }

        private void exitItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void openItem_Click(object sender, RoutedEventArgs e)
        {
            StreamReader inputStream;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text Files (*.txt)|*.txt";
            dialog.InitialDirectory = initialDir;
            if (dialog.ShowDialog() == true)
            {
                currentFile = dialog.FileName;
                inputStream = File.OpenText(currentFile);
                mainTextBox.Text = inputStream.ReadToEnd();
                inputStream.Close();
            }
        }

        private void saveItem_Click(object sender, RoutedEventArgs e)
        {
            if (currentFile == "")
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Text Files (*.txt)|*.txt";
                dialog.InitialDirectory = initialDir;
                if (dialog.ShowDialog() == true)
                {
                    currentFile = dialog.FileName;
                }
            }
            StreamWriter outputStream = File.CreateText(currentFile);
            outputStream.Write(mainTextBox.Text);
            outputStream.Close();
        }

        private void saveAsItem_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter outputStream;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text Files (*.txt)|*.txt";
            dialog.InitialDirectory = initialDir;
            if (dialog.ShowDialog() == true)
            {
                currentFile = dialog.FileName;
                outputStream = File.CreateText(currentFile);
                outputStream.Write(mainTextBox.Text);
                outputStream.Close();
            }
        }

        private void aboutItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
