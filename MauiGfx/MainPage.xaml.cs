using MauiGfx.ViewModels;

namespace MauiGfx;

public partial class MainPage : ContentPage
{
    private readonly MainPageViewModel mainPageViewModel;
    private readonly IDrawable drawable;

    public MainPage(MainPageViewModel mainPageViewModel, IDrawable drawable)
    {
        this.mainPageViewModel = mainPageViewModel;
        this.drawable = drawable;

        InitializeComponent();

        BindingContext = mainPageViewModel;
        mainPageViewModel.PropertyChanged += (sender, e) =>
        {
            graphicsView.Invalidate();
        };
        graphicsView.Drawable = drawable;
    }
}

