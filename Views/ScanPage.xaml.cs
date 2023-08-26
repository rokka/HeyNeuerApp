using System.Text.RegularExpressions;

using ZXing.Net.Maui;

namespace HeyNeuer.Views;

public partial class ScanPage : ContentPage
{
	public ScanPage()
	{
		InitializeComponent();
    }

    private void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        var scannedBarcode = e.Results.FirstOrDefault()?.Value;

        if (scannedBarcode == null)
        {
            return;
        }

        cameraBarcodeReaderView.IsDetecting = false;

        var regex = new Regex("\\/.*-([0-9]*)$");

        var match = regex.Match(scannedBarcode);

        if (!match.Success)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                DisplayAlert("Ungültiger Barcode", $"Der gescannte Barcode\"{scannedBarcode}\" ist ungültig.", "OK");
            });

            cameraBarcodeReaderView.IsDetecting = true;
            return;
        }

        Device.BeginInvokeOnMainThread(() =>
        {
            Shell.Current.GoToAsync($"..?ComputerNo={match.Groups[1].Value}");
        });
    }
}