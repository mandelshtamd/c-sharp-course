using System;
using System.IO;

namespace Task3
{
    class Program
    {
        public static Tuple<string, bool> findFile(string filename, DirectoryInfo root, string format = "*")
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;
            try
            {
                files = root.GetFiles($"{filename}.{format}");
            }
            catch
            {
                return new Tuple<string, bool>("", false);
            }
            if (files != null && files.Length > 0)
                return new Tuple<string, bool>(files[0].ToString(), true);

            subDirs = root.GetDirectories();
            foreach (DirectoryInfo dirInfo in subDirs)
            {
                var ans = findFile(filename, dirInfo);
                if (ans.Item2)
                    return ans;
            }
            return new Tuple<string, bool>("", false);
        }

        static void Main(string[] args)
        {
            var ans = findFile("Program", new DirectoryInfo("C:\\"), "cs");
            if (ans.Item2)
            {
                Console.WriteLine(ans.Item1);
            }
            else
            {
                // may work too long
                Console.WriteLine("No such file found.");
            }
        }
    }
}
