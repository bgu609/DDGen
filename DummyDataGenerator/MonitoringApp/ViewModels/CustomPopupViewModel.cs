using Caliburn.Micro;
using MonitoringApp.Helpers;

namespace MonitoringApp.ViewModels
{
    public class CustomPopupViewModel : Conductor<object>
    {
        private string brokerip;
        public string BROKERIP
        {
            get => brokerip;
            set
            {
                brokerip = value;
                NotifyOfPropertyChange(() => BROKERIP);
            }
        }

        public CustomPopupViewModel(string title)
        {
            DisplayName = title;
        }

        private string topic;
        public string Topic
        {
            get => topic;
            set
            {
                topic = value;
                NotifyOfPropertyChange(() => Topic);
            }
        }
        
        public void accept()
        {
            Commons.BROKER_HOST = brokerip;
            Commons.PUBLISH_TOPIC = topic;
        }

        public void iscancel()
        {
            TryClose(true);
        }
    }
}
