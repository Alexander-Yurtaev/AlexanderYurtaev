// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;

namespace AlexanderYurtaev.Framework.Behaviors
{
    public class SystemContextMenuBehavior : BaseBehavior<Window>
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

        #region IsActive

        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register(
            "IsActive", typeof(bool), typeof(SystemContextMenuBehavior), new PropertyMetadata(default(bool)));

        public bool IsActive
        {
            get => (bool)GetValue(IsActiveProperty);
            set => SetValue(IsActiveProperty, value);
        }

        #endregion IsActive

        #region SystemContextMenu

        public static readonly DependencyProperty SystemContextMenuProperty = DependencyProperty.Register(
            "SystemContextMenu", typeof(ContextMenu), typeof(SystemContextMenuBehavior),
            new PropertyMetadata(default(ContextMenu)));

        public ContextMenu SystemContextMenu
        {
            get => (ContextMenu)GetValue(SystemContextMenuProperty);
            set => SetValue(SystemContextMenuProperty, value);
        }

        #endregion

        #region SystemContextItemBase

        public static readonly DependencyProperty SystemContextMenuItemsProperty = DependencyProperty.Register(
            "SystemContextMenuItems", typeof(ICollection<SystemContextItemBase>), typeof(SystemContextMenuBehavior),
            new PropertyMetadata(default(ICollection<SystemContextItemBase>)));

        public ICollection<SystemContextItemBase> SystemContextMenuItems
        {
            get => (ICollection<SystemContextItemBase>)GetValue(SystemContextMenuItemsProperty);
            set => SetValue(SystemContextMenuItemsProperty, value);
        }

        #endregion SystemContextItemBase

        #region DllImports

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll")]
        private static extern bool InsertSystemMenuItem(IntPtr hWnd, int wPosition, int wFlags, int wIdNewItem, string lpNewItem);

        #endregion DllImports

        #region Overrides of BaseBehavior<Window>

        protected override void Subscribe()
        {
            AddHook(TargetElement);
        }

        protected override void UnSubscribe()
        {
            RemoveHook(TargetElement);
        }

        #endregion

        #region Private Methods

        private void AddHook(Window wnd)
        {
            IntPtr windowHandler = new WindowInteropHelper(wnd).Handle;
            HwndSource hwndSource = HwndSource.FromHwnd(windowHandler);

            if (SystemContextMenuItems?.Any() == true)
            {
                IntPtr systemMenuHandler = GetSystemMenu(windowHandler, false);
                foreach (SystemContextItemBase menuItem in SystemContextMenuItems)
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

        private void RemoveHook(Window wnd)
        {
            IntPtr windowHandler = new WindowInteropHelper(wnd).Handle;
            HwndSource hwndSource = HwndSource.FromHwnd(windowHandler);
            hwndSource?.RemoveHook(WndProc);
        }

        private IntPtr WndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            Window window = (Window)HwndSource.FromHwnd(hWnd)?.RootVisual;
            if (window == null) return IntPtr.Zero;

            if (msg == WM_CONTEXTMENU)
            {
                if (!IsActive) return IntPtr.Zero;
            }

            if (msg == WM_NCRBUTTONDOWN && wParam.ToInt32() == HTCAPTION)
            {
                handled = ShowContextMenu();
            }

            if (msg == WM_SYSCOMMAND)
            {
                if (SystemContextMenuItems?.Any() != true) return IntPtr.Zero;
                var id = wParam.ToInt32();
                if (!(SystemContextMenuItems.FirstOrDefault(i => i.Id == id) is SystemContextItemWithAction
                    menuItem)) return IntPtr.Zero;
                if (menuItem.Command == null) return IntPtr.Zero;
                if (menuItem.Command.CanExecute(null))
                {
                    menuItem.Command.Execute(null);
                }
            }

            return IntPtr.Zero;
        }

        private bool ShowContextMenu()
        {
            if (SystemContextMenu == null) return false;
            SystemContextMenu.IsOpen = true;
            return true;
        }

        #endregion Private Methods
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
