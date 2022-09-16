namespace Moxitech_Tasklist_Open_Source;

public partial class SettingPage : ContentPage
{
	public SettingPage()
	{
		InitializeComponent();
	}

	private async void Back_Button_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("///MainPage");
	}
}