using Xamarin.Forms;

namespace OpenCaller.Mobile.Controls
{
    public class FormsNavigationView : ContentView
    {
        public void OnNavigationItemSelected(FormsNavigationItemSelectedEventArgs e) { NavigationItemSelected?.Invoke(this, e); }

        public event FormsNavigationItemSelectedEventHandler NavigationItemSelected;
    }
}