using System.Collections.ObjectModel;

namespace MauiApp5;

public partial class TaskPage : ContentPage
{



        public ObservableCollection<Task> Tasks { get; set; } // Using ObservableCollection for automatic updates

        public TaskPage()
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

            CollectionView collectionView = new CollectionView();
            collectionView.SetBinding(ItemsView.ItemsSourceProperty, nameof(Tasks));



        }
    private async void OnTaskSelected(object sender, SelectionChangedEventArgs e)
    {
     //  var SelectedTask = e.CurrentSelection.FirstOrDefault() as Task;
     //  if (SelectedTask != null)
     //  {
     //      await Navigation.PushAsync(new TaskDeatailsPage(SelectedTask));
     //      // Reset selection to avoid re-triggering the same item
     //      ((CollectionView)sender).SelectedItem = null;
     //  }
    }
    private void Addnewtask(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewtaskPage());

        }
}
    