using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace KnowledgeBase
{
    public class Folder
    {
        public bool IsFolder => true;
        public bool IsOpen { get; set; } = false;
        public string Name { get; set; }
        public string Path { get; set; }
        public string NormalizedPath => Path.Replace(@"\\", @"\");
        public List<Folder> Subfolders { get; set; } = new List<Folder>();
        public List<MarkDownFile> Files { get; set; } = new List<MarkDownFile>();

        public Folder(string path)
        {
            Path = path.Replace(@"\", @"\\");
            Name = System.IO.Path.GetFileName(path);    

            GetFiles();
            GetDirectories();    
        } 

        private void GetFiles()
        {
            var files = Directory.GetFiles(NormalizedPath);
            foreach (var file in files)
            {
                Files.Add(new MarkDownFile(file));
            }
        }

        private void GetDirectories()
        {
            var dirs = Directory.GetDirectories(NormalizedPath);
            foreach (var dir in dirs)
            {
                var dirName = System.IO.Path.GetFileName(dir);
                if(!dirName.StartsWith("_"))
                    Subfolders.Add(new Folder(dir));
            }
        }
    }
}