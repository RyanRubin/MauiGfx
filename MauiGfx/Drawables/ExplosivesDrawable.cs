using MauiGfx.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiGfx.Drawables;

public class ExplosivesDrawable : IDrawable
{
    private readonly MainPageViewModel mainPageViewModel;

    public ExplosivesDrawable(MainPageViewModel mainPageViewModel)
    {
        this.mainPageViewModel = mainPageViewModel;
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        // draw the explosive lines
        foreach (var explosiveLine in mainPageViewModel.ExplosiveLines)
        {
            canvas.StrokeColor = Colors.Blue;
            canvas.StrokeSize = 2;
            //canvas.StrokeDashPattern = new float[] { 1, 1 };
            canvas.DrawLine(explosiveLine.X1, explosiveLine.Y1, explosiveLine.X2, explosiveLine.Y2);
        }

        // draw the explosives
        foreach (var explosive in mainPageViewModel.Explosives)
        {
            var color = explosive.IsSelected ? Colors.Green : Colors.Red;

            canvas.StrokeColor = color;
            canvas.StrokeSize = 1;
            canvas.DrawEllipse(explosive.X, explosive.Y, explosive.Size, explosive.Size);

            canvas.FontColor = color;
            canvas.FontSize = 10;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Arial");
            canvas.DrawString(explosive.Label, explosive.X + 10, explosive.Y + 20, HorizontalAlignment.Left);
        }

        // draw the virtual pointer
        canvas.StrokeColor = Colors.Black;
        canvas.StrokeSize = 1;
        canvas.DrawEllipse(mainPageViewModel.Pointer.X, mainPageViewModel.Pointer.Y, 10, 10);
        canvas.DrawEllipse(mainPageViewModel.Pointer.X + 5, mainPageViewModel.Pointer.Y + 5, 10, 10);
    }
}
