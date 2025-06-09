using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using System.Collections.Generic;

namespace EkzIra
{
    public partial class MainWindow : Window
    {
        public List<Material> Materials => MaterialsList.Instance.Materials;

        public MainWindow()
        {
            InitializeComponent();
            MaterialListBox.ItemsSource = Materials;
        }

        private void AddMat_Click(object? sender, RoutedEventArgs e)
        {
            var wam = new WindowAdMaterial();
            wam.Show();
            this.Close();
        }

        private void MaterialItem_PointerPressed(object? sender, PointerPressedEventArgs e)
        {
            var point = e.GetCurrentPoint(this);
            var border = sender as Border;
            if (border == null)
                return;

            var material = border.DataContext as Material;
            if (material == null)
                return;

            if (point.Properties.IsLeftButtonPressed)
            {
                if (MaterialListBox.SelectedItem is Material selectedItem)
                {
                    var wem = new WindowEditMaterial(selectedItem);
                    wem.Show();
                    this.Close();
                }
            }
            else if (point.Properties.IsRightButtonPressed)
            {
                e.Handled = true;

                var contextMenu = new ContextMenu();

                var suppliersItem = new MenuItem { Header = "Поставщики" };
                suppliersItem.Click += (s, args) =>
                {
                    var ws = new WindowSuppliers(material); 
                    ws.Show();
                    this.Close();
                };

                var accountingItem = new MenuItem { Header = "Учет партий" };
                accountingItem.Click += (s, args) =>
                {
                    var wa = new WindowAccounting();
                    wa.Show();
                    this.Close();
                };

                contextMenu.ItemsSource = new[] { suppliersItem, accountingItem };
                contextMenu.Open(border);
            }
        }
    }
}
