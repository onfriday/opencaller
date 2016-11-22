using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OpenCaller.Mobile.ViewModels.Acesso
{
    sealed class LoginViewModel : ViewModelBase
    {
        public LoginViewModel(INavigation pNavigation = null) : base(pNavigation)
        {
            if (Debugger.IsAttached)
            {
                this._Email = "jefferson@balivo.com.br";
                this._Senha = "123@Mudar";
            }
        }

        private string _Email;
        public string Email
        {
            get { return this._Email; }
            set { SetProperty(ref this._Email, value); }
        }

        private string _Senha;
        public string Senha
        {
            get { return this._Senha; }
            set { SetProperty(ref this._Senha, value); }
        }

        //<Button Text="Esqueci minha senha" Command="{Binding EsqueciCommand}" />
        private Command _EsqueciCommand;
        public Command EsqueciCommand => this._EsqueciCommand ?? (this._EsqueciCommand = new Command(async () => await EsqueciCommandExecute()));

        private Task EsqueciCommandExecute()
        {
            return UserDialogs.Instance.AlertAsync("Indisponível", "Oooops...", "Ok");
        }

        //<Button Text = "Login" Command="{Binding LoginCommand}" />
        private Command _LoginCommand;
        public Command LoginCommand => this._LoginCommand ?? (this._LoginCommand = new Command(async () => await LoginCommandExecute()));

        private async Task LoginCommandExecute()
        {
            try
            {
                if (this.IsBusy)
                    return;

                this.IsBusy = true;

                //UserDialogs.Instance.ShowLoading("Validando acesso...", MaskType.Black);

                var _loginResult = await AcessoClient.Login(this._Email, this._Senha);

                //if (_loginResult.IsValid)
                //    SettingsService.Current.UsuarioLogado = _loginResult.Result;

                switch (Device.OS)
                {
                    case TargetPlatform.Other:
                        break;
                    case TargetPlatform.iOS:
                        break;
                    case TargetPlatform.Android:
                        //App.Current.MainPage = new DroidRootPage();
                        break;
                    case TargetPlatform.WinPhone:
                        break;
                    case TargetPlatform.Windows:
                        break;
                    default:
                        break;
                }
            }
            catch (InvalidOperationException ex) { UserDialogs.Instance.Alert(ex.Message, "Oooops..."); }
            catch (ArgumentException ex) { UserDialogs.Instance.Alert(ex.Message, "Oooops..."); }
            catch (Exception ex) { UserDialogs.Instance.Alert(ex.Message, "Ah não!"); }
            finally
            {
                this.IsBusy = false;
                UserDialogs.Instance.HideLoading();
            }
        }

        //<Button Text = "Facebook" Command="{Binding SocialLoginCommand}" />
        private Command _SocialLoginCommand;
        public Command SocialLoginCommand => this._SocialLoginCommand ?? (this._SocialLoginCommand = new Command(async () => await SocialLoginCommandExecute()));

        private Task SocialLoginCommandExecute()
        {
            return UserDialogs.Instance.AlertAsync("Indisponível", "Oooops...", "Ok");
        }

        //<Button Text = "Cadastre-se" Command="{Binding RegistrarCommand}" />
        private Command _RegistrarCommand;
        public Command RegistrarCommand => this._RegistrarCommand ?? (this._RegistrarCommand = new Command(async () => await RegistrarCommandExecute()));

        private async Task RegistrarCommandExecute()
        {
            //switch (SettingsService.Current.AppType)
            //{
            //    case AppTypes.Usuario:
            //        await this.Navigation.PushAsync(new CadastroUsuarioPage());
            //        break;
            //    case AppTypes.Veterinario:
            //        await this.Navigation.PushAsync(new CadastroVeterinarioPage());
            //        break;
            //    default:
            //        break;
            //}
        }

        //<Button Text = "Lembrar" Command="{Binding LembrarCommand}" />
        private Command _LembrarCommand;
        public Command LembrarCommand => this._LembrarCommand ?? (this._LembrarCommand = new Command(async () => await LembrarCommandExecute()));

        private Task LembrarCommandExecute()
        {
            return UserDialogs.Instance.AlertAsync("Indisponível", "Oooops...", "Ok");
        }
    }
}

