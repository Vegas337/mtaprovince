using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static MTAProvince.Information;

namespace MTAProvince
{
    internal class WriteRead
    {
        public static string path = "Settings.txt";
        public static void StreamWrite (string user, int UserLevel)
        {
            StreamReader reader = new StreamReader(path);
            string textReader = reader.ReadToEnd();
            string[] words = textReader.Split("\n");
            reader.Close();
            StreamWriter writer = new StreamWriter(path, false);
            if (user == "Vegas337")
            {
                writer.WriteLine($@"{UserLevel} 
{BLACK_KANEKIF_}");
            } else if (user == "BLACK_KANEKIF")
            {
                writer.WriteLine($@"{Vegas337_} 
{UserLevel}");
            }
            writer.Close();
        }
        public static void StreamRead()
        {
            StreamReader reader = new StreamReader(path);
            string textReader = reader.ReadToEnd();
            string[] words = textReader.Split("\n");
            reader.Close();
            if (words.Length < 1) { StreamWrite("Vegas337", 4); StreamWrite("BLACK_KANEKIF", 4); }
            Vegas337_ = int.Parse(words[0]);
            BLACK_KANEKIF_ = int.Parse(words[1]);
        }
    }
}
