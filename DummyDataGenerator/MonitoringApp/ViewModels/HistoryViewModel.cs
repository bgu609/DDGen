using Bogus;
using Caliburn.Micro;
using MonitoringApp.Helpers;
using MonitoringApp.Models;
using MySql.Data.MySqlClient;
using OxyPlot;
using System;
using System.Windows.Forms;

namespace MonitoringApp.ViewModels
{
    public class HistoryViewModel : Conductor<object>
    {
        private BindableCollection<DivisionModel> divisions;
        public BindableCollection<DivisionModel> Divisions
        {
            get => divisions;
            set
            {
                divisions = value;
                NotifyOfPropertyChange(() => Divisions);
            }
        }

        private DivisionModel seleceddiv;
        public DivisionModel SelectedDiv
        {
            get => seleceddiv;
            set
            {
                seleceddiv = value;
                NotifyOfPropertyChange(() => SelectedDiv);
            }
        }

        private string startpicker;
        public string Startpicker
        {
            get => startpicker;
            set
            {
                startpicker = DateTime.Parse(value).ToString("yyyy-MM-dd");
                endpicker = DateTime.Parse(value).ToString("yyyy-MM-dd");
                NotifyOfPropertyChange(() => Startpicker);
                NotifyOfPropertyChange(() => Endpicker);
            }
        }

        private string endpicker;
        public string Endpicker
        {
            get => endpicker;
            set
            {
                endpicker = DateTime.Parse(value).ToString("yyyy-MM-dd");
                NotifyOfPropertyChange(() => Endpicker);
            }
        }

        private string tempValues;
        public string TempValues
        {
            get => tempValues;
            set
            {
                tempValues = value;
                NotifyOfPropertyChange(() => TempValues);
            }
        }

        private string humidValues;
        public string HumidValues
        {
            get => humidValues;
            set
            {
                humidValues = value;
                NotifyOfPropertyChange(() => HumidValues);
            }
        }

        private string pressValues;
        public string PressValues
        {
            get => pressValues;
            set
            {
                pressValues = value;
                NotifyOfPropertyChange(() => PressValues);
            }
        }



        public HistoryViewModel()
        {
            initcontrols();
        }



        public void initcontrols()
        {
            divisions = new BindableCollection<DivisionModel>
            {
                new DivisionModel { KeyVal=0, DivisionVal="0room"},
                new DivisionModel { KeyVal=1, DivisionVal="1room"},
                new DivisionModel { KeyVal=2, DivisionVal="2room"},
                new DivisionModel { KeyVal=3, DivisionVal="3room"},
                new DivisionModel { KeyVal=4, DivisionVal="4room"}
            };
            //SelectedDiv = divisions.
        }

        public void Search()
        {
            if(SelectedDiv.KeyVal==0)
            {
                return;
            }

            DataSet dataSet = new DataSet();
            System.Collections.Generic.List<DataPoint> TempValues = new System.Collections.Generic.List<DataPoint>();

            
        }

        public void mySql()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(Commons.CONSTR))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand
                    {
                        Connection = con
                    };

                    string strQuery = "";

                    //MySqlDataReader reader = new MySqlDataReader();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"에러 발생 {ex.Message}", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
