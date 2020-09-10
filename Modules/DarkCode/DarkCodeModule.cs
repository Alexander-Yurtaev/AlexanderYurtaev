using System;
using AlexanderYurtaev.Common;
using AlexanderYurtaev.Common.Data;
using DarkCode.ViewModels;
using DarkCode.Views;
using Prism.Ioc;
using Prism.Regions;

namespace DarkCode
{
    public class DarkCodeModule : BaseModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainerProvider _containerProvider;

        public DarkCodeModule(IRegionManager regionManager, IContainerProvider containerProvider)
        {
            _regionManager = regionManager;
            _containerProvider = containerProvider;
            InitChildModuleItems();
        }

        public override string Title => "DarkCode";
        public override Type View => typeof(MainView);

        public override void OnInitialized(IContainerProvider containerProvider)
        {
            RegisterModule(containerProvider);
        }

        public override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton(typeof(MainView));
            containerRegistry.RegisterSingleton(typeof(AnimatedLoginForm));
            PreRegisterModule(containerRegistry);
        }

        public override void Select(Type viewType)
        {
            //_regionManager.Regions["MyRegion"].Add(myView, "MyView");
            //var theView = _regionManager.Regions["MyRegion"].GetView("MyView");
            //_regionManager.Regions["MyRegion"].Remove(theView);
            
            var region = _regionManager.Regions[Constants.MainRegionName];
            region.RemoveAll();
            _regionManager.RegisterViewWithRegion(Constants.MainRegionName, viewType);
        }

        private void InitChildModuleItems()
        {
            Nodes.Add(new Node(this, AnimatedLoginFormViewModel.Title, typeof(AnimatedLoginForm), Icon));
        }
    }
}