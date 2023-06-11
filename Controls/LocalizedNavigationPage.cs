using CommunityToolkit.Mvvm.Messaging;
using SayWhat.Maui.Messages;
using SayWhat.Maui.Utilities;

namespace SayWhat.Maui.Controls
{
    public class LocalizedNavigationPage : ContentPage 
    {
        public static readonly BindableProperty TitleResourceNameProperty =
        BindableProperty.Create(
            nameof(TitleResourceName),
            typeof(string),
            typeof(LocalizedNavigationPage),
            null,
            BindingMode.Default,
            propertyChanged: TitleResourceNameChanged);

        public LocalizedNavigationPage() 
        {
            new WeakReferenceMessenger().Register<CultureChangedMessage>(this, (o, s) => UpdateText(this));
        }

        public string TitleResourceName
        {
            get => GetValue(TitleResourceNameProperty) as string;
            set => SetValue(TitleResourceNameProperty, value);
        }

        public static void TitleResourceNameChanged(BindableObject bindable, object oldValue, object newValue)
        { 
            var page = bindable as LocalizedNavigationPage;
            page.TitleResourceName = (string)newValue;
            SetPlaceHolder(page);
        }

        public static void SetPlaceHolder(LocalizedNavigationPage page)
        {
            page.Title = DynamicLocalizer.GetText(page.TitleResourceName);
        }

        public void UpdateText(LocalizedNavigationPage page)
        {
            page.Title = DynamicLocalizer.GetText(page.TitleResourceName);
        }

        public void Dispose()
        {
            new WeakReferenceMessenger().Unregister<CultureChangedMessage>(this);
        }
    }
}
