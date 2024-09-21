namespace MauiApp5;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
    string tempUsername = "m";
    string tempPassword = "12";
    private void PasswordShow(object sender, EventArgs e)
    {
        passwordEntry.IsPassword = !passwordEntry.IsPassword;
    }
    private void LoginButton(object sender, EventArgs e)
    {
        string username = userNameEntry.Text;
        string password = passwordEntry.Text;

        if (username == tempUsername && password == tempPassword)
        {
            App.Current.MainPage = new SmsPage();
        }
        else
        {
            DisplayAlert("Stupid", "UserName or Password Wrong :/", "Bedeh SHihs");
        }
    }

    private void forgotPasswordButton(object sender, EventArgs e)
    {
        App.Current.MainPage = new ForgetPasswordPage();
    }
}