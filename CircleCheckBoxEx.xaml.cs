using Fantasy.Maui.Controls.Animation;
namespace Fantasy.Maui.Controls;

public partial class CircleCheckBoxEx : ContentView
{
	public CircleCheckBoxEx()
	{
		InitializeComponent();
		if (this.IsChecked)
			this.thumb.FadeTo(1);
		else
			this.thumb.FadeTo(0);
	}

	public static BindableProperty IsCheckedProperty = BindableProperty.Create(
		"IsChecked",
		typeof(bool),
		typeof(CircleCheckBoxEx),
		defaultValue:false

		);

	public bool IsChecked
	{
		get { return (bool)GetValue(IsCheckedProperty); }
		set { SetValue(IsCheckedProperty, value); }
	}

	public static BindableProperty TextProperty = BindableProperty.Create(
		"Text",
		typeof(string),
		typeof(CircleCheckBoxEx),
		defaultValue: ""
		);

	public string Text
	{
		get { return (string)GetValue(TextProperty); }
		set { SetValue(TextProperty, value); }
	}


    void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
		this.IsChecked = !this.IsChecked;
		if(!this.IsChecked)
		{
			this.thumb.FadeTo(0);
		
		}
		else
		{
			this.thumb.FadeTo(1);
		}
        this.thumb.OnceAninmation(TransformType.Scale, 1.4, 1, 200, Easing.Default);
    }
}
