using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;

namespace MauiApp5;

public partial class GroupDetailsPage : ContentPage
{
    public ObservableCollection<Member> Members { get; set; }
    public ObservableCollection<Member> FilteredMember { get; set; }
    public ObservableCollection<Task> Tasks { get; set; }
    public ObservableCollection<Task> FilteredTask { get; set; }

    public GroupDetailsPage(Group SelectedGroup)
    {
        InitializeComponent();
        BindingContext = SelectedGroup;

        Tasks = new ObservableCollection<Task>();
        FilteredTask = new ObservableCollection<Task>();

        string FTtitle = "task 1";
        string FTDescription = "This is a description.";
        string FsingToUser = "gisoo";
        string Fmanager = "PEDRAM";
        string FpriviousTask = "TASK 2";
        string Fdeadline = " april 22 AT 12:00";
        string FnextTask = "TASK 3";
        string FcoupleTask = " TASK 4,5,6";
        int Fpriority = 50;





        for (int i = 0; i < 20; i++)
        {
            Tasks.Add(new Task(FTtitle, FTDescription, FsingToUser, Fmanager, FpriviousTask, Fdeadline, FnextTask, FcoupleTask, Fpriority));
        }


        //BindingContext = this;
        //
        //CollectionView collectionView = new CollectionView();
        //collectionView.SetBinding(ItemsView.ItemsSourceProperty, nameof(Tasks));



        Members = new ObservableCollection<Member>();
        FilteredMember = new ObservableCollection<Member>();
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
            Members.Add(new Member(FFname, FLname, FUsername, FUDescription, ImageSource, Fjobtitle, Fphonenumber, Fkodmeli));
        }

        //this will complete all the collectionviews :)
        BindingContext = this;

 
    }




    //SEARCH AND SORT TASK
    private void OnSearchBarTask(object sender, TextChangedEventArgs e)
    {
        string searchText = e.NewTextValue?.ToLower() ?? string.Empty;

        FilteredTask.Clear();

        foreach (var task in Tasks)
        {
            if (task.Title.ToLower().Contains(searchText) ||
                task.Description.ToLower().Contains(searchText))
            {
                FilteredTask.Add(task);
            }
        }

        TaskCollectionView.ItemsSource = FilteredTask;
    }

    private void OnSortOptionTask(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        var selectedSortOption = picker.SelectedItem.ToString();

        var sortedTask = selectedSortOption switch
        {
            "Task Name" => Tasks.OrderBy(t => t.Title).ToList(),
            "Job Title" => Tasks.OrderBy(t => t.Description).ToList(),
            _ => Tasks.ToList()
        };

        FilteredTask.Clear();
        foreach (var task in sortedTask)
        {
            FilteredTask.Add(task);
        }

        TaskCollectionView.ItemsSource = FilteredTask;
    }

    //SEARCH AND SORT userrrrrrrr
    private void OnSearchBaruser(object sender, TextChangedEventArgs e)
    {
        string searchText = e.NewTextValue?.ToLower() ?? string.Empty;

        FilteredMember.Clear();

        foreach (var member in Members)
        {
            if (member.Username.ToLower().Contains(searchText) ||
                member.JobTitle.ToLower().Contains(searchText))
            {
                FilteredMember.Add(member);
            }
        }

        UserCollectionView.ItemsSource = FilteredMember;
    }

    private void OnSortOptionUser(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        var selectedSortOption = picker.SelectedItem.ToString();

        var sortedUser = selectedSortOption switch
        {
            "Username" => Members.OrderBy(m => m.Username).ToList(),
            "Job Title" => Members.OrderBy(m => m.JobTitle).ToList(),
            _ => Members.ToList()
        };

        FilteredMember.Clear();
        foreach (var member in sortedUser)
        {
            FilteredMember.Add(member);
        }

        UserCollectionView.ItemsSource = FilteredMember;
    }





    //selected task and mwmber
    private async void OnTaskSelected(object sender, SelectionChangedEventArgs e)
    {
        var SelectedTask = e.CurrentSelection.FirstOrDefault() as Task;
        if (SelectedTask != null)
        {
            await Navigation.PushAsync(new TaskDeatailsPage(SelectedTask));
            // Reset selection to avoid re-triggering the same item
            ((CollectionView)sender).SelectedItem = null;
        }
    }
    private async void OnMemberSelected(object sender, SelectionChangedEventArgs e)
    {
        var selectedMember = e.CurrentSelection.FirstOrDefault() as Member;
        if (selectedMember != null)
        {
            await Navigation.PushAsync(new MemberDetailsPage(selectedMember));
            ((CollectionView)sender).SelectedItem = null;
        }
    }

    //other function
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