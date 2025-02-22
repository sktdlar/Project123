using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Project123.Components.DataBase;

namespace Project123.Components.Pages
{
    public partial class ProductEditPage : Page
    {
        private Products currentProduct;

        public ProductEditPage(Products product = null)
        {
            InitializeComponent();

            if (product != null)
            {
                currentProduct = product;
                ArticleTextBox.Text = currentProduct.Article.ToString();
                NameTextBox.Text = currentProduct.Name;
                ProductTypeComboBox.SelectedIndex = currentProduct.ProductTypeId;
                DescriptionTextBox.Text = currentProduct.Description;

                LoadMaterials();
                LoadImage();
            }
            else
            {
                currentProduct = new Products();
            }
        }

        private void LoadMaterials()
        {
            var materials = App.db.ProductionMaterials
                                  .Where(pm => pm.ProductArticle == currentProduct.Article)
                                  .Select(pm => pm.MaterialID)
                                  .ToList();
            MaterialsDataGrid.ItemsSource = materials;
        }

        private void LoadImage()
        {
            if (currentProduct.Image != null && currentProduct.Image.Length > 0)
            {
                using (var stream = new MemoryStream(currentProduct.Image))
                {
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                    ProductImage.Source = bitmap;
                }
            }
            else
            {
                ProductImage.Source = null;
            }
        }

        private void SelectImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Выберите изображение"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                currentProduct.Image = File.ReadAllBytes(openFileDialog.FileName);
                LoadImage();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            int article;
            if (!int.TryParse(ArticleTextBox.Text, out article))
            {
                MessageBox.Show("Введите корректный артикул (число).");
                return;
            }

            if (App.db.Products.Any(p => p.Article == article && p.Article != currentProduct.Article))
            {
                MessageBox.Show("Продукт с таким артикулом уже существует!");
                return;
            }

            currentProduct.Article = article;
            currentProduct.Name = NameTextBox.Text;
            currentProduct.ProductTypeId = ProductTypeComboBox.SelectedIndex;
            currentProduct.Description = DescriptionTextBox.Text;

            if (App.db.Products.Any(p => p.Article == currentProduct.Article))
            {
                var existingProduct = App.db.Products.First(p => p.Article == currentProduct.Article);
                existingProduct.Name = currentProduct.Name;
                existingProduct.ProductTypeId = currentProduct.ProductTypeId;
                existingProduct.Description = currentProduct.Description;
                existingProduct.Image = currentProduct.Image;
            }
            else
            {
                App.db.Products.Add(currentProduct);
            }

            App.db.SaveChanges();
            MessageBox.Show("Продукт сохранен");

            NavigationService.GoBack();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить этот продукт?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (App.db.AgentSalesHistory.Any(s => s.ProductID == currentProduct.Article))
                {
                    MessageBox.Show("Невозможно удалить продукт, так как он был продан.");
                    return;
                }

                var requestDetails = App.db.RequestDetails.Where(rd => rd.ProductID == currentProduct.Article).ToList();
                App.db.RequestDetails.RemoveRange(requestDetails);

                var priceHistoryRecords = App.db.ProductPriceHistory.Where(ph => ph.ProductID == currentProduct.Article).ToList();
                App.db.ProductPriceHistory.RemoveRange(priceHistoryRecords);

                var productMaterials = App.db.ProductionMaterials.Where(pm => pm.ProductArticle == currentProduct.Article).ToList();
                App.db.ProductionMaterials.RemoveRange(productMaterials);

                App.db.Products.Remove(currentProduct);
                App.db.SaveChanges();

                MessageBox.Show("Продукт удален");
                NavigationService.GoBack();
            }
        }

        private void AddMaterialButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("");

        }

        private void RemoveMaterialButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("");

        }
    }
}
