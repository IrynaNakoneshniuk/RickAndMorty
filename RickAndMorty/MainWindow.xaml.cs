using RickAndMorty.Net.Api.Models.Domain;
using RickAndMorty.Net.Api.Service;
using RickAndMorty.NewFolder;
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

namespace RickAndMorty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObjectsViewModels viewModels;
        public MainWindow()
        {
            viewModels = new ObjectsViewModels();
            InitializeComponent();
            this.DataContext = viewModels;
    
        }
        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            
        }

    }
}
