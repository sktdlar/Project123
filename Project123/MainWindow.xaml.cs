using Project123.Components.Controls;
using Project123.Components.Pages;
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

namespace Project123
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public TabControl tabControl;
        public MainWindow()
        {
            InitializeComponent();
            tabControl = MainTB;
            App.mainWindow = this;
//            MainFrame.Navigate(new ProductListPage());
        }


        private void ProductsBtn_Click(object sender, RoutedEventArgs e)
        {
            TabControlMechanism.AddTab(new ProductListPage(), "Продукты");
        }
    }
}
