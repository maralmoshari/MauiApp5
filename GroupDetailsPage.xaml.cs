using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;

namespace MauiApp5;

public partial class GroupDetailsPage : ContentPage
{
    public ObservableCollection<Member> Members { get; set; }

    public ObservableCollection<Task> Tasks { get; set; }

    public GroupDetailsPage(Group SelectedGroup)
    {
        InitializeComponent();
        BindingContext = SelectedGroup;

        Tasks = new ObservableCollection<Task>();

        string Ftitle = "task 1";
        string FDescription = "This is a description.";


        for (int i = 0; i < 20; i++)
        {
            Tasks.Add(new Task(Ftitle, FDescription));
        }


        //BindingContext = this;
        //
        //CollectionView collectionView = new CollectionView();
        //collectionView.SetBinding(ItemsView.ItemsSourceProperty, nameof(Tasks));



        Members = new ObservableCollection<Member>();

        string FUsername = "User1";
        string FuserDescription = "This is a description.";
        string ImageSource = "Resources/Images/account.png";
        string Fjobtitle = "manager";
        string Fphonenumber = "0901090827";

        for (int i = 0; i < 20; i++)
        {
            Members.Add(new Member(FUsername, FuserDescription, ImageSource, Fjobtitle, Fphonenumber));
        }

        //this will complete all the collectionviews :)
        BindingContext = this;

 
    }
    private void AddTask(object sender, EventArgs e)
    {
        this.ShowPopup(new TaskPopup());


    }
    private void AddUser(object sender, EventArgs e)
    {
        
            var popup = new UserPopup();
            this.ShowPopup(popup);


        
    }
}