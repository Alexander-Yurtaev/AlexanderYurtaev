// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Windows;
using System.Windows.Controls;
using Prism.Commands;

namespace AlexanderYurtaev.Framework.EventHandlers
{
    public partial class AttachedProperties
    {
        public static readonly DependencyProperty SelectedItemChangedProperty = DependencyProperty.RegisterAttached(
            "SelectedItemChanged", typeof(DelegateCommand<object>), typeof(AttachedProperties),
            new PropertyMetadata(default(DelegateCommand<object>), PropertyChangedCallback));

        public static void SetSelectedItemChanged(DependencyObject element, DelegateCommand<object> value)
        {
            element.SetValue(SelectedItemChangedProperty, value);
        }

        public static DelegateCommand<object> GetSelectedItemChanged(DependencyObject element)
        {
            return (DelegateCommand<object>) element.GetValue(SelectedItemChangedProperty);
        }

        private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TreeView treeView = (TreeView)d;
            if (e.OldValue == null && e.NewValue != null)
            {
                treeView.SelectedItemChanged += TreeViewOnSelectedItemChanged;
            }
            else if (e.OldValue != null && e.NewValue == null)
            {
                treeView.SelectedItemChanged -= TreeViewOnSelectedItemChanged;
            }
        }

        private static void TreeViewOnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (!(sender is TreeView treeView)) return;

            DelegateCommand<object> command = GetSelectedItemChanged(treeView);
            if (command != null && command.CanExecute(e.NewValue))
            {
                command.Execute(e.NewValue);
            }
        }
    }
}