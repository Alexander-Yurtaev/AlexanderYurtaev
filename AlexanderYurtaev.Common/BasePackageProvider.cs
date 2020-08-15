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
