using Caliburn.Micro;
using MonitoringApp.Helpers;
using System;
using System.Windows;

namespace MonitoringApp.ViewModels
{
    public class MainViewModel : Conductor<object>
    {
        public MainViewModel()
        {
            DisplayName = "MQTT Monitoring App";
            Commons.BROKER_CLIENT = "????";
        }

        public void exitprogram()
        {
            Environment.Exit(0);
        }

        public void exitbutton()
        {
            exitprogram();
        }

        public void LoadDatabaseView()
        {
            if(Commons.BROKER_CLIENT != null)
            {
                ActivateItem(new DatabaseViewModel());
            }
            else
            {
                var wManager = new WindowManager();
                wManager.ShowDialog(new ErrorPopupViewModel("Error"));
            }
        }

        public void LoadRealtimeView()
        {
            ActivateItem(new RealtimeViewModel());
        }

        public void LoadHistoryView()
        {
            ActivateItem(new HistoryViewModel());
        }

        public void menustart()
        {
            var wManager = new WindowManager();
            wManager.ShowDialog(new CustomPopupViewModel("New Broker"));
        }

        public void mqttstart()
        {
            var wManager = new WindowManager();
            wManager.ShowDialog(new CustomPopupViewModel("New Broker"));
        }
    }
}
