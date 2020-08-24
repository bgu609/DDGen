using System;
using System.Windows.Forms;
using Caliburn.Micro;
using MonitoringApp.Helpers;
using MySql.Data.MySqlClient;
using uPLibrary.Networking.M2Mqtt;
using MonitoringApp.Models;
using System.Threading;
using Bogus;
using Newtonsoft.Json;
using System.Text;

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

        //private bool isconnected;
        //public bool IsConnected
        //{
        //    get => isconnected;
        //    set
        //    {
        //        isconnected = value;
        //        NotifyOfPropertyChange(() => IsConnected);
        //    }
        //}

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
            //IsConnected = false;
            Togglecontent = "Connect";
            Commons.IS_CONNECTED = false;
        }

        public void Connect()
        {
            //Commons.BROKER_CLIENT = new MqttClient

            string str = Togglecontent;

            if(Togglecontent=="Connect")
            {
                Commons.IS_CONNECTED = true;
                Togglecontent = "Disconnect";
            }
            else
            {
                Commons.IS_CONNECTED = false;
                Togglecontent = "Connect";
            }

            Log(str);
        }



        public static string MqttBrokerUrl { get; set; }
        public static MqttClient BrokerClient { get; set; }
        public static Thread MqttThread { get; set; }
        public static Faker<SensorInfo> SensorFaker { get; set; }

        public static string CurrValue { get; set; }

        private static void InitializeAll()
        {
            MqttBrokerUrl = "localhost"; // or 127.0.0.1

            string[] Rooms = new[] { "Dining Room", "Living Room", "Bath Room", "Bed Room", "Guest Room" };

            SensorFaker = new Faker<SensorInfo>()
                .RuleFor(o => o.Dev_ID, f => f.PickRandom(Rooms))
                .RuleFor(o => o.Curr_Time, f => f.Date.Past(0).ToString("yyyy-MM-dd HH:mm:ss.ff"))
                .RuleFor(o => o.Temp, f => float.Parse(f.Random.Float(20.0f, 35.9f).ToString("0.00")))
                .RuleFor(o => o.Humid, f => float.Parse(f.Random.Float(40.0f, 63.9f).ToString("0.0")))
                .RuleFor(o => o.Press, f => float.Parse(f.Random.Float(899.0f, 1005.9f).ToString("0.0")));
        }

        private static void ConnectMqttBroker()
        {
            BrokerClient = new MqttClient(MqttBrokerUrl);
            BrokerClient.Connect("FakerDaemon");
        }

        private static void StartPublish()
        {
            MqttThread = new Thread(new ThreadStart(LoopPublish));
            //MqttThread = new Thread(() => LoopPublish());
            MqttThread.Start();
        }

        private static void LoopPublish()
        {
            while (true)
            {
                SensorInfo ThisValue = SensorFaker.Generate();
                CurrValue = JsonConvert.SerializeObject(ThisValue, Formatting.Indented);

                BrokerClient.Publish("home/device/data/", Encoding.Default.GetBytes(CurrValue));
                Console.WriteLine($"Published : {CurrValue}");

                Thread.Sleep(1000);
            }
        }

        public void Log(string content)
        {
            InitializeAll();
            ConnectMqttBroker();
            StartPublish();

            DBlog += $"Published : {CurrValue}";//"Database is " + content + "ed\n";
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

                    //MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, con);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"에러 발생 {ex.Message}", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
