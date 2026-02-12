namespace TshirtFormMockup;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnMenuClick(object sender, EventArgs e)
	{
		if (sender is not MenuFlyoutItem item || item.CommandParameter is not string action)
		{
			return;
		}

		if (action == "File/Exit")
		{
			Application.Current?.Quit();
			return;
		}

		if (action == "Help/About")
		{
			AboutOverlay.IsVisible = true;
			return;
		}

		await DisplayAlert("Menu", $"{action} selected", "OK");
	}

	private void OnAboutCloseClicked(object sender, EventArgs e)
	{
		AboutOverlay.IsVisible = false;
	}

	private void OnAboutOverlayTapped(object sender, TappedEventArgs e)
	{
		AboutOverlay.IsVisible = false;
	}
}

