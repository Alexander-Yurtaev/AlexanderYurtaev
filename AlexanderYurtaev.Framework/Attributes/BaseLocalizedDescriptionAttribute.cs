// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using AlexanderYurtaev.Framework.LocalizedDescriptionProviders;
using System.ComponentModel;

namespace AlexanderYurtaev.Framework.Attributes
{
    public abstract class BaseLocalizedDescriptionAttribute : DescriptionAttribute
    {
        private readonly ILocalizedDescriptionProvider _provider;
        private readonly string _resourceKey;

        protected BaseLocalizedDescriptionAttribute(ILocalizedDescriptionProvider provider, string resourceKey)
        {
            _provider = provider;
            _resourceKey = resourceKey;
        }

        #region Overrides of DescriptionAttribute

        public override string Description
        {
            get
            {
                string description = _provider.GetString(_resourceKey);
                return string.IsNullOrEmpty(description)
                    ? _resourceKey
                    : description;
            }
        }

        #endregion Overrides of DescriptionAttribute
    }
}