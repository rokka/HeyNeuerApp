using HeyNeuer.Models.ViewModels;
using HeyNeuer.Services;

namespace HeyNeuer.Views;

[QueryProperty("ComputerNo", "ComputerNo")]
public partial class MainPage : ContentPage
{
    private readonly IHeyNeuerApiService heyNeuerApiService;

    public string ComputerNo { get; set; }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        if (this.ComputerNo != null)
        {
            await this.Search(this.ComputerNo);
            return;
        }

        base.OnNavigatedTo(args);
    }

    public MainPage()
    {
        this.heyNeuerApiService = new HeyNeuerApiService();

        this.InitializeComponent();

        this.BindingContext = new ComputerDetailViewModel();
    }

	private async void SearchEntry_TextChanged(object sender, EventArgs e)
    {
        this.SearchButton.IsEnabled = this.SearchEntry.Text.Length > 0;
    }

    private async void SearchEntry_Completed(object sender, EventArgs e)
    {
        await this.Search(this.SearchEntry.Text);
    }

    private async void SearchButton_Clicked(object sender, EventArgs e)
    {
        await this.Search(this.SearchEntry.Text);
    }

    private async void ScanButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ScanPage));
    }

    private async Task Search(string computerNo)
    {
        this.DisableSearchBar();

        var identifier = $"HA-E-{computerNo}";

        var response = await this.heyNeuerApiService.GetComputer(identifier);

        if (response == null)
        {
            await DisplayAlert("Kein Ergebnis", $"Der Computer mit der Nummer \"{identifier}\" wurde nicht gefunden.", "OK");
            this.EnableSearchBar();
            return;
        }

        var computer = response.computer;

        if (computer != null)
        {
            var viewModel = new ComputerDetailViewModel
            {
                Type = this.GetType(computer.type),
                Number = computer.number,
                Model = computer.model,
                Cpu = computer.cpu,
                Ram = $"{computer.memory_in_gb} GB",
                Disk = $"{computer.hard_drive_space_in_gb} GB {this.GetDriveTyp(computer.hard_drive_type)}",
                IsNotNew = false,
                IsNotInProgress = true,
                IsLoaded = true,
            };

            this.BindingContext = viewModel;

            this.SearchEntry.Text = String.Empty;
        }
        else
        {
            this.BindingContext = new ComputerDetailViewModel();
        }

        this.EnableSearchBar();
    }

    private void EnableSearchBar()
    {
        this.SearchEntry.IsEnabled = true;
        this.SearchButton.IsEnabled = true;
        this.ScanButton.IsEnabled = true;
    }

    private void DisableSearchBar()
    {
        this.SearchEntry.IsEnabled = false;
        this.SearchButton.IsEnabled = false;
        this.ScanButton.IsEnabled = false;
    }

    private string GetType(int typeId)
    {
        switch (typeId)
        {
            case 1:
                return "Desktop";
            case 2:
                return "Laptop";
            case 3:
                return "Tablet";
            case 4:
                return "Small Form Factor";
            default:
                return "Unbekannt";
        }
    }

    private string GetDriveTyp(int driveTypeId)
    {
        switch (driveTypeId)
        {
            case 1:
                return "HDD";
            case 2:
                return "SSD";
            default:
                return "Unbekannt";
        }
    }
}

