
using System.Collections.ObjectModel;

namespace Moxitech_Tasklist_Open_Source;

public partial class MainPage : ContentPage
{
	public string content = FileSystem.Current.AppDataDirectory + "/content.txt";
	public delegate void deleteDo(int id);
	public MainPage()
	{
		InitializeComponent();
		//deleteDo deldo;
		var deldo1 = DeleteDo;
		TaskView taskView1 = new TaskView("Hello ", deldo1);
		var allTask = loadAllTask();
        foreach (var item in allTask)
        {
        	TaskList.Add(item);
        }
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
	{
		/*
		 *	Создание новой задачи
		 *								**/
        string res = await DisplayPromptAsync("Создать задачу", "Введите текст задачи");
		if (res != "" && res != null)
		{
			var deldo = DeleteDo;
            TaskList.Add(new TaskView(res, deldo));
		}
    }
    internal void DeleteDo(int id)
	{
		/*
		 * Удаление задачи по id
		 * **/
		--id;
		if (TaskList.Count == 0)
		{
			TaskList.Clear();
		}
		else if (TaskList.Count == 1)
		{
			TaskList.Clear();
		}
		else
		{
			TaskList.RemoveAt(id);
		}
		}
	private async void Setting_Button_Clicked(object sender, EventArgs e)
	{
		/*
		 * Переход к настройкам
		 * **/
		await Shell.Current.GoToAsync("///SettingPage");
	}
	public List<TaskView> loadAllTask()
	{
		/*
		 * Загрузка всех задач из файла
		 * 
		 * **/
		List<TaskView> taskList = new List<TaskView>();	
		try
		{
			using (FileStream fs = new FileStream(content, FileMode.Open, FileAccess.ReadWrite))
			{
				using (StreamReader sr = new StreamReader(fs))
				{
                    var deldo = DeleteDo;
					while (!sr.EndOfStream)
					{
						TaskView taskView = new TaskView(sr.ReadLine(), deldo);
						taskList.Add(taskView);
					}
				}
			}
		}
		catch(Exception)
		{
            using (FileStream fs = new FileStream(content , FileMode.Create))
            {

            }
        }
		return taskList;
	}
    public void flushAllChanges(IView[] taskViews)
    {
		/*
		 *	Запись всех изменений в файл
		 * 
		 * **/
		using (FileStream fs = new FileStream(content, FileMode.OpenOrCreate, FileAccess.ReadWrite))
		{
			using (StreamWriter sw = new StreamWriter(fs))
			{
				foreach (var item in taskViews)
				{
					var titem = (TaskView)item;
					sw.WriteLine(titem.Text);
				}
			}
		}
	}

	private void Save_Button_Clicked(object sender, EventArgs e)
	{
        flushAllChanges(TaskList.ToArray());
    }
}

