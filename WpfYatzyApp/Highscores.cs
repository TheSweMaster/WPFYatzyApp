using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WpfYatzyApp
{
    public static class Highscores
    {
        public static readonly string FilePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\yatzy_highscores.txt";
        public static readonly Encoding Encoding = Encoding.UTF8;

        public static void SaveScore(int score)
        {
            using (StreamWriter writer = new StreamWriter(FilePath, true, Encoding))
            {
                writer.Write($"{score}\n");
            }
        }

        public static List<int> GetHighscoreList()
        {
            var initList = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            if (!File.Exists(FilePath))
            {
                return initList;
            }

            File.GetAccessControl(FilePath);
            var textLines = File.ReadAllLines(FilePath, Encoding);

            var numberList = new List<int>();
            foreach (var textLine in textLines)
            {
                numberList.Add(int.TryParse(textLine, out int res1) ? res1 : 0);
            }

            numberList.AddRange(initList);

            return numberList
                .OrderByDescending(n => n)
                .Take(10)
                .ToList();
        }

    }
}
