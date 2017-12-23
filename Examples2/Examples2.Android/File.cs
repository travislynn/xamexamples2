using System;
using Examples2.Data;
using Examples2.Droid;
using System.IO;
using Environment = System.Environment;

[assembly: Xamarin.Forms.Dependency(typeof(FileImplementation))]
namespace Examples2.Droid
{
    class FileImplementation : IFile
    {
        private readonly string _documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        public void SaveText(string fileName, string text)
        {
            var filePath = Path.Combine(_documentsFolder, fileName);
            File.Delete(filePath);
            File.WriteAllText(filePath, text);
        }

        public string LoadText(string filename)
        {
            var filePath = Path.Combine(_documentsFolder, filename);
            return FileExists(filename) ? File.ReadAllText(filePath) : String.Empty;
        }

        public string ClearFile(string filename)
        {
            var filePath = Path.Combine(_documentsFolder, filename);
            File.Delete(filePath);
            return string.Empty;
        }

        public bool FileExists(string filename)
        {
            var filePath = Path.Combine(_documentsFolder, filename);
            return File.Exists(filePath);
        }
    }
}