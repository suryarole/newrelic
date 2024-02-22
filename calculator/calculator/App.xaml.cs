using NewRelic.Xamarin.Plugin;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace calculator
{
    public partial class App : Application
    {
       
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

            Application.Current.PageAppearing += OnPageAppearing;
            Application.Current.PageDisappearing += PageDisappearing;

            CrossNewRelicClient.Current.HandleUncaughtException();
            CrossNewRelicClient.Current.TrackShellNavigatedEvents()
      // Set optional agent configuration
      // Options are: crashReportingEnabled, loggingEnabled, logLevel, collectorAddress, crashCollectorAddress
      AgentStartConfiguration agentConfig = new AgentStartConfiguration(true, true, LogLevel.INFO, "mobile-collector.newrelic.com", "mobile-crash.newrelic.com");
            if (Device.RuntimePlatform == Device.Android)
            {
                //CrossNewRelicClient.Current.Start("<APP-TOKEN-HERE>");
                // Start with optional agent configuration
                CrossNewRelicClient.Current.Start("<APP-TOKEN-HERE", agentConfig);
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                //CrossNewRelicClient.Current.Start("<APP-TOKEN-HERE>");
                // Start with optional agent configuration 
                CrossNewRelicClient.Current.Start("<APP-TOKEN-HERE", agentConfig);
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
