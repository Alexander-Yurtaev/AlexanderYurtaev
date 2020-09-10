using System;

namespace AlexanderYurtaev.Framework.Extensions
{
    public static class ObjectExtension
    {
        public static void ThrowIfNull(this object obj, string message = "")
        {
            if (obj != null) return;
            if (!string.IsNullOrEmpty(message))
            {
                throw new NullReferenceException(message);
            }

            throw new NullReferenceException();
        }

        public static void ThrowIfNotTypeOf<T>(this object obj, string message = "")
        {
            if (obj is T) return;
            if (!string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException(message);
            }
            throw new ArgumentNullException();
        }
    }
}
