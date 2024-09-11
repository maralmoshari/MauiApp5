using CommunityToolkit.Maui.Views;

namespace MauiApp5;

public partial class NewuserPage1 : ContentPage
{
	public NewuserPage1()
	{
		InitializeComponent();
	}

    private void ChooseGroup(object sender, EventArgs e)
    {
        var popup = new GroupPopup();
        this.ShowPopup(popup);

    }
    private void ChooseDomain(object sender, EventArgs e)
    {

    }
    private void AddNewUser(object sender , EventArgs e)
    {
        Navigation.PopAsync();
    }
}