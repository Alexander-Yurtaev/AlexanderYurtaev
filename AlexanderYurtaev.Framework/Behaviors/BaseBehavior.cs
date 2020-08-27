// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Microsoft.Xaml.Behaviors;
using System.Windows;

namespace AlexanderYurtaev.Framework.Behaviors
{
    public abstract class BaseBehavior<T> : Behavior<T> where T : FrameworkElement
    {
        protected T TagElement;

        protected override void OnAttached()
        {
            base.OnAttached();
            TagElement = AssociatedObject;
            if (TagElement.IsLoaded)
            {
                Subscribe();
                TagElement.Unloaded += AssociatedObjectOnUnloaded;
            }
            else
            {
                TagElement.Loaded += AssociatedObjectOnLoaded;
            }
        }

        protected override void OnDetaching()
        {
            TagElement.Loaded -= AssociatedObjectOnLoaded;
            TagElement.Unloaded -= AssociatedObjectOnUnloaded;
            UnSubscribe();
        }

        #region Hendlers

        private void AssociatedObjectOnLoaded(object sender, RoutedEventArgs e)
        {
            UnSubscribe();
            Subscribe();
            TagElement.Unloaded -= AssociatedObjectOnLoaded;
            TagElement.Unloaded += AssociatedObjectOnUnloaded;
        }

        private void AssociatedObjectOnUnloaded(object sender, RoutedEventArgs e)
        {
            UnSubscribe();
            TagElement.Unloaded += AssociatedObjectOnLoaded;
            TagElement.Unloaded -= AssociatedObjectOnUnloaded;
        }

        #endregion Hendlers

        protected abstract void Subscribe();

        protected abstract void UnSubscribe();
    }
}