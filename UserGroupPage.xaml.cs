namespace MauiApp5;
using System.Collections.ObjectModel;
using Android.Nfc;
using Microsoft.Maui.Controls;

public partial class UserGroupPage : ContentPage
{

    public ObservableCollection<Group> Groups { get; set; }

    public ObservableCollection<Group> FilteredGroups { get; set; }


    public UserGroupPage()
    {
        InitializeComponent();

        Groups = new ObservableCollection<Group>();
        FilteredGroups = new ObservableCollection<Group>();


        string Fgroupname = "group1";
        string FDescription = "This is a description.";



        for (int i = 0; i < 20; i++)
        {
            Groups.Add(new Group(Fgroupname, FDescription));
        }





        BindingContext = this;

    }

    private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
    {
        string searchText = e.NewTextValue?.ToLower() ?? string.Empty;

        FilteredGroups.Clear();

        foreach (var group in Groups)
        {
            if (group.Groupname.ToLower().Contains(searchText) ||
                group.Description.ToLower().Contains(searchText))
            {
                FilteredGroups.Add(group);
            }
        }

        GroupCollectionView.ItemsSource = FilteredGroups;
    }

    private void OnSortOptionChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        var selectedSortOption = picker.SelectedItem.ToString();

        var sortedGroups = selectedSortOption switch
        {
            "Group Name" => Groups.OrderBy(g => g.Groupname).ToList(),
            "Job Title" => Groups.OrderBy(g => g.Groupname).ToList(),
            _ => Groups.ToList()
        };

        FilteredGroups.Clear();
        foreach (var group in sortedGroups)
        {
            FilteredGroups.Add(group);
        }

        GroupCollectionView.ItemsSource = FilteredGroups;
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
