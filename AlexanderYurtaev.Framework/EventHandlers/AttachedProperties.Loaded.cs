using System.Windows;
using System.Windows.Input;

namespace AlexanderYurtaev.Framework.EventHandlers
{
    public partial class AttachedProperties
    {
        public static readonly DependencyProperty OnLoadedProperty = DependencyProperty.RegisterAttached(
            "OnLoaded", typeof(ICommand), typeof(AttachedProperties),
            new PropertyMetadata(default(ICommand), OnOnLoaded));

        private static void OnOnLoaded(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement) d;
            if (e.OldValue == null && e.NewValue != null)
            {
                element.Loaded += ElementOnLoaded;
            }
            else if (e.OldValue != null && e.NewValue == null)
            {
                element.Loaded -= ElementOnLoaded;
            }
        }

        public static void SetOnLoaded(DependencyObject element, ICommand value)
        {
            element.SetValue(OnLoadedProperty, value);
        }

        public static ICommand GetOnLoaded(DependencyObject element)
        {
            return (ICommand) element.GetValue(OnLoadedProperty);
        }

        private static void ElementOnLoaded(object sender, RoutedEventArgs e)
        {
            if (!(sender is FrameworkElement element)) return;

            ICommand command = GetOnLoaded(element);
            if (command != null && command.CanExecute(element))
            {
                command.Execute(element);
            }
        }
    }
}
