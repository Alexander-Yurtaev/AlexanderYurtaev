// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DarkCode.Controls
{
    /// <summary>
    /// Interaction logic for FloatingGhost.xaml
    /// </summary>
    public partial class FloatingGhost : UserControl
    {
        public FloatingGhost()
        {
            InitializeComponent();
        }

        #region Fill

        public static readonly DependencyProperty FillProperty = DependencyProperty.Register(
            "Fill", typeof(Brush), typeof(FloatingGhost),
            new PropertyMetadata(new SolidColorBrush(Color.FromRgb(0xf2, 0xf2, 0xf2))));

        public Brush Fill
        {
            get => (Brush)GetValue(FillProperty);
            set => SetValue(FillProperty, value);
        }

        #endregion Fill
    }
}