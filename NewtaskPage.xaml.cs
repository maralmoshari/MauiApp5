using CommunityToolkit.Maui.Views;

namespace MauiApp5;

public partial class NewtaskPage : ContentPage
{
	public NewtaskPage()
	{
		InitializeComponent();
	}
    private void ChooseUser(object sender, EventArgs e)
    {
        var popup = new UserPopup();
        this.ShowPopup(popup);

    }
    private void ChooseManager(object sender, EventArgs e)
    {

        var popup = new UserPopup();
        this.ShowPopup(popup);
    }
    private void ChooseDeadline(object sender, EventArgs e)
    {

        var popup = new DeadlinePopup();
        this.ShowPopup(popup);
    }
    private void ChoosePrerequisite(object sender, EventArgs e)
    {


    }
    private void ChooseNextTask(object sender, EventArgs e)
    {
        this.ShowPopup(new TaskPopup());

    }

    private void ChooseCouple(object sender, EventArgs e)
    {
        this.ShowPopup(new TaskPopup());

    }
    private void ChoosePriority(object sender, EventArgs e)
    {
        var popup = new PriorityPopup();
        this.ShowPopup(popup);

    }
    private void Choosecreatedby(object sender, EventArgs e)
    {
        var popup = new UserPopup();
        this.ShowPopup(popup);


    }
    private void ChoosePreTask(object sender, EventArgs e)
    {
        this.ShowPopup(new TaskPopup());

    }

    private void AddNewTask(object sender, EventArgs e)
    {
        Navigation.PopAsync();

    }

}