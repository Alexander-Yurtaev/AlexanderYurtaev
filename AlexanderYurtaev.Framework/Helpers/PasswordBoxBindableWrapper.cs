// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using System;
using System.Windows;
using System.Windows.Controls;

namespace AlexanderYurtaev.Framework.Helpers
{
    public class PasswordBoxBindableWrapper : FrameworkElement
    {
        #region DependencyProperty PasswordBox

        public static readonly DependencyProperty PasswordBoxProperty = DependencyProperty.Register(
            "PasswordBox", typeof(PasswordBox), typeof(PasswordBoxBindableWrapper),
            new PropertyMetadata(default(PasswordBox), PasswordBoxPropertyChangedCallback));

        private static void PasswordBoxPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is PasswordBoxBindableWrapper wrapper)) throw new ArgumentException(nameof(d));

            if (e.OldValue is PasswordBox oldPasswordBox)
            {
                oldPasswordBox.Loaded -= wrapper.PasswordBoxOnLoaded;
                oldPasswordBox.Unloaded -= wrapper.PasswordBoxOnUnloaded;
                oldPasswordBox.PasswordChanged -= wrapper.PasswordBoxOnPasswordChanged;
            }

            if (e.NewValue is PasswordBox newPasswordBox)
            {
                if (newPasswordBox.IsLoaded)
                {
                    newPasswordBox.Unloaded += wrapper.PasswordBoxOnUnloaded;
                    newPasswordBox.PasswordChanged += wrapper.PasswordBoxOnPasswordChanged;
                }
                else
                {
                    newPasswordBox.Loaded += wrapper.PasswordBoxOnLoaded;
                }
            }
        }

        private void PasswordBoxOnLoaded(object sender, RoutedEventArgs e)
        {
            if (!(sender is PasswordBox passwordBox)) throw new ArgumentException(nameof(passwordBox));

            passwordBox.Loaded -= PasswordBoxOnLoaded;
            passwordBox.Unloaded += PasswordBoxOnUnloaded;
            passwordBox.PasswordChanged += PasswordBoxOnPasswordChanged;
        }

        private void PasswordBoxOnUnloaded(object sender, RoutedEventArgs e)
        {
            if (!(sender is PasswordBox passwordBox)) throw new ArgumentException(nameof(passwordBox));

            passwordBox.Loaded += PasswordBoxOnLoaded;
            passwordBox.Unloaded -= PasswordBoxOnUnloaded;
            passwordBox.PasswordChanged -= PasswordBoxOnPasswordChanged;
        }

        private void PasswordBoxOnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!(sender is PasswordBox passwordBox)) throw new ArgumentException(nameof(passwordBox));

            Password = passwordBox.Password;
        }

        public PasswordBox PasswordBox
        {
            get => (PasswordBox)GetValue(PasswordBoxProperty);
            set => SetValue(PasswordBoxProperty, value);
        }

        #endregion DependencyProperty PasswordBox

        #region DependencyProperty Password

        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register(
            "Password", typeof(string), typeof(PasswordBoxBindableWrapper), new PropertyMetadata(default(string)));

        public string Password
        {
            get => (string)GetValue(PasswordProperty);
            set => SetValue(PasswordProperty, value);
        }

        #endregion DependencyProperty Password
    }
}