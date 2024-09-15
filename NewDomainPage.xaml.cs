using CommunityToolkit.Maui.Views;

namespace MauiApp5;

public partial class NewDomainPage : ContentPage
{
    public NewDomainPage()
    {
        InitializeComponent();
    }
    private void ChooseeDomain(object sender, EventArgs e)
    {
        var popup = new DomainPopup();
        this.ShowPopup(popup);


    }
    private void AdddMember(object sender, EventArgs e)
    {

        this.ShowPopup(new UserPopup());

    }
    private void AddNewDomain(object sender, EventArgs e)
    {

        Navigation.PushAsync(new DomainPage()); ;

    }


}