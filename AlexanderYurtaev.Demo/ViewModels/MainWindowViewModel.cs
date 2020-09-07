using AlexanderYurtaev.Framework.Extensions;
using Prism.Modularity;
using Prism.Mvvm;

namespace AlexanderYurtaev.Demo.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";

        public MainWindowViewModel(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.IfNullException();
            moduleCatalog.IfNotTypeException<DirectoryModuleCatalog>(nameof(moduleCatalog));

            ModuleCatalog = moduleCatalog;
        }

        public IModuleCatalog ModuleCatalog { get; }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
    }
}