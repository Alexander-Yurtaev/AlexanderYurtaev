using System;
using System.Windows;
using System.Windows.Controls;

namespace DarkCode.Controls.SocialMediaButtons
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:DarkCode.Controls.SocialMediaButtons"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:DarkCode.Controls.SocialMediaButtons;assembly=DarkCode.Controls.SocialMediaButtons"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:SocialMediaButtonsGroupBase/>
    ///
    /// </summary>
    public abstract class SocialMediaButtonsGroupBase : UserControl
    {
        static SocialMediaButtonsGroupBase()
        {
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(SocialMediaButtonsGroupBase), new FrameworkPropertyMetadata(typeof(SocialMediaButtonsGroupBase)));
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
            "FacebookLink", typeof(string), typeof(SocialMediaButtonsGroupBase),
            new FrameworkPropertyMetadata(default(string)), ValidateValueCallback);

        public string FacebookLink
        {
            get => (string)GetValue(FacebookLinkProperty);
            set => SetValue(FacebookLinkProperty, value);
        }

        #endregion FacebookLink

        #region ShowFacebookLink

        public static readonly DependencyProperty ShowFacebookLinkProperty = DependencyProperty.Register(
            "ShowFacebookLink", typeof(bool), typeof(SocialMediaButtonsGroupBase),
            new PropertyMetadata(true));

        public bool ShowFacebookLink
        {
            get => (bool)GetValue(ShowFacebookLinkProperty);
            set => SetValue(ShowFacebookLinkProperty, value);
        }

        #endregion ShowFacebookLink

        #endregion Facebook

        #region Twitter

        #region TwitterLink

        public static readonly DependencyProperty TwitterLinkProperty = DependencyProperty.Register(
            "TwitterLink", typeof(string), typeof(SocialMediaButtonsGroupBase),
            new FrameworkPropertyMetadata(default(string)), ValidateValueCallback);

        public string TwitterLink
        {
            get => (string)GetValue(TwitterLinkProperty);
            set => SetValue(TwitterLinkProperty, value);
        }

        #endregion TwitterLink

        #region ShowTwitterLink

        public static readonly DependencyProperty ShowTwitterLinkProperty = DependencyProperty.Register(
            "ShowTwitterLink", typeof(bool), typeof(SocialMediaButtonsGroupBase),
            new PropertyMetadata(true));

        public bool ShowTwitterLink
        {
            get => (bool)GetValue(ShowTwitterLinkProperty);
            set => SetValue(ShowTwitterLinkProperty, value);
        }

        #endregion ShowTwitterLink

        #endregion Twitter

        #region Instagram

        #region InstagramLink

        public static readonly DependencyProperty InstagramLinkProperty = DependencyProperty.Register(
            "InstagramLink", typeof(string), typeof(SocialMediaButtonsGroupBase),
            new FrameworkPropertyMetadata(default(string)), ValidateValueCallback);

        public string InstagramLink
        {
            get => (string)GetValue(InstagramLinkProperty);
            set => SetValue(InstagramLinkProperty, value);
        }

        #endregion InstagramLink

        #region ShowInstagramLink

        public static readonly DependencyProperty ShowInstagramLinkProperty = DependencyProperty.Register(
            "ShowInstagramLink", typeof(bool), typeof(SocialMediaButtonsGroupBase),
            new PropertyMetadata(true));

        public bool ShowInstagramLink
        {
            get => (bool)GetValue(ShowInstagramLinkProperty);
            set => SetValue(ShowInstagramLinkProperty, value);
        }

        #endregion ShowInstagramLink

        #endregion Instagram

        #region Youtube

        #region YoutubeLink

        public static readonly DependencyProperty YoutubeLinkProperty = DependencyProperty.Register(
            "YoutubeLink", typeof(string), typeof(SocialMediaButtonsGroupBase),
            new FrameworkPropertyMetadata(default(string)), ValidateValueCallback);

        public string YoutubeLink
        {
            get => (string)GetValue(YoutubeLinkProperty);
            set => SetValue(YoutubeLinkProperty, value);
        }

        #endregion YoutubeLink

        #region ShowYoutubeLink

        public static readonly DependencyProperty ShowYoutubeLinkProperty = DependencyProperty.Register(
            "ShowYoutubeLink", typeof(bool), typeof(SocialMediaButtonsGroupBase),
            new PropertyMetadata(true));

        public bool ShowYoutubeLink
        {
            get => (bool)GetValue(ShowYoutubeLinkProperty);
            set => SetValue(ShowYoutubeLinkProperty, value);
        }

        #endregion ShowYoutubeLink

        #endregion Youtube

        #region LinkedIn

        #region LinkedInLink

        public static readonly DependencyProperty LinkedInLinkProperty = DependencyProperty.Register(
            "LinkedInLink", typeof(string), typeof(SocialMediaButtonsGroupBase),
            new FrameworkPropertyMetadata(default(string)), ValidateValueCallback);

        public string LinkedInLink
        {
            get => (string)GetValue(LinkedInLinkProperty);
            set => SetValue(LinkedInLinkProperty, value);
        }

        #endregion LinkedInLink

        #region ShowLinkedInLink

        public static readonly DependencyProperty ShowLinkedInLinkProperty = DependencyProperty.Register(
            "ShowLinkedInLink", typeof(bool), typeof(SocialMediaButtonsGroupBase),
            new PropertyMetadata(true));

        public bool ShowLinkedInLink
        {
            get => (bool)GetValue(ShowLinkedInLinkProperty);
            set => SetValue(ShowLinkedInLinkProperty, value);
        }

        #endregion ShowLinkedInLink

        #endregion LinkedIn

        #region BeHance

        #region BeHanceLink

        public static readonly DependencyProperty BeHanceLinkProperty = DependencyProperty.Register(
            "BeHanceLink", typeof(string), typeof(SocialMediaButtonsGroupBase),
            new FrameworkPropertyMetadata(default(string)), ValidateValueCallback);

        public string BeHanceLink
        {
            get => (string)GetValue(BeHanceLinkProperty);
            set => SetValue(BeHanceLinkProperty, value);
        }

        #endregion BeHanceLink

        #region ShowBeHanceLink

        public static readonly DependencyProperty ShowBeHanceLinkProperty = DependencyProperty.Register(
            "ShowBeHanceLink", typeof(bool), typeof(SocialMediaButtonsGroupBase),
            new PropertyMetadata(true));

        public bool ShowBeHanceLink
        {
            get => (bool)GetValue(ShowBeHanceLinkProperty);
            set => SetValue(ShowBeHanceLinkProperty, value);
        }

        #endregion ShowBeHanceLink

        #endregion BeHance
    }
}