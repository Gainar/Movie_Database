using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Movie.Proxy.Proxy;

namespace Movie.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    using Ninject;
    using System.Windows;

    public partial class App
    {
        private IKernel container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            this.container = new StandardKernel();
            container.Bind<IDesktop>().To<Desktop>().InTransientScope();
        }

        private void ComposeObjects()
        {
            Current.MainWindow = this.container.Get<MainWindow>();
            Current.MainWindow.Title = "MainWindow";
        }
    }
}
