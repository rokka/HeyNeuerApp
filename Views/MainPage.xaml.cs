using Newtonsoft.Json;

namespace HeyNeuer.Views;

using HeyNeuer.Models.ViewModels;
using HeyNeuer.Services;
using Microsoft.Maui.Platform;
using Models;

public partial class MainPage : ContentPage
{
    private readonly IHeyNeuerApiService heyNeuerApiService;

    public MainPage()
    {
        this.heyNeuerApiService = new HeyNeuerApiService();

        this.InitializeComponent();

        this.BindingContext = new ComputerDetailViewModel();
    }

    private async void SearchButton_Clicked(object sender, EventArgs e)
    {
        await this.Search();
    }

    private async void ScanButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ScanPage));
    }

	private async void SearchEntry_TextChanged(object sender, EventArgs e)
    {
        this.SearchButton.IsEnabled = this.SearchEntry.Text.Length > 0;

        if (this.SearchEntry.Text.Length == 4)
        {
            await this.Search();
        }
    }

    private async Task Search()
    {
        this.SearchEntry.IsEnabled = false;
        this.SearchButton.IsEnabled = false;
        this.ScanButton.IsEnabled = false;

        var response = await this.heyNeuerApiService.GetComputer("HA-E-" + this.SearchEntry.Text);

        var computer = response.computer;

        if (computer != null)
        {
            var viewModel = new ComputerDetailViewModel
            {
                Number = computer.number,
                Model = computer.model,
                Cpu = computer.cpu,
                Ram = "8 GB",
                Disk = "478 GB HDD",
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

        this.SearchEntry.IsEnabled = true;
        this.SearchButton.IsEnabled = true;
        this.ScanButton.IsEnabled = true;
    }
}

