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
        graphicsView.StartInteraction += GraphicsView_StartInteraction;
        graphicsView.DragInteraction += GraphicsView_DragInteraction;
        graphicsView.EndInteraction += GraphicsView_EndInteraction;
    }

    private void GraphicsView_StartInteraction(object sender, TouchEventArgs e)
    {
        mainPageViewModel.Pointer.X = (int)e.Touches[0].X;
        mainPageViewModel.Pointer.Y = (int)e.Touches[0].Y;
    }

    private void GraphicsView_DragInteraction(object sender, TouchEventArgs e)
    {
        mainPageViewModel.Pointer.X = (int)e.Touches[0].X;
        mainPageViewModel.Pointer.Y = (int)e.Touches[0].Y;
    }

    private void GraphicsView_EndInteraction(object sender, TouchEventArgs e)
    {
        mainPageViewModel.SelectExplosiveCommand.Execute(null);
    }
}
