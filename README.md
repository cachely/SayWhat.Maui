# SayWhat.Maui
Dynamic localization framework for Xamarin.Maui. Using wrapper classes for controls and pages, applications are able to update localized text to the UI regardless of chosen
design patterns or UI implementation (c# or xaml). 

### Example 
Full example is shown here:
https://github.com/cachely/SayWhat.Maui/tree/058509d8b5a89aff15789f1b44f5d477ecfac816/SayWhat.Maui.Demo

It is recommended to initialize in the app.xaml.cs, app.cs, or MauiProgram.cs file as it is done here:
https://github.com/cachely/SayWhat.Maui/tree/058509d8b5a89aff15789f1b44f5d477ecfac816/SayWhat.Maui.Demo

//Initialization<br>
var resourceManager = new ResourceManager("SayWhat.Forms.Demo.Resources.AppResources", Assembly.GetAssembly(typeof(MainPage)));
Utilities.SayWhat.Settings.SetResourceManager(resourceManager);
Utilities.SayWhat.Settings.UpdateCulture(new CultureInfo({CultureHere}));

Usage in xaml See: https://github.com/cachely/SayWhat.Maui/blob/058509d8b5a89aff15789f1b44f5d477ecfac816/SayWhat.Maui.Demo/MainPage.xaml
