using OpenCaller.Mobile.ViewModels.Acesso;
using Xamarin.Forms;

namespace OpenCaller.Mobile.Pages.Acesso
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            this.InitializeComponent();

            this.BindingContext = new LoginViewModel(this.Navigation);
        }
    }
}
