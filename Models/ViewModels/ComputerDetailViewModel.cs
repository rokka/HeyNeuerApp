using CommunityToolkit.Mvvm.ComponentModel;

namespace HeyNeuer.Models.ViewModels;

public partial class ComputerDetailViewModel : ObservableObject
{
    [ObservableProperty] 
    private bool isLoaded;
    
    [ObservableProperty]
    public int id;
    
    [ObservableProperty]
    public string type;

    [ObservableProperty] 
    public int number;

    [ObservableProperty]
    public string model;

    [ObservableProperty]
    public string cpu;

    [ObservableProperty] 
    public string ram;

    [ObservableProperty]
    public string disk;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotNew))]
    [NotifyPropertyChangedFor(nameof(IsNotInProgress))]
    [NotifyPropertyChangedFor(nameof(IsNotRefurbished))]
    [NotifyPropertyChangedFor(nameof(IsNotPicked))]
    [NotifyPropertyChangedFor(nameof(IsNotDelivered))]
    [NotifyPropertyChangedFor(nameof(IsNotLoss))]
    [NotifyPropertyChangedFor(nameof(IsNotDestroyed))]
    public string state;
    
    public string Name => $"HA-E-{this.number:0000}";

    public bool IsNotNew => this.State != "new";

    public bool IsNotInProgress => this.State != "in_progress";

    public bool IsNotRefurbished => this.State != "refurbished";

    public bool IsNotPicked => this.State != "picked";

    public bool IsNotDelivered => this.State != "delivered";

    public bool IsNotLoss => this.State != "loss";

    public bool IsNotDestroyed => this.State != "destroyed";
}