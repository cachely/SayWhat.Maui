# SayWhat.Maui
Dynamic localization framework for Xamarin.Forms. Using wrapper classes for controls and pages, applications are able to update localized text to the UI regardless of chosen
design patterns or UI implementation (c# or xaml). 
<!-- wp:heading -->
<h2>Supported Controls</h2>
<!-- /wp:heading -->

<!-- wp:list -->
<ul><li>The framework supports titles on all pages <ul><li>LocalizedCarouselPage</li><li>LocalizedContentPage</li><li>LocalizedFlyoutPage</li><li>LocalizedNavigationPage</li><li>LocalizeTemplated</li></ul></li><li> As well as text and placeholders (if the control supports it) for:<ul><li>LocalizedButton</li><li>LocalizedEntry</li><li>LocalizedLabel</li></ul></li></ul>
<!-- /wp:list -->

<!-- wp:heading -->
<h2>Usage</h2>
<!-- /wp:heading -->

<!-- wp:paragraph -->
<p><a href="https://github.com/cachely/SayWhat.Maui/tree/058509d8b5a89aff15789f1b44f5d477ecfac816/SayWhat.Maui.Demo">Click here For a full example and demo.</a> </p>
<!-- /wp:paragraph -->

<!-- wp:heading {"level":4} -->
<h4>Initialization</h4>
<!-- /wp:heading -->

<!-- wp:paragraph -->
<p>var resourceManager = new ResourceManager("SayWhat.Forms.Demo.Resources.AppResources", Assembly.GetAssembly(typeof(MainPage)));
Utilities.SayWhat.Settings.SetResourceManager(resourceManager); 
Utilities.SayWhat.Settings.UpdateCulture(new CultureInfo({CultureHere}));</p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>It is recommended to initialize in the app.xaml.cs or app.cs file as it is done <a href="https://github.com/cachely/SayWhat.Forms/blob/main/SayWhat.Forms.Demo/SayWhat.Forms.Demo/App.xaml.cs">here</a>.</p>
<!-- /wp:paragraph -->

<!-- wp:heading {"level":4} -->
<h4>Xaml</h4>
<!-- /wp:heading -->

<!-- wp:paragraph -->
<p><a href="https://github.com/cachely/SayWhat.Maui/blob/058509d8b5a89aff15789f1b44f5d477ecfac816/SayWhat.Maui.Demo/MainPage.xaml">File on GitHub</a></p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>In Xaml, create a variable from the namespace. Here I have assigned it to 'sw' for SayWhat". However, it can be anything such as: il8n, localization, translations, etc.</p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>Now you can use controls and set the resource name of the string you want translated to the resourcename property on each control. </p>
<!-- /wp:paragraph -->

<!-- wp:code -->
<pre class="wp-block-code"><code>&lt;?xml version="1.0" encoding="utf-8" ?>
&lt;sw:LocalizedContentPage
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    <strong> xmlns:sw="clr-namespace:SayWhat.Maui.Controls;assembly=SayWhat.Maui"</strong>
    x:Class="SayWhat.Maui.Demo.MainPage"
    <strong>TitleResourceName="TranslatedTitle"</strong>>
    &lt;StackLayout 
        HorizontalOptions="Center"
        VerticalOptions="Center">
        &lt;<strong>sw:LocalizedLabel </strong>
            <strong>TextResourceName="HelloWorld" </strong>
            FontSize="18"/>
        &lt;<strong>sw:LocalizedEntry</strong>
            <strong>PlaceHolderResourceName="PlaceholderText"</strong> />
        &lt;<strong>sw:LocalizedButton </strong>
            <strong>TextResourceName="UpdateLanguage"</strong> 
            Clicked="Button_Clicked" />
    &lt;/StackLayout>
&lt;/sw:LocalizedContentPage></code></pre>
<!-- /wp:code -->

<!-- wp:heading {"level":4} -->
<h4>C#</h4>
<!-- /wp:heading -->

<!-- wp:paragraph -->
<p>Translation of the above example in C#.</p>
<!-- /wp:paragraph -->

<!-- wp:code -->
<pre class="wp-block-code"><code>Using SayWhat.Forms
public MainPage : LocalizedContentPage
{
   public MainPage()
   {
       <strong>TitleResourceName = "TranslatedTitle</strong>"
       Content = new StackLayout
       {
           Children = 
           {
              new <strong>LocalizedLabel </strong>{ <strong>TextResourceName="HelloWorld"</strong>, FontSize="18"},
              new <strong>LocalizedEntry</strong> { <strong>PlaceHolderResourceName="PlaceholderText"</strong> },
              new <strong>LocalizedButton </strong>{ <strong>TextResourceName="UpdateLanguage"</strong>,   Clicked="Button_Clicked"}
           } 
       }
   }
}</code></pre>
<!-- /wp:code -->

<!-- wp:heading -->
<h2>Code Behind</h2>
<!-- /wp:heading -->

<!-- wp:paragraph -->
<p>The idea is a fairly simple one. Basically wrap the original control or page, take items that are translatable and when the culture is updated notify the control to retrieve the updated value. And of course, allow the garbage collector to clean up when no longer in use.</p>
<!-- /wp:paragraph -->

<!-- wp:code -->
<pre class="wp-block-code"><code>﻿using CommunityToolkit.Mvvm.Messaging;
using SayWhat.Maui.Messages;
using SayWhat.Maui.Utilities;

namespace SayWhat.Maui.Controls
{
    public class LocalizedContentPage : ContentPage 
    {
        public static readonly BindableProperty TitleResourceNameProperty =
        BindableProperty.Create(
            nameof(TitleResourceName),
            typeof(string),
            typeof(LocalizedContentPage),
            null,
            BindingMode.Default,
            propertyChanged: TitleResourceNameChanged);

        public LocalizedContentPage() 
        {
            WeakReferenceMessenger.Default.Register<CultureChangedMessage>(this, (o, s) => UpdateText(this));
        }

        public string TitleResourceName
        {
            get => GetValue(TitleResourceNameProperty) as string;
            set => SetValue(TitleResourceNameProperty, value);
        }

        public static void TitleResourceNameChanged(BindableObject bindable, object oldValue, object newValue)
        { 
            var page = bindable as LocalizedContentPage;
            page.TitleResourceName = (string)newValue;
            SetPlaceHolder(page);
        }

        public static void SetPlaceHolder(LocalizedContentPage page)
        {
            page.Title = DynamicLocalizer.GetText(page.TitleResourceName);
        }

        public void UpdateText(LocalizedContentPage page)
        {
            page.Title = DynamicLocalizer.GetText(page.TitleResourceName);
        }

        public void Dispose()
        {
            WeakReferenceMessenger.Default.Unregister<CultureChangedMessage>(this);
        }
    }
}</code></pre>
<!-- /wp:code -->

<!-- wp:heading -->
<h2>Future Updates</h2>
<!-- /wp:heading -->

<!-- wp:paragraph -->
<p>In the future, I hope to support more localized items such as images, but if you want to jump in the game, feel free to fork the repository too! Hopefully, this framework will make someone's life a little easier if the requirement of dynamic localization ever comes their way.</p>
<!-- /wp:paragraph -->
