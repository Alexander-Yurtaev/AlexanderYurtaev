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
            "Fill", typeof(Brush), typeof(FloatingGhost), new PropertyMetadata(default(Brush)));

        public Brush Fill
        {
            get => (Brush) GetValue(FillProperty);
            set => SetValue(FillProperty, value);
        }

        #endregion
    }
}
