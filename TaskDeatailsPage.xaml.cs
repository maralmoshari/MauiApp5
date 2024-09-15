namespace MauiApp5;

public partial class TaskDeatailsPage : ContentPage
{
    public TaskDeatailsPage(Task SelectedDomainTask)
    {
        InitializeComponent();
        BindingContext = SelectedDomainTask;
    }

}
