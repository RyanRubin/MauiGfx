using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiGfx.Models;

public class ExplosiveLine : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private int x1;
    public int X1
    {
        get { return x1; }
        set
        {
            x1 = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(X1)));
        }
    }

    private int y1;
    public int Y1
    {
        get { return y1; }
        set
        {
            y1 = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Y1)));
        }
    }

    private int x2;
    public int X2
    {
        get { return x2; }
        set
        {
            x2 = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(X2)));
        }
    }

    private int y2;
    public int Y2
    {
        get { return y2; }
        set
        {
            y2 = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Y2)));
        }
    }
}
