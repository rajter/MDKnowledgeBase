using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KnowledgeBase.Models;

namespace KnowledgeBase
{
    public interface IKnowledgeBaseService
    {
        IEnumerable<string> GetKnowledgeBases(string path);
        IEnumerable<MarkDownFile> GetMdFilesFromDirectory(string dir);
        string GetMarkdown(string dir, string filePath);
        IEnumerable<MarkDownFile> SearchFor(string dir, string pattern);
        void SaveMarkdown(string dir, string filePath, string markdown);
    }
}