using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiGfx.Models;

public class Explosive : INotifyPropertyChanged
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

    private int size;
    public int Size
    {
        get { return size; }
        set
        {
            size = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Size)));
        }
    }

    private string label;
    public string Label
    {
        get { return label; }
        set
        {
            label = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Label)));
        }
    }

    private bool isSelected;
    public bool IsSelected
    {
        get { return isSelected; }
        set
        {
            isSelected = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsSelected)));
        }
    }
}
