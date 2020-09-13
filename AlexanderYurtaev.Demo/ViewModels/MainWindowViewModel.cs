// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using AlexanderYurtaev.Common;
using AlexanderYurtaev.Common.Data;
using AlexanderYurtaev.Demo.Events;
using AlexanderYurtaev.Framework.Extensions;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using System.Collections.Generic;
using System.Linq;

namespace AlexanderYurtaev.Demo.ViewModels
{
    public class MainWindowViewModel : BaseMainWindowViewModel
    {
        private readonly IContainerProvider _container;
        private string _title = "Prism Application";

        public MainWindowViewModel(IContainerProvider container, IModuleCatalog moduleCatalog)
        {
            _container = container;
            moduleCatalog.ThrowIfNull();
            moduleCatalog.ThrowIfNotTypeOf<DirectoryModuleCatalog>(nameof(moduleCatalog));

            InitCommands();

            var eventAggregator = _container.Resolve<IEventAggregator>();
            eventAggregator.GetEvent<AllModuleInitialized>().Subscribe(InitModulesCollection);
        }

        public DelegateCommand<object> SelectedItemChanged { get; private set; }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private void ExecuteMethod(object obj)
        {
            if (!(obj is Node node)) return;

            node.Select();
        }

        private void InitCommands()
        {
            SelectedItemChanged = new DelegateCommand<object>(ExecuteMethod);
        }

        private void InitModulesCollection(bool value)
        {
            if (!value) return;
            var modules = _container.Resolve<List<BaseModule>>();
            Nodes.Clear();
            foreach (var node in modules.Select(module => new Node(module, module.Title, module.View, module.Icon, module.Nodes)))
            {
                Nodes.Add(node);
            }
        }
    }
}