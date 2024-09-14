namespace MauiApp5;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();
	}
    private void EditProfile(object sender, EventArgs e)
    {
        Navigation.PopAsync();

    }
}