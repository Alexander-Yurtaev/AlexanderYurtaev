// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using Prism.Mvvm;
using System.ComponentModel;

namespace AlexanderYurtaev.Framework
{
    public class BaseModelView : BindableBase
    {
        #region INotifyPropertyChanged

        protected virtual void RaisePropertiesChanged(params string[] propertyNames)
        {
            foreach (string propertyName in propertyNames)
            {
                base.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion INotifyPropertyChanged
    }
}