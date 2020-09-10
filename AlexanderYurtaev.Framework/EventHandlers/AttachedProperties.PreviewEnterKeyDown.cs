// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Windows;
using System.Windows.Input;
using Prism.Commands;

namespace AlexanderYurtaev.Framework.EventHandlers
{
    public partial class AttachedProperties
    {
        public static readonly DependencyProperty OnPreviewEnterKeyDownProperty = DependencyProperty.RegisterAttached(
            "OnPreviewEnterKeyDown", typeof(DelegateCommand), typeof(AttachedProperties),
            new PropertyMetadata(default(DelegateCommand), OnOnPreviewEnterKeyDown));

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

        public static void SetOnPreviewEnterKeyDown(DependencyObject element, DelegateCommand value)
        {
            element.SetValue(OnPreviewEnterKeyDownProperty, value);
        }

        public static DelegateCommand GetOnPreviewEnterKeyDown(DependencyObject element)
        {
            return (DelegateCommand)element.GetValue(OnPreviewEnterKeyDownProperty);
        }

        private static void ElementOnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.Key != (int)Key.Enter) return;
            if (!(sender is UIElement element)) return;

            DelegateCommand command = GetOnEnterKeyDown(element);
            if (command != null && command.CanExecute())
            {
                command.Execute();
            }
        }
    }
}