using System.Windows;
using AlexanderYurtaev.Common;

namespace Colorlib
{
    public class PackageProvider : BasePackageProvider
    {
        public PackageProvider() : base()
        {
        }

        public override string Name => "Colorlib";
        public override string ImagePath => "/Colorlib;component/LoginForm.jpg";
        protected override Window CreateEmptyForm()
        {
            return new LoginForm();
        }
    }
}
