namespace MauiApp5;
using System.Collections.ObjectModel;
using Android.Nfc;
using Microsoft.Maui.Controls;

public partial class UserGroupPage : ContentPage
{

    public ObservableCollection<Group> Groups { get; set; }



    public UserGroupPage()
    {
        InitializeComponent();

        Groups = new ObservableCollection<Group>();



        string Fgroupname = "group1";
        string FDescription = "This is a description.";



        for (int i = 0; i < 20; i++)
        {
            Groups.Add(new Group(Fgroupname, FDescription));
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


}
