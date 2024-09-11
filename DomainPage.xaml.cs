using System.Collections.ObjectModel;

namespace MauiApp5;

public partial class DomainPage : ContentPage
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

        CollectionView collectionView = new CollectionView();
        collectionView.SetBinding(ItemsView.ItemsSourceProperty, nameof(Domains));



    }


}
