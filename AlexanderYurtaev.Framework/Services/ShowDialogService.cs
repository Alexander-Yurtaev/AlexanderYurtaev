namespace AlexanderYurtaev.Framework.Services
{
    public abstract class ShowDialogService : IFileService
    {
        public string Filter { get; set; } = FileServiceConstants.AllFileFilter;

        public bool UseAllFiles { get; set; }

        protected abstract string ShowDialog(params string[] parameters);

        public string GetFileName()
        {
            var filter = Filter.Trim();
            if (UseAllFiles)
            {
                if (string.IsNullOrEmpty(filter))
                {
                    filter = FileServiceConstants.AllFileFilter;
                }
                else
                {
                    filter += "|" + FileServiceConstants.AllFileFilter;
                }
            }

            return ShowDialog(filter);
        }
    }
}