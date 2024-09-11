using CommunityToolkit.Maui.Views;

namespace MauiApp5;

public partial class NewGroupPage : ContentPage
{
	public NewGroupPage()
	{
		InitializeComponent();
	}

    private void AddMember(object sender, EventArgs e)
    {

    }
    private void ChooseDomain(object sender, EventArgs e)
    {

    }

    private void AddNewGroup(object sender, TappedEventArgs e)
    {
        Navigation.PopAsync();
    }
}