using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        List<Blog> GetBlogListWithCategory();
        List<Blog> GetBlogByIdWithCategory(Expression<Func<Blog, bool>> filter);
        List<Blog> GetBlogListWithCategoryByWriter(int id);
        List<Blog> GetBlogListWithCategoryByWriter();

    }
}
