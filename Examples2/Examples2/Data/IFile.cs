using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples2.Data
{
    public interface IFile
    {

        void SaveText(string filename, string text);
        string LoadText(string filename);
        string ClearFile(string filename);
        bool FileExists(string filename);
    }
}
