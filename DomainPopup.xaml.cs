using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;

namespace MauiApp5;

public partial class DomainPopup : Popup
{

    public ObservableCollection<Domain> Domains { get; set; } // Using ObservableCollection for automatic updates

    public DomainPopup()
    {
        InitializeComponent();
        Domains = new ObservableCollection<Domain>();

        string Ftitle = "domain 1";
        string FDescription = "This is a description.";

        for (int i = 0; i < 20; i++)
        {
            Domains.Add(new Domain(Ftitle + " " + (i + 1), FDescription));
        }

        BindingContext = this;
    }
    private async void OnDomainSelect(object sender, SelectionChangedEventArgs e)
    {

        
    }


    private void ChooseDomain(object sender, EventArgs e)
    {
        Close();
    }
}

