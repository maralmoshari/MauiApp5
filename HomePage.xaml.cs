namespace MauiApp5;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}
    private void groupButton(object sender, EventArgs e)
    {
        Navigation.PushAsync(new GroupPage());
    }

    private void peopleButton(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PeoplePage()); ;

    }

    private void domainButton(object sender, EventArgs e)
    {
        Navigation.PushAsync(new DomainPage()); ;
    }

    private void taskButton(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TaskPage());

    }
    
}