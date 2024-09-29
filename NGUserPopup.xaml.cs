using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;

namespace MauiApp5;

public partial class NGUserPopup : Popup
{
    public ObservableCollection<Member> Members { get; set; }

    public NGUserPopup()
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
    private void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            // عملیات برای زمانی که CheckBox تیک خورده است
        }
        else
        {
            // عملیات برای زمانی که CheckBox تیک نخورده است
        }
    }
    private void Chooseuser(object sender, EventArgs e)
    {
        Close();

    }
}
