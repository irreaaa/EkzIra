using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using Tmds.DBus.Protocol;

namespace EkzIra;

public partial class WindowEditMaterial : Window
{
    public List<Material> Materials => MaterialsList.Instance.Materials;
    private Material _material;
    public WindowEditMaterial(Material material)
    {
        InitializeComponent();
        _material = material;
        NameBox.Text = material.Name;
        TypeBox.SelectedItem = material.Type;
        CostBox.Text = material.Cost.ToString();
        QuantityBox.Text = material.StockQuantity.ToString();
        MinQuantityBox.Text = material.MinQuantity.ToString();
        MeasureBox.SelectedItem = material.Measure;
        QuantityInWrapper.Text = material.QuantityInWrapper.ToString();
    }

    private void Return_Click(object? sender, RoutedEventArgs e)
    {
        MainWindow mw = new MainWindow();
        mw.Show();
        this.Close();
    }

    private void SaveChanges_Click(object? sender, RoutedEventArgs e)
    {
        string newName = NameBox.Text;
        string type = TypeBox.SelectedItem as string;
        string measure = MeasureBox.SelectedItem as string;
        foreach(var item in Materials)
        {
            if(item.Name == newName && item != _material)
            {
                ShowError("Материал с таким названием уже есть.");
                return;
            }
        }
        if (string.IsNullOrWhiteSpace(newName))
        {   
            ShowError("Имя или тип материала не могут быть пустыми.");
            return;
        }

        if (!double.TryParse(CostBox.Text, out double cost) || cost <= 0)
        {
            ShowError("Некорректное значение цены.");
            return;
        }

        if (!int.TryParse(QuantityBox.Text, out int quantity) || quantity <= 0 || !int.TryParse(MinQuantityBox.Text, out int minQuantity) || minQuantity <= 0 || !int.TryParse(QuantityInWrapper.Text, out int wrQuantity) || wrQuantity <= 0)
        {
            ShowError("Некорректное значение количества.");
            return;
        }
        if (type == null || measure == null)
        {
            ShowError("Значения из выпадающего списка не выбраны.");
            return;
        }
        else
        {
            _material.Name = newName;
            _material.Type = type;
            _material.Measure = measure;
            _material.Cost = Math.Round(cost, 2);
            _material.StockQuantity = quantity;
            _material.MinQuantity = minQuantity;
            _material.QuantityInWrapper = wrQuantity;

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }

    private void ShowError(string message)
    {
        var error = new WindowNotificationManager(this)
        {
            Position = NotificationPosition.BottomCenter
        };
        error.Show(new Notification("Ошибка", message, NotificationType.Error));
    }
}