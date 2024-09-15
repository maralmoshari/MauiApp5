using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;

namespace MauiApp5;

public partial class DomainDetailPage : ContentPage
{
    public ObservableCollection<Task> Tasks { get; set; }
    public ObservableCollection<Group> Groups { get; set; }
    public DomainDetailPage(Domain SelectedSubDomain)
	{
		InitializeComponent();
		BindingContext = SelectedSubDomain;

        Groups = new ObservableCollection<Group>();

        string Fgroupname = "group1";
        string FGDescription = "This is a description.";



        for (int i = 0; i < 20; i++)
        {
            Groups.Add(new Group(Fgroupname, FGDescription));
        }


        Tasks = new ObservableCollection<Task>();

        string Ftitle = "task 1";
        string FDescription = "This is a description.";
        //string FsingToUser = "gisoo";
        //string Fmanager = "PEDRAM";
        //string FpriviousTask = "TASK 2";
        //string Fdeadline = " april 22 AT 12:00";
        //string FnextTask = "TASK 3";
        //string FcoupleTask = " TASK 4,5,6";
        //int Fpriority = 50;




        for (int i = 0; i < 20; i++)
        {
            Tasks.Add(new Task(Ftitle, FDescription));
        }


        BindingContext = this;

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