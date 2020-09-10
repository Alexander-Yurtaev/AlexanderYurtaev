// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Windows;
using Prism.Commands;

namespace AlexanderYurtaev.Framework.EventHandlers
{
    public partial class AttachedProperties
    {
        public static readonly DependencyProperty OnLoadedProperty = DependencyProperty.RegisterAttached(
            "OnLoaded", typeof(DelegateCommand), typeof(AttachedProperties),
            new PropertyMetadata(default(DelegateCommand), OnOnLoaded));

        private static void OnOnLoaded(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)d;
            if (e.OldValue == null && e.NewValue != null)
            {
                element.Loaded += ElementOnLoaded;
            }
            else if (e.OldValue != null && e.NewValue == null)
            {
                element.Loaded -= ElementOnLoaded;
            }
        }

        public static void SetOnLoaded(DependencyObject element, DelegateCommand value)
        {
            element.SetValue(OnLoadedProperty, value);
        }

        public static DelegateCommand GetOnLoaded(DependencyObject element)
        {
            return (DelegateCommand)element.GetValue(OnLoadedProperty);
        }

        private static void ElementOnLoaded(object sender, RoutedEventArgs e)
        {
            if (!(sender is FrameworkElement element)) return;

            DelegateCommand command = GetOnLoaded(element);
            if (command != null && command.CanExecute())
            {
                command.Execute();
            }
        }
    }
}