namespace TshirtFormMockup;

#nullable enable

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		var window = base.CreateWindow(activationState);
		window.Title = "Mom™ Pro v 1.0";

		#if WINDOWS
		window.Created += (sender, args) =>
		{
			var nativeWindow = window.Handler?.PlatformView as Microsoft.UI.Xaml.Window;
			if (nativeWindow is null)
			{
				return;
			}

			var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
			var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hwnd);
			var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
			appWindow?.Resize(new Windows.Graphics.SizeInt32(1280, 1024));
		};
		#endif

		return window;
	}
}
