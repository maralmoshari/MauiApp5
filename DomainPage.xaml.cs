using System.Collections.ObjectModel;

namespace MauiApp5;

public partial class DomainPage : ContentPage
{


    public ObservableCollection<Domain> Domains { get; set; } // Using ObservableCollection for automatic updates

    public DomainPage()
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
       var SelectedDomain = e.CurrentSelection.FirstOrDefault() as Domain;
       if (SelectedDomain != null)
       {
           await Navigation.PushAsync(new DomainsSubPage(SelectedDomain));
           // Reset selection to avoid re-triggering the same item
           ((CollectionView)sender).SelectedItem = null;
       }
    }

    private void AddNewDomain(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NewDomainPage());
    }
}
