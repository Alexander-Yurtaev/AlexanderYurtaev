// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using Prism.Mvvm;
using System;
using System.Windows.Media.Imaging;

namespace AlexanderYurtaev.Common
{
    public abstract class BaseModuleViewModel : BindableBase
    {
        public abstract string Title { get; }
        protected abstract string IconName { get; }

        public BitmapImage Icon
        {
            get
            {
                Uri uri = new Uri($"/DarkCode;component/Images/{IconName}.png", UriKind.Relative);
                return new BitmapImage(uri);
            }
        }
    }
}