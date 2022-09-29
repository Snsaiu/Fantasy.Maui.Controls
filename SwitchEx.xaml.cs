using System.Runtime.CompilerServices;

using Fantasy.Maui.Controls.Animation;

namespace Fantasy.Maui.Controls;

public partial class SwitchEx : ContentView
{
	public SwitchEx()
	{
		InitializeComponent();
        this.BindingContext = this;
	}


    /// <summary>
    /// check 选中属性
    /// </summary>
    public static BindableProperty CheckedProperty = BindableProperty.Create(
        "Checked",
        typeof(bool),
        typeof(SwitchEx),
        defaultValue: false,
        propertyChanged: CheckedChanged);

    private static void CheckedChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var control=bindable as SwitchEx;
        if (control != null)
        {
            
            control.thumb.OnceAninmation(TransformType.Scale, 1.5, 1, 150, Easing.SinInOut);

            bool checkRes = (bool)newvalue;
            if (checkRes)
            {
                control.maingrid.SetColumn(control.thumb, 1);
                control.thumb.HorizontalOptions=LayoutOptions.End;
                control.thumb.Fill = control.OnThumbColor;
                control.border.Background=control.OnFillColor;
            }
            else
            {
                control.maingrid.SetColumn(control.thumb, 0);
                control.thumb.HorizontalOptions=LayoutOptions.Start;
                control.thumb.Fill = control.OffThumbColor;
                control.border.Background = control.OffFillColor;
            }
        }
    }

    public bool Checked
    {
        get { return (bool)GetValue(CheckedProperty); }
        set { SetValue(CheckedProperty, value); }
    }

    /// <summary>
    /// 选中状态是false时候的背景颜色
    /// </summary>
    public static BindableProperty OffFillColorProperty = BindableProperty.Create(
        "OffFileColor",
        typeof(Color),
        typeof(SwitchEx),
        defaultValue: Colors.Transparent
    );

    public Color OffFillColor
    {
        get { return (Color)GetValue(OffFillColorProperty); }
        set { SetValue(OffFillColorProperty, value); }
    }


    /// <summary>
    /// check 选中的背景颜色
    /// </summary>
    public static BindableProperty OnFillColorProperty = BindableProperty.Create(
        "OnFillColor",
        typeof(Color),
        typeof(SwitchEx),
        defaultValue: Colors.Transparent
    );

    public Color OnFillColor
    {
        get { return (Color)GetValue(OnFillColorProperty); }
        set { SetValue(OnFillColorProperty, value); }
    }


    /// <summary>
    /// thumb为true 
    /// </summary>
    public static BindableProperty OnThumbColorProperty = BindableProperty.Create(
        "OnThumbColor",
        typeof(Color),
        typeof(SwitchEx),
        defaultValue: Colors.White);


    public Color OnThumbColor
    {
        get { return (Color)GetValue(OnThumbColorProperty); }
        set { SetValue(OnThumbColorProperty, value); }
    }

    /// <summary>
    /// thumb为false
    /// </summary>
    public static BindableProperty OffThumbColorProperty = BindableProperty.Create(
        "OffThumbColor",
        typeof(Color),
        typeof(SwitchEx),
        defaultValue: Colors.White);


    public Color OffThumbColor
    {
        get { return (Color)GetValue(OffThumbColorProperty); }
        set { SetValue(OffThumbColorProperty, value); }
    }


    public static BindableProperty TextProperty = BindableProperty.Create(
        "Text",
        typeof(string),
        typeof(SwitchEx),
        defaultValue: "");

    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }

    public static BindableProperty TextColorProperty = BindableProperty.Create(
        "TextColor",
        typeof(Color),
        typeof(SwitchEx),
        defaultValue: Colors.White
    );

    public Color TextColor
    {
        get { return (Color)GetValue(TextColorProperty); }
        set { SetValue(TextColorProperty, value); }
    }

    public static BindableProperty TextSizeProperty = BindableProperty.Create("TextSize",
        typeof(int),
        typeof(SwitchEx),
        defaultValue: 10);

    public int TextSize
    {
        get { return (int)GetValue(TextSizeProperty); }
        set { SetValue(TextSizeProperty, value); }
    }

    private void ThumbChangedEvent(object sender, TappedEventArgs e)
    {
        this.Checked = !this.Checked;
    }
}