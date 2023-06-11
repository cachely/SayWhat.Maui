using CommunityToolkit.Mvvm.Messaging;
using SayWhat.Maui.Messages;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

[assembly: InternalsVisibleTo("SayWhat.Tests")]
namespace SayWhat.Maui.Utilities
{
    /// <summary>
    /// Provides access to the singleton Settings property.
    /// </summary>
    public static class SayWhat
    {
       private static Lazy<Settings> _settingsInstance = new Lazy<Settings>(() => new Settings());

       public static Settings Settings => _settingsInstance.Value;
    }

    /// <summary>
    /// Class is a singleton, please access through SayWhat.Settings property.
    /// </summary>
    public sealed class Settings
    {
        private bool _initialized;

        /// <summary>
        /// Turns on throwing exceptions in Release Configuration.
        /// Otherwise Exceptions are only thrown in Debug Configuration.
        /// </summary>
        public bool AlwaysThrowExceptions { get; set; } = false;

        internal CultureInfo Culture { get; private set; } = new CultureInfo("en-US");

        /// <summary>
        /// Initializes framework with provided resource manager.
        /// </summary>
        /// <param name="resourceManager">Applications resource manger will be assigned to a singleton internally</param>
        public void SetResourceManager(ResourceManager resourceManager)
        {
            DynamicLocalizer.CreateResourceManager(resourceManager);
        }

        /// <summary>
        /// Changes the culture based on the key provided. Else, defaults back to en-US
        /// </summary>
        /// <param name="cultureKey"></param>
        public void UpdateCulture(string cultureKey = "en-US")
        {
            Culture = new CultureInfo(cultureKey);

            if (_initialized)
                WeakReferenceMessenger.Default.Send<CultureChangedMessage>();
            else
                _initialized = true;            
        }
    }
}