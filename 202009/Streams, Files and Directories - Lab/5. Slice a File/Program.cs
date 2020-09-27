using System;
using System.IO;
using System.Linq;

namespace _5._Slice_a_File
{
    class Program
    {
        static void Main(string[] args)
        {
            var parts = 4;

            using var fsStream = new FileStream("sliceMe.txt", FileMode.Open);

            long bufferLength = (long)Math.Ceiling(fsStream.Length * 1.0 / parts);

            var buffer = new byte[bufferLength];

            for (int i = 1; i <= parts; i++)
            {
                var bytesRead = fsStream.Read(buffer);

                using var currentPartStream = new FileStream($"Part-{i}.txt", FileMode.Create);

                if (bytesRead < bufferLength)
                {
                    buffer = buffer
                        .Take(bytesRead)
                        .ToArray();
                }

                currentPartStream.Write(buffer);
            }
        }
    }
}
