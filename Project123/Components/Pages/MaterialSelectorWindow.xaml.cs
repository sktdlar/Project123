using System.Linq;
using System.Windows;
using System.Windows.Media.Media3D;
using Project123.Components.DataBase;

namespace Project123.Components.Windows
{
    public partial class MaterialSelectorWindow : Window
    {
        public Materials SelectedMaterial { get; private set; }

        public MaterialSelectorWindow()
        {
            InitializeComponent();
            MaterialsListBox.ItemsSource = App.db.Materials.ToList();
            MaterialsListBox.DataContext = App.db.Materials.ToList();
        }

        private void LoadMaterials()
        {
            var materials = App.db.Materials.ToList();
            MaterialsListBox.ItemsSource = materials;
        }

        private void SearchTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            var searchText = SearchTextBox.Text.ToLower();
            var filteredMaterials = App.db.Materials
                .Where(m => m.Name.ToLower().Contains(searchText))
                .ToList();

            MaterialsListBox.ItemsSource = filteredMaterials;
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedMaterial = MaterialsListBox.SelectedItem as Materials;
            if (SelectedMaterial != null)
            {
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Выберите материал.");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
