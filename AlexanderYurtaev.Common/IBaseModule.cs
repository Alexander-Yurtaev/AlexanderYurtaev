using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using AlexanderYurtaev.Common.Data;
using Prism.Modularity;

namespace AlexanderYurtaev.Common
{
    public interface IBaseModule : IModule
    {
        string Title { get; }
        Type View { get; }
        BitmapImage Icon { get; }
        List<Node> Nodes { get; }
        void Select(Type viewType);
    }
}