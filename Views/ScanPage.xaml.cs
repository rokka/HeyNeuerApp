namespace HeyNeuer.Views;

using ZXing.Net.Maui;

public partial class ScanPage : ContentPage
{
	public ScanPage()
	{
		InitializeComponent();
    }

    private void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        foreach (var barcode in e.Results)
        {
            DisplayAlert("Foo", "Bar", "OK");
            //DisplayAlert(barcode.Format.ToString(), barcode.Value, "OK");
        }
    }
}