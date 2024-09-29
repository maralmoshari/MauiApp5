using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;

namespace MauiApp5;

public partial class DomainDetailPage : ContentPage
{
    public ObservableCollection<Task> Tasks { get; set; }
    public ObservableCollection<Task> FilteredTask { get; set; }
    public ObservableCollection<Group> Groups { get; set; }
    public ObservableCollection<Group> FilteredGroups { get; set; }
    public DomainDetailPage(Domain SelectedSubDomain)
	{
		InitializeComponent();
		BindingContext = SelectedSubDomain;
        Groups = new ObservableCollection<Group>();
        FilteredGroups = new ObservableCollection<Group>();
        string Fgroupname = "group1";
        string FGDescription = "This is a description.";

        for (int i = 0; i < 20; i++)
        {
            Groups.Add(new Group(Fgroupname, FGDescription));
        }

        //task
        Tasks = new ObservableCollection<Task>();
        FilteredTask = new ObservableCollection<Task>();

        string Ftitle = "task 1";
        string FDescription = "This is a description.";
        string FsingToUser = "gisoo";
        string Fmanager = "PEDRAM";
        string FpriviousTask = "TASK 2";
        string Fdeadline = " april 22 AT 12:00";
        string FnextTask = "TASK 3";
        string FcoupleTask = " TASK 4,5,6";
        int Fpriority = 50;




        for (int i = 0; i < 20; i++)
        {
            Tasks.Add(new Task(Ftitle, FDescription , FsingToUser , Fmanager, FpriviousTask , Fdeadline, FnextTask, FcoupleTask , Fpriority));
        }


        BindingContext = this;

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

        GroupCollectionView.ItemsSource = FilteredGroups;
    }

    private void OnSortOptionChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        var selectedSortOption = picker.SelectedItem.ToString();

        var sortedGroups = selectedSortOption switch
        {
            "Group Name" => Groups.OrderBy(g => g.Groupname).ToList(),
            "Job Title" => Groups.OrderBy(g => g.Groupname).ToList(),
            _ => Groups.ToList()
        };

        FilteredGroups.Clear();
        foreach (var group in sortedGroups)
        {
            FilteredGroups.Add(group);
        }

        GroupCollectionView.ItemsSource = FilteredGroups;
    }
    //sort search for task
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

    private async void OnDomainGroupSelected(object sender, SelectionChangedEventArgs e)
    {
        var SelectedDomainGroup = e.CurrentSelection.FirstOrDefault() as Group;
        if (SelectedDomainGroup != null)
        {
            await Navigation.PushAsync(new GroupDetailsPage(SelectedDomainGroup));
            // Reset selection to avoid re-triggering the same item
            ((CollectionView)sender).SelectedItem = null;
        }
    }
    private async void OnDomainTaskSelected(object sender, SelectionChangedEventArgs e)
    {
        var SelectedDomainTask = e.CurrentSelection.FirstOrDefault() as Task;
        if (SelectedDomainTask != null)
        {
            await Navigation.PushAsync(new TaskDeatailsPage(SelectedDomainTask));
            // Reset selection to avoid re-triggering the same item
            ((CollectionView)sender).SelectedItem = null;
        }
    }

    private void AddGroup(object sender, EventArgs e)
    {
        var popup = new GroupPopupPage();
        this.ShowPopup(popup);
    }
    private void AddTask(object sender, EventArgs e)
    {
        var popup = new TaskPopup();
        this.ShowPopup(popup);
    }
}