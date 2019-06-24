using System;
using System.IO;
using System.Collections.Generic;

public class MarkDownFile
{
    public string Name { get; set; }
    public string Path { get; set; }

    public string NormalizedPath => Path.Replace(@"\\", @"\");

    public MarkDownFile(string path)
    {
        Path = path.Replace(@"\", @"\\");
        Name = System.IO.Path.GetFileName(path);        
    } 

    public string GetMarkDownText()
    {
        return System.IO.File.ReadAllText(Path);
    }

    public void SaveMarkdownText(string text)
    {
        System.IO.File.WriteAllText(Path, text);
    }

    public IEnumerable<string> Search(string pattern)
    {
        if(string.IsNullOrEmpty(pattern))
            return null;

        string line = string.Empty;
        List<string> lines = new List<string>();
            
        if(File.Exists(Path))
        {
            System.IO.StreamReader file = new System.IO.StreamReader(Path);
            while((line = file.ReadLine()) != null)
            {
                if(line.ToUpper().Contains(pattern.ToUpper()))
                    lines.Add(line);
            }
            file.Close();
        }

        if(lines.Count > 0)
            return lines;
        else
            return null;
    }
}