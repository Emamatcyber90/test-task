using System.Collections.Generic;

namespace TestTask.Web.Models
{
    public class CatalogViewModel
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public string RootPath { get; set; }

        public List<string> Folders { get; set; }
    }
}
