using System.Collections.ObjectModel;
using System.Linq;

namespace MauiApp5
{
    public partial class PeoplePage : ContentPage
    {
        public ObservableCollection<Member> Members { get; set; }
        public ObservableCollection<Member> FilteredMembers { get; set; }

        private string searchText = "";
        private string firstNameFilter = "";
        private string jobTitleFilter = "";
        private string currentSortOption = "Username"; // گزینه پیش فرض مرتب‌سازی 

        public PeoplePage()
        {
            InitializeComponent();

            Members = new ObservableCollection<Member>();
            FilteredMembers = new ObservableCollection<Member>();

            int MemberCount = 20;
            string FFname = "maral";
            string FLname = "moshari";
            string FUsername = "User1";
            string FDescription = "This is a description.";
            string ImageSource = "Resources/Images/account.png";
            string Fjobtitle = "manager";
            string Fphonenumber = "0901090827";

            // اضافه کردن اعضا به لیست اصلی 
            for (int i = 0; i < MemberCount; i++)
            {
                var member = new Member(FFname, FLname, FUsername, FDescription, ImageSource, Fjobtitle, Fphonenumber);
                Members.Add(member);
            }

            // اعمال لیست فیلتر شده به BindingContext 
            UpdateFilteredMembers();
            BindingContext = this;
        }

        private async void OnMemberSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedMember = e.CurrentSelection.FirstOrDefault() as Member;
            if (selectedMember != null)
            {
                await Navigation.PushAsync(new MemberDetailsPage(selectedMember));
                ((CollectionView)sender).SelectedItem = null;
            }
        }

        private void Addnewuser(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewuserPage1());
        }

        private void GgroupButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GroupPage());
        }

        // متد جستجو بر اساس Username 
        private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            searchText = e.NewTextValue.ToLower();
            UpdateFilteredMembers();
        }

        // فیلتر بر اساس First Name 
        private void OnFirstNameFilterChanged(object sender, TextChangedEventArgs e)
        {
            firstNameFilter = e.NewTextValue.ToLower();
            UpdateFilteredMembers();
        }

        // فیلتر بر اساس Job Title 
        private void OnJobTitleFilterChanged(object sender, TextChangedEventArgs e)
        {
            jobTitleFilter = e.NewTextValue.ToLower();
            UpdateFilteredMembers();
        }

        // تغییر مرتب‌سازی بر اساس انتخاب کاربر 
        private void OnSortOptionChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            currentSortOption = picker.SelectedItem.ToString();
            UpdateFilteredMembers();
        }

        // به‌روزرسانی اعضای فیلترشده و مرتب‌سازی بر اساس انتخاب 
        private void UpdateFilteredMembers()
        {
            FilteredMembers.Clear();

            var filtered = Members
                .Where(m =>
                    m.Username.ToLower().Contains(searchText) &&
                    // m.FirstName.ToLower().Contains(firstNameFilter) && 
                    m.JobTitle.ToLower().Contains(jobTitleFilter));

            // اعمال مرتب‌سازی بر اساس انتخاب کاربر 
            switch (currentSortOption)
            {

                case "Job Title":
                    filtered = filtered.OrderBy(m => m.JobTitle);
                    break;
                default:
                    filtered = filtered.OrderBy(m => m.Username);
                    break;
            }
            foreach (var member in filtered)
            {
                FilteredMembers.Add(member);
            }
        }
    }
}
