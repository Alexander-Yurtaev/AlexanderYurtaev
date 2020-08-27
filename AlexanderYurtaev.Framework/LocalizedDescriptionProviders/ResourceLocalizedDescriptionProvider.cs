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

        #endregion
    }
}
