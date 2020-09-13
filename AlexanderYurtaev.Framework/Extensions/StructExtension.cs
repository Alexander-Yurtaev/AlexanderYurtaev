// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using System;

namespace AlexanderYurtaev.Framework.Extensions
{
    public static class StructExtension
    {
        public static void IfNullException<T>(this T? value, string message = "") where T : struct
        {
            if (value.HasValue) return;
            if (!string.IsNullOrEmpty(message))
            {
                throw new NullReferenceException(message);
            }

            throw new NullReferenceException();
        }
    }
}