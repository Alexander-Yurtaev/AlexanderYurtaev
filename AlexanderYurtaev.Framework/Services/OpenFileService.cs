using System.Linq;
using Microsoft.Win32;

namespace AlexanderYurtaev.Framework.Services
{
    public class OpenFileService : ShowDialogService, IOpenFileService
    {
        public bool Multiselect { get; set; }
        
        #region Overrides of ShowDialogService<string>

        protected override string ShowDialog(params string[] parameters)
        {
            string filter = "";
            if (parameters != null)
            {
                filter = parameters.FirstOrDefault() ?? FileServiceConstants.AllFileFilter;
            }

            var dlg = new OpenFileDialog() { Filter = filter, Multiselect = this.Multiselect };
            return dlg.ShowDialog() == true ? dlg.FileName : string.Empty;
        }

        #endregion
    }
}
