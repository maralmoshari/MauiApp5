namespace MauiApp5;

    public class Group
    {
        public string Groupname { get; set; }
        public string Description { get; set; }

        public Group(string groupname, string description )
        {
            Groupname = groupname;
            Description = description;
            

        }
    }