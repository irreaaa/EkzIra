using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Interactivity;
using System.Collections.Generic;

namespace EkzIra;

public partial class WindowEditMaterial : Window
{
    public List<Material> Materials => MaterialsList.Instance.Materials;
    private Material _material;
    public WindowEditMaterial(Material material)
    {
        InitializeComponent();
        NameBox.Text = material.Name;
        TypeBox.SelectedItem = material.Type;
        CostBox.Text = material.Cost.ToString();
        QuantityBox.Text = material.StockQuantity.ToString();
        MinQuantityBox.Text = material.MinQuantity.ToString();
        MeasureBox.SelectedItem = material.Measure;
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
            if(item.Name == newName)
            {
                ShowError("Материал с таким названием уже есть.");
                return;
            }
        }
        if (NameBox.Text == null)
        {
            ShowError("Имя или тип материала не могут быть пустыми.");
            return;
        }

        if (!double.TryParse(CostBox.Text, out double cost) || cost <= 0)
        {
            ShowError("Некорректное значение цены.");
            return;
        }

        if (!int.TryParse(QuantityBox.Text, out int quantity) || quantity <= 0 || !int.TryParse(MinQuantityBox.Text, out int minQuantity) || minQuantity <= 0)
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
            _material.Cost = cost;
            _material.StockQuantity = quantity;
            _material.MinQuantity = minQuantity;

            var success = new WindowNotificationManager(this)
            {
                Position = NotificationPosition.TopCenter
            };
            success.Show(new Notification("Готово", "Данные материала обновлены.", NotificationType.Success));
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