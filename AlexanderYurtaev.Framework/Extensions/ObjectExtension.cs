using System;

namespace AlexanderYurtaev.Framework.Extensions
{
    public static class ObjectExtension
    {
        public static void IfNullException(this object obj, string message = "")
        {
            if (obj != null) return;
            if (!string.IsNullOrEmpty(message))
            {
                throw new NullReferenceException(message);
            }

            throw new NullReferenceException();
        }
    }
}
