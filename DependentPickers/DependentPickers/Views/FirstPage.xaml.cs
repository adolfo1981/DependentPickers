using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DependentPickers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstPage : ContentPage
    {
        public FirstPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new MainPage());
        }
    }
}