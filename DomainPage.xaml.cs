using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;

namespace MauiApp5;

public partial class DomainPage : ContentPage
{

    public ObservableCollection<Domain> FilteredDomains { get; set; }
    public ObservableCollection<Domain> Domains { get; set; }
    public ObservableCollection<Task> Tasks { get; set; }
    public ObservableCollection<Task> FilteredTask { get; set; }

    public DomainPage()
    {
        InitializeComponent();

        Domains = new ObservableCollection<Domain>();
        FilteredDomains = new ObservableCollection<Domain>();


        string Ftitle = "domain 1";
        string FDescription = "This is a description.";


        for (int i = 0; i < 20; i++)
        {
            Domains.Add(new Domain(Ftitle, FDescription));
        }


        ///task

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

        BindingContext = this;

    }
    private bool isSwipeAction = false;

    private bool isSwiping = false; // To track if swipe is happening

    private void OnSwipeStarted(object sender, EventArgs e)
    {
        isSwiping = true; // Indicate that swiping is in progress
    }

    private void OnSwipeEnded(object sender, EventArgs e)
    {
        isSwiping = false; // Indicate that swiping has ended
    }



    // Swipe Command Handler (bind this to the Swipe command in the XAML)
    private void OnSwipeAction(object sender, EventArgs e)
           {
               isSwipeAction = true;
           }
 //ON DOMAIN AND TASK SELECTED
    private async void OnDomainSelect(object sender, SelectionChangedEventArgs e)
    {
        // If swiping, ignore the selection
        if (isSwiping)
        {
            return; // Skip selection
        }

        // Handle selection
        var SelectedDomain = e.CurrentSelection.FirstOrDefault() as Domain;
        if (SelectedDomain != null)
        {
            await Navigation.PushAsync(new DomainsSubPage(SelectedDomain));

            // Reset selection to avoid re-triggering the same item
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
 //SEARCH AND SORT DOMAIN
    private void OnSearchBarTextDomain(object sender, TextChangedEventArgs e)
    {
        string searchText = e.NewTextValue?.ToLower() ?? string.Empty;

        FilteredDomains.Clear();

        foreach (var domain in Domains)
        {
            if (domain.Title.ToLower().Contains(searchText) ||
                domain.Description.ToLower().Contains(searchText))
            {
                FilteredDomains.Add(domain);
            }
        }

        DomainCollectionView.ItemsSource = FilteredDomains;
    }

    private void OnSortOptionDomain(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        var selectedSortOption = picker.SelectedItem.ToString();

        var sortedDomain = selectedSortOption switch
        {
            "Title" => Domains.OrderBy(d => d.Title).ToList(),
            "Description" => Domains.OrderBy(d => d.Title).ToList(),
            _ => Domains.ToList()
        };

        FilteredDomains.Clear();
        foreach (var domain in sortedDomain)
        {
            FilteredDomains.Add(domain);
        }

        DomainCollectionView.ItemsSource = FilteredDomains;
    }
 //SEARCH AND SORT TASKKKK
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
    //OTHER
    private void AddTask(object sender, EventArgs e)
    {
        this.ShowPopup(new TaskPopup());


    }

    private void AddNewDomain(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NewDomainPage());
    }

}
