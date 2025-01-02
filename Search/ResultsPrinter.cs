using Search.Models;

namespace Search
{
    public class ResultsPrinter
    {
        public static void Print(List<DirectoryList> searchResults)
        {
            if (!searchResults.Any())
            {
                Console.WriteLine("No results found.");
                return;
            }

            foreach (var item in searchResults)
            {
                string currentDate = item.CreateDate.ToString();
                if (currentDate.Length == 9)
                {
                    currentDate = $"0{currentDate}";
                }
                Console.WriteLine($"{currentDate} - {item.Folder}");
            }
        }
    }
}