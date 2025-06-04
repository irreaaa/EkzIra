using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;

namespace EkzIra;

public partial class WindowSuppliers : Window
{
    public List<Supplier> Suppliers => SupplierList.Instance.Suppliers;
    public WindowSuppliers()
    {
        InitializeComponent();
        SuppliersListBox.ItemsSource = Suppliers;
    }

    public void Return_Click(object? sender, RoutedEventArgs e)
    {
        MainWindow mw = new MainWindow();
        mw.Show();
        this.Close();
    }
}