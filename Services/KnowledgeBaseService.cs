using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using KnowledgeBase.Models;

namespace KnowledgeBase
{
    public class KnowledgeBaseService : IKnowledgeBaseService
    {
        public IEnumerable<string> GetKnowledgeBases(string path)
        {
            var knowledgeBases = Directory.EnumerateDirectories(path);
            return knowledgeBases.Select(x => System.IO.Path.GetFileName(x));
        }

        public IEnumerable<MarkDownFile> GetMdFilesFromDirectory(string dir)
        {
            List<MarkDownFile> mdFiles = Directory.EnumerateFiles(dir, "*.md", SearchOption.AllDirectories).Select(x => new MarkDownFile(x)).ToList();            

            return mdFiles;
        }

        public string GetMarkdown(string dir, string filePath)
        {
            var mdFiles = GetMdFilesFromDirectory(dir);
            var mdFile = mdFiles.FirstOrDefault(x => x.NormalizedPath == filePath);

            if(mdFile != null)
                return mdFile.GetMarkDownText();
            else
                return string.Empty;
        }

        public IEnumerable<MarkDownFile> SearchFor(string dir, string pattern)
        {
            var mdFiles = GetMdFilesFromDirectory(dir);
            List<MarkDownFile> foundFiles = new List<MarkDownFile>();
            foreach(MarkDownFile mdFile in mdFiles)
            {
                var matches = mdFile.Search(pattern);
                if(matches != null)
                {   
                    foundFiles.Add(mdFile);
                }
            }

            return foundFiles;
        }

        public void SaveMarkdown(string dir, string filePath, string markdown)
        {
            var mdFiles = GetMdFilesFromDirectory(dir);
            var mdFile = mdFiles.FirstOrDefault(x => x.NormalizedPath == filePath);

            if(mdFile != null)
                mdFile.SaveMarkdownText(markdown);
        }
    }
}