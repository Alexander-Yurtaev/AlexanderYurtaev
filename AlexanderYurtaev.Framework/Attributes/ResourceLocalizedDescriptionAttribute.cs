// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using AlexanderYurtaev.Framework.LocalizedDescriptionProviders;
using System;

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