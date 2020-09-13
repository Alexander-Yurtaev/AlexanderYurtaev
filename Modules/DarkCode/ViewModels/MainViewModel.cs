// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using Prism.Mvvm;

namespace DarkCode.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public MainViewModel()
        {
            Message = "Main View from your Prism Module";
        }
    }
}