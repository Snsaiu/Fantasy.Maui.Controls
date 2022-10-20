using System.Windows.Input;

using Microsoft.Maui.Controls;

namespace Fantasy.Maui.Controls;

public partial class TabHeader : ContentView
{
    private ArrowState state;
	public TabHeader()
	{
		InitializeComponent();
		this.state=ArrowState.Close;
        this.Loaded += (s, e) =>
        {
            this.line.ScaleXTo(0);
            this.contentLayout.ScaleYTo(0);
        };


    }

    public static BindableProperty ChildProperty =
        BindableProperty.Create("Child", typeof(View), typeof(TabHeader), defaultValue:null, propertyChanged: childChanged);

    


    public View Child
    {
        get { return (View)GetValue(ChildProperty); }
        set { SetValue(ChildProperty, value); }
    }

    private static void childChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var control = bindable as TabHeader;
        if (control != null)
        {
            if (newvalue == null) return;

            control.contentLayout.Children.Clear();
            control.contentLayout.Children.Add((View)newvalue);
        }
    }


    /// <summary>
    /// ����
    /// </summary>
    public static BindableProperty TitleProperty=BindableProperty.Create("Title",typeof(string),typeof(TabHeader),"",propertyChanged:TitleChanged);

    private static void TitleChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
       var control=  bindable as TabHeader;
       if (control != null)
       {
           control.titleLabel.Text = (string)newvalue;
       }
    }

    public string Title
    {
        get { return (string)GetValue(TitleProperty); }
        set { SetValue(TitleProperty, value); }
    }

    /// <summary>
    /// ��״̬
    /// </summary>
    public static BindableProperty IsOpenProperty=BindableProperty.Create("IsOpen",typeof(bool),typeof(TabHeader),false);

    public bool IsOpen
    {
        get { return (bool)GetValue(IsOpenProperty); }
        set { SetValue(IsOpenProperty, value); }
    }

    public void ShowLinw(bool show)
    {
        this.lineContainer.IsVisible = show;
    }

	private void ArrawImageClickEvent(object sender, TappedEventArgs e)
	{
        if (this.state == ArrowState.Close)
        {
            arrowImage.RotateTo(180);
			this.state=ArrowState.Open;
            this.IsOpen=true;
            this.contentLayout.IsVisible = true;
            this.line.ScaleXTo(1);
            this.line.IsVisible = true;
            this.contentLayout.ScaleYTo(1);
    
        }
        else
        {
            arrowImage.RotateTo(0);
            this.state = ArrowState.Close;
            this.IsOpen=false;
            this.contentLayout.ScaleYTo(0);

            this.line.ScaleXTo(0);
            this.line.IsVisible = false;
            this.contentLayout.IsVisible = false;
         
        }
      
    }
}

public enum ArrowState
{
	Open,Close
}