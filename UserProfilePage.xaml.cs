using System.Collections.ObjectModel;

namespace MauiApp5;

public partial class UserProfilePage : ContentPage
{
    public ObservableCollection<Member> Members { get; set; }
    public ObservableCollection<Task> Tasks { get; set; } // Using ObservableCollection for automatic updates

    public UserProfilePage()
    {
        InitializeComponent();
        BindingContext = this;

        Members = new ObservableCollection<Member>();
        int MemberCount = 20;
        string FFname = "maral";
        string FLname = "moshari";
        string FUsername = "User1";
        string FDescription = "This is a description.";
        string ImageSource = "Resources/Images/account.png";
        string Fjobtitle = "manager";
        string Fphonenumber = "0901090827";
        string Fkodmeli = "0927043187";
        // اضافه کردن اعضا به لیست اصلی 
        for (int i = 0; i < MemberCount; i++)
        {
            var member = new Member(FFname, FLname, FUsername, FDescription, ImageSource, Fjobtitle, Fphonenumber, Fkodmeli);
            Members.Add(member);
        }


        //task

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
    private void Addnewtask(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NewtaskPage());

    }

    private void EditProfile(object sender, EventArgs e)
    {
        Navigation.PopAsync();

    }
    private void editButton(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ProfileEditPage()); ;
    }
}