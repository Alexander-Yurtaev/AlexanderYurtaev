using System.Linq;
using Microsoft.Win32;

namespace AlexanderYurtaev.Framework.Services
{
    public class SaveFileService : ShowDialogService, ISaveFileService
    {
        #region Overrides of ShowDialogService<string>

        protected override string ShowDialog(params string[] parameters)
        {
            string filter = "";
            if (parameters != null)
            {
                filter = parameters.FirstOrDefault() ?? FileServiceConstants.AllFileFilter;
            }

            var dlg = new SaveFileDialog() { Filter = filter };
            return dlg.ShowDialog() == true ? dlg.FileName : string.Empty;
        }

        #endregion
    }
}
