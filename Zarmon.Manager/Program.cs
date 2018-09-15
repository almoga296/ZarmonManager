using System;
using System.Net;
using System.Timers;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using Zarmon.Connection.Connections.Http;
using Zarmon.Connection.Connections.Tcp;
using Zarmon.Connection.Connections.Udp;
using Zarmon.Device.Implementation.CricketCore;
using Zarmon.Device.Implementation.PowerSupplyCore.ApcCore;
using Zarmon.Device.Implementation.RubidiumCore;
using Zarmon.Device.Implementation.TplBoosterCore;

namespace Zarmon.Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss.fff} {Level:u3}] {Properties:j} {Message:lj}{NewLine}{Exception}")
                    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
                    {
                        AutoRegisterTemplate = true,
                        AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6
                    })
                .CreateLogger();
            DeviceManager deviceManager = new DeviceManager();
            var zoneA = deviceManager.AddZone("ZoneA");
            var zoneB = deviceManager.AddZone("ZoneB");
            var zoneC = deviceManager.AddZone("ZoneC");

            Site.Site siteAA = zoneA.AddSite(new Site.Site("ZoneA-SiteA"));

            TplBooster tplBooster = CreateTplBooster();
            Rubidium rubidium = CreateRubidium();
            CricketTransciever cricketTransciever = CreateCricketTransciever();
            Apc7920B apc = CreateApc();
            //Moxa moxa = CreateMoxa();

            siteAA.AddDeviceToSite(tplBooster);
            siteAA.AddDeviceToSite(rubidium);
            siteAA.AddDeviceToSite(cricketTransciever);
            siteAA.AddDeviceToSite(apc);
            //ControlledDevice powerSupply = DeviceFactory.CreateDevice(AvailableDeviceType.PowerSupply, new List<(AvailableApi, AvailableConnection, AvailableSyntax,ConnectionSettings)>
            //{
            //    //( AvailableApi.PowerSupplyApi, AvailableConnection.TcpConnection, AvailableSyntax.ScpiSyntax,new TcpConnectionSettings(new IPEndPoint(IPAddress.Loopback, 8888))),
            //    ( AvailableApi.PowerManagementApi, AvailableConnection.TcpConnection, AvailableSyntax.ScpiSyntax,new TcpConnectionSettings(new IPEndPoint(IPAddress.Loopback, 7777))),
            //});

            //ControlledDevice cricket = DeviceFactory.CreateDevice(AvailableDeviceType.CricketTransciever, new List<(AvailableApi, AvailableConnection, AvailableSyntax, ConnectionSettings)>
            //{
            //    ( AvailableApi.CricketTranscieverApi, AvailableConnection.UdpConnection, AvailableSyntax.ScpiSyntax, new UdpConnectionSettings(new IPEndPoint(IPAddress.Loopback, 11000))),
            //});

            //ControlledDevice rubidium = DeviceFactory.CreateDevice(AvailableDeviceType.Rubidium, new List<(AvailableApi, AvailableConnection, AvailableSyntax, ConnectionSettings)>
            //{
            //    ( AvailableApi.RubidiumApi, AvailableConnection.TcpConnection, AvailableSyntax.RubidiumSyntax, new TcpConnectionSettings(new IPEndPoint(IPAddress.Loopback, 8888))),
            //});

            //siteAA.AddDeviceToSite(powerSupply);
            //siteAA.AddDeviceToSite(cricket);
            //siteAA.AddDeviceToSite(rubidium);

            //RubidiumApi rubidiumApi = ApiFactory.ConfigureDeviceApis<RubidiumApi>(AvailableConnection.TcpConnection,
            //  new TcpConnectionSettings(new IPEndPoint(IPAddress.Parse("127.0.0.1"),8888)), new RubidiumSyntax());

            //Rubidium rubidium = new Rubidium(new PowerSupplySettings());
            //rubidium.AddApi(rubidiumApi);
            //var s = JsonConvert.SerializeObject(rubidium);
            //deviceManager.AddDevice(rubidium, true);

            //var rep = rubidium.GetApi<RubidiumApi>().GetBitReport();
            //var report = rubidiumApi.GetBitReport();
            //var report2 = rubidiumApi.GetSystemReport();
            //var report3 = rubidiumApi.GetTimeReport();

            //TplBoosterApi tplBoosterApi = ApiFactory.ConfigureDeviceApis<TplBoosterApi>(AvailableConnection.HttpConnection,
            //    new HttpConnectionSettings(new UriEndPoint(new Uri("http://localhost:9999"))), new TplBoosterSyntax());


            //PowerSupplyApi psApi = ApiFactory.ConfigureDeviceApis<PowerSupplyApi>(AvailableConnection.TcpConnection,
            //    new TcpConnectionSettings(new IPEndPoint(IPAddress.Loopback, 8888)), new ScpiSyntax());

            //psApi.TurnOn(2);

            //PowerSupply powerSupply =
            //    new PowerSupply(
            //        new PowerSupplySettings());

            ////powerSupply.AddApi(psApi);
            //powerSupply.AddLogic(new PingMonitor(new MonitorSettings(),psApi));
            //powerSupply.Init();

            //SerialEndPoint serialEndPoint = new SerialEndPoint("COM3");
            //DataAcquisition dataAcquisition =
            //    new DataAcquisition(
            //        new DataAcuisitionSettings(new SerialConnectionSettings(serialEndPoint)
            //        {
            //            BaudRate = 115200,
            //            DataBits = 8,
            //            Parity = Parity.None,
            //            StopBits = StopBits.One
            //        }));

            //dataAcquisition.Init();

            //PingMonitor pingMonitor = powerSupply.GetLogic<PingMonitor>();
            //pingMonitor.MonitorSettings.SamplingRate = TimeSpan.FromSeconds(1);

            while (true)
            {
                Console.WriteLine("Press A for activate monitor or D for deactivate");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.A)
                {
                    foreach (var controlledDevice in siteAA.Devices)
                    {
                        controlledDevice.Value.StartAllMonitors();
                    }
                }
                else if (key.Key == ConsoleKey.D)
                {
                    foreach (var controlledDevice in siteAA.Devices)
                    {
                        controlledDevice.Value.StopAllMonitors();
                    }
                }
                else if (key.Key == ConsoleKey.T)
                {
                    //powerSupply.GetLogic<PowerSupplyControlLogic>()?.TurnOn(2);
                }
                else if (key.Key == ConsoleKey.S)
                {
                    Console.WriteLine();
                }
                else if (key.Key == ConsoleKey.Q)
                {
                    break;
                }

            }
        }

        private static Apc7920B CreateApc()
        {
            TcpConnection tcp = new TcpConnection(new TcpConnectionSettings(new IPEndPoint(IPAddress.Loopback, 23)));
            tcp.OpenConnection();

            Apc7920B apc7920b = new Apc7920B(new Apc7920bSettings() { FirstChannel = 1, LastChannel = 5 });
            apc7920b.Connections.Add(tcp);
            apc7920b.Init();
            return apc7920b;
        }
        private static Rubidium CreateRubidium()
        {
            TcpConnection tcp = new TcpConnection(new TcpConnectionSettings(new IPEndPoint(IPAddress.Loopback, 5001)));
            tcp.OpenConnection();

            Rubidium rubidium = new Rubidium(new RubidiumSettings());
            rubidium.Connections.Add(tcp);
            rubidium.Init();
            return rubidium;
        }
        private static CricketTransciever CreateCricketTransciever()
        {
            UdpConnection udp = new UdpConnection(new UdpConnectionSettings(new IPEndPoint(IPAddress.Loopback, 35005)));
            udp.OpenConnection();

            CricketTransciever cricketTransciever = new CricketTransciever(new CricketTranscieverSettings());
            cricketTransciever.Connections.Add(udp);
            cricketTransciever.Init();
            return cricketTransciever;
        }
        private static TplBooster CreateTplBooster()
        {
            HttpConnection http = new HttpConnection(new HttpConnectionSettings(new UriEndPoint(new Uri("https://localhost:44331/api/booster"))));
            TplBooster tplBooster = new TplBooster(new TplBoosterSettings());
            tplBooster.Connections.Add(http);
            tplBooster.Init();
            return tplBooster;
        }

        private static void Update(object sender, ElapsedEventArgs e)
        {
            Log.Debug("timer elapsed event {@event}", e);
        }
    }
}