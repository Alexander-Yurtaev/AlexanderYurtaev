namespace AlexanderYurtaev.Framework.Services
{
    public class OpenImageFileService : OpenFileService, IOpenFileService
    {
        public OpenImageFileService()
        {
            Filter = "JPG file (*.jpg)|*.jpg";
        }
    }
}