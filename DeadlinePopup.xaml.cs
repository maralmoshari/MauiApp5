namespace MauiApp5;

using Android.Content.Res;
using CommunityToolkit.Maui.Views;

public partial class DeadlinePopup : Popup

{
	public DeadlinePopup()
	{
		InitializeComponent();
	}
    private void OnTimeSelected(object sender, EventArgs e)
    {
        // Display the selected time in the label
        SelectedTimeLabel.Text = "Selected Time: " + TimePickerControl.Time.ToString(@"hh\:mm");
    }
    

private void AcceptTime(object sender, EventArgs e)
    {
       Close();

    }
}