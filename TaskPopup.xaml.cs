using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;

namespace MauiApp5;

public partial class TaskPopup : Popup
{

    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Task(string title, string description)
        {
            Title = title;
            Description = description;

        }
    }

    public ObservableCollection<Task> Tasks { get; set; } // Using ObservableCollection for automatic updates

    public TaskPopup()
	{
		InitializeComponent();

        Tasks = new ObservableCollection<Task>();

        string Ftitle = "task 1";
        string FDescription = "This is a description.";


        for (int i = 0; i < 20; i++)
        {
            Tasks.Add(new Task(Ftitle, FDescription));
        }


        BindingContext = this;

    }
    private async void OnTaskSelected(object sender, SelectionChangedEventArgs e)
    {
        // var selectedMember = e.CurrentSelection.FirstOrDefault() as Member;
        // if (selectedMember != null)
        // {
        //     //await Navigation.PushAsync(new MemberDetailsPage(selectedMember));
        //     
        //     // Reset selection to avoid re-triggering the same item
        //     ((CollectionView)sender).SelectedItem = null;
        // }
    }
}
