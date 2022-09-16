
namespace Moxitech_Tasklist_Open_Source;

public partial class TaskView : ContentView
{
	public bool TrueState = false;
	public System.Action<int> deleteThisDo;
	public static int Id = 0;
	internal int id;

	public TaskView(string Text, System.Action<int> deleteDo)
	{
		InitializeComponent();
		LabelOfTask.Text = Text;
		id = Id;
		Id++;
		this.deleteThisDo = deleteDo;
	}

	private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		if (e.Value)
		{ 
			TrueState = true;
			
		}
		else 
		{ 
			TrueState = false;
		}
	}
	

	private void DeleteBtnClicked(object sender, EventArgs e)
	{
		deleteThisDo(id);
	}

	~TaskView()
	{
		Id--;
	}
	
}