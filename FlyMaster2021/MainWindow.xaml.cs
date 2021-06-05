using System;
using System.Collections.Generic;
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
using System.Windows.Forms;
using FlyMaster2021.business;


namespace FlyMaster2021
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                var result = fbd.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    FlyImporter fi = FlyImporter.importFromDirectory(fbd.SelectedPath);

                    foreach (FlyWing wing in fi.Objects)
                    {
                        string entry = $"Area: {wing.Area} Per: {wing.Perimeter} Length: {wing.Length}";
                        lstWing.Items.Add(entry);
                    }
                    
                }
        
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
