using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ParallelLab3.CounterTool
{
    abstract class Counter
    {
        protected List<string> files;

        protected Counter(string dataPath)
        {
            files = Directory.GetFiles(dataPath).ToList();
        }

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
    }
}
