using System;
using System.Reflection;
using System.Windows.Media.Imaging;
using Prism.Ioc;
using Prism.Modularity;

namespace AlexanderYurtaev.Common
{
    public abstract class BaseModule : IModule
    {
        private BitmapImage _icon;

        public abstract string Name { get; }
        private BitmapImage Icon
        {
            get
            {
                var assembly = Assembly.GetCallingAssembly();

                Uri uri = new Uri("/" + GetType().Assembly.ToString().Split(',')[0] + ";component/Icon.png", UriKind.Relative);

                return _icon ?? (_icon = new BitmapImage(uri));
            }
        }

        #region Implementation of IModule

        public abstract void RegisterTypes(IContainerRegistry containerRegistry);

        public abstract void OnInitialized(IContainerProvider containerProvider);

        #endregion
    }
}
