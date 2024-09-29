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
        int MemberCount = 20;
        string FFname = "maral";
        string FLname = "moshari";
        string FUsername = "User1";
        string FDescription = "This is a description.";
        string ImageSource = "Resources/Images/account.png";
        string Fjobtitle = "manager";
        string Fphonenumber = "0901090827";
        string Fkodmeli = "0927043187";


        for (int i = 0; i < MemberCount; i++)
        {
            Members.Add(new Member(FFname, FLname, FUsername, FDescription, ImageSource, Fjobtitle, Fphonenumber, Fkodmeli));
        }

        BindingContext = this;
    }
    private void OnMemberSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count > 0)
        {
            var selectedUser = e.CurrentSelection[0] as Member;

            // تغییر وضعیت IsEntryVisible
            selectedUser.IsEntryVisible = !selectedUser.IsEntryVisible;

            // در صورت تمایل، سایر کاربران را مخفی کنید
            foreach (var member in Members)
            {
                if (member != selectedUser)
                {
                    member.IsEntryVisible = false;
                }
            }

            // به‌روزرسانی نمایش
            OnPropertyChanged(nameof(Members));
        }
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
        Close();


    }

    
    //  private void AddUserToTask(object sender, EventArgs e)
    // {
    //    
    //     Close();
    // }
}