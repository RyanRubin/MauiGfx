using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiGfx.Models;

public class VirtualPointer : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private int x;
    public int X
    {
        get { return x; }
        set
        {
            x = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(X)));
        }
    }

    private int y;
    public int Y
    {
        get { return y; }
        set
        {
            y = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Y)));
        }
    }
}
