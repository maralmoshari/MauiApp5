using CommunityToolkit.Maui.Views;

namespace MauiApp5;

public partial class DescriptionPopup : Popup
{
	public DescriptionPopup()
	{
		InitializeComponent();
	}
    
     private void SaveDescription(object sender, EventArgs e)
    {
        Close();

    }
}