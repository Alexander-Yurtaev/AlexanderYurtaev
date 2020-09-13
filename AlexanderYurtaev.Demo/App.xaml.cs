// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using AlexanderYurtaev.Demo.Events;
using AlexanderYurtaev.Demo.Views;
using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Windows;

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

        #endregion Overrides of PrismApplicationBase
    }
}