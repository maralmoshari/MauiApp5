
namespace MauiApp5
{
    public partial class MemberDetailsPage : ContentPage
    {
        public MemberDetailsPage(Member selectedMember)
        {
            InitializeComponent();
            BindingContext = selectedMember;
        }
        private void ProfileButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfilePage());
        }

    }
}