// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Windows;
using System.Windows.Controls;

namespace AlexanderYurtaev.Controls.Visibleable
{
    public class VisibleableColumnDefinition : ColumnDefinition
    {
        static VisibleableColumnDefinition()
        {
            WidthProperty.OverrideMetadata(typeof(VisibleableColumnDefinition),
                new FrameworkPropertyMetadata(new GridLength(1, GridUnitType.Star), null, CoerceWidth));
        }

        private static object CoerceWidth(DependencyObject d, object value)
        {
            return (((VisibleableColumnDefinition)d).Visible) ? value : new GridLength(0);
        }

        #region Dependency Property Visible

        public static readonly DependencyProperty VisibleProperty = DependencyProperty.Register(
            "Visible", typeof(bool), typeof(VisibleableColumnDefinition), new PropertyMetadata(true, OnVisibleChanged));

        public bool Visible
        {
            get => (bool)GetValue(VisibleProperty);
            set => SetValue(VisibleProperty, value);
        }

        private static void OnVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.CoerceValue(WidthProperty);
        }

        #endregion Dependency Property Visible
    }
}