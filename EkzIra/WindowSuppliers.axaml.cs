using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.Linq;

namespace EkzIra;

public partial class WindowSuppliers : Window
{
    public WindowSuppliers(Material material)
    {
        InitializeComponent();

        var suppliers = SupplierList.Instance.Suppliers
            .Where(s => s.Materials.Any(m => m.Name == material.Name))
            .ToList();

        if (suppliers.Count > 0)
        {
            SuppliersListBox.ItemsSource = suppliers;
        }
        else
        {
            SuppliersListBox.ItemsSource = new List<string> { "Данные о поставщике не добавлены" };
        }
    }

    private void Return_Click(object? sender, RoutedEventArgs e)
    {
        var mw = new MainWindow();
        mw.Show();
        this.Close();
    }
}
