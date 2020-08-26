using System;
using System.Resources;

namespace AlexanderYurtaev.Framework.LocalizedDescriptionDepositories
{
    public class ResourceLocalizedDescriptionDepository : ILocalizedDescriptionDepository
    {
        private readonly ResourceManager _resourceManager;

        public ResourceLocalizedDescriptionDepository(Type resourceType)
        {
            _resourceManager = new ResourceManager(resourceType);
        }

        #region Implementation of ILocalizedDescriptionDepository

        public string GetString(string key)
        {
            return _resourceManager.GetString(key);
        }

        #endregion
    }
}
