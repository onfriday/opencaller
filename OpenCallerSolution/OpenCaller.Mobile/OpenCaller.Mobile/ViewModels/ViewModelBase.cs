using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OpenCaller.Mobile.ViewModels
{
    abstract class ViewModelBase : BaseViewModel
    {
        protected readonly INavigation Navigation;

        public ViewModelBase(INavigation pNavigation = null)
        {
            this.Navigation = pNavigation;
        }

        //protected ILogger Logger { get; } = DependencyService.Get<ILogger>();
        //protected IToast Toast { get; } = DependencyService.Get<IToast>();

        private Command _VoltarCommand;
        public Command VoltarCommand => this._VoltarCommand ?? (this._VoltarCommand = new Command(() => VoltarCommandExecute()));

        private async void VoltarCommandExecute()
        {
            if (this.Navigation != null)
                await this.Navigation.PopAsync();
        }
    }
}
