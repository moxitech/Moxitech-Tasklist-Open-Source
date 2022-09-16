
namespace Moxitech_Tasklist_Open_Source;

public partial class MainPage : ContentPage
{
	public delegate void deleteDo(int id);
	public MainPage()
	{
		InitializeComponent();
		deleteDo deldo;
		deldo = DeleteDo;
		var allTask = loadAllTask();
		foreach (var item in allTask)
		{
			TaskList.Add(item);
		}
	}

    private async void Button_Clicked_1(object sender, EventArgs e)
	{
        string res = await DisplayPromptAsync("Создать задачу", "Введите текст задачи");
		if (res != "" && res != null)
		{
			var deldo = DeleteDo;
            TaskList.Add(new TaskView(res, deldo));
			
		}
	}
	internal void DeleteDo(int id)
	{
		if(id == 0)
		{
			TaskList.Clear();
		}
		TaskList.RemoveAt(id);
	}
	private async void Setting_Button_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("///SettingPage");
	}


	//public void flushAllChanges() { }
	public List<TaskView> loadAllTask()
	{
		List<TaskView> taskList = new List<TaskView>();	
		try
		{
			using (FileStream fs = new FileStream("./content.txt", FileMode.Open, FileAccess.ReadWrite))
			{
				using (StreamReader sr = new StreamReader(fs))
				{
                    var deldo = DeleteDo;
                    TaskView taskView = new TaskView(sr.ReadLine(), deldo);
				}
			}
		}
		catch(Exception e)
		{
            using (FileStream fs = new FileStream("./content.txt", FileMode.Create))
            {

            }
        }
		return taskList;
	} 
}

