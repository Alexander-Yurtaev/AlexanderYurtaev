// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using AlexanderYurtaev.Common.Data;
using AlexanderYurtaev.Demo.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;

namespace AlexanderYurtaev.Demo.DesignerMode
{
    public class DesignerVewModel : BaseMainWindowViewModel
    {
        public DesignerVewModel()
        {
            var modules = Enumerable.Range(1, 10)
                .Select(i => new DesignerModule($"Item {i}"))
                .Select(m => new Node(m, null, m.Title, m.Icon, m.Nodes));

            Nodes.AddRange(modules);
        }
    }
}