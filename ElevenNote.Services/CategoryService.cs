using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryService
    {
        //private List<Category> _categoryList = new List<Category>();
        private ApplicationDbContext _db = new ApplicationDbContext();
        //Simple constructor -- Guid Id not necessary --- this will be a simpler class than the Note
        public CategoryService()
        {

        }

        public List<Category> Index()
        {
            List<Category> categoryList = _db.Categories.ToList();
            List<Category> orderedList = categoryList.OrderBy(category => category.Name).ToList();
            return orderedList;

        }
        //C of Crud for creating Category
        public bool CreateCategory(CategoryCreate model)
        {
            var entity = new Category()
            {
                Name = model.Name,
                Description = model.Description
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
               return ctx.SaveChanges() == 1;
           }


            }
    

    public IEnumerable<CategoryListItem> GetCategories()
    {
        using (var ctx = _db)
        {
            var query = ctx.Categories.Select(e =>
                                                     new CategoryListItem
                                                     {
                                                         CategoryId = e.CategoryId,
                                                         Description = e.Description,
                                                         Name = e.Name
                                                     }
                                                      );
            return query.ToArray();

        }
    }
    //C of Crud
    //public bool CreateCategory(CategoryCreate model)
    //{
    //    var entity = new Category()
    //    {
    //        if (ModelState.IsValid)
    //    {
    //        Name = model.Name,
    //        Description = model.Description,
    //       }

    //}



}



    }

