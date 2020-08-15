using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace AlexanderYurtaev.Framework.Behaviors
{
    public interface ICloseWindow
    {
        event EventHandler OnClose;
    }

    public class CloseWindowBehavior : BaseBehavior<Window>
    {
        public ICommand Close { get; set; }
        public ICloseWindow ViewModel => AssociatedObject.DataContext as ICloseWindow;

        #region Overrides of BaseBehavior<Window>

        protected override void Subscribe()
        {
            if (!(TagElement.DataContext is ICloseWindow viewModel)) return;
            viewModel.OnClose  += CloseHandler;
            TagElement.Closing += TagElementOnClosing;
        }

        protected override void UnSubscribe()
        {
            if (!(TagElement.DataContext is ICloseWindow viewModel)) return;
            viewModel.OnClose -= CloseHandler;
        }

        #endregion

        #region Handlers

        private void CloseHandler(object sender, EventArgs e)
        {
            AssociatedObject.Close();
        }

        private void TagElementOnClosing(object sender, CancelEventArgs e)
        {
            if (Close != null)
            {
                e.Cancel = !Close.CanExecute(null);
            }
        }

        #endregion Handlers
    }
}
