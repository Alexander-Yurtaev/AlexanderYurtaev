// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Prism.Mvvm;

namespace AlexanderYurtaev.Demo.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public MainWindowViewModel()
        {
        }
    }
}