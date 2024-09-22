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
            Navigation.PushAsync(new ProfilePage());
        }

        private void ProfileImageClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfilePage());
        }
        private void TasksImageClicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new ProfilePage());
        }

        private void TasksClicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new TaskPage());
        }
        private void GroupsImageClicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new GroupPage());
        }

        private void GroupsClicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new GroupPage());
        }
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