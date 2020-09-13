// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using System.Windows;
using System.Windows.Media;

namespace AlexanderYurtaev.Framework.Helpers
{
    public static class LinearGradientBrushHelper
    {
        #region SetEndPointFromAngle

        public static readonly DependencyProperty AngleProperty = DependencyProperty.RegisterAttached(
            "Angle", typeof(double), typeof(LinearGradientBrush),
            new PropertyMetadata(default(double), AngleChangedCallback));

        public static void SetAngle(DependencyObject element, double value)
        {
            element.SetValue(AngleProperty, value);
        }

        public static double GetAngle(DependencyObject element)
        {
            return (double)element.GetValue(AngleProperty);
        }

        private static void AngleChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var angle = e.NewValue is double value ? value : 0;
            if (!(d is LinearGradientBrush brush)) return;

            var rotateTransform = new RotateTransform(angle, 0.5, 0.5);
            var transformGroup = new TransformGroup();
            transformGroup.Children.Add(rotateTransform);
            brush.RelativeTransform = transformGroup;
        }

        #endregion SetEndPointFromAngle
    }
}