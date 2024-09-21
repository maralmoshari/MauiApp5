using CommunityToolkit.Maui.Views;

namespace MauiApp5;

public partial class SleepTimePopup : Popup
{
	public SleepTimePopup()
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