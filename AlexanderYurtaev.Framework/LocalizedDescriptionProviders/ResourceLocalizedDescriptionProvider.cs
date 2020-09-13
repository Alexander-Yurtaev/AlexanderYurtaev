// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using System;
using System.Resources;

namespace AlexanderYurtaev.Framework.LocalizedDescriptionProviders
{
    public class ResourceLocalizedDescriptionProvider : ILocalizedDescriptionProvider
    {
        private readonly ResourceManager _resourceManager;

        public ResourceLocalizedDescriptionProvider(Type resourceType)
        {
            _resourceManager = new ResourceManager(resourceType);
        }

        #region Implementation of ILocalizedDescriptionProvider

        public string GetString(string key)
        {
            return _resourceManager.GetString(key);
        }

        #endregion Implementation of ILocalizedDescriptionProvider
    }
}