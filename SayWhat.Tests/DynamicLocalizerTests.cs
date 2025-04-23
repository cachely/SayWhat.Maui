using NUnit.Framework;
using System.Resources;
using System.Reflection;
using SayWhat.Maui.Utilities;

namespace SayWhat.Forms.Tests
{
    public class DynamicLocalizerTests
    {

        [Test]
        public void GetText_ParamIsFound_ReturnsStringValue()
        {
            //arrange
            var expectedString = "Found";
            var assembly = Assembly.GetAssembly(typeof(DynamicLocalizer))!;
            SayWhat.Maui.Utilities.SayWhat.Settings.SetResourceManager(new ResourceManager("SayWhat.Maui.AppResources", assembly));

            //act
            var result = DynamicLocalizer.GetText("FoundTestString");

            //assert
            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.EqualTo(expectedString));
        }

#if RELEASE
        [Test]
        public void GetText_ParamIsNull_ReturnsEmptyString()
        {
            //arrange
            var assembly = Assembly.GetAssembly(typeof(DynamicLocalizer))!;
            SayWhat.Maui.Utilities.SayWhat.Settings.SetResourceManager(new ResourceManager("SayWhat.Maui.AppResources", assembly));

            //act
            var result = DynamicLocalizer.GetText(null);
            
            //assert
            Assert.That(string.IsNullOrEmpty(result));
        }

        [Test]
        public void GetText_ParamIsNotFound_ReturnsEmptyString()
        {
            //arrange
            var assembly = Assembly.GetAssembly(typeof(DynamicLocalizer))!;
            SayWhat.Maui.Utilities.SayWhat.Settings.SetResourceManager(new ResourceManager("SayWhat.Maui.AppResources", assembly));

            //act
            var result = DynamicLocalizer.GetText("NotFoundTest");

            //assert
            Assert.That(string.IsNullOrEmpty(result));
        }

        [Test]
        public void GetText_ResourceIsNotFoundInReleaseAndAlwaysThrowExceptionsIsTrue_ThrowsException()
        {
            //arrange
            var assembly = Assembly.GetAssembly(typeof(DynamicLocalizer))!;
            SayWhat.Maui.Utilities.SayWhat.Settings.SetResourceManager(new ResourceManager("SayWhat.Maui.NOTFOUND", assembly));

            //act 
            SayWhat.Maui.Utilities.SayWhat.Settings.AlwaysThrowExceptions = true;

            //assert
            Assert.Throws<Exception>(() => DynamicLocalizer.GetText("FoundTestString"));
        }
#endif


#if DEBUG
        
        [Test]
        public void GetText_ResourceIsNotFoundInDebug_ThrowsException()
        {
            //arrange
            var assembly = Assembly.GetAssembly(typeof(DynamicLocalizer))!;
            SayWhat.Maui.Utilities.SayWhat.Settings.SetResourceManager(new ResourceManager("SayWhat.Maui.FAKEAppResources", assembly));
            
            //act 
            //assert
            Assert.Throws<Exception>(() => DynamicLocalizer.GetText("FoundTestString"));
        }
#endif

    }
}