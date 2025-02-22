using Project123.Components.DataBase;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Project123.Components.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ProductUCSelect.xaml
    /// </summary>
    public partial class ProductUCSelect : UserControl
    {
        public Products Product { get; }

        public ProductUCSelect(Products product)
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
    }
}
    
