// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using System.Windows.Controls;
using System.Windows.Navigation;

namespace DarkCode.Views
{
    /// <summary>
    /// Interaction logic for AnimatedLoginForm
    /// </summary>
    public partial class AnimatedLoginForm : UserControl
    {
        public AnimatedLoginForm()
        {
            InitializeComponent();
        }

        private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
        }
    }
}