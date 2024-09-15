using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;

namespace MauiApp5;

public partial class PrerequisitePage : Popup
{
    public ObservableCollection<Member> Members { get; set; }

    public PrerequisitePage()
	{
		InitializeComponent();
        Members = new ObservableCollection<Member>();

        string FUsername = "User1";
        string FDescription = "This is a description.";
        string ImageSource = "Resources/Images/account.png";
        string Fjobtitle = "manager";
        string Fphonenumber = "0901090827";

        for (int i = 0; i < 20; i++)
        {
            Members.Add(new Member(FUsername, FDescription, ImageSource, Fjobtitle, Fphonenumber));
        }

        BindingContext = this;
    }
    private async void OnMemberSelected(object sender, SelectionChangedEventArgs e)
    {
        // var selectedMember = e.CurrentSelection.FirstOrDefault() as Member;
        // if (selectedMember != null)
        // {
        //     //await Navigation.PushAsync(new MemberDetailsPage(selectedMember));
        //     
        //     // Reset selection to avoid re-triggering the same item
        //     ((CollectionView)sender).SelectedItem = null;
        // }
    }
    private async void OnPickFileClicked(object sender, EventArgs e)
    {
        try
        {
            var result = await FilePicker.PickAsync();
            if (result != null)
            {
                var filePath = result.FullPath;
                await Application.Current.MainPage.DisplayAlert("فایل انتخاب شده", filePath, "باشه");
            }
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("خطا", "خطایی رخ داده است: " + ex.Message, "باشه");
        }
    }
    
     private void AddPrrequisite(object sender, EventArgs e)
    {
         //Navigation.PopAsync();

    }
    
     private void AddUserToTask(object sender, EventArgs e)
    {
       

    }
}