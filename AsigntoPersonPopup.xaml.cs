using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;

namespace MauiApp5;

public partial class AsigntoPersonPopup : Popup
{
    public ObservableCollection<Group> Groups { get; set; }
    public ObservableCollection<Member> Members { get; set; }
    public AsigntoPersonPopup()
	{
		InitializeComponent();

        Groups = new ObservableCollection<Group>();



        string Fgroupname = "group1";
        string FDescription = "This is a description.";



        for (int i = 0; i < 20; i++)
        {
            Groups.Add(new Group(Fgroupname, FDescription));
        }

        //user
        Members = new ObservableCollection<Member>();
        int MemberCount = 20;
        string FFname = "maral";
        string FLname = "moshari";
        string FUsername = "User1";
        string FUDescription = "This is a description.";
        string ImageSource = "Resources/Images/account.png";
        string Fjobtitle = "manager";
        string Fphonenumber = "0901090827";
        string Fkodmeli = "0927043187";


        for (int i = 0; i < MemberCount; i++)
        {
            Members.Add(new Member(FFname, FLname, FUsername, FUDescription, ImageSource, Fjobtitle, Fphonenumber , Fkodmeli));
        }

        BindingContext = this;

    }
    private async void OnGroupSelected(object sender, SelectionChangedEventArgs e)
    {
        var SelectedGroup = e.CurrentSelection.FirstOrDefault() as Group;
        if (SelectedGroup != null)
        {
           // await Navigation.PushAsync(new GroupDetailsPage(SelectedGroup));
           // // Reset selection to avoid re-triggering the same item
           // ((CollectionView)sender).SelectedItem = null;
        }
    }

    private async void OnMemberSelected(object sender, SelectionChangedEventArgs e)
    {
        var selectedMember = e.CurrentSelection.FirstOrDefault() as Member;
        if (selectedMember != null)
        {
            //await Navigation.PushAsync(new MemberDetailsPage(selectedMember));
            //// Reset selection to avoid re-triggering the same item
            //((CollectionView)sender).SelectedItem = null;
        }
    }

}