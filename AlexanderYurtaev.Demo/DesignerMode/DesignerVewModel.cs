using System.Collections.ObjectModel;
using System.Linq;
using AlexanderYurtaev.Common.Data;
using AlexanderYurtaev.Demo.ViewModels;

namespace AlexanderYurtaev.Demo.DesignerMode
{
    public class DesignerVewModel : BaseMainWindowViewModel
    {
        public DesignerVewModel()
        {
            var modules = Enumerable.Range(1, 10)
                .Select(i => new DesignerModule($"Item {i}"))
                .Select(m => new Node(m, m.Title, null, m.Icon, m.Nodes));

            Nodes.AddRange(modules);
        }
    }
}
