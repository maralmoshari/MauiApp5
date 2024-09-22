namespace MauiApp5;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;

public partial class GroupPage : ContentPage
{
    public ObservableCollection<Group> Groups { get; set; }
    public ObservableCollection<Task> Tasks { get; set; }
    public ObservableCollection<Group> FilteredGroups { get; set; }

    public GroupPage()
    {
        InitializeComponent();

        Groups = new ObservableCollection<Group>();
        FilteredGroups = new ObservableCollection<Group>();

        string Fgroupname = "group1";
        string FDescription = "This is a description.";

        for (int i = 0; i < 20; i++)
        {
            Groups.Add(new Group($"{Fgroupname} {i + 1}", FDescription));
        }
        FilteredGroups = new ObservableCollection<Group>(Groups);
        CollectionView.ItemsSource = FilteredGroups;

        ///task

        Tasks = new ObservableCollection<Task>();

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
        BindingContext = this;

    }

    private async void OnGroupSelected(object sender, SelectionChangedEventArgs e)
    {
        var SelectedGroup = e.CurrentSelection.FirstOrDefault() as Group;
        if (SelectedGroup != null)
        {
            await Navigation.PushAsync(new GroupDetailsPage(SelectedGroup));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
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

    private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
    {
        string searchText = e.NewTextValue?.ToLower() ?? string.Empty;

        FilteredGroups.Clear(); 
 
        foreach (var group in Groups)
        {
            if (group.Groupname.ToLower().Contains(searchText) || 
                group.Description.ToLower().Contains(searchText))
            {
                FilteredGroups.Add(group);
            }
        } 
 
        CollectionView.ItemsSource = FilteredGroups;
    }

    private void OnSortOptionChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        var selectedSortOption = picker.SelectedItem.ToString();

        var sortedGroups = selectedSortOption switch
        {
            "Username" => Groups.OrderBy(g => g.Groupname).ToList(),
            "First Name" => Groups.OrderBy(g => g.Description).ToList(), // Adjust based on actual properties
            "Job Title" => Groups.OrderBy(g => g.Groupname).ToList(), // Adjust if needed
            _ => Groups.ToList()
        };

        FilteredGroups.Clear();
        foreach (var group in sortedGroups)
        {
            FilteredGroups.Add(group);
        } 
 
        CollectionView.ItemsSource = FilteredGroups;
    }
    private void AddTask(object sender, EventArgs e)
    {
        this.ShowPopup(new TaskPopup());


    }
    private async void Addnewgroup(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewGroupPage());
    }
}
