﻿using NUnit.Framework;
using System.Resources;
using System.Reflection;
using System.Globalization;
using SayWhat.Maui.Utilities;

namespace SayWhat.Forms.Tests
{
    internal class SettingsTests
    {
        [Test]
        public void Settings_InitializeWithCultureParameter_SetsCulture()
        {
            //arrange
            var settings = new Settings();
            var assembly = Assembly.GetAssembly(typeof(DynamicLocalizer))!;
            var resourceManager = new ResourceManager("SayWhat.Forms.TestResource", assembly)!;
            var cultureString = "es-MX";
            CultureInfo expectedCulture = new CultureInfo(cultureString);

            //act
            settings.Initialize(resourceManager, cultureString);

            //assert
            Assert.That(settings.Culture, Is.EqualTo(expectedCulture));
        }

        [Test]
        public void Settings_InitializeWithoutCultureParameter_SetsCultureToEnUS()
        {
            //arrange
            var settings = new Settings();
            var assembly = Assembly.GetAssembly(typeof(DynamicLocalizer))!;
            var resourceManager = new ResourceManager("SayWhat.Forms.TestResource", assembly)!;
            var cultureString = "en-US";
            CultureInfo expectedCulture = new CultureInfo(cultureString);

            //act
            settings.Initialize(resourceManager);

            //assert
            Assert.That(settings.Culture, Is.EqualTo(expectedCulture));
        }

        [Test]
        public void UpdateCulture_WithoutCultureParameter_SetsCultureToEnUS()
        {
            //arrange
            var settings = new Settings();
            var assembly = Assembly.GetAssembly(typeof(DynamicLocalizer))!;
            var resourceManager = new ResourceManager("SayWhat.Forms.TestResource", assembly)!;
            var cultureString = "en-US";
            CultureInfo expectedCulture = new CultureInfo(cultureString);

            //act
            settings.UpdateCulture();

            //assert
            Assert.That(settings.Culture, Is.EqualTo(expectedCulture));
        }

        [Test]
        public void UpdateCulture_WithCultureParameter_SetsCulture()
        {
            //arrange
            var settings = new Settings();
            var assembly = Assembly.GetAssembly(typeof(DynamicLocalizer))!;
            var resourceManager = new ResourceManager("SayWhat.Forms.TestResource", assembly)!;
            var cultureString = "es-MX";
            CultureInfo expectedCulture = new CultureInfo(cultureString);

            //act
            settings.UpdateCulture(cultureString);

            //assert
            Assert.That(settings.Culture, Is.EqualTo(expectedCulture));
        }
    }
}
