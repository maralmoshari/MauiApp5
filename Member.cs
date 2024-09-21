namespace MauiApp5
{
    public class Member
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
        public string ImageSource { get; set; }
        public string JobTitle { get; set; }
        public string PhoneNumber { get; set; }
        public Member(string username, string description, string imageSource)
        {
            Username = username;
            Description = description;
            ImageSource = imageSource;
          
        }
        public Member(string firstname, string lastname, string username, string description, string imageSource, string jobtitle, string phonenumber)
        {
            Username = username;
            Description = description;
            ImageSource = imageSource;
            JobTitle = jobtitle;
            PhoneNumber = phonenumber;
            Firstname = firstname;
            Lastname = lastname;
        }

    }
}