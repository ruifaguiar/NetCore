using System.IO;

namespace NetCore.ProxyPattern
{
    public class FileReader : IReader
    {
        StreamReader sr;
        public void Dispose()
        {
            sr.Dispose();
        }

        public string Read()
        {
            var fileStream = new FileStream(@"FileExample.txt", FileMode.Open, FileAccess.Read);
            sr = new StreamReader(fileStream);
            string line = sr.ReadToEnd();
            return line;
        }
    }
}