using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.IO;
using ParallelLab3.CounterTool;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;

namespace ParallelLab3.Pages
{
    [RequestSizeLimit(100_000_000)]
    [IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {
        private IWebHostEnvironment ihostingEnvironment;

        public Dictionary<string, int> WordsAmount { get; set; } = new Dictionary<string, int>();

        public IndexModel(IWebHostEnvironment ihostingEnvironment)
        {
            this.ihostingEnvironment = ihostingEnvironment;
        }

        public void OnGet()
        {
        }
        public void OnPost(IFormFile[] files)
        {
            if (files != null && files.Length > 0)
            {
                SaveFiles(files);

                var path = Path.Combine(ihostingEnvironment.WebRootPath);
                ICounter counter  = new AsyncWithLinqWordCounter(path);

                WordsAmount = counter.CountAll().OrderBy(w => Convert.ToInt32(w.Key)).ToDictionary(d => d.Key, d => d.Value);


                DeleteFiles(path);
            }
        }

        private void SaveFiles(IFormFile[] files)
        {
            var path = Path.Combine(ihostingEnvironment.WebRootPath);
            foreach (var file in files)
            {
                var filePath = Path.Combine(path, file.FileName);
                var stream = new FileStream(filePath, FileMode.Create);
                file.CopyTo(stream);
                stream.Close();
            }
        }

        private void DeleteFiles(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }

    }
}
