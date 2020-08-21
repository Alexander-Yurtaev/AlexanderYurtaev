using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace AlexanderYurtaev.Framework.AttachedProperties
{
    public static class SystemContextMenu
    {
        ///<summary>
        /// For more <see href="www.pinvoke.net/default.aspx/Constants/WM.html">information</see>
        ///</summary>
        private const uint WN_NCRBUTTONDOWN = 0x0a4;
        private const uint HTCAPTION = 0x02;

        public static readonly DependencyProperty ContextMenuProperty = DependencyProperty.RegisterAttached(
            "ContextMenu", typeof(ContextMenu), typeof(Window),
            new PropertyMetadata(default(ContextMenu), ContextMenuChangedCallback));

        public static void SetContextMenu(DependencyObject element, ContextMenu value)
        {
            element.SetValue(ContextMenuProperty, value);
        }

        public static ContextMenu GetContextMenu(DependencyObject element)
        {
            return (ContextMenu) element.GetValue(ContextMenuProperty);
        }

        private static void ContextMenuChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is Window wnd)) return;

            if (wnd.IsLoaded)
            {
                AddHook(wnd);
            }
            else
            {
                wnd.Loaded += WndOnLoaded;
            }
        }

        private static void WndOnLoaded(object sender, RoutedEventArgs e)
        {
            if (!(e.OriginalSource is Window wnd)) return;

            wnd.Loaded -= WndOnLoaded;
            wnd.Unloaded += WndOnUnloaded;

            AddHook(wnd);
        }

        private static void WndOnUnloaded(object sender, RoutedEventArgs e)
        {
            if (!(e.OriginalSource is Window wnd)) return;

            wnd.Loaded += WndOnLoaded;
            wnd.Unloaded -= WndOnUnloaded;

            RemoveHook(wnd);
        }

        private static void AddHook(Window wnd)
        {
            IntPtr windowHandler = new WindowInteropHelper(wnd).Handle;
            HwndSource hwndSource = HwndSource.FromHwnd(windowHandler);
            hwndSource?.AddHook(WndProc);
        }

        private static void RemoveHook(Window wnd)
        {
            IntPtr windowHandler = new WindowInteropHelper(wnd).Handle;
            HwndSource hwndSource = HwndSource.FromHwnd(windowHandler);
            hwndSource?.RemoveHook(WndProc);
        }

        private static IntPtr WndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WN_NCRBUTTONDOWN && wParam.ToInt32() == HTCAPTION)
            {
                ShowContextMenu(hWnd);

                handled = true;
            }

            return IntPtr.Zero;
        }

        private static void ShowContextMenu(IntPtr hWnd)
        {
            Window window = (Window) HwndSource.FromHwnd(hWnd)?.RootVisual;
            var contextMenu = SystemContextMenu.GetContextMenu(window);
            if (contextMenu == null) return;
            contextMenu.IsOpen = true;
        }
    }
}
