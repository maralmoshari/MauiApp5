using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;

namespace MauiApp5;

public partial class GroupPopup : Popup
{

    public ObservableCollection<Group> Groups { get; set; } // Using ObservableCollection for automatic updates

    public GroupPopup()
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
    /*private async void OnGroupSelected(object sender, SelectionChangedEventArgs e)
    {
        var SelectedGroup = e.CurrentSelection.FirstOrDefault() as Group;
        if (SelectedGroup != null)
        {
            await Navigation.PushAsync(new GroupDetailsPage(SelectedGroup));
            // Reset selection to avoid re-triggering the same item
            ((CollectionView)sender).SelectedItem = null;
        }
    }*/

}
