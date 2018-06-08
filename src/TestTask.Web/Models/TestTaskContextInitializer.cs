using System.Collections.Generic;
using System.Data.Entity;

namespace TestTask.Web.Models
{
    public class TestTaskContextInitializer : DropCreateDatabaseIfModelChanges<TestTaskContext>
    {
        protected override void Seed(TestTaskContext context)
        {
            var folder = new Folder
            {
                Name = "Creating Digital Images",
                Childrens = new List<Folder>
                {
                    new Folder
                    {
                        Name = "Resources",
                        Childrens = new List<Folder>
                        {
                            new Folder
                            {
                                Name = "Primary Sources"
                            },
                            new Folder
                            {
                                Name = "Secondary Sources"
                            }
                        }
                    },
                    new Folder
                    {
                        Name = "Evidence"
                    },
                    new Folder
                    {
                        Name = "Graphic Products",
                        Childrens = new List<Folder>
                        {
                            new Folder
                            {
                                Name = "Process"
                            },
                            new Folder
                            {
                                Name = "Final Product"
                            }
                        }
                    },
                }
            };

            context.Folders.Add(folder);
            context.SaveChanges();
        }
    }
}