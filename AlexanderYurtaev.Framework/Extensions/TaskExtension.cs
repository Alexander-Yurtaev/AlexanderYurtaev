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
