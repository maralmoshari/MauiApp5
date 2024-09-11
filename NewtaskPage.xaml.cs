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
        

    }
    private void ChoosePrerequisite(object sender, EventArgs e)
    {


    }
    private void ChooseTask(object sender, EventArgs e)
    {


    }
    private void ChooseCouple(object sender, EventArgs e)
    {


    }
    private void ChoosePriority(object sender, EventArgs e)
    {


    }
    private void AddNewTask(object sender, EventArgs e)
    {
        Navigation.PopAsync();

    }

}