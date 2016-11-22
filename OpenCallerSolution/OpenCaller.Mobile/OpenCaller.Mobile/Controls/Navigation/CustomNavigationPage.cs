using Xamarin.Forms;

namespace OpenCaller.Mobile.Controls
{
    sealed class CustomNavigationPage : NavigationPage
    {
        public CustomNavigationPage(Page root) : base(root)
        {
            Initialize();

            Title = root.Title;
            Icon = root.Icon;
        }

        public CustomNavigationPage()
        {
            Initialize();
        }

        void Initialize()
        {
            switch (Device.OS)
            {
                case TargetPlatform.iOS:
                    BarBackgroundColor = Color.FromHex("DE966A");
                    break;
                //case TargetPlatform.Other:
                //case TargetPlatform.Android:
                //case TargetPlatform.WinPhone:
                //case TargetPlatform.Windows:
                default:
                    BarBackgroundColor = Color.FromHex("DE966A"); //(Color)Application.Current.Resources["Primary"];
                    BarTextColor = Color.FromHex("FFFFFF"); //(Color)Application.Current.Resources["NavigationText"];
                    break;
            }
        }
    }
}

