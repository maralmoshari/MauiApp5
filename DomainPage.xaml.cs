using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;

namespace MauiApp5;

public partial class DomainPage : ContentPage
{


    public ObservableCollection<Domain> Domains { get; set; }
    public ObservableCollection<Task> Tasks { get; set; }

    public DomainPage()
    {
        InitializeComponent();

        Domains = new ObservableCollection<Domain>();

        string Ftitle = "domain 1";
        string FDescription = "This is a description.";


        for (int i = 0; i < 20; i++)
        {
            Domains.Add(new Domain(Ftitle, FDescription));
        }


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
    private async void OnDomainSelect(object sender, SelectionChangedEventArgs e)
    {
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
    private void AddTask(object sender, EventArgs e)
    {
        this.ShowPopup(new TaskPopup());


    }

    private void AddNewDomain(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NewDomainPage());
    }
}
