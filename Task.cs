namespace MauiApp5;


    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string SingToUser { get; set; }
        public string Manager { get; set; }
        public string PriviousTask { get; set; }
        public string Deadline { get; set; }
        public string NextTask { get; set; }
        public string CoupleTask { get; set; }
        public int  Priority { get; set; }

    public Task(string title, string description)
        {
            Title = title;
            Description = description;

        }
    //context 
    public Task(string title, string description , string singToUser , string manager , string priviousTask ,string deadline , string nextTask , string coupleTask ,int priority)
    { 
        Title = title;
        Description = description;
        SingToUser = singToUser;
        Manager = manager;
        PriviousTask = priviousTask;
        Deadline = deadline;
        NextTask = nextTask;
        CoupleTask = coupleTask;
        Priority = priority;


    }
    }
