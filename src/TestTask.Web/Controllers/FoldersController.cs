using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using TestTask.Web.Models;

namespace TestTask.Web.Controllers
{
    public class FoldersController : Controller
    {
        private readonly TestTaskContext _db = new TestTaskContext();

        public async Task<ActionResult> Index(string path)
        {
            if (!string.IsNullOrWhiteSpace(path))
            {
                var split = path.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries).Reverse().ToList();

                if (!split.Any())
                {
                    return HttpNotFound();
                }

                IEnumerable<Folder> folders = null;
                foreach (var s in split)
                {
                    if (folders == null)
                    {
                        folders = await _db.Folders.Where(x => x.Name == s).ToListAsync();
                    }
                    else
                    {
                        folders = folders.Where(x => x.Parent?.Name == s);
                    }

                    var count = folders.Count();
                    if (count == 0)
                    {
                        return HttpNotFound();
                    }

                    if (count != 1)
                    {
                        continue;
                    }

                    var folder = folders.Single();
                    var catalogViewModel = new CatalogViewModel
                    {
                        Name = folder.Name,
                        Path = $"/{path}",
                        RootPath = $"/{string.Join("/", split.Skip(1))}",
                        Folders = folder.Childrens.Select(x => x.Name).ToList()
                    };

                    return View(catalogViewModel);
                }

                throw new InvalidOperationException("Multiple catalogs with same name and nesting are not allowed");
            }
            else
            {
                var folders = await _db.Folders.Where(x => x.Parent == null).Select(x => x.Name).ToListAsync();

                var catalogViewModel = new CatalogViewModel
                {
                    Name = "Root",
                    Path = "/",
                    Folders = folders
                };

                return View(catalogViewModel);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
