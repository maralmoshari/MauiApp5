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
       var popup = new GroupPopupPage();
        this.ShowPopup(popup);

    }
    private void ChooseDomain(object sender, EventArgs e)
    {
         var popup = new DomainPopup();
        this.ShowPopup(popup);

    }
    private void AddNewUser(object sender , EventArgs e)
    {
        Navigation.PopAsync();
    }
}