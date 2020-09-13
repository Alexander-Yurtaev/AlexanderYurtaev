// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
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
            if (!(TargetElement.DataContext is ICloseWindow viewModel)) return;
            viewModel.OnClose += CloseHandler;
            TargetElement.Closing += TargetElementOnClosing;
        }

        protected override void UnSubscribe()
        {
            if (!(TargetElement.DataContext is ICloseWindow viewModel)) return;
            viewModel.OnClose -= CloseHandler;
        }

        #endregion Overrides of BaseBehavior<Window>

        #region Handlers

        private void CloseHandler(object sender, EventArgs e)
        {
            AssociatedObject.Close();
        }

        private void TargetElementOnClosing(object sender, CancelEventArgs e)
        {
            if (Close != null)
            {
                e.Cancel = !Close.CanExecute(null);
            }
        }

        #endregion Handlers
    }
}