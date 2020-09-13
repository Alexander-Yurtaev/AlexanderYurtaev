// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace AlexanderYurtaev.Framework
{
    public class EnumDescriptionTypeConverter : EnumConverter
    {
        public EnumDescriptionTypeConverter(Type type) : base(type)
        {
        }

        #region Overrides of EnumConverter

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != typeof(string) || value == null) return base.ConvertTo(context, culture, value, destinationType);

            FieldInfo fi = value.GetType().GetField(value.ToString());
            if (fi == null) return base.ConvertTo(context, culture, value, destinationType);

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            var attribute = attributes.FirstOrDefault();
            return (!string.IsNullOrEmpty(attribute?.Description)) ? attribute.Description : value.ToString();
        }

        #endregion Overrides of EnumConverter
    }
}