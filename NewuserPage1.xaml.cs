using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Storage;

namespace MauiApp5;

public partial class NewuserPage1 : ContentPage
{
	public NewuserPage1()
	{
		InitializeComponent();
	}

    private void ChooseGroup(object sender, EventArgs e)
    {
       var popup = new NUGroupPopup();
        this.ShowPopup(popup);

    }

    private void AddNewUser(object sender , EventArgs e)
    {
        Navigation.PopAsync();
    }
    private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        if (RolePicker.SelectedIndex != -1)
        {
            string selectedRole = RolePicker.Items[RolePicker.SelectedIndex];
            SelectedRoleLabel.Text = $"Selected Role: {selectedRole}";
        }
    }
    private void DescriptionButton(object sender, EventArgs e)
    {

        this.ShowPopup(new DescriptionPopup());

    }
}