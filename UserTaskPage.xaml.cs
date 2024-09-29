using System.Collections.ObjectModel;

namespace MauiApp5;

public partial class UserTaskPage : ContentPage
{


    public ObservableCollection<Task> FilteredTasks { get; set; }
    public ObservableCollection<Task> Tasks { get; set; } // Using ObservableCollection for automatic updates

    public UserTaskPage()
    {
        InitializeComponent();
        FilteredTasks = new ObservableCollection<Task>(); // ???? ????? ???
        Tasks = new ObservableCollection<Task>();

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
            Tasks.Add(new Task(Ftitle, FDescription, FsingToUser, Fmanager, FpriviousTask, Fdeadline, FnextTask, FcoupleTask, Fpriority));
        }
        // ??? ???? ????? ?? ???? ????? ???
        foreach (var task in Tasks)
        {
            FilteredTasks.Add(task);
        }

        

        BindingContext = this;



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
    private void OnTaskPageSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        string searchText = e.NewTextValue.ToLower();
        FilterTaskPageTasks(searchText);
    }


    private void FilterTaskPageTasks(string searchText)
    {
        FilteredTasks.Clear();

        var filtered = Tasks.Where(t => t.Title.ToLower().Contains(searchText) ||
                                        t.Description.ToLower().Contains(searchText)).ToList();

        foreach (var task in filtered)
        {
            FilteredTasks.Add(task);
        }
    }


    private void OnTaskPageSortOptionChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;
        string selectedSortOption = picker.SelectedItem.ToString();

        SortTaskPageTasks(selectedSortOption);
    }


    private void SortTaskPageTasks(string sortOption)
    {
        var sortedList = new List<Task>();

        switch (sortOption)
        {
            case "Title":
                sortedList = FilteredTasks.OrderBy(t => t.Title).ToList();
                break;
            case "Description":
                sortedList = FilteredTasks.OrderBy(t => t.Description).ToList();
                break;
            case "Priority":
                sortedList = FilteredTasks.OrderBy(t => t.Priority).ToList();
                break;
        }

        FilteredTasks.Clear();
        foreach (var task in sortedList)
        {
            FilteredTasks.Add(task);
        }
    }

}
