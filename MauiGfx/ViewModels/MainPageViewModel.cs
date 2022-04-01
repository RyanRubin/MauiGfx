using MauiGfx.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiGfx.ViewModels;

public class MainPageViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public ICommand DrawExplosivesCommand { get; set; }
    public ICommand SelectExplosiveCommand { get; set; }
    public ICommand StartDrawLineCommand { get; set; }
    public ICommand EndDrawLineCommand { get; set; }
    public ICommand CancelDrawLineCommand { get; set; }
    public ICommand ClearDrawLineCommand { get; set; }

    private Explosive startExplosive;

    public MainPageViewModel()
    {
        RowCount = 10;
        ColCount = 10;
        Explosives = new ObservableCollection<Explosive>();
        Pointer = new VirtualPointer();
        ExplosiveLines = new ObservableCollection<ExplosiveLine>();

        DrawExplosivesCommand = new Command(DrawExplosives);
        SelectExplosiveCommand = new Command(SelectExplosive);
        StartDrawLineCommand = new Command(StartDrawLine);
        EndDrawLineCommand = new Command(EndDrawLine);
        CancelDrawLineCommand = new Command(CancelDrawLine);
        ClearDrawLineCommand = new Command(ClearDrawLine);
    }

    private int rowCount;
    public int RowCount
    {
        get { return rowCount; }
        set
        {
            rowCount = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RowCount)));
        }
    }

    private int colCount;
    public int ColCount
    {
        get { return colCount; }
        set
        {
            colCount = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ColCount)));
        }
    }

    private ObservableCollection<Explosive> explosives;
    public ObservableCollection<Explosive> Explosives
    {
        get { return explosives; }
        set
        {
            explosives = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Explosives)));
            explosives.CollectionChanged += (sender, e) => { PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(nameof(Explosives))); };
        }
    }

    private VirtualPointer pointer;
    public VirtualPointer Pointer
    {
        get { return pointer; }
        set
        {
            pointer = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Pointer)));
            pointer.PropertyChanged += (sender, e) => { PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(nameof(VirtualPointer))); };
        }
    }

    private ObservableCollection<ExplosiveLine> explosiveLines;
    public ObservableCollection<ExplosiveLine> ExplosiveLines
    {
        get { return explosiveLines; }
        set
        {
            explosiveLines = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Explosives)));
            explosiveLines.CollectionChanged += (sender, e) => { PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(nameof(ExplosiveLines))); };
        }
    }


    private void DrawExplosives()
    {
        int vSpace = 480 / rowCount;
        int hSpace = 480 / colCount;

        Explosives.Clear();

        for (int row = 0; row < RowCount; row++)
        {
            for (int col = 0; col < ColCount; col++)
            {
                var explosive = new Explosive
                {
                    X = row * vSpace + 20,
                    Y = col * hSpace + 20,
                    Size = 30,
                    Label = $"{row}{col}"
                };
                explosive.PropertyChanged += (sender, e) => { PropertyChanged?.Invoke(sender, e); };
                Explosives.Add(explosive);
            }
        }
    }

    private void SelectExplosive()
    {
        foreach (var explosive in Explosives)
        {
            if (
                Pointer.X > explosive.X && Pointer.X < explosive.X + explosive.Size &&
                Pointer.Y > explosive.Y && Pointer.Y < explosive.Y + explosive.Size
            )
            {
                explosive.IsSelected = !explosive.IsSelected;
            }
        }
    }

    private void StartDrawLine()
    {
        foreach (var explosive in Explosives)
        {
            if (
                Pointer.X > explosive.X && Pointer.X < explosive.X + explosive.Size &&
                Pointer.Y > explosive.Y && Pointer.Y < explosive.Y + explosive.Size
            )
            {
                startExplosive = explosive;
                startExplosive.IsSelected = true;
            }
        }
    }

    private void EndDrawLine()
    {
        if (startExplosive == null)
        {
            return;
        }

        foreach (var explosive in Explosives)
        {
            if (
                Pointer.X > explosive.X && Pointer.X < explosive.X + explosive.Size &&
                Pointer.Y > explosive.Y && Pointer.Y < explosive.Y + explosive.Size &&
                explosive != startExplosive
            )
            {
                startExplosive.IsSelected = false;
                var explosiveLine = new ExplosiveLine
                {
                    X1 = startExplosive.X + 10,
                    Y1 = startExplosive.Y + 20,
                    X2 = explosive.X + 10,
                    Y2 = explosive.Y + 20
                };
                explosiveLine.PropertyChanged += (sender, e) => { PropertyChanged?.Invoke(sender, e); };
                ExplosiveLines.Add(explosiveLine);
            }
        }
    }

    private void CancelDrawLine()
    {
        foreach (var explosive in Explosives)
        {
            if (
                Pointer.X > explosive.X && Pointer.X < explosive.X + explosive.Size &&
                Pointer.Y > explosive.Y && Pointer.Y < explosive.Y + explosive.Size
            )
            {
                startExplosive = null;
            }
        }
    }

    private void ClearDrawLine()
    {
        ExplosiveLines.Clear();
    }
}
