using Microsoft.Extensions.DependencyInjection;
using PCB_Test.DataProvider.Implementation;
using PCB_Test.DataProvider.Interfaces;
using PCB_Test.Services.Implementations;
using PCB_Test.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PCB_Test.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() : base()
        {
            Services = ConfigureServices();
        }

        /// <summary>
        /// Gets the current <see cref="App"/> instance in use
        /// </summary>
        public new static App Current => (App)Application.Current;

        /// <summary>
        /// Gets the service from ServiceProvider
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetService<T>() => Current.Services.GetRequiredService<T>();

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
        /// </summary>
        public IServiceProvider Services { get; }

        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IDataProvider, PredefinedDataProvider>();
            services.AddSingleton<IOrderFactory, OrderFactory>();

            return services.BuildServiceProvider();
        }
    }
}
