﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
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