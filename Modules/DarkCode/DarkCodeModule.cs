// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using AlexanderYurtaev.Common;
using AlexanderYurtaev.Common.Data;
using DarkCode.ViewModels;
using DarkCode.Views;
using Prism.Ioc;
using Prism.Regions;
using System;
using DarkCode.Controls;

namespace DarkCode
{
    public class DarkCodeModule : BaseModule
    {
        private readonly IRegionManager _regionManager;

        public DarkCodeModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
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
            containerRegistry.RegisterSingleton(typeof(FloatingGhostView));
            containerRegistry.RegisterSingleton(typeof(AmazingHoverEffectOnSocialMediaButtonsView));
            
            PreRegisterModule(containerRegistry);
            InitChildModuleItems();
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
            var animatedLoginFormModuleViewModel = ContainerLocator.Current.Resolve<AnimatedLoginFormModuleViewModel>();
            InitChildModuleItem(typeof(AnimatedLoginForm), animatedLoginFormModuleViewModel);

            var floatingGhostViewModel = ContainerLocator.Current.Resolve<FloatingGhostViewModel>();
            InitChildModuleItem(typeof(FloatingGhostView), floatingGhostViewModel);

            var amazingHoverEffectOnSocialMediaButtonsViewModel = ContainerLocator.Current.Resolve<AmazingHoverEffectOnSocialMediaButtonsViewModel>();
            InitChildModuleItem(typeof(AmazingHoverEffectOnSocialMediaButtonsView), amazingHoverEffectOnSocialMediaButtonsViewModel);
        }

        private void InitChildModuleItem(Type viewType, BaseModuleViewModel moduleViewModel)
        {
            Nodes.Add(new Node(this, viewType, moduleViewModel.Title, moduleViewModel.Icon));
        }
    }
}