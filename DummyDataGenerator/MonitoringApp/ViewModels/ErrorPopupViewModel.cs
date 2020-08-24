using Caliburn.Micro;

namespace MonitoringApp.ViewModels
{
    public class ErrorPopupViewModel : Conductor<object>
    {
        public ErrorPopupViewModel(string title)
        {
            DisplayName = title;
        }

        public void cfclose()
        {
            TryClose(true);
        }
    }
}
