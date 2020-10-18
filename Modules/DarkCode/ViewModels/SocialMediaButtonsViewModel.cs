// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using AlexanderYurtaev.Common;

namespace DarkCode.ViewModels
{
    public class SocialMediaButtonsViewModel : BaseModuleViewModel
    {
        #region Overrides of BaseModuleViewModel

        public override string Title => "Social Media Buttons";
        protected override string IconName => "SocialMediaButtons";

        #endregion Overrides of BaseModuleViewModel
    }
}