﻿using Project123.Components.DataBase;
using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Project123.Components.UserControls
{
    public partial class ProductUC : UserControl
    {
        public Products Product { get; }

        public ProductUC(Products product)
        {
            InitializeComponent();
            DataContext = product; 

            Product = product;

            LoadProductImage();
        }

        private void LoadProductImage()
        {
            if (Product.Image != null && Product.Image.Length > 0)
            {
                using (var ms = new MemoryStream(Product.Image))
                {
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = ms;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                    ProductImage.Source = bitmap;
                }
            }
            else
            {
                ProductImage.Source = new BitmapImage(new Uri("C:\\Users\\SKTDLAR\\source\\repos\\Project123\\Project123\\Components\\Images\\ваыва.png"));
            }
        }
        public void changeColor()
        {
            if(MainGrid.Background == Brushes.LightBlue)
            {
                MainGrid.Background = Brushes.LightGreen;
            }
            else
            MainGrid.Background = Brushes.LightBlue;
        }
        private void UserControl_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            App.productUC = this;
            App.productListPage.navigatee(Product);
        }
    }
}
