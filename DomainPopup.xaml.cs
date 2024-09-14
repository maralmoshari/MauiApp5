using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;

namespace MauiApp5;

public partial class DomainPopup : Popup
{
    public class Domain
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Domain(string title, string description)
        {
            Title = title;
            Description = description;

        }
    }

    public ObservableCollection<Domain> Domains { get; set; } // Using ObservableCollection for automatic updates

    public DomainPopup()
    {
        InitializeComponent();

        Domains = new ObservableCollection<Domain>();

        string Ftitle = "domain 1";
        string FDescription = "This is a description.";


        for (int i = 0; i < 20; i++)
        {
            Domains.Add(new Domain(Ftitle, FDescription));
        }


        BindingContext = this;


    }
    private async void OnDomainSelect(object sender, SelectionChangedEventArgs e)
    {
        //  var SelectedDomain = e.CurrentSelection.FirstOrDefault() as Domain;
        //  if (SelectedDomain != null)
        //  {
        //      await Navigation.PushAsync(new DomainsSubPage(SelectedDomain));
        //      // Reset selection to avoid re-triggering the same item
        //      ((CollectionView)sender).SelectedItem = null;
        //  }
    }
    private void ChooseDomain(object sender, EventArgs e)
    {
       

    }

}