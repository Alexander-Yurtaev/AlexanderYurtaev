// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Threading.Tasks;

namespace AlexanderYurtaev.Framework.Extensions
{
    public static class TaskExtension
    {
        public static async void Await(this Task task, Action completed = null, Action<Exception> callbackError = null)
        {
            try
            {
                await task;
                completed?.Invoke();
            }
            catch (Exception ex)
            {
                callbackError?.Invoke(ex);
            }
        }
    }
}