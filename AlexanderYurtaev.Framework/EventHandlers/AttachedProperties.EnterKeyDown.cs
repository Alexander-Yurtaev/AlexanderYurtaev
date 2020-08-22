using System.Windows;
using System.Windows.Input;

namespace AlexanderYurtaev.Framework.EventHandlers
{
    public partial class AttachedProperties
    {
        public static readonly DependencyProperty OnEnterKeyDownProperty = DependencyProperty.RegisterAttached(
            "OnEnterKeyDown", typeof(ICommand), typeof(AttachedProperties),
            new PropertyMetadata(default(ICommand), OnOnEnterKeyDown));

        private static void OnOnEnterKeyDown(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = (UIElement) d;
            if (e.OldValue == null && e.NewValue != null)
            {
                element.KeyDown += ElementOnKeyDown;
            }
            else if (e.OldValue != null && e.NewValue == null)
            {
                element.KeyDown -= ElementOnKeyDown;
            }
        }

        public static void SetOnEnterKeyDown(DependencyObject element, ICommand value)
        {
            element.SetValue(OnEnterKeyDownProperty, value);
        }

        public static ICommand GetOnEnterKeyDown(DependencyObject element)
        {
            return (ICommand) element.GetValue(OnEnterKeyDownProperty);
        }

        private static void ElementOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter && e.Key != Key.Return) return;
            if (!(sender is UIElement element)) return;

            ICommand command = GetOnEnterKeyDown(element);
            if (command != null && command.CanExecute(element))
            {
                command.Execute(element);
            }
        }
    }
}
