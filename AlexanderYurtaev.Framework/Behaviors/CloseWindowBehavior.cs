using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace AlexanderYurtaev.Framework.Behaviors
{
    public interface ICloseWindow
    {
        event EventHandler OnClose;
    }

    public class CloseWindowBehavior : Behavior<Window>
    {
        public ICommand Close { get; set; }
        public ICloseWindow ViewModel => AssociatedObject.DataContext as ICloseWindow;

        protected override void OnAttached()
        {
            base.OnAttached();
            
            UnSubscribeViewModel(ViewModel);
            SubscribeViewModel(ViewModel);
            AssociatedObject.DataContextChanged += AssociatedObjectOnDataContextChanged;
            
            AssociatedObject.Closing += AssociatedObjectOnClosing;
        }

        protected override void OnDetaching()
        {
            UnSubscribeViewModel(ViewModel);
            AssociatedObject.DataContextChanged -= AssociatedObjectOnDataContextChanged;
            AssociatedObject.Closing -= AssociatedObjectOnClosing;

            base.OnDetaching();
        }

        #region Handlers

        private void AssociatedObjectOnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void CloseHandler(object sender, EventArgs e)
        {
            AssociatedObject.Close();
        }

        private void AssociatedObjectOnClosing(object sender, CancelEventArgs e)
        {
            if (Close != null)
            {
                e.Cancel = !Close.CanExecute(null);
            }
        }

        #endregion Handlers

        #region Private Methods

        private void SubscribeViewModel(ICloseWindow viewModel)
        {
            if (viewModel == null) return;
            viewModel.OnClose  += CloseHandler;
        }

        private void UnSubscribeViewModel(ICloseWindow viewModel)
        {
            if (viewModel == null) return;
            viewModel.OnClose -= CloseHandler;
        }

        #endregion Private Methods
    }
}
