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

        this.ShowPopup(new NGUserPopup());

    }
    private void ChooseDomain(object sender, EventArgs e)
    {
         var popup = new DomainPopup();
         this.ShowPopup(popup);


    }

    private void AddNewGroup(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
    private void DescriptionButton(object sender, EventArgs e)
    {

        this.ShowPopup(new DescriptionPopup()); ;

    }
}