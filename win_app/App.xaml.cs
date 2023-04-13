using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SOM;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        public App()
        {
            _host = Host
                .CreateDefaultBuilder()
                .ConfigureServices((context, service) =>
                {
                    service.AddSingleton(() => new MainWindow());
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {


            base.OnStartup(e);
        }
    }
}
