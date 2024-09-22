

using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;

namespace MauiApp5;

public partial class DomainsSubPage : ContentPage
{
    public ObservableCollection<Domain> Domains { get; set; }
    public DomainsSubPage(Domain SelectedDomain)
	{

		InitializeComponent();
		BindingContext = SelectedDomain;
        Domains = new ObservableCollection<Domain>();

        string Ftitle = "sub domain ";
        string FDescription = "This is a description.";


        for (int i = 0; i < 20; i++)
        {
            Domains.Add(new Domain(Ftitle, FDescription));
        }


        BindingContext = this;
    }
    private async void OnSubDomainSelect(object sender, SelectionChangedEventArgs e)
    {
       var SelectedSubDomain = e.CurrentSelection.FirstOrDefault() as Domain;
       if (SelectedSubDomain != null)
       {
           await Navigation.PushAsync(new DomainDetailPage(SelectedSubDomain));
           // Reset selection to avoid re-triggering the same item
           ((CollectionView)sender).SelectedItem = null;
       }
    }

    private void AddSubDomain(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NewDomainPage());
    }
}