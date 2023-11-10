using WEBSITE101.DTO;

namespace WEBSITE101.Interface
{
    public interface ICategoryRepository
    {
        public bool AddCategory(CategoryDto category);
        public CategoryDto GetCategory(int id);
        public bool UpdateCategory(CategoryDto category);
        public bool DeleteCategory(int id);
    }
}
