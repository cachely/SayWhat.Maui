using CommunityToolkit.Mvvm.Messaging;
using SayWhat.Maui.Messages;
using SayWhat.Maui.Utilities;

namespace SayWhat.Maui.Controls
{
    public class LocalizedLabel : Label, IDisposable
    {
        public static readonly BindableProperty TextResourceNameProperty =
            BindableProperty.Create(
                  nameof(TextResourceName),
                  typeof(string),
                  typeof(LocalizedLabel),
                  null,
                  BindingMode.Default,
                  propertyChanged: TextResourceNameChanged);

        public LocalizedLabel()
        {
            new WeakReferenceMessenger().Register<CultureChangedMessage>(this, (o, s) => UpdateText(this));
        }

        public string TextResourceName
        {
            get => GetValue(TextResourceNameProperty) as string;
            set => SetValue(TextResourceNameProperty, value);
        }

        public static void TextResourceNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            LocalizedLabel label = (LocalizedLabel)bindable;
            label.TextResourceName = (string) newValue;
            SetText(label);
        }

        public static void SetText(LocalizedLabel label)
        {
            label.Text = DynamicLocalizer.GetText(label.TextResourceName);
        }

        public void UpdateText(LocalizedLabel label)
        {
            label.Text = DynamicLocalizer.GetText(label.TextResourceName);
        }

        public void Dispose()
        {
            new WeakReferenceMessenger().Unregister<CultureChangedMessage>(this);
        }
    }
}
