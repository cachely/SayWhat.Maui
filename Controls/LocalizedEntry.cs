using CommunityToolkit.Mvvm.Messaging;
using SayWhat.Maui.Messages;
using SayWhat.Maui.Utilities;

namespace SayWhat.Maui.Controls
{
    public class LocalizedEntry : Entry
    {
        public static readonly BindableProperty PlaceHolderResourceNameProperty =
           BindableProperty.Create(
                 nameof(PlaceHolderResourceName),
                 typeof(string),
                 typeof(LocalizedEntry),
                 null,
                 BindingMode.Default,
                 propertyChanged: PlaceHolderResourceNameChanged);

        public LocalizedEntry()
        {
            new WeakReferenceMessenger().Register<CultureChangedMessage>(this, (o, s) => UpdateText(this));
        }

        public string PlaceHolderResourceName
        {
            get => GetValue(PlaceHolderResourceNameProperty) as string;
            set => SetValue(PlaceHolderResourceNameProperty, value);
        }

        public static void PlaceHolderResourceNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            LocalizedEntry entry = (LocalizedEntry)bindable;
            entry.PlaceHolderResourceName = (string)newValue;
            SetPlaceHolder(entry);
        }

        public static void SetPlaceHolder(LocalizedEntry entry)
        {
            entry.Placeholder = DynamicLocalizer.GetText(entry.PlaceHolderResourceName);
        }

        public void UpdateText(LocalizedEntry entry)
        {
            entry.Placeholder = DynamicLocalizer.GetText(entry.PlaceHolderResourceName);
        }

        public void Dispose()
        {
            new WeakReferenceMessenger().Unregister<CultureChangedMessage>(this);
        }
    }
}
