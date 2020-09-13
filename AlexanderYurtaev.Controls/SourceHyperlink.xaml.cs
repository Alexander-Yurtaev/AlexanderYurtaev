// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AlexanderYurtaev.Controls
{
    /// <summary>
    /// Interaction logic for SourceHyperlink.xaml
    /// </summary>
    public partial class SourceHyperlink : UserControl
    {
        public SourceHyperlink()
        {
            InitializeComponent();
        }

        #region DependencyProperty NavigateUri

        public static readonly DependencyProperty NavigateUriProperty = DependencyProperty.Register(
            "NavigateUri", typeof(string), typeof(SourceHyperlink), new PropertyMetadata(default(string)));

        public string NavigateUri
        {
            get => (string)GetValue(NavigateUriProperty);
            set => SetValue(NavigateUriProperty, value);
        }

        #endregion DependencyProperty NavigateUri

        #region DependencyProperty HyperlinkText

        public static readonly DependencyProperty HyperlinkTextProperty = DependencyProperty.Register(
            "HyperlinkText", typeof(string), typeof(SourceHyperlink), new PropertyMetadata(default(string)));

        public string HyperlinkText
        {
            get => (string)GetValue(HyperlinkTextProperty);
            set => SetValue(HyperlinkTextProperty, value);
        }

        #endregion DependencyProperty HyperlinkText

        private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
        }
    }
}