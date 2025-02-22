using Project123.Components.DataBase;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Project123.Components.Pages
{
    public partial class PriceChangeWindow : Window
    {
        private decimal averagePrice;
        private List<Products> productList;

        public PriceChangeWindow(List<Products> productList)
        {
            InitializeComponent();
            this.productList = productList;
            decimal sum = 0;
            foreach(var i in productList)
            {
                sum += i.MinAgentPrice;
            }
            sum = sum / productList.Count;
            averagePrice = sum;
            NewPriceTextBox.Text = averagePrice.ToString("F2"); 
        }

        private void ChangePriceConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            double newPrice;
            if (double.TryParse(NewPriceTextBox.Text, out newPrice))
            {

                if (productList != null)
                {
                    foreach (var product in productList)
                    {
                        product.MinAgentPrice = (decimal)newPrice;
                        App.db.SaveChanges();
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Не удалось найти страницу с товарами.");
                }
            }
            else
            {
                MessageBox.Show("Введите корректную цену.");
            }
        }

    }
}
