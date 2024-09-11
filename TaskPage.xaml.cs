using System.Collections.ObjectModel;

namespace MauiApp5;

public partial class TaskPage : ContentPage
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
        private void Addnewtask(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewtaskPage());

        }
}
    