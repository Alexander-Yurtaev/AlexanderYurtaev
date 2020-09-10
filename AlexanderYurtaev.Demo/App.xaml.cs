using System;
using AlexanderYurtaev.Demo.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using AlexanderYurtaev.Demo.Events;
using AlexanderYurtaev.Demo.ViewModels;
using Prism.Events;

namespace AlexanderYurtaev.Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        #region Overrides of PrismApplicationBase

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            if (!(moduleCatalog is DirectoryModuleCatalog directoryModuleCatalog)) throw new ArgumentNullException(nameof(moduleCatalog));
            directoryModuleCatalog.ModulePath = "Modules";
            directoryModuleCatalog.Load();
        }

        protected override void InitializeModules()
        {
            var moduleManager = Container.Resolve<IModuleManager>();
            moduleManager.LoadModuleCompleted += (sender, args) =>
            {
                if (args.Error == null) return;
                MessageBox.Show(Application.Current.MainWindow,
                    $@"Module {args.ModuleInfo.ModuleName} could not be loaded.{Environment.NewLine}{args.Error.Message}");
                args.IsErrorHandled = true;
            };

            base.InitializeModules();
            
            var eventAggregator = Container.Resolve<IEventAggregator>();
            eventAggregator.GetEvent<AllModuleInitialized>().Publish(true);
        }

        #endregion
    }
}
