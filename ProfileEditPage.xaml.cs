namespace MauiApp5;

public partial class ProfileEditPage : ContentPage
{
    public ProfileEditPage()
    {
        InitializeComponent();
    }
    private void EditProfile(object sender, EventArgs e)
    {
        Navigation.PopAsync();

    }
}