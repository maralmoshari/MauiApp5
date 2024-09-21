namespace MauiApp5;
using System.Collections.ObjectModel;
using Android.Nfc;
using Microsoft.Maui.Controls;

public partial class GroupPage : ContentPage
{

    public ObservableCollection<Group> Groups { get; set; }
    public ObservableCollection<Task> Tasks { get; set; } 


    public GroupPage()
    {
        InitializeComponent();

        Groups = new ObservableCollection<Group>();



        string Fgroupname = "group1";
        string FDescription = "This is a description.";



        for (int i = 0; i < 20; i++)
        {
            Groups.Add(new Group(Fgroupname, FDescription));
        }


        ///task

        Tasks = new ObservableCollection<Task>();

        string Ftitle = "task 1";
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
            Tasks.Add(new Task(Ftitle, FTDescription, FsingToUser, Fmanager, FpriviousTask, Fdeadline, FnextTask, FcoupleTask, Fpriority));
        }


        BindingContext = this;

    }
    private async void OnGroupSelected(object sender, SelectionChangedEventArgs e)
    {
        var SelectedGroup = e.CurrentSelection.FirstOrDefault() as Group;
        if (SelectedGroup != null)
        {
            await Navigation.PushAsync(new GroupDetailsPage(SelectedGroup));
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
    private void Addnewgroup(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NewGroupPage());

    }
}
