using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _5._Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"./";
            var resultPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\report.txt";

            var filesByExtension = new Dictionary<string, Dictionary<string, long>>
                (StringComparer.InvariantCultureIgnoreCase);

            var fileList = Directory.GetFiles(path);

            foreach (var file in fileList)
            {
                var fileInfo = new FileInfo(file);
                var fileName = fileInfo.Name;
                var extension = fileInfo.Extension;
                var size = fileInfo.Length;
                
                if (!filesByExtension.ContainsKey(extension))
                {
                    filesByExtension.Add(extension, new Dictionary<string, long>
                        (StringComparer.InvariantCultureIgnoreCase));
                }

                if (!filesByExtension[extension].ContainsKey(fileName))
                {
                    filesByExtension[extension].Add(fileName, 0);
                }

                filesByExtension[extension][fileName] = size;
            }

            var result = new StringBuilder();

            foreach (var extension in filesByExtension.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                result.AppendLine(extension.Key);

                foreach (var file in extension.Value.OrderBy(x => x.Value))
                {
                    result.AppendLine($"--{file.Key} - {(file.Value * 1.0 / 1024):F3}kb");
                }
            }

            using (var writer = new StreamWriter(resultPath))
            {
                writer.Write(result);
            }
        }
    }
}
