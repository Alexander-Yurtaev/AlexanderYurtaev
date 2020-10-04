// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using AlexanderYurtaev.Common;
using AlexanderYurtaev.Common.Data;
using Prism.Ioc;
using Prism.Regions;
using System;
using TestModule.Views;

namespace TestModule
{
    public class TestModuleModule : BaseModule
    {
        private readonly IRegionManager _regionManager;

        public TestModuleModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            InitChildModuleItems();
        }

        #region Overrides of BaseModule

        public override string Title => "Test Module";
        public override Type View => typeof(ViewA);

        public override void Select(Type viewType)
        {
            var region = _regionManager.Regions[Constants.MainRegionName];
            region.RemoveAll();
            _regionManager.RegisterViewWithRegion(Constants.MainRegionName, viewType);
        }

        public override void OnInitialized(IContainerProvider containerProvider)
        {
            RegisterModule(containerProvider);
        }

        public override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton(typeof(ViewA));
            PreRegisterModule(containerRegistry);
        }

        #endregion Overrides of BaseModule

        private void InitChildModuleItems()
        {
            Nodes.Add(new Node(this, typeof(ViewA), "Test module", Icon));
        }
    }
}