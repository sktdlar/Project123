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
            Filter.SelectedIndex = 0;
            int pageNumber = 0;
            Refresh();
        }

        int GetType()
        {
            if (Filter.SelectedIndex == 1)
            {
                return 3;
            }
            if (Filter.SelectedIndex == 2)
            {
                return 1;
            }
            if (Filter.SelectedIndex == 3)
            {
                return 5;
            }
            if (Filter.SelectedIndex == 4)
            {
                return 4;
            }
            if (Filter.SelectedIndex == 5)
            {
                return 5;
            }
            return 0;
        }
        List<Products> listik;
        void Refresh()
        {
            ProductsWP.Children.Clear();
            int pagePosition = 20 * pageNumber;
            visibleList.Clear();
            listik = App.db.Products.ToList();
            if (GetType() != 0)
            {
                listik = listik.Where(x => x.ProductTypeId == GetType()).ToList();
            }
            if(SearchTb.Text.Length >= 1)
            {
                listik = listik.Where(x => x.Name.ToLower().Contains(SearchTb.Text.ToLower())).ToList();
            }
            for (int i = (pagePosition); i < pagePosition + 20; i++)
            {
                try
                {
                    visibleList.Add(listik[i]);
                }
                catch { }
            } 
            foreach(var i in visibleList)
            {
                ProductsWP.Children.Add(new ProductUC(i));
            }
            PageNumber.Text = (pageNumber + 1).ToString();
            CountVisible.Text = $"{visibleList.Count} из {listik.Count}";
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
                    visibleList1.Add(listik[i]);
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

        private void Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
    }
}
