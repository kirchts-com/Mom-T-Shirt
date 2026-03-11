using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace TshirtFormMockup;

public partial class MainWindow : Window
{
    public string TerminalOutputText => Localization.Localizer.GetString("Terminal_Output_Text");
    public string AboutTitle => Localization.Localizer.GetString("About_Title");
    public string AboutSubtitle => Localization.Localizer.GetString("About_Subtitle");
        public string AboutPermissionsLabel => Localization.Localizer.GetString("About_PermissionsLabel");
        public string AboutPermissions => Localization.Localizer.GetString("About_Permissions");
        public string AboutSupportEmailLabel => Localization.Localizer.GetString("About_SupportEmailLabel");
        public string AboutSupportEmail => Localization.Localizer.GetString("About_SupportEmail");
        public string AboutForever => Localization.Localizer.GetString("About_Forever");
        public string AboutAllRightsReserved => Localization.Localizer.GetString("About_AllRightsReserved");
        public string AboutUnauthorizedArguments => Localization.Localizer.GetString("About_UnauthorizedArguments");
    public string AboutBackgroundProcesses => Localization.Localizer.GetString("About_BackgroundProcesses");
    public string AboutVersionLabel => Localization.Localizer.GetString("About_VersionLabel");
    public string AboutVersion => Localization.Localizer.GetString("About_Version");
    public string AboutBuildLabel => Localization.Localizer.GetString("About_BuildLabel");
    public string AboutBuild => Localization.Localizer.GetString("About_Build");
    public string AboutUptimeLabel => Localization.Localizer.GetString("About_UptimeLabel");
    public string AboutUptime => Localization.Localizer.GetString("About_Uptime");
    public string AboutLicenseLabel => Localization.Localizer.GetString("About_LicenseLabel");
    public string AboutLicense => Localization.Localizer.GetString("About_License");
    // Localized properties for UI binding
    public string TitleBarText => Localization.Localizer.GetString("MainWindow_Title");
    public string MenuFile => Localization.Localizer.GetString("Menu_File");
    public string MenuNew => Localization.Localizer.GetString("Menu_New");
    public string MenuOpen => Localization.Localizer.GetString("Menu_Open");
    public string MenuSave => Localization.Localizer.GetString("Menu_Save");
    public string MenuExit => Localization.Localizer.GetString("Menu_Exit");
    public string MenuEdit => Localization.Localizer.GetString("Menu_Edit");
    public string MenuUndo => Localization.Localizer.GetString("Menu_Undo");
    public string MenuRedo => Localization.Localizer.GetString("Menu_Redo");
    public string MenuCopy => Localization.Localizer.GetString("Menu_Copy");
    public string MenuPaste => Localization.Localizer.GetString("Menu_Paste");
    public string MenuView => Localization.Localizer.GetString("Menu_View");
    public string MenuRefresh => Localization.Localizer.GetString("Menu_Refresh");
    public string MenuToggleTheme => Localization.Localizer.GetString("Menu_ToggleTheme");
    public string MenuHelp => Localization.Localizer.GetString("Menu_Help");
    public string MenuAbout => Localization.Localizer.GetString("Menu_About");
    public string SubmitButtonText => Localization.Localizer.GetString("SubmitButton_Text");

    // Notify UI of property changes
    // Hides AvaloniaObject.PropertyChanged intentionally for INotifyPropertyChanged
    public new event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;
    private void NotifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
    }

    // Call this method after localization changes to refresh terminal output
    public void RefreshTerminalOutput()
    {
        NotifyPropertyChanged(nameof(TerminalOutputText));
    }
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
        Console.WriteLine("MainWindow constructor reached. If you see this, Console.WriteLine works.");
        Console.WriteLine($"Config.Language = {Config.Language}");
        Console.WriteLine($"CurrentUICulture before SetCulture = {System.Globalization.CultureInfo.CurrentUICulture.Name}");
        Localization.Localizer.SetCulture(Config.Language);
        Console.WriteLine($"CurrentUICulture after SetCulture = {System.Globalization.CultureInfo.CurrentUICulture.Name}");
        var testValue = Localization.Localizer.GetString("Menu_File");
        Console.WriteLine($"Menu_File localized value = {testValue}");
        // Set DataContext for bindings
        this.DataContext = this;
        InitializeComponent();
        // Set window icon
        this.Icon = new WindowIcon("Resources/AppIcon/mom.ico");
        // Restore window size
        this.Width = 2100;
        this.Height = 2100;
        // Set localized window title
        this.Title = Localization.Localizer.GetString("MainWindow_Title");
    }

    // Method to change language
    public void ChangeLanguage(string cultureName)
    {
        Localization.Localizer.SetCulture(cultureName);
        this.Title = TitleBarText;
        NotifyPropertyChanged(nameof(TitleBarText));
        NotifyPropertyChanged(nameof(MenuFile));
        NotifyPropertyChanged(nameof(MenuNew));
        NotifyPropertyChanged(nameof(MenuOpen));
        NotifyPropertyChanged(nameof(MenuSave));
        NotifyPropertyChanged(nameof(MenuExit));
        NotifyPropertyChanged(nameof(MenuEdit));
        NotifyPropertyChanged(nameof(MenuUndo));
        NotifyPropertyChanged(nameof(MenuRedo));
        NotifyPropertyChanged(nameof(MenuCopy));
        NotifyPropertyChanged(nameof(MenuPaste));
        NotifyPropertyChanged(nameof(MenuView));
        NotifyPropertyChanged(nameof(MenuRefresh));
        NotifyPropertyChanged(nameof(MenuToggleTheme));
        NotifyPropertyChanged(nameof(MenuHelp));
        NotifyPropertyChanged(nameof(MenuAbout));
        NotifyPropertyChanged(nameof(SubmitButtonText));
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