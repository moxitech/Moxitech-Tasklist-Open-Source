using Microsoft.Maui.Controls;

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

	private void Color_Change_Picker(object sender, EventArgs e)
	{
		string color = ColorPicker.SelectedItem.ToString();
		switch (color)
		{
			case "Темная тема":
				
				break;

            case "Светлая тема":
                break;

            case "Летняя тема":
                break;

            case "Зимняя тема":
                break;
			default:

				break;
        }
	}
}