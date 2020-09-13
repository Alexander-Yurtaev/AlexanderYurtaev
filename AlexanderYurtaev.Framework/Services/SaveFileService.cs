// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using Microsoft.Win32;
using System.Linq;

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

        #endregion Overrides of ShowDialogService<string>
    }
}