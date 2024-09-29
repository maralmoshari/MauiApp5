using System.ComponentModel;

namespace MauiApp5
{
    public class Member : INotifyPropertyChanged
    {
        private bool _isEntryVisible;

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Kodmeli { get; set; }
        public string Description { get; set; }
        public string ImageSource { get; set; }
        public string JobTitle { get; set; }
        public string PhoneNumber { get; set; }

        public bool IsEntryVisible
        {
            get => _isEntryVisible;
            set
            {
                if (_isEntryVisible != value)
                {
                    _isEntryVisible = value;
                    OnPropertyChanged(nameof(IsEntryVisible));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Member(string username, string description, string imageSource , string kodmeli)
        {
            Username = username;
            Description = description;
            ImageSource = imageSource;
            Kodmeli = kodmeli;
        }

        public Member(string firstname, string lastname, string username, string description, string imageSource, string jobtitle, string phonenumber , string kodmeli  )
        {
            Username = username;
            Description = description;
            ImageSource = imageSource;
            JobTitle = jobtitle;
            PhoneNumber = phonenumber;
            Firstname = firstname;
            Lastname = lastname;
            Kodmeli = kodmeli;
        }
    }
}