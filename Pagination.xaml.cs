using System.Windows.Input;
using Fantasy.Maui.Controls.Animation;

namespace Fantasy.Maui.Controls;


public class PageModel
{
    public int  PageIndex { get; set; }

    public int PageSize { get; set; }
}


public delegate void UpdateDataDelegate(PageModel pm);

public delegate void PageChangedDeleate(PageModel pm);



public partial class Pagination : ContentView
{

    public event UpdateDataDelegate UpdateDataEvent;
    public event PageChangedDeleate PageChangedEvent;

    #region fields


    #endregion


    #region dependency properties






    /// <summary>
    /// 每页条数
    /// </summary>
    public static BindableProperty PageSizeProperty = BindableProperty.Create(
    "PageSize",
    typeof(int),
    typeof(Pagination),
    defaultValue: 5
    );


    public int PageSize
    {
        get { return (int)GetValue(PageSizeProperty); }
        set { SetValue(PageSizeProperty, value); }
    }




    /// <summary>
    /// 总页数
    /// </summary>
    public static BindableProperty CountProperty = BindableProperty.Create(
        "Count",
        typeof(int),
        typeof(Pagination),
        defaultValue: 0,
        propertyChanged: CountChanged);

    private static void CountChanged(BindableObject bindable, object oldValue, object newValue)
    {
        //计算分页
        var control = bindable as Pagination;
        int count = (int)newValue;
        if (count == 0)
        {
            control.currentPageLabel.Text = "1";
            control.pageCountLabel.Text = "0";
            return;
        }
        int pageindex = Convert.ToInt32( control.currentPageLabel.Text);
        int pagecount = (count + control.PageSize - 1) / control.PageSize;
        control.currentPageLabel.Text = pageindex.ToString();
        control.pageCountLabel.Text = pagecount.ToString();
        var pm = new PageModel { PageIndex = pageindex, PageSize = control.PageSize };
        control.UpdateDataEvent?.Invoke(pm);

    }

    public int Count
    {
        get { return (int)GetValue(CountProperty); }
        set { SetValue(CountProperty, value); }
    }



    #endregion

    #region dependency command


    /// <summary>
    /// 上一页命令
    /// </summary>
    public static BindableProperty PreviewPageCommandProperty = BindableProperty.Create(
        "PreviewPageCommand",
        typeof(ICommand),
        typeof(Pagination),
        defaultValue:null
        );

    public ICommand PreviewPageCommand
    {
        get { return (ICommand)GetValue(PreviewPageCommandProperty); }
        set { SetValue(PreviewPageCommandProperty, value); }
    }

    /// <summary>
    /// 下一页命令
    /// </summary>
    public static BindableProperty NextPageCommandProperty = BindableProperty.Create(
    "NextPageCommand",
    typeof(ICommand),
    typeof(Pagination),
    defaultValue: null,
    propertyChanged:nextCommandChanged
    );

    private static void nextCommandChanged(BindableObject bindable, object oldValue, object newValue)
    {
       
    }

    public ICommand NextPageCommand
    {
        get { return (ICommand)GetValue(NextPageCommandProperty); }
        set { SetValue(NextPageCommandProperty, value); }
    }

    /// <summary>
    /// 上一页参数
    /// </summary>
    public static BindableProperty PreviewPageCommandParamterProperty = BindableProperty.Create(
        "PreviewPageCommandParamter",
        typeof(object),
        typeof(Pagination),
        defaultValue: null
        );

    public object PreviewPageCommandParamter
    {
        get { return (object)GetValue(PreviewPageCommandParamterProperty); }
        set { SetValue(PreviewPageCommandParamterProperty, value); }
    }


    /// <summary>
    ///  首页命令
    /// </summary>
    public static BindableProperty FirstPageCommandProperty = BindableProperty.Create(
 "FirstPageCommand",
 typeof(ICommand),
 typeof(Pagination),
 defaultValue: null
 );

    public ICommand FirstPageCommand
    {
        get { return (ICommand)GetValue(FirstPageCommandProperty); }
        set { SetValue(FirstPageCommandProperty, value); }
    }


    /// <summary>
    /// 首页命令参数
    /// </summary>
    public static BindableProperty FirstPageCommandParamterProperty = BindableProperty.Create(
"FirstPageCommandParamter",
typeof(object),
typeof(Pagination),
defaultValue: null
);

    public object FirstPageCommandParamter
    {
        get { return (object)GetValue(FirstPageCommandParamterProperty); }
        set { SetValue(FirstPageCommandParamterProperty, value); }
    }

    /// <summary>
    /// 尾页命令
    /// </summary>
    public static BindableProperty TailPageCommandProperty = BindableProperty.Create(
"TailPageCommand",
typeof(ICommand),
typeof(Pagination),
defaultValue: null
);

    public ICommand TailPageCommand
    {
        get { return (ICommand)GetValue(TailPageCommandProperty); }
        set { SetValue(TailPageCommandProperty, value); }
    }


    /// <summary>
    /// 尾页命令参数
    /// </summary>
    public static BindableProperty TailPageCommandParamterProperty = BindableProperty.Create(
"TailPageCommandParamter",
typeof(object),
typeof(Pagination),
defaultValue: null
);

    public object TailPageCommandParamter
    {
        get { return (object)GetValue(TailPageCommandParamterProperty); }
        set { SetValue(TailPageCommandParamterProperty, value); }
    }


    /// <summary>
    /// 下一页参数
    /// </summary>
    public static BindableProperty NextPageCommandParamterProperty = BindableProperty.Create(
    "NextPageCommandParamter",
    typeof(PageModel),
    typeof(Pagination),
    defaultBindingMode:BindingMode.TwoWay,
    defaultValue: new PageModel()
    );


    public PageModel NextPageCommandParamter
    {
        get
        {

            if (this.currentPageLabel == null) return null;
            int pageindex = int.Parse(this.currentPageLabel.Text);
            if (pageindex < int.Parse(this.pageCountLabel.Text))
                pageindex++;
            this.currentPageLabel.Text = pageindex.ToString();
            return new PageModel { PageIndex = pageindex, PageSize = this.PageSize };
        }
        //get {
        //    return (PageModel)GetValue(NextPageCommandParamterProperty); }
        set { SetValue(NextPageCommandParamterProperty, value); }
    }

    #endregion


    public Pagination()
	{
		InitializeComponent();
  
	}


    #region events
    void firstPageClickEvent(System.Object sender, System.EventArgs e)
    {
        this.firstPageBtn.OnceAninmation(TransformType.Scale, 0.8, 1, 50, Easing.Default);
        int pageindex = 1;

        this.currentPageLabel.Text = pageindex.ToString();
        this.PageChangedEvent?.Invoke(new PageModel { PageIndex = pageindex, PageSize = this.PageSize });
        //  this.FirstPageCommandParamter = new PageModel { PageIndex = pageindex, PageSize = this.PageSize };


    }

    void previewPageClickEvent(System.Object sender, System.EventArgs e)
    {
        this.previewPageBtn.OnceAninmation(TransformType.Scale, 0.8, 1, 50, Easing.Default);

        int pageindex = int.Parse(this.currentPageLabel.Text);
        if (pageindex > 1)
            pageindex--;
        this.currentPageLabel.Text = pageindex.ToString();
        this.PageChangedEvent?.Invoke(new PageModel { PageIndex = pageindex, PageSize = this.PageSize });
        //    this.PreviewPageCommandParamter = new PageModel { PageIndex = pageindex, PageSize = this.PageSize };

    }

    void nextPageClickEvent(System.Object sender, System.EventArgs e)
    {
        this.nextPageBtn.OnceAninmation(TransformType.Scale, 0.8, 1, 50, Easing.Default);
        int pageindex = int.Parse(this.currentPageLabel.Text);
        if (pageindex < int.Parse(this.pageCountLabel.Text))
            pageindex++;
        this.currentPageLabel.Text = pageindex.ToString();
        // this.NextPageCommandParamter = new PageModel { PageIndex = 1, PageSize = this.PageSize };
        this.PageChangedEvent?.Invoke(new PageModel { PageIndex = pageindex, PageSize = this.PageSize });
    }

    async void ChangePageSizeEvent(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        this.changePageGrp.OnceAninmation(TransformType.Scale, 0.8, 1, 50, Easing.Default);

        string actionRes = await Application.Current.MainPage.DisplayActionSheet("选择显示条数", "取消", "确定", "5", "10", "20", "30", "40");

        int ps = 0;
        if (int.TryParse(actionRes, out ps))
        {
            this.PageSize = ps;
            this.pagesizeLabel.Text = this.PageSize.ToString();
            this.currentPageLabel.Text = "1";
            int pagecount = (this.Count + this.PageSize - 1) / this.PageSize;
            this.pageCountLabel.Text = pagecount.ToString();
            this.UpdateDataEvent?.Invoke(new PageModel { PageIndex=1,PageSize=this.PageSize});
        }
    }

    void tailPageClickEvent(System.Object sender, System.EventArgs e)
    {
        this.tailPageBtn.OnceAninmation(TransformType.Scale, 0.8, 1, 50, Easing.Default);
        int pageindex = int.Parse(this.pageCountLabel.Text);
        this.currentPageLabel.Text = pageindex.ToString();
        this.PageChangedEvent?.Invoke(new PageModel { PageIndex = pageindex, PageSize = this.PageSize });
        //   this.TailPageCommandParamter = new PageModel { PageIndex = pageindex, PageSize = this.PageSize };
    }
    #endregion


}
