using System.Collections.ObjectModel;

namespace MauiApp5;

public partial class UserTaskPage : ContentPage
{



    public ObservableCollection<Task> Tasks { get; set; } // Using ObservableCollection for automatic updates

    public UserTaskPage()
    {
        InitializeComponent();

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

}
