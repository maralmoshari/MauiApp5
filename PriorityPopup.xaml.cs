using CommunityToolkit.Maui.Views;

namespace MauiApp5;

public partial class PriorityPopup : Popup
{
	public PriorityPopup()
	{
		InitializeComponent();	

          // اضافه کردن رویداد تغییر مقدار اسلایدر
            mySlider.ValueChanged += OnSliderValueChanged;
    }

    private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
      // بروزرسانی Label با مقدار جدید اسلایدر
      sliderValueLabel.Text = $"Value: {e.NewValue:F1}";  }
    


private void AddPriority(object sender, EventArgs e)
    {

		Close();
    }
}