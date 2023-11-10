using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;
using WEBSITE101.Data;
using WEBSITE101.DTO;
using WEBSITE101.Interface;
using WEBSITE101.Model;

namespace WEBSITE101.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public bool AddCategory(CategoryDto category)
        {
            Category obj = new Category();
            obj.Name = category.Name;
           _context.Add(obj);
            var rowsAffected = _context.SaveChanges();
            if (rowsAffected < 0)
                return false;
            return true;
        }

        public bool DeleteCategory(int id)
        {
            var category =_context.Categories.Where(x => x.Id == id).FirstOrDefault();
            _context.Remove(category);
            var rowsAffected = _context.SaveChanges();
            if (rowsAffected < 0)
                return false;
            return true;
        }

        public CategoryDto GetCategory(int id)
        {
            CategoryDto categoryDto = new CategoryDto();
            var category = _context.Categories.Where(x=>x.Id == id).FirstOrDefault();
            categoryDto.Name = category.Name;
            categoryDto.Id = category.Id;
            return categoryDto;
        }

        public bool UpdateCategory(CategoryDto categoryDto)
        {
            var category = _context.Categories.Where(x => x.Id == categoryDto.Id).FirstOrDefault();
            
            category.Id = categoryDto.Id;
            category.Name = categoryDto.Name;

            var result = _context.SaveChanges();
            if(result < 0) return false;
            return true;
            

        }
    }
}
