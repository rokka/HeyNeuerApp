using HeyNeuer.Views;

namespace HeyNeuer;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
		Routing.RegisterRoute(nameof(ScanPage), typeof(ScanPage));
	}
}
