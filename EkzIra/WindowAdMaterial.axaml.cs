using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;

namespace EkzIra;

public partial class WindowAdMaterial : Window
{
    public List<Material> Materials => MaterialsList.Instance.Materials;
    public WindowAdMaterial()
    {
        InitializeComponent();
    }
    
    private void Return_Click(object? sender, RoutedEventArgs e)
    {
        MainWindow mw = new MainWindow();
        mw.Show();
        this.Close();
    }

    public void Add_Click(object? sender, RoutedEventArgs e)
    {
        string enteredName = NameBox.Text;
        string type = TypeBox.SelectedItem as string;
        string measure = MeasureBox.SelectedItem as string;
        foreach (var item in Materials) {
            if (item.Name == enteredName) {
                ShowError("Такой товар уже есть.");
                return;

            }
        }
        if(NameBox.Text == null)
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
        if(type == null || measure == null)
        {
            ShowError("Значения из выпадающего списка не выбраны.");
            return;
        }
        else
        {
            Materials.Add(new Material
            {
                Name = enteredName,
                Type = type,
                MinQuantity = minQuantity,
                StockQuantity = quantity,
                Cost = Math.Round(cost, 2),
                Measure = measure,
                QuantityInWrapper = wrQuantity
            });

            var success = new WindowNotificationManager(this)
            {
                Position = NotificationPosition.TopCenter
            };
            success.Show(new Notification("Готово", "Материал успешно добавлен.", NotificationType.Success));

            NameBox.Text = "";
            TypeBox.SelectedIndex = -1;
            CostBox.Text = "";
            QuantityBox.Text = "";
            MinQuantityBox.Text = "";
            MeasureBox.SelectedIndex = -1;
            QuantityInWrapper.Text = "";
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