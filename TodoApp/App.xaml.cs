using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CommonServiceLocator;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using WpfApp2.Interfaces;
using WpfApp2.Services;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IViewNavigator, ViewNavigator>();
            containerRegistry.RegisterSingleton<ITodoManager, TodoManager>();
        }

        protected override Window CreateShell()
        {
            return ServiceLocator.Current.GetInstance<MainWindow>();
        }
    }
}
