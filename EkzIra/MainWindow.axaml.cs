using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;

namespace EkzIra
{
    public partial class MainWindow : Window
    {
        public List<Material> Materials => MaterialsList.Instance.Materials;
        public Material _material;
        public MainWindow()
        {
            InitializeComponent();
            MaterialListBox.ItemsSource = Materials;
            MaterialListBox.SelectionChanged += SelectedMaterial_Click;
        }

        private void AddMat_Click(object? sender, RoutedEventArgs e)
        {
            WindowAdMaterial wam = new WindowAdMaterial();
            wam.Show();
            this.Close();
        }

        private void SelectedMaterial_Click(object? sender, RoutedEventArgs e)
        {
            if(MaterialListBox.SelectedItem is Material selectedItem)
            {
                WindowEditMaterial wem = new WindowEditMaterial(selectedItem);
                wem.Show();
                this.Close();
            }
        }

        //(5500-1570)/30*15,29
        //(MinQuantity-StockQuantity)/(округлить в большую сторону)QuantityInWrapper*Cost
        //мне нужно, чтоб стоимость закупки, если количество на складе меньше, чем минимальное количество, рассчитывалась по логике (MinQuantity-StockQuantity)/(округлить в большую сторону всегда)QuantityInWrapper*Cost

    }
}