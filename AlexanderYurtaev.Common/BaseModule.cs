using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using AlexanderYurtaev.Common.Data;
using Prism.Ioc;

namespace AlexanderYurtaev.Common
{
    public abstract class BaseModule : IBaseModule
    {
        private BitmapImage _icon;

        public BitmapImage Icon
        {
            get
            {
                Uri uri = new Uri("/" + AssemblyName + ";component/Icon.png", UriKind.Relative);
                return _icon ?? (_icon = new BitmapImage(uri));
            }
        }

        public List<Node> Nodes { get; } = new List<Node>();
        
        public abstract string Title { get; }
        public abstract Type View { get; }
        private string AssemblyName => GetType().Assembly.ToString().Split(',')[0];

        public abstract void Select(Type viewType);

        protected void PreRegisterModule(IContainerRegistry containerRegistry)
        {
            var isRegistered = containerRegistry.IsRegistered<List<BaseModule>>();
            if (!isRegistered)
            {
                var modules = new List<BaseModule>();
                containerRegistry.RegisterInstance(modules);
            }
        }

        protected void RegisterModule(IContainerProvider containerProvider)
        {
            var modules = containerProvider.Resolve<List<BaseModule>>();
            modules.Add(this);
        }

        #region Implementation of IModule

        public abstract void OnInitialized(IContainerProvider containerProvider);

        public abstract void RegisterTypes(IContainerRegistry containerRegistry);
        #endregion
    }
}
