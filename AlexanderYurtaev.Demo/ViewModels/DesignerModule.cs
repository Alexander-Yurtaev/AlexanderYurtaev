// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using AlexanderYurtaev.Common;
using AlexanderYurtaev.Common.Data;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace AlexanderYurtaev.Demo.ViewModels
{
    internal class DesignerModule : IBaseModule
    {
        private BitmapImage _icon;

        public DesignerModule(string title)
        {
            Title = title;
        }

        #region Implementation of IModule

        public void OnInitialized(IContainerProvider containerProvider)
        {
            throw new System.NotImplementedException();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            throw new System.NotImplementedException();
        }

        #endregion Implementation of IModule

        #region Implementation of IBaseModule

        public BitmapImage Icon
        {
            get
            {
                Uri uri = new Uri("/" + AssemblyName + ";component/DesignerMode/Icon.png", UriKind.Relative);
                return _icon ?? (_icon = new BitmapImage(uri));
            }
        }

        public List<Node> Nodes => new List<Node>
        {
            new Node(null, $"{Title}1", null, null),
            new Node(null, $"{Title}2", null, null),
        };

        public string Title { get; }

        public Type View { get; }

        public void Select(Type viewType)
        {
            throw new NotImplementedException();
        }

        #endregion Implementation of IBaseModule

        private string AssemblyName => GetType().Assembly.ToString().Split(',')[0];
    }
}