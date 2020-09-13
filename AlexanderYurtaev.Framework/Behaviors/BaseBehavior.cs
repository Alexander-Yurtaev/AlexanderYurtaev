// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using Microsoft.Xaml.Behaviors;
using System.Windows;

namespace AlexanderYurtaev.Framework.Behaviors
{
    public abstract class BaseBehavior<T> : Behavior<T> where T : FrameworkElement
    {
        protected T TargetElement;

        protected override void OnAttached()
        {
            base.OnAttached();
            TargetElement = AssociatedObject;
            if (TargetElement.IsLoaded)
            {
                Subscribe();
                TargetElement.Unloaded += AssociatedObjectOnUnloaded;
            }
            else
            {
                TargetElement.Loaded += AssociatedObjectOnLoaded;
            }
        }

        protected override void OnDetaching()
        {
            TargetElement.Loaded -= AssociatedObjectOnLoaded;
            TargetElement.Unloaded -= AssociatedObjectOnUnloaded;
            UnSubscribe();
        }

        #region Hendlers

        private void AssociatedObjectOnLoaded(object sender, RoutedEventArgs e)
        {
            UnSubscribe();
            Subscribe();
            TargetElement.Unloaded -= AssociatedObjectOnLoaded;
            TargetElement.Unloaded += AssociatedObjectOnUnloaded;
        }

        private void AssociatedObjectOnUnloaded(object sender, RoutedEventArgs e)
        {
            UnSubscribe();
            TargetElement.Unloaded += AssociatedObjectOnLoaded;
            TargetElement.Unloaded -= AssociatedObjectOnUnloaded;
        }

        #endregion Hendlers

        protected abstract void Subscribe();

        protected abstract void UnSubscribe();
    }
}