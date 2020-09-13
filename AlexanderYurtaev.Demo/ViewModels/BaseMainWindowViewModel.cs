// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using AlexanderYurtaev.Common.Data;
using AlexanderYurtaev.Framework;
using System.Collections.ObjectModel;

namespace AlexanderYurtaev.Demo.ViewModels
{
    public abstract class BaseMainWindowViewModel : BaseModelView
    {
        protected readonly ObservableCollection<Node> _nodes = new ObservableCollection<Node>();

        public ObservableCollection<Node> Nodes => _nodes;
    }
}