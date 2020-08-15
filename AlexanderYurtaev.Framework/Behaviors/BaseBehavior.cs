using System.Windows;
using Microsoft.Xaml.Behaviors;

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

        #endregion Handlers

        protected abstract void Subscribe();
        protected abstract void UnSubscribe();
    }
}
