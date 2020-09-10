using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace AlexanderYurtaev.Common.Data
{
    public class Node
    {
        public Node(IBaseModule module, string title, Type view, BitmapImage icon, List<Node> nodes = null)
        {
            Module = module;
            Title = title;
            View = view;
            Icon = icon;
            Nodes = nodes ?? new List<Node>();
        }

        public IBaseModule Module { get; set; }
        public string Title { get; set; }
        public Type View { get; set; }
        public BitmapImage Icon { get; set; }
        public List<Node> Nodes { get; set; }

        public void Select()
        {
            Module.Select(View);
        }
    }
}