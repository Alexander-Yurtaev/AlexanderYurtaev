// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using System.Globalization;
using System.Windows;
using System.Windows.Markup;

namespace AlexanderYurtaev.Framework.Helpers
{
    public static class LocalizationHelper
    {
        public static void SetGlobalLanguage()
        {
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement),
                new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.Name)));
        }

        public static void SetGlobalFlowDirection()
        {
            var flowDirection = CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft
                ? FlowDirection.RightToLeft
                : FlowDirection.LeftToRight;

            FrameworkElement.FlowDirectionProperty.OverrideMetadata(typeof(FrameworkElement),
                new FrameworkPropertyMetadata(flowDirection));
        }

        public static void SetGlobalLocalization()
        {
            SetGlobalLanguage();
            SetGlobalFlowDirection();
        }
    }
}