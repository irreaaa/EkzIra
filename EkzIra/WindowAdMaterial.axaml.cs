using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using HarfBuzzSharp;
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
        foreach (var item in Materials) {
            if (item.Name == enteredName) {
                var error = new WindowNotificationManager(this)
                {
                    Position = NotificationPosition.BottomCenter
                };
                error.Show(new Notification("Ошибка", "Такой товар уже есть.", NotificationType.Error));
                return;

            }
        }

        if (!double.TryParse(CostBox.Text, out double cost) || cost <= 0)
        {
            var error = new WindowNotificationManager(this)
            {
                Position = NotificationPosition.BottomCenter
            };
            error.Show(new Notification("Ошибка", "Некорректное значение цены.", NotificationType.Error));
            return;
        }

        if (!int.TryParse(QuantityBox.Text, out int quantity) || quantity <= 0 || !int.TryParse(MinQuantityBox.Text, out int minQuantity) || minQuantity <= 0)
        {
            var error = new WindowNotificationManager(this)
            {
                Position = NotificationPosition.BottomCenter
            };
            error.Show(new Notification("Ошибка", "Некорректное значение количества.", NotificationType.Error));
            return;
        }
        else
        {
            Materials.Add(new Material
            {
                Name = enteredName,
                MinQuantity = minQuantity,
                StockQuantity = quantity,
                Cost = cost,
                //Measure = MeasureBox.Text
            });

            NameBox.Text = "";
            TypeBox = null;
            CostBox.Text = "";
            QuantityBox.Text = "";
            MinQuantityBox.Text = "";
            MeasureBox = null;
        }

    }
}