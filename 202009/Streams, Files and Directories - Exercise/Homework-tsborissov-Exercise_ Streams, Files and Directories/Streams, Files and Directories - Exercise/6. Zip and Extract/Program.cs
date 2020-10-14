using System;
using System.IO;
using System.IO.Compression;

namespace _6._Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "../../../_resources/";
            string inputFile = "copyMe.png";
            string zipName = "myZip.zip";
            string destinationPath = "../../../_extracted/";

            Directory.CreateDirectory(destinationPath);

            using (ZipArchive zipArchive = ZipFile.Open(inputPath + zipName, ZipArchiveMode.Create))
            {
                zipArchive.CreateEntryFromFile(inputPath + inputFile, inputFile);
            }

            using (ZipArchive zipArchive = ZipFile.Open(inputPath + zipName, ZipArchiveMode.Read))
            {
                zipArchive.ExtractToDirectory(destinationPath, true);
            }
        }
    }
}
