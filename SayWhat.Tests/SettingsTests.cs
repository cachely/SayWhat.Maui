using NUnit.Framework;
using System.Resources;
using System.Reflection;
using System.Globalization;

namespace SayWhat.Forms.Tests
{
    internal class SettingsTests
    {
        [Test]
        public void UpdateCulture_WithoutCultureParameter_SetsCultureToEnUS()
        {
            //arrange
            var cultureString = "en-US";
            CultureInfo expectedCulture = new CultureInfo(cultureString);
            var assembly = Assembly.GetAssembly(typeof(Maui.Utilities.DynamicLocalizer))!;
            var resourceManager = new ResourceManager("SayWhat.Maui.AppResources", assembly)!;
            SayWhat.Maui.Utilities.SayWhat.Settings.SetResourceManager(resourceManager);

            //act
            SayWhat.Maui.Utilities.SayWhat.Settings.UpdateCulture();

            //assert
            Assert.That(SayWhat.Maui.Utilities.SayWhat.Settings.Culture, Is.EqualTo(expectedCulture));
        }

        [Test]
        public void UpdateCulture_WithCultureParameter_SetsCulture()
        {
            //arrange
            var cultureString = "es-MX";
            var assembly = Assembly.GetAssembly(typeof(Maui.Utilities.DynamicLocalizer))!;
            var resourceManager = new ResourceManager("SayWhat.Maui.AppResources", assembly)!;
            CultureInfo expectedCulture = new CultureInfo(cultureString);
            SayWhat.Maui.Utilities.SayWhat.Settings.SetResourceManager(resourceManager);

            //act
            SayWhat.Maui.Utilities.SayWhat.Settings.UpdateCulture(cultureString);

            //assert
            Assert.That(SayWhat.Maui.Utilities.SayWhat.Settings.Culture, Is.EqualTo(expectedCulture));
        }
    }
}
