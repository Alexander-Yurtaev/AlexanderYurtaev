// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using Prism.Commands;
using System.Windows;
using System.Windows.Input;

namespace AlexanderYurtaev.Framework.EventHandlers
{
    public partial class AttachedProperties
    {
        public static readonly DependencyProperty OnEnterKeyDownProperty = DependencyProperty.RegisterAttached(
            "OnEnterKeyDown", typeof(DelegateCommand), typeof(AttachedProperties),
            new PropertyMetadata(default(DelegateCommand), OnOnEnterKeyDown));

        private static void OnOnEnterKeyDown(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = (UIElement)d;
            if (e.OldValue == null && e.NewValue != null)
            {
                element.KeyDown += ElementOnKeyDown;
            }
            else if (e.OldValue != null && e.NewValue == null)
            {
                element.KeyDown -= ElementOnKeyDown;
            }
        }

        public static void SetOnEnterKeyDown(DependencyObject element, DelegateCommand value)
        {
            element.SetValue(OnEnterKeyDownProperty, value);
        }

        public static DelegateCommand GetOnEnterKeyDown(DependencyObject element)
        {
            return (DelegateCommand)element.GetValue(OnEnterKeyDownProperty);
        }

        private static void ElementOnKeyDown(object sender, KeyEventArgs e)
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