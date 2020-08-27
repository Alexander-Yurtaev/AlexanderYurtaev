// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using AlexanderYurtaev.Common;
using System.Windows;

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