// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Windows;

namespace AlexanderYurtaev.Common
{
    public abstract class BasePackageProvider
    {
        protected BasePackageProvider()
        {
        }

        public abstract string Name { get; }
        public abstract string ImagePath { get; }  //"/Colorlib;component/LoginForm.jpg";

        protected abstract Window CreateEmptyForm();

        public Window CreateForm(object dataContext)
        {
            var window = CreateEmptyForm();
            window.DataContext = dataContext;
            return window;
        }
    }
}