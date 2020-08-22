using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;

namespace AlexanderYurtaev.Framework.AttachedProperties
{
    public static class SystemContextMenu
    {
        ///<summary>
        /// For more <see href="www.pinvoke.net/default.aspx/Constants/WM.html">information</see>
        ///</summary>
        private const int WM_CONTEXTMENU = 0x007B;

        private const uint WM_NCRBUTTONDOWN = 0xa4;
        private const uint HTCAPTION = 0x02;

        private const int MF_BYPOSITION = 0x400;
        private const int MF_SEPARATOR = 0x800;
        
        private const int WM_SYSCOMMAND = 0x112;

        #region Attached property IsActive

        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.RegisterAttached(
            "IsActive", typeof(bool), typeof(SystemContextMenu), new PropertyMetadata(default(bool)));

        public static void SetIsActive(DependencyObject element, bool value)
        {
            element.SetValue(IsActiveProperty, value);
        }

        public static bool GetIsActive(DependencyObject element)
        {
            return (bool) element.GetValue(IsActiveProperty);
        }

        #endregion Attached property IsActive

        #region Attached property SystemContextMenu

        public static readonly DependencyProperty ContextMenuProperty = DependencyProperty.RegisterAttached(
            "SystemContextMenu", typeof(ContextMenu), typeof(Window),
            new PropertyMetadata(default(ContextMenu), ContextMenuChangedCallback));

        public static void SetContextMenu(DependencyObject element, ContextMenu value)
        {
            element.SetValue(ContextMenuProperty, value);
        }

        public static ContextMenu GetContextMenu(DependencyObject element)
        {
            return (ContextMenu)element.GetValue(ContextMenuProperty);
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
                wnd.Loaded -= WndOnLoaded;
                wnd.Loaded += WndOnLoaded;
            }
        }

        #endregion Attached property SystemContextMenu

        #region Attached property SystemContextMenuItems

        public static readonly DependencyProperty SystemContextMenuItemsProperty = DependencyProperty.RegisterAttached(
            "SystemContextMenuItems", typeof(ICollection<SystemContextItemBase>), typeof(SystemContextMenu),
            new PropertyMetadata(default(ICollection<SystemContextItemBase>), SystemContextMenuItemsChangedCallback));

        public static void SetSystemContextMenuItems(DependencyObject element, ICollection<SystemContextItemBase> value)
        {
            element.SetValue(SystemContextMenuItemsProperty, value);
        }

        public static ICollection<SystemContextItemBase> GetSystemContextMenuItems(DependencyObject element)
        {
            return (ICollection<SystemContextItemBase>) element.GetValue(SystemContextMenuItemsProperty);
        }

        private static void SystemContextMenuItemsChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is Window wnd)) return;

            if (wnd.IsLoaded)
            {
                if (SystemContextMenu.GetContextMenu(wnd) == null) AddHook(wnd);
            }
            else
            {
                wnd.Loaded -= WndOnLoaded;
                wnd.Loaded += WndOnLoaded;
            }
        }

        #endregion

        #region DllImports

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll")]
        private static extern bool InsertSystemMenuItem(IntPtr hWnd, int wPosition, int wFlags, int wIdNewItem, string lpNewItem);

        #endregion DllImports

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

            var systemContextMenuItems = GetSystemContextMenuItems(wnd);
            if (systemContextMenuItems?.Any() == true)
            {
                IntPtr systemMenuHandler = GetSystemMenu(windowHandler, false);
                foreach (SystemContextItemBase menuItem in systemContextMenuItems)
                {
                    int flags = MF_BYPOSITION;
                    if (menuItem is SystemContextSeparator)
                    {
                        flags = MF_BYPOSITION | MF_SEPARATOR;
                    }

                    InsertSystemMenuItem(systemMenuHandler, menuItem.Position, flags, menuItem.Id,
                        menuItem.Header);
                }
            }

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
            Window window = (Window)HwndSource.FromHwnd(hWnd)?.RootVisual;
            if (window == null) return IntPtr.Zero;

            if (msg == WM_CONTEXTMENU)
            {
                if (!GetIsActive(window)) return IntPtr.Zero;
            }

            if (msg == WM_NCRBUTTONDOWN && wParam.ToInt32() == HTCAPTION)
            {
                handled = ShowContextMenu(window);
            }

            if (msg == WM_SYSCOMMAND)
            {
                var systemContextMenuItems = GetSystemContextMenuItems(window);
                if (systemContextMenuItems?.Any() != true) return IntPtr.Zero;
                var id = wParam.ToInt32();
                if (!(systemContextMenuItems.FirstOrDefault(i => i.Id == id) is SystemContextItemWithAction
                    menuItem)) return IntPtr.Zero;
                if (menuItem.Command == null) return IntPtr.Zero;
                if (menuItem.Command.CanExecute(null))
                {
                    menuItem.Command.Execute(null);
                }
            }

            return IntPtr.Zero;
        }

        private static bool ShowContextMenu(Window window)
        {
            if (window == null) return false;
            var contextMenu = GetContextMenu(window);
            if (contextMenu == null) return false;
            contextMenu.IsOpen = true;
            return true;
        }
    }

    public abstract class SystemContextItemBase
    {
        protected SystemContextItemBase(int position, int id, string header)
        {
            Position = position;
            Id = id;
            Header = header;
        }

        public int Position { get; }
        public int Id { get; }

        public string Header { get; }
    }

    public class SystemContextSeparator : SystemContextItemBase
    {
        public SystemContextSeparator(int position, int id) : base(position, id, string.Empty)
        {

        }
    }

    public class SystemContextItemWithAction : SystemContextItemBase
    {
        public SystemContextItemWithAction(int position, int id, string header, ICommand command) : base(position, id, header)
        {
            Command = command;
        }

        public ICommand Command { get; }
    }
}
