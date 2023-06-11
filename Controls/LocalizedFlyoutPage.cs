using CommunityToolkit.Mvvm.Messaging;
using SayWhat.Maui.Messages;
using SayWhat.Maui.Utilities;

namespace SayWhat.Maui.Controls
{
    public class LocalizedFlyoutPage : FlyoutPage 
    {
        public static readonly BindableProperty TitleResourceNameProperty =
        BindableProperty.Create(
            nameof(TitleResourceName),
            typeof(string),
            typeof(LocalizedFlyoutPage),
            null,
            BindingMode.Default,
            propertyChanged: TitleResourceNameChanged);

        public LocalizedFlyoutPage() 
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
            var page = bindable as LocalizedFlyoutPage;
            page.TitleResourceName = (string)newValue;
            SetPlaceHolder(page);
        }

        public static void SetPlaceHolder(LocalizedFlyoutPage page)
        {
            page.Title = DynamicLocalizer.GetText(page.TitleResourceName);
        }

        public void UpdateText(LocalizedFlyoutPage page)
        {
            page.Title = DynamicLocalizer.GetText(page.TitleResourceName);
        }

        public void Dispose()
        {
            new WeakReferenceMessenger().Unregister<CultureChangedMessage>(this);
        }
    }
}
