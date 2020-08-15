using System.ComponentModel;
using Prism.Mvvm;

namespace AlexanderYurtaev.Framework
{
    public partial class BaseModelView : BindableBase
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
