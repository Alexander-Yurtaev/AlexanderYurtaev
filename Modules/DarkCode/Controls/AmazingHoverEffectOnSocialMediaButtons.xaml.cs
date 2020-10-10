// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace DarkCode.Controls
{
    /// <summary>
    /// Interaction logic for AmazingHoverEffectOnSocialMediaButtons.xaml
    /// </summary>
    public partial class AmazingHoverEffectOnSocialMediaButtons : UserControl
    {
        public AmazingHoverEffectOnSocialMediaButtons()
        {
            InitializeComponent();
        }

        private static bool ValidateValueCallback(object value)
        {
            var url = value?.ToString();
            if (string.IsNullOrEmpty(url)) return true;
            var isWellFormed = Uri.IsWellFormedUriString(url, UriKind.Absolute);
            if (!isWellFormed) return false;
            var uri = new Uri(url);
            return uri.IsAbsoluteUri;
        }

        #region Facebook

        #region FacebookLink

        public static readonly DependencyProperty FacebookLinkProperty = DependencyProperty.Register(
            "FacebookLink", typeof(string), typeof(AmazingHoverEffectOnSocialMediaButtons),
            new FrameworkPropertyMetadata(default(string)), ValidateValueCallback);

        public string FacebookLink
        {
            get => (string)GetValue(FacebookLinkProperty);
            set => SetValue(FacebookLinkProperty, value);
        }

        #endregion

        #region ShowFacebookLink

        public static readonly DependencyProperty ShowFacebookLinkProperty = DependencyProperty.Register(
            "ShowFacebookLink", typeof(bool), typeof(AmazingHoverEffectOnSocialMediaButtons),
            new PropertyMetadata(true));

        public bool ShowFacebookLink
        {
            get => (bool) GetValue(ShowFacebookLinkProperty);
            set => SetValue(ShowFacebookLinkProperty, value);
        }

        #endregion ShowFacebookLink

        #endregion Facebook

        #region Twitter

        #region TwitterLink

        public static readonly DependencyProperty TwitterLinkProperty = DependencyProperty.Register(
            "TwitterLink", typeof(string), typeof(AmazingHoverEffectOnSocialMediaButtons),
            new FrameworkPropertyMetadata(default(string)), ValidateValueCallback);

        public string TwitterLink
        {
            get => (string)GetValue(TwitterLinkProperty);
            set => SetValue(TwitterLinkProperty, value);
        }

        #endregion

        #region ShowTwitterLink

        public static readonly DependencyProperty ShowTwitterLinkProperty = DependencyProperty.Register(
            "ShowTwitterLink", typeof(bool), typeof(AmazingHoverEffectOnSocialMediaButtons),
            new PropertyMetadata(true));

        public bool ShowTwitterLink
        {
            get => (bool) GetValue(ShowTwitterLinkProperty);
            set => SetValue(ShowTwitterLinkProperty, value);
        }

        #endregion ShowTwitterLink

        #endregion Twitter

        #region Instagram

        #region InstagramLink

        public static readonly DependencyProperty InstagramLinkProperty = DependencyProperty.Register(
            "InstagramLink", typeof(string), typeof(AmazingHoverEffectOnSocialMediaButtons),
            new FrameworkPropertyMetadata(default(string)), ValidateValueCallback);

        public string InstagramLink
        {
            get => (string)GetValue(InstagramLinkProperty);
            set => SetValue(InstagramLinkProperty, value);
        }

        #endregion

        #region ShowInstagramLink

        public static readonly DependencyProperty ShowInstagramLinkProperty = DependencyProperty.Register(
            "ShowInstagramLink", typeof(bool), typeof(AmazingHoverEffectOnSocialMediaButtons),
            new PropertyMetadata(true));

        public bool ShowInstagramLink
        {
            get => (bool) GetValue(ShowInstagramLinkProperty);
            set => SetValue(ShowInstagramLinkProperty, value);
        }

        #endregion

        #endregion Instagram

        #region Youtube

        #region YoutubeLink

        public static readonly DependencyProperty YoutubeLinkProperty = DependencyProperty.Register(
            "YoutubeLink", typeof(string), typeof(AmazingHoverEffectOnSocialMediaButtons),
            new FrameworkPropertyMetadata(default(string)), ValidateValueCallback);

        public string YoutubeLink
        {
            get => (string)GetValue(YoutubeLinkProperty);
            set => SetValue(YoutubeLinkProperty, value);
        }

        #endregion

        #region ShowYoutubeLink

        public static readonly DependencyProperty ShowYoutubeLinkProperty = DependencyProperty.Register(
            "ShowYoutubeLink", typeof(bool), typeof(AmazingHoverEffectOnSocialMediaButtons),
            new PropertyMetadata(true));

        public bool ShowYoutubeLink
        {
            get => (bool) GetValue(ShowYoutubeLinkProperty);
            set => SetValue(ShowYoutubeLinkProperty, value);
        }

        #endregion ShowYoutubeLink

        #endregion Youtube

        #region LinkedIn

        #region LinkedInLink

        public static readonly DependencyProperty LinkedInLinkProperty = DependencyProperty.Register(
            "LinkedInLink", typeof(string), typeof(AmazingHoverEffectOnSocialMediaButtons),
            new FrameworkPropertyMetadata(default(string)), ValidateValueCallback);

        public string LinkedInLink
        {
            get => (string)GetValue(LinkedInLinkProperty);
            set => SetValue(LinkedInLinkProperty, value);
        }

        #endregion

        #region ShowLinkedInLink

        public static readonly DependencyProperty ShowLinkedInLinkProperty = DependencyProperty.Register(
            "ShowLinkedInLink", typeof(bool), typeof(AmazingHoverEffectOnSocialMediaButtons),
            new PropertyMetadata(true));

        public bool ShowLinkedInLink
        {
            get => (bool) GetValue(ShowLinkedInLinkProperty);
            set => SetValue(ShowLinkedInLinkProperty, value);
        }

        #endregion ShowLinkedInLink

        #endregion

        #region BeHance

        #region BeHanceLink

        public static readonly DependencyProperty BeHanceLinkProperty = DependencyProperty.Register(
            "BeHanceLink", typeof(string), typeof(AmazingHoverEffectOnSocialMediaButtons),
            new FrameworkPropertyMetadata(default(string)), ValidateValueCallback);

        public string BeHanceLink
        {
            get => (string)GetValue(BeHanceLinkProperty);
            set => SetValue(BeHanceLinkProperty, value);
        }

        #endregion

        #region ShowBeHanceLink

        public static readonly DependencyProperty ShowBeHanceLinkProperty = DependencyProperty.Register(
            "ShowBeHanceLink", typeof(bool), typeof(AmazingHoverEffectOnSocialMediaButtons),
            new PropertyMetadata(true));

        public bool ShowBeHanceLink
        {
            get => (bool) GetValue(ShowBeHanceLinkProperty);
            set => SetValue(ShowBeHanceLinkProperty, value);
        }

        #endregion

        #endregion BeHance

        private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            if (!e.Uri.IsAbsoluteUri) return;
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
