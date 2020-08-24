using System;
using System.ComponentModel;
using System.Resources;

namespace AlexanderYurtaev.Framework.Attributes
{
    public class LocalizedDescriptionAttribute : DescriptionAttribute
    {
        private readonly ResourceManager _resourceManager;
        private readonly string _resourceKey;

        public LocalizedDescriptionAttribute(string resourceKey, Type resourceType)
        {
            _resourceManager=new ResourceManager(resourceType);
            _resourceKey = resourceKey;
        }

        #region Overrides of DescriptionAttribute

        public override string Description
        {
            get
            {
                string description = _resourceManager.GetString(_resourceKey);
                return string.IsNullOrEmpty(description)
                    ? $"[[{_resourceKey}]]"
                    : description;
            }
        }

        #endregion
    }
}
