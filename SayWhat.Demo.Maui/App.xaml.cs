using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using SayWhat.Maui.Utilities;

namespace SayWhat.Maui.Demo;

public partial class App : Application
{
    public static string CurrentCulture = "en-US";
    
    public App()
	{
		InitializeComponent();

        var resourceManager = new ResourceManager("SayWhat.Maui.Demo.Resources.AppResources", Assembly.GetAssembly(typeof(MainPage)));
        Utilities.SayWhat.Settings.SetResourceManager(resourceManager);
        MainPage = new NavigationPage(new MainPage());
        Utilities.SayWhat.Settings.UpdateCulture(CurrentCulture);
    }

    public static void UpdateCulture()
    {
        CurrentCulture = CurrentCulture.Equals("en-US") ? "es-US" : "en-US";
        Utilities.SayWhat.Settings.UpdateCulture(CurrentCulture);
    }
}
