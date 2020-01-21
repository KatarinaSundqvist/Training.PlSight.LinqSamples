using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction {
    class Program {
        static void Main(string[] args) {
            string path = @"C:\Temp";
            ShowLargeFilesWithoutLinq(path);
            Console.WriteLine();
            ShowLargeFilesWithLinq(path);
        }

        private static void ShowLargeFilesWithLinq(string path) {
            //var query = from file in new DirectoryInfo(path).GetFiles()
            //            orderby file.Length descending
            //            select file;

            var query = new DirectoryInfo(path).GetFiles()
                        .OrderByDescending(f => f.Length)
                        .Take(5);

            Console.WriteLine("With Linq:");
            foreach (var file in query) {
                Console.WriteLine($"{file.Name,-55}: {file.Length,10:N0}");
            }
        }

        private static void ShowLargeFilesWithoutLinq(string path) {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileInfoComparer());
            Console.WriteLine("Without Linq:");
            for (int i=0; i<5;i++) {
                FileInfo file = files[i];
                Console.WriteLine($"{file.Name, -55}: {file.Length, 10:N0}");
            }
        }
    }

    public class FileInfoComparer : IComparer<FileInfo> {
        public int Compare(FileInfo x, FileInfo y) {
            return y.Length.CompareTo(x.Length);
        }
    }
}
