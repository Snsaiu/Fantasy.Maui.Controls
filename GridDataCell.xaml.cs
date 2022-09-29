namespace Fantasy.Maui.Controls;

public partial class GridDataCell : ContentView
{



	public GridDataCell()
	{
		InitializeComponent();
	}


	/// <summary>
	/// up color
	/// </summary>
	public static BindableProperty UpBorderColorProperty = BindableProperty.Create("UpBorderColor"
        , typeof(Color)
		, typeof(GridDataCell)
	  
		, propertyChanged: onUpBorderColorChanged);

	private static void onUpBorderColorChanged(BindableObject bindable, object oldValue, object newValue)
	{
		GridDataCell control = bindable as GridDataCell;
		var c = (Color)newValue;
		control.up.Color = c;
		if(c==Colors.Transparent)
		{
			control.up.HeightRequest = 0;
		}
		else
		{
            control.up.HeightRequest = 2;
        }



	}

	public Color UpBorderColor
	{
		get { return (Color)GetValue(UpBorderColorProperty); }
		set { SetValue(UpBorderColorProperty, value); }
	}



	/// <summary>
	/// bottom color
	/// </summary>
    public static BindableProperty BottomBorderColorProperty = BindableProperty.Create("BottomBorderColor"
        , typeof(Color)
        , typeof(GridDataCell)

        , propertyChanged: onBottomBorderColorChanged);

    private static void onBottomBorderColorChanged(BindableObject bindable, object oldValue, object newValue)
    {
        GridDataCell control = bindable as GridDataCell;
        var c = (Color)newValue;
        control.bottom.Color = c;
        if (c == Colors.Transparent)
        {
            control.bottom.HeightRequest = 0;
        }
        else
        {
            control.bottom.HeightRequest = 2;
        }



    }

    public Color BottomBorderColor
    {
        get { return (Color)GetValue(BottomBorderColorProperty); }
        set { SetValue(BottomBorderColorProperty, value); }
    }

    /// <summary>
    /// left color
    /// </summary>
    public static BindableProperty LeftBorderColorProperty = BindableProperty.Create("LeftBorderColor"
      , typeof(Color)
      , typeof(GridDataCell)

      , propertyChanged: onLeftBorderColorChanged);

    private static void onLeftBorderColorChanged(BindableObject bindable, object oldValue, object newValue)
    {
        GridDataCell control = bindable as GridDataCell;
        var c = (Color)newValue;
        control.left.Color = c;
        if (c == Colors.Transparent)
        {
            control.left.WidthRequest = 0;
        }
        else
        {
            control.left.WidthRequest = 2;
        }
    }

    public Color LeftBorderColor
    {
        get { return (Color)GetValue(LeftBorderColorProperty); }
        set { SetValue(LeftBorderColorProperty, value); }
    }

    /// <summary>
    /// right color
    /// </summary>
    public static BindableProperty RightBorderColorProperty = BindableProperty.Create("RightBorderColor"
    , typeof(Color)
    , typeof(GridDataCell)

    , propertyChanged: onRightBorderColorChanged);

    private static void onRightBorderColorChanged(BindableObject bindable, object oldValue, object newValue)
    {
        GridDataCell control = bindable as GridDataCell;
        var c = (Color)newValue;
        control.right.Color = c;
        if (c == Colors.Transparent)
        {
            control.right.WidthRequest = 0;
        }
        else
        {
            control.right.WidthRequest = 2;
        }
    }

    public Color RightBorderColor
    {
        get { return (Color)GetValue(RightBorderColorProperty); }
        set { SetValue(RightBorderColorProperty, value); }
    }



    public static BindableProperty ChildProperty = BindableProperty.Create("Child"
		, typeof(View)
		, typeof(GridDataCell)
		, defaultValue: null
		, propertyChanged: childChanged);

	private static void childChanged(BindableObject bindable, object oldValue, object newValue)
	{
		if (newValue == null) return;
		GridDataCell control = bindable as GridDataCell;
		control.content.Children.Clear();
		control.content.Children.Add((View)newValue);

	}

	public View Child
	{
		get
		{
			return (View)GetValue(ChildProperty);
		}
		set
		{
			SetValue(ChildProperty, value);
		}
	}


}
