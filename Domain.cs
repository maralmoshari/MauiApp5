using System.ComponentModel;

public class Domain : INotifyPropertyChanged
{
    private bool _isFramVisible;
    private bool _selectedDomain;

    public string Title { get; set; }
    public string Description { get; set; }

    public bool isFramVisible
    {
        get => _isFramVisible;
        set
        {
            if (_isFramVisible != value)
            {
                _isFramVisible = value;
                OnPropertyChanged(nameof(isFramVisible));
            }
        }
    }

    public bool SelectedDomain
    {
        get => _selectedDomain;
        set
        {
            if (_selectedDomain != value)
            {
                _selectedDomain = value;
                OnPropertyChanged(nameof(SelectedDomain));
            }
        }
    }

    public Domain(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}