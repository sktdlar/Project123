using Project123.Components.DataBase;
using Project123.Components.UserControls;
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

namespace Project123.Components.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductListPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {
        int pageNumber;
        List<Products> visibleList = new List<Products>();
        public ProductListPage()
        {
            InitializeComponent();
            int pageNumber = 0;
            Refresh();

        }
        void Refresh()
        {
            ProductsWP.Children.Clear();
            int pagePosition = 20 * pageNumber;
            visibleList.Clear();
            for (int i = (pagePosition); i < pagePosition + 20; i++)
            {
                try
                {
                    visibleList.Add(App.db.Products.ToList()[i]);
                }
                catch { }
            } 
            foreach(var i in visibleList)
            {
                ProductsWP.Children.Add(new ProductUC(i));
            }
            PageNumber.Text = pageNumber.ToString();
            CountVisible.Text = $"{pagePosition} из {pagePosition + 20}";
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if(pageNumber == 0)
            {

            }
            else
            {
                pageNumber--; ;
                Refresh();
            }
        }

        private void ToBtn_Click(object sender, RoutedEventArgs e)
        {
            int pagePosition = 20 * (pageNumber + 1);
            List<Products> visibleList1 = new List<Products>();

            for (int i = (pagePosition); i < pagePosition + 20; i++)
            {
                try
                {
                    visibleList1.Add(App.db.Products.ToList()[i]);
                }
                catch { }
            }
            if (visibleList1.Count == 0)
            {

            }
            else
            {
                pageNumber++;
                Refresh();
            }
        }
    }
}
