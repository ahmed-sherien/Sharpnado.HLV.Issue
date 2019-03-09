using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Sharpnado.HLV.Issue.Views;
using Sharpnado.HLV.Issue.Navigation;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Sharpnado.HLV.Issue
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<NavigationService>();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
