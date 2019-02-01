using System;
using System.IO;
using GameDev.Droid;
using GameDev.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace GameDev.Droid
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}