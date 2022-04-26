using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelLab1
{
    abstract class Counter
    {
        private static string dataPath = @".\Data";
        protected List<string> files = Directory.GetFiles(dataPath).ToList();

        protected static Stopwatch stopwatch = new Stopwatch();

        protected static Dictionary<string, int> allWords = new Dictionary<string, int>();



        protected Dictionary<string, int> CountInFile(string file)
        {
            Dictionary<string, int> fileWords = new Dictionary<string, int>();
            string[] words = File.ReadAllLines(file);
            foreach (var word in words)
            {
                if (fileWords.ContainsKey(word))
                    fileWords[word]++;
                else
                    fileWords.Add(word, 1);
            }
            return fileWords;
        }

        protected Dictionary<string, int> MergeDictionaries(Dictionary<string, int> dict1, Dictionary<string, int> dict2)
        {
            foreach (string key in dict1.Keys)
            {
                if (dict2.Keys.Contains(key))
                    dict1[key] += dict2[key];
            }
            return dict1;
        }

        public string ShowResult()
        {
            StringBuilder builder = new StringBuilder();
            foreach(KeyValuePair<string, int> word in allWords.OrderBy(w => Convert.ToInt32(w.Key)))
            {
                builder.Append($"\"{word.Key}\":{word.Value}, ");
            }
            return builder.ToString();
        }
        public static void Reset()
        {
            stopwatch.Reset();
            allWords = default;
        }
    }
}
