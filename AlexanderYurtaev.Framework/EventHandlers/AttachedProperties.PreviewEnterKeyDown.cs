using System.Windows;
using System.Windows.Input;

namespace AlexanderYurtaev.Framework.EventHandlers
{
    public partial class AttachedProperties
    {
        public static readonly DependencyProperty OnPreviewEnterKeyDownProperty = DependencyProperty.RegisterAttached(
            "OnPreviewEnterKeyDown", typeof(ICommand), typeof(AttachedProperties),
            new PropertyMetadata(default(ICommand), OnOnPreviewEnterKeyDown));

        private static void OnOnPreviewEnterKeyDown(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = (UIElement)d;
            if (e.OldValue == null && e.NewValue != null)
            {
                element.PreviewKeyDown += ElementOnPreviewKeyDown;
            }
            else if (e.OldValue != null && e.NewValue == null)
            {
                element.PreviewKeyDown -= ElementOnPreviewKeyDown;
            }
        }

        public static void SetOnPreviewEnterKeyDown(DependencyObject element, ICommand value)
        {
            element.SetValue(OnPreviewEnterKeyDownProperty, value);
        }

        public static ICommand GetOnPreviewEnterKeyDown(DependencyObject element)
        {
            return (ICommand)element.GetValue(OnPreviewEnterKeyDownProperty);
        }

        private static void ElementOnPreviewKeyDown(object sender, KeyEventArgs e)
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
