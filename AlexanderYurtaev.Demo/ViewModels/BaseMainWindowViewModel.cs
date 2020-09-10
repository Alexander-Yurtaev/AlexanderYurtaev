using System.Collections.ObjectModel;
using AlexanderYurtaev.Common.Data;
using AlexanderYurtaev.Framework;

namespace AlexanderYurtaev.Demo.ViewModels
{
    public abstract class BaseMainWindowViewModel : BaseModelView
    {
        protected readonly ObservableCollection<Node> _nodes = new ObservableCollection<Node>();

        public ObservableCollection<Node> Nodes => _nodes;
    }
}