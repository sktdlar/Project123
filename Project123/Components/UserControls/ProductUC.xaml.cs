using Project123.Components.DataBase;
using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Project123.Components.UserControls
{
    public partial class ProductUC : UserControl
    {
        public Products Product { get; }

        public ProductUC(Products product)
        {
            InitializeComponent();
            DataContext = product; // Привязываем данные

            Product = product;

            // Загружаем изображение продукта
            LoadProductImage();
        }

        // Метод для загрузки изображения из базы данных
        private void LoadProductImage()
        {
            if (Product.Image != null && Product.Image.Length > 0)
            {
                // Преобразуем байты в изображение
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
                // Если изображения нет, используем изображение-заглушку
                ProductImage.Source = new BitmapImage(new Uri("C:\\Users\\mazit\\Source\\Repos\\Project123\\Project123\\Components\\Images\\ваыва.png"));
            }
        }
    }
}
