namespace FullScreenApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
	}
    public virtual Android.Views.Window? Window { get; set; }

}
