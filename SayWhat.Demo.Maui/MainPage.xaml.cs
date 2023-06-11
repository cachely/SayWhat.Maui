using SayWhat.Maui.Demo.Maui;
using SayWhat.Maui.Controls;

namespace SayWhat.Maui.Demo
{
    public partial class MainPage : LocalizedContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            App.UpdateCulture();
        }
    }
}
