using CommunityToolkit.Maui.Views;

namespace MauiApp5;

public partial class NewtaskPage : ContentPage
{
	public NewtaskPage()
	{
		InitializeComponent();
	}
    private void ChooseAsign(object sender, EventArgs e)
    {
        var popup = new AsigntoPersonPopup();
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

        this.ShowPopup(new PrerequisitePage());
    }
    private void ChoosSleeptime(object sender, EventArgs e)
    {
        this.ShowPopup(new SleepTimePopup());

    }

    private void ChooseCouple(object sender, EventArgs e)
    {
        this.ShowPopup(new TaskPopup());

    }
    private void ChoosePriority(object sender, EventArgs e)
    {
        this.ShowPopup(new PriorityPopup());

    }
    //private void Choosecreatedby(object sender, EventArgs e)
    //{
    //    var popup = new UserPopup();
    //    this.ShowPopup(popup);
    //
    //
    //}
    private void ChoosePreNTask(object sender, EventArgs e)
    {
        this.ShowPopup(new PreOrNextTaskPopup());

    }

    private void AddNewTask(object sender, EventArgs e)
    {
        Navigation.PopAsync();

    }
    private void DescriptionButton(object sender, EventArgs e)
    {

        this.ShowPopup(new DescriptionPopup()); 

    }

}