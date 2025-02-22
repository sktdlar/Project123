//using System;
//using System.Windows;

//namespace Project123.Components.Pages
//{
//    public partial class PriceChangeWindow : Window
//    {
//        private double averagePrice;
//        private ProductListPage productListPage;

//        public PriceChangeWindow(double averagePrice, ProductListPage productListPage)
//        {
//            InitializeComponent();
//            this.averagePrice = averagePrice;
//            NewPriceTextBox.Text = averagePrice.ToString("F2"); // Отображаем среднюю цену
//            this.productListPage = productListPage;
//        }

//        private void ChangePriceConfirmBtn_Click(object sender, RoutedEventArgs e)
//        {
//            double newPrice;
//            if (double.TryParse(NewPriceTextBox.Text, out newPrice))
//            {
//                // Получаем ссылку на текущую страницу (ProductListPage)
//                var productListPage = ((MainWindow)App.Current.MainWindow).MainFrame.Content as ProductListPage;

//                if (productListPage != null)
//                {
//                    // Изменяем цену для выбранных товаров
//                    foreach (var product in productListPage.selectedProducts)
//                    {
//                        product.MinAgentPrice = (decimal)newPrice;
//                        // Обновляем цену в базе данных
//                        App.db.SaveChanges();
//                    }

//                    this.Close();
//                }
//                else
//                {
//                    MessageBox.Show("Не удалось найти страницу с товарами.");
//                }
//            }
//            else
//            {
//                MessageBox.Show("Введите корректную цену.");
//            }
//        }

//    }
//}
