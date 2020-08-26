using System;
using System.ComponentModel;
using AlexanderYurtaev.Framework.LocalizedDescriptionDepositories;

namespace AlexanderYurtaev.Framework.Attributes
{
    public class LocalizedDescriptionAttribute : DescriptionAttribute
    {
        private readonly ILocalizedDescriptionDepository _repository;
        private readonly string _resourceKey;

        public LocalizedDescriptionAttribute(ILocalizedDescriptionDepository repository, string resourceKey, Type resourceType)
        {
            _repository = repository;
            _resourceKey = resourceKey;
        }

        #region Overrides of DescriptionAttribute

        public override string Description
        {
            get
            {
                string description = _repository.GetString(_resourceKey);
                return string.IsNullOrEmpty(description)
                    ? $"[[{_resourceKey}]]"
                    : description;
            }
        }

        #endregion
    }
}
