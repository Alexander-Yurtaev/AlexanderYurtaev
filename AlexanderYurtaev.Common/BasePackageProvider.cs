// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Windows;
using Prism.Ioc;
using Prism.Modularity;

namespace AlexanderYurtaev.Common
{
    public abstract class BasePackageProvider : IModule
    {
        protected BasePackageProvider()
        {
        }

        public abstract string Name { get; }
        public abstract string PreviewImagePath { get; }  //"/Colorlib;component/LoginForm.jpg";

        #region List of resources - styles, colors, brushes, and etc

        public abstract ResourceDictionary ResourceDictionary { get; }

        #endregion List of resources - styles, colors, brushes, and etc

        #region LoginForm

        protected abstract Window CreateEmptyForm();

        public Window CreateForm(object dataContext)
        {
            var window = CreateEmptyForm();
            window.DataContext = dataContext;
            return window;
        }

        #endregion LoginForm

        #region Implementation of IModule

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // ResourceDictionaryProvider
            // LoginFormProvider
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            // ???
        }

        #endregion
    }
}