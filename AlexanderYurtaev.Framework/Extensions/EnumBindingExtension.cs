﻿using System;
using System.Windows.Markup;

namespace AlexanderYurtaev.Framework.Extensions
{
    public class EnumBindingExtension : MarkupExtension
    {
        public Type EnumType { get; private set; }

        public EnumBindingExtension(Type enumType)
        {
            if (enumType == null || enumType.IsEnum)
                throw new ArgumentException($"{nameof(EnumType)} must not be null and of type {nameof(Enum)}");

            EnumType = enumType;
        }

        #region Overrides of MarkupExtension

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(EnumType);
        }

        #endregion
    }
}