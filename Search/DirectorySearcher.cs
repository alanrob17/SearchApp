using Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    public class DirectorySearcher
    {
        private readonly string _rootDirectory;

        public DirectorySearcher(string rootDirectory)
        {
            _rootDirectory = rootDirectory;
        }

        public List<DirectoryList> Search(IEnumerable<string> searchTerms)
        {
            var list = new List<DirectoryList>();
            var subFolders = GetSubFolderList(GetFolderList(_rootDirectory));

            GetDirectoryList(subFolders, list);

            var searchResults = list.Where(item =>
                searchTerms.Any(arg => item.Folder.Contains(arg, StringComparison.OrdinalIgnoreCase)))
                .OrderByDescending(item => item.CreateDate)
                .ToList();

            return searchResults;
        }

        private void GetDirectoryList(List<string> subFolders, List<DirectoryList> list)
        {
            foreach (var subFolder in subFolders)
            {
                var dir = new DirectoryInfo(subFolder);
                list.Add(new DirectoryList
                {
                    Folder = dir.Name,
                    CreateDate = DateOnly.FromDateTime(dir.CreationTime)
                });
            }
        }

        private List<string> GetSubFolderList(IEnumerable<string> folders)
        {
            var subFolders = new List<string>();
            foreach (var folder in folders)
            {
                var folderList = GetFolderList(folder);
                subFolders.AddRange(folderList);
            }
            return subFolders;
        }

        private IEnumerable<string> GetFolderList(string folder)
        {
            var dir = new DirectoryInfo(folder);
            var folderList = new List<string>();
            GetFolders(dir, folderList);
            return folderList;
        }

        private void GetFolders(DirectoryInfo d, ICollection<string> folderList)
        {
            foreach (var dir in d.GetDirectories("*"))
            {
                var dirName = dir.ToString();
                if (!dirName.Contains("_Training_CleanUp") && !dirName.Contains("Youtube"))
                {
                    folderList.Add(dir.FullName);
                }
            }
        }
    }
}
