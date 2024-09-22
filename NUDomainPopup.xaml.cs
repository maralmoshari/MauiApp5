using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;

namespace MauiApp5;

public partial class NUDomainPopup : Popup
{
    public ObservableCollection<Domain> Domains { get; set; } // Using ObservableCollection for automatic updates

    public NUDomainPopup()
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
        if (e.CurrentSelection.Count > 0)
        {
            var selectedDomain = e.CurrentSelection[0] as Domain;

            // تغییر وضعیت IsEntryVisible
            selectedDomain.isFramVisible = !selectedDomain.isFramVisible;

            // در صورت تمایل، سایر کاربران را مخفی کنید
            foreach (var domain in Domains)
            {
                if (domain != selectedDomain)
                {
                    domain.SelectedDomain = false;
                }
            }

            // به‌روزرسانی نمایش
            OnPropertyChanged(nameof(Domains));
        }
    }

    private void ChooseDomain(object sender, EventArgs e)
    {
        Close();
    }
}