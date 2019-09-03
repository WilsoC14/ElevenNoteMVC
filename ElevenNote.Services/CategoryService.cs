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
        //R of cRud for reading list of Categories
        public List<Category> Index()
        {
            List<Category> categoryList = _db.Categories.ToList();
            List<Category> orderedList = categoryList.OrderBy(category => category.Name).ToList();
            return orderedList;

        }

        //U of crUd for update a Category
        public bool UpdateCategory (CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.Single(e => e.CategoryId == model.CategoryId);
                
                entity.Name = model.Name;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;


               }
        }

        //D of cruD for Delete a Category
        public bool DeleteCategory(int categoryId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.Single(e => e.CategoryId == categoryId);
                ctx.Categories.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }












            //Helper Method to create CategoryListItem from Db contents
        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
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
       


        //Helper Method to get Category by Id
        public CategoryDetail GetCategoryById (int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.Single(e => e.CategoryId == id);
                return new CategoryDetail
                {
                    CategoryId = entity.CategoryId,
                    Name = entity.Name,
                    Description = entity.Description
                };
                
            }
        }



    }



}

