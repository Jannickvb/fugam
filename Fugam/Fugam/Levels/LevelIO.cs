using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fugam.Levels.Tile;

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
            DirectoryPath = Path.Combine(DirectoryPath, "Resources");
            Console.WriteLine("Path: {0}",DirectoryPath);
            Console.WriteLine(Directory.Exists(DirectoryPath));
        }

        public static int[,] GetLevel(string levelId)
        {
            Console.WriteLine("File: "+File.Exists(Path.Combine(DirectoryPath, levelId + ".txt")));

            int arrayWidth, arrayHeight;
            int[,] tilemap = null;
            StreamReader reader = null;

            try
            {
                reader = new StreamReader(Path.Combine(DirectoryPath, levelId + ".txt"));
                arrayWidth = int.Parse(reader.ReadLine());
                arrayHeight = int.Parse(reader.ReadLine());
                tilemap = new int[arrayHeight,arrayWidth];
                int row = 0;
                string text;

                while ((text = reader.ReadLine()) != string.Empty)
                {
                    Console.WriteLine("readline: "+text);
                    if (row < arrayHeight)
                    {
                        string[] tileValues = text.Split(',');
                        for(int col = 0; col < arrayWidth;col++)
                            tilemap[row,col] = int.Parse(tileValues[col]);
                        row++;
                    }
                }
                //zero index rows
                if (row < arrayHeight - 1)
                {
                    throw new IOException("Expected tile height does not match actual row height");
                }
                return tilemap;
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                try
                {
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return tilemap;
        }
    }
}
