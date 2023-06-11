using System.Reflection;
using System.Resources;
using SayWhat.Maui.Utilities;

namespace SayWhat.Maui.Demo;

public partial class App : Application
{
    public static string CurrentCulture = "en-US";

    public App()
	{
		InitializeComponent();

        var resourceManager = new ResourceManager("SayWhat.Maui.Demo.Resources.AppResources", Assembly.GetAssembly(typeof(MainPage)));
        new Settings().Initialize(resourceManager, CurrentCulture);
        MainPage = new NavigationPage(new MainPage());
        UpdateCulture();
	}
    public static void UpdateCulture()
    {
        CurrentCulture = CurrentCulture.Equals("en-US") ? "es-US" : "en-US";
        new Settings().UpdateCulture(CurrentCulture);
    }
}
