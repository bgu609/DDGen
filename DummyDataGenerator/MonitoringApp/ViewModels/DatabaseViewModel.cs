using Caliburn.Micro;
using MonitoringApp.Helpers;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using uPLibrary.Networking.M2Mqtt;

namespace MonitoringApp.ViewModels
{
    public class DatabaseViewModel : Conductor<object>
    {
        private string brokerurl;
        public string Brokerurl
        {
            get => brokerurl;
            set
            {
                brokerurl = value;
                NotifyOfPropertyChange(() => Brokerurl);
            }
        }

        private string constring;
        public string Constring
        {
            get => constring;
            set
            {
                constring = value;
                NotifyOfPropertyChange(() => Constring);
            }
        }

        private bool isconnected;
        public bool IsConnected
        {
            get => isconnected;
            set
            {
                isconnected = value;
                NotifyOfPropertyChange(() => IsConnected);
            }
        }

        private string dblog;
        public string DBlog
        {
            get => dblog;
            set
            {
                dblog = value;
                NotifyOfPropertyChange(() => DBlog);
            }
        }

        private string togglecontent;
        public string Togglecontent
        {
            get => togglecontent;
            set
            {
                togglecontent = value;
                NotifyOfPropertyChange(() => Togglecontent);
            }
        }

        public DatabaseViewModel()
        {
            Brokerurl = "Broker Url";
            Constring = "Constring";
            IsConnected = false;
            Togglecontent = "Connect";
        }

        public void Connect()
        {
            //Commons.BROKER_CLIENT = new MqttClient

            string str = Togglecontent;
            if(Togglecontent=="Connect")
            {
                IsConnected = true;
                Togglecontent = "Disconnect";
            }
            else
            {
                IsConnected = false;
                Togglecontent = "Connect";
            }
            Log(str);
        }

        public void Log(string content)
        {
            DBlog += "Database is " + content + "ed\n";
        }
    }
}
