using Caliburn.Micro;
using System;
using System.Windows;

namespace MonitoringApp.ViewModels
{
    public class MainViewModel : Conductor<object>
    {
        public MainViewModel()
        {
            DisplayName = "MQTT Monitoring App";
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
            ActivateItem(new DatabaseViewModel());
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
