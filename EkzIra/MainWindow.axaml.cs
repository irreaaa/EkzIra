using Avalonia.Controls;
using Avalonia.Interactivity;
using HarfBuzzSharp;
using System.Collections.Generic;
using System.Xml.Linq;

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

        private void Add_Click(object? sender, RoutedEventArgs e)
        {
            string type = "Пластичные материалы";
            string name = "Глина";
            int minQuantity = 5500;
            int stockQuantity = 1570;
            double cost = 15.29;
            string measure = "кг";
            Materials.Add(new Material
            {
                Type = type,
                Name = name,
                MinQuantity = minQuantity,
                StockQuantity = stockQuantity,
                Cost = cost,
                Measure = measure
            });
            MaterialListBox.ItemsSource = null;
            MaterialListBox.ItemsSource = Materials;
        }

        private void AddMat_Click(object? sender, RoutedEventArgs e)
        {
            WindowAdMaterial wam = new WindowAdMaterial();
            wam.Show();
            this.Close();
        }
    }
}