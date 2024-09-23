using Microsoft.Maui.Controls;

namespace MauiApp5
{
    public partial class FlyoutHomePage : ContentPage
    {
        private bool _isFlyoutVisible = false;

        public FlyoutHomePage()
        {
            InitializeComponent();
        }

        private async void OnMenuClicked(object sender, EventArgs e)
        {
            if (_isFlyoutVisible)
            {
                //CLOSE MENU
                await FlyoutMenu.TranslateTo(-250, 0, 250, Easing.SinIn);
                FlyoutMenu.IsVisible = false;
            }
            else
            {
                // OPEN MENU
                FlyoutMenu.IsVisible = true;
                await FlyoutMenu.TranslateTo(0, 0, 250, Easing.SinIn);
            }

            _isFlyoutVisible = !_isFlyoutVisible;
        }
        private void ProfileClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserProfilePage());
        }

        private void ProfileImageClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserProfilePage());
        }
        private void TasksImageClicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new UserTaskPage());
        }

        private void TasksClicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new UserTaskPage());
        }
        private void GroupsImageClicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new UserGroupPage());
        }

        private void GroupsClicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new UserGroupPage());
        }

        //hoooome page
        private void peopleButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PeoplePage()); ;

        }

        private void domainButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DomainPage()); ;
        }

        private void taskButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TaskPage());

        }

 //hideeeeeeeeeeee
        private async void HideFlyout()
        {
            // CLOSE MENU AFTER CLICK TO BUTTON
            await FlyoutMenu.TranslateTo(-250, 0, 250, Easing.SinIn);
            FlyoutMenu.IsVisible = false;
            _isFlyoutVisible = false;
        }
        private async void OnMainContentTapped(object sender, EventArgs e)
        {
            // CLOSE MENU AFTER CLICK TO PAGE
            await FlyoutMenu.TranslateTo(-250, 0, 250, Easing.SinIn);
            FlyoutMenu.IsVisible = false;
            _isFlyoutVisible = false;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}