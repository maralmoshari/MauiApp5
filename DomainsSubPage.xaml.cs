

using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;

namespace MauiApp5;

public partial class DomainsSubPage : ContentPage
{
    public ObservableCollection<Domain> Domains { get; set; }
    public ObservableCollection<Domain> FilteredSubDomains { get; set; }
    public ObservableCollection<Task> Tasks { get; set; }
    public ObservableCollection<Task> FilteredTask { get; set; }


    public DomainsSubPage(Domain SelectedDomain)
	{

		InitializeComponent();
		BindingContext = SelectedDomain;
        Domains = new ObservableCollection<Domain>();
        FilteredSubDomains = new ObservableCollection<Domain>();

        string Ftitle = "sub domain ";
        string FDescription = "This is a description.";


        for (int i = 0; i < 20; i++)
        {
            Domains.Add(new Domain(Ftitle, FDescription));
        }
        // Initially set filtered subdomains to all domains
        FilteredSubDomains = new ObservableCollection<Domain>(Domains);

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
    private async void OnSubDomainSelect(object sender, SelectionChangedEventArgs e)
    {
       var SelectedSubDomain = e.CurrentSelection.FirstOrDefault() as Domain;
       if (SelectedSubDomain != null)
       {
           await Navigation.PushAsync(new DomainDetailPage(SelectedSubDomain));
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
    private void AddTask(object sender, EventArgs e)
    {
        this.ShowPopup(new TaskPopup());


    }

    private void AddSubDomain(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NewDomainPage());
    }

    //ssssssssss

    // Method to handle text changes in the SearchBar for filtering
    private void OnSubDomainSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        string searchText = e.NewTextValue.ToLower();
        FilterSubDomains(searchText);
    }

    // Method to filter subdomains based on search text
    private void FilterSubDomains(string searchText)
    {
        FilteredSubDomains.Clear();

        var filtered = Domains.Where(d => d.Title.ToLower().Contains(searchText) ||
                                          d.Description.ToLower().Contains(searchText)).ToList();

        foreach (var subdomain in filtered)
        {
            FilteredSubDomains.Add(subdomain);
        }
    }

    // Method to handle sorting option change
    private void OnSubDomainSortOptionChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;
        string selectedSortOption = picker.SelectedItem.ToString();

        SortSubDomains(selectedSortOption);
    }

    // Method to sort subdomains based on the selected sorting option
    private void SortSubDomains(string sortOption)
    {
        var sortedList = new List<Domain>();

        switch (sortOption)
        {
            case "Title":
                sortedList = FilteredSubDomains.OrderBy(d => d.Title).ToList();
                break;
            case "Description":
                sortedList = FilteredSubDomains.OrderBy(d => d.Description).ToList();
                break;
        }

        // Clear current filtered list and add sorted subdomains
        FilteredSubDomains.Clear();
        foreach (var subdomain in sortedList)
        {
            FilteredSubDomains.Add(subdomain);
        }
    }


}