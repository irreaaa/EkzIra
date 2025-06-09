using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace EkzIra;

public partial class WindowAccounting : Window
{
    public WindowAccounting()
    {
        InitializeComponent();
    }

    public void Return_Click(object? sender, RoutedEventArgs e)
    {
        MainWindow mw = new MainWindow();
        mw.Show();
        this.Close();
    }
}