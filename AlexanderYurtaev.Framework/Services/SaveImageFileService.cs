namespace AlexanderYurtaev.Framework.Services
{
    public class SaveImageFileService : SaveFileService, ISaveFileService
    {
        public SaveImageFileService()
        {
            Filter = "JPG file (*.jpg)|*.jpg";
        }
    }
}