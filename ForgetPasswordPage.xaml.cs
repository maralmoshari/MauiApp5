namespace MauiApp5;

public partial class ForgetPasswordPage : ContentPage
{
	public ForgetPasswordPage()
	{
		InitializeComponent();
	}
    string Tempnumber = "0915";
    string Tempnational = "092";
    private void AcceptButton(object sender, EventArgs e)
    {
        string Number = NumbberEntry.Text;
        string National = NationalCodeEntry.Text;

        if (Number == Tempnumber && National == Tempnational)
        {
            App.Current.MainPage = new SmsPage();
        }
        else
        {
            DisplayAlert("Stupid", "UserName or Password Wrong :/", "ok");
        }
    }


}