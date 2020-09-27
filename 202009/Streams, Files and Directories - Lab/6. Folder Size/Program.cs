using System;
using System.IO;

namespace _6._Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {

            var files = Directory.GetFiles("TestFolder");

            double totalSize = 0;

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                totalSize += fileInfo.Length;
            }

            using (var writer = new StreamWriter("Output.txt"))
            {
                writer.Write(totalSize.ToString());
            }


        }
    }
}
