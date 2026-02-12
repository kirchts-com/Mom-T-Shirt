using Avalonia.Controls;
using Avalonia.Interactivity;

namespace TshirtFormMockup;

public partial class MainWindow : Window
{
    private void OnTitleBarPointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
    {
        BeginMoveDrag(e);
    }
    private void OnMinimizeClick(object? sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void OnMaximizeClick(object? sender, RoutedEventArgs e)
    {
        if (WindowState == WindowState.Maximized)
            WindowState = WindowState.Normal;
        else
            WindowState = WindowState.Maximized;
    }

    private void OnCloseClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
    public MainWindow()
    {
        InitializeComponent();
        // Set window icon
        this.Icon = new WindowIcon("Resources/AppIcon/mom.ico");
    }

    private async void OnMenuClick(object? sender, RoutedEventArgs e)
    {
        if (sender is not MenuItem item || item.Tag is not string action)
        {
            return;
        }

        if (action == "File/Exit")
        {
            Close();
            return;
        }

        if (action == "Help/About")
        {
            AboutOverlay.IsVisible = true;
            return;
        }

        // Show a simple message box for other menu items
        var dialog = new Window
        {
            Title = "Menu",
            Width = 300,
            Height = 150,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
            Content = new StackPanel
            {
                Margin = new Avalonia.Thickness(20),
                Spacing = 16,
                Children =
                {
                    new TextBlock { Text = $"{action} selected" },
                    new Button { Content = "OK", HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center }
                }
            }
        };
        ((Button)((StackPanel)dialog.Content).Children[1]).Click += (s, args) => dialog.Close();
        await dialog.ShowDialog(this);
    }

    private void OnAboutCloseClicked(object? sender, RoutedEventArgs e)
    {
        AboutOverlay.IsVisible = false;
    }
}