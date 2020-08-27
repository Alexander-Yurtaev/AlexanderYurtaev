using System;
using AlexanderYurtaev.Framework.LocalizedDescriptionProviders;

namespace AlexanderYurtaev.Framework.Attributes
{
    public class ResourceLocalizedDescriptionAttribute : BaseLocalizedDescriptionAttribute
    {
        public ResourceLocalizedDescriptionAttribute(Type resourceType, string resourceKey) : base(
            new ResourceLocalizedDescriptionProvider(resourceType), resourceKey)
        {
        }

        public int I { get; set; }
    }
}
