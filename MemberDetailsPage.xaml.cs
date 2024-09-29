
namespace MauiApp5
{
    public partial class MemberDetailsPage : ContentPage
    {
        public MemberDetailsPage(Member selectedMember)
        {
            InitializeComponent();
            BindingContext = selectedMember;
        }


    }
}