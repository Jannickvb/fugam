using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fugam.Levels
{
    class LevelIO
    {
        private static string DirectoryPath = "";

        public static void SetPath()
        {
            string[] items = Environment.CurrentDirectory.Split(Path.DirectorySeparatorChar);

            int p = 0;
            
            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine(items[i]);
                if (items[i] == "bin")
                {
                    p = i;
                    break;
                }
            }
           
            for (int i = 0; i < p; i++)
            {
                DirectoryPath += (items[i] + @"\");
            }
            DirectoryPath = Path.Combine(DirectoryPath, "Levels");
            Console.WriteLine("Path: {0}",DirectoryPath);
            Console.WriteLine(Directory.Exists(DirectoryPath));
        }

        public static Level GetLevel(string levelId)
        {
            Level newLevel = new Level();
            Console.WriteLine("File: "+File.Exists(Path.Combine(DirectoryPath, levelId + ".txt")));
            
            StreamReader reader = new StreamReader(Path.Combine(DirectoryPath, levelId + ".txt"));
            int counter = 0;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
                counter++;
            }
            reader.Close();
            return newLevel;
        }
    }
}
