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
            using (StreamWriter writer = new StreamWriter(FilePath, true, Encoding.UTF8))
            {
                writer.Write($"{score};");
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
            string text = File.ReadAllText(FilePath, Encoding);
            var textList = text.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Take(10);

            var numberList = new List<int>();
            foreach (var item in textList)
            {
                numberList.Add(int.TryParse(item, out int res1) ? res1 : 0);
            }

            initList.AddRange(numberList);

            return initList
                .OrderByDescending(s => s)
                .Take(10)
                .ToList();
        }

    }
}
