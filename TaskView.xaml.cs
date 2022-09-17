
namespace Moxitech_Tasklist_Open_Source;

public partial class TaskView : ContentView
{
	public string Text { get; set; }
	public bool TrueState = false;
	private System.Action<int> deleteThisDo;
	public static int Id = 0;
	public int id { get; set; }

    public TaskView(string Text, System.Action<int> deleteDo)
	{
		InitializeComponent();
		this.Text = Text;
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
	public override string ToString()
	{
		return LabelOfTask.Text.ToString();
	}
	~TaskView()
	{
		Id--;
	}
}