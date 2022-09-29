namespace Fantasy.Maui.Controls;

public partial class TabControl : VerticalStackLayout
{


    public static BindableProperty ShowLineProperty= BindableProperty.Create("ShowLine",typeof(bool),typeof(TabControl),false,propertyChanged:showlineChanged);


    public bool ShowLine
    {
        get { return (bool)GetValue(ShowLineProperty); }
        set { SetValue(ShowLineProperty, value); }
    }
    

    private static void showlineChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
       var control=bindable as TabControl;
        if (control == null) return;

        bool vis = (bool)newvalue;

        foreach (IView view in control.list.Children)
        {
            if (view is TabHeader item)
            {
                item.ShowLinw(vis);
            }
        }


    }

    //public static BindableProperty ItemsProperty=BindableProperty.Create("ItemsProperty",typeof(List<TabHeader>),typeof(TabControl)
 //   ,new List<TabHeader>(),BindingMode.TwoWay,propertyChanged:itemChanged
 //   );

 //   public List<TabHeader> Items
 //   {
 //       get { return (List<TabHeader>)GetValue(ItemsProperty); }
 //       set { SetValue(ItemsProperty, value); }
 //   }

    //private static void itemChanged(BindableObject bindable, object oldvalue, object newvalue)
    //{
        
    //}

    public TabControl()
	{
		InitializeComponent();
        this.ChildAdded += (s, e) =>
        {
            if (e.Element is TabHeader item)
            {
                item.ShowLinw(this.ShowLine);
            }
        };

    }
}