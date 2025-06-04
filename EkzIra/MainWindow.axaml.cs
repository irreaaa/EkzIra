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
    }
}