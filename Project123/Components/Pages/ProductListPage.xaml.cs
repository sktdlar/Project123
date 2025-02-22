using Project123.Components.DataBase;
using Project123.Components.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Project123.Components.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductListPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {
        int pageNumber;
        List<Products> visibleList = new List<Products>();
        List<Products> listik;
        private Products selectedProduct;

        public ProductListPage()
        {
            InitializeComponent();
            Filter.SelectedIndex = 0;
            pageNumber = 0;
            Refresh();
        }

        private int GetType()
        {
            switch (Filter.SelectedIndex)
            {
                case 1: return 3;
                case 2: return 1;
                case 3: return 5;
                case 4: return 4;
                case 5: return 5;
                default: return 0;
            }
        }

        private void Refresh()
        {
            ProductsWP.Children.Clear();
            int pagePosition = 20 * pageNumber;
            visibleList.Clear();
            listik = App.db.Products.ToList();

            if (GetType() != 0)
            {
                listik = listik.Where(x => x.ProductTypeId == GetType()).ToList();
            }

            if (SearchTb.Text.Length >= 1)
            {
                listik = listik.Where(x => x.Name.ToLower().Contains(SearchTb.Text.ToLower())).ToList();
            }

            for (int i = pagePosition; i < pagePosition + 20; i++)
            {
                if (i < listik.Count)
                {
                    visibleList.Add(listik[i]);
                }
            }

            foreach (var product in visibleList)
            {
                var productUC = new ProductUC(product);
                productUC.MouseLeftButtonDown += (sender, e) => OnProductSelected(product);
                if (IsProductUnsoldLastMonth(product.Article))
                {
                    productUC.Background = new SolidColorBrush(Colors.LightCoral);
                }
                ProductsWP.Children.Add(productUC);
            }

            PageNumber.Text = (pageNumber + 1).ToString();
            CountVisible.Text = $"{visibleList.Count} из {listik.Count}";
        }

        private void OnProductSelected(Products product)
        {
            // Снимаем выделение с предыдущего продукта
            
            // Отмечаем текущий продукт как выбранный
            selectedProduct = product;

            // Изменяем фон выбранного продукта
            var selectedProductUC = (ProductUC)ProductsWP.Children
                .Cast<UIElement>()
                .FirstOrDefault(x => ((ProductUC)x).Product == product);
            if (selectedProductUC != null)
                selectedProductUC.Background = Brushes.LightBlue; // Изменяем фон для выделенного
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
           
                NavigationService.Navigate(new ProductEditPage(new Products()));
           
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (pageNumber > 0)
            {
                pageNumber--;
                Refresh();
            }
        }

        private void ToBtn_Click(object sender, RoutedEventArgs e)
        {
            int pagePosition = 20 * (pageNumber + 1);
            if (pagePosition < listik.Count)
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

        private bool IsProductUnsoldLastMonth(int productId)
        {
            DateTime lastMonth = DateTime.Now.AddMonths(-1);
            return !App.db.AgentSalesHistory.Any(s => s.ProductID == productId && s.SaleDate >= lastMonth);
        }
        private void ProductsWP_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.OriginalSource is FrameworkElement element && element.DataContext is Products selectedProduct)
            {
                NavigationService.Navigate(new ProductEditPage(selectedProduct));
            }
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
