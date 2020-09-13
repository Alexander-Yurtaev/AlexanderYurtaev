// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using AlexanderYurtaev.Common.Data;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

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