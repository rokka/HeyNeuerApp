using CommunityToolkit.Mvvm.ComponentModel;

namespace HeyNeuer.Models.ViewModels;

public partial class ComputerDetailViewModel : ObservableObject
{
    [ObservableProperty] private bool isLoaded;

    public string Name => $"HA-E-{this.number:0000}";

    [ObservableProperty] public string type;

    [ObservableProperty] public int number;

    [ObservableProperty] public string model;

    [ObservableProperty] public string cpu;

    [ObservableProperty] public string ram;

    [ObservableProperty] public string disk;

    [ObservableProperty] public bool isNotNew;

    [ObservableProperty] public bool isNotInProgress;
}