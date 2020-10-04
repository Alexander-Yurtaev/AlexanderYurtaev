// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace AlexanderYurtaev.Common.Data
{
    public class Node
    {
        private readonly BaseModuleViewModel _moduleViewModel;

        public Node(IBaseModule module, Type view, string title, BitmapImage icon, List<Node> nodes = null)
        {
            Module = module;
            View = view;
            Title = title;
            Icon = icon;
            Nodes = nodes ?? new List<Node>();
        }

        public IBaseModule Module { get; set; }
        public string Title { get; }
        public Type View { get; set; }
        public BitmapImage Icon { get; }
        public List<Node> Nodes { get; set; }

        public void Select()
        {
            Module.Select(View);
        }
    }
}