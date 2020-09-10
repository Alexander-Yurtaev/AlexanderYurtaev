using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DarkCode.ViewModels
{
    public class AnimatedLoginFormViewModel : BindableBase
    {
        public const string Title = "Animated Login Form";

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public AnimatedLoginFormViewModel()
        {
            Message = "Animated Login Form from your Prism Module";
        }
    }
}
