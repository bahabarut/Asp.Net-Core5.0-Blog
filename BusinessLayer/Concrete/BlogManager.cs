using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public void TAdd(Blog blog)
        {
            _blogDal.Insert(blog);
        }

        public void TDelete(Blog blog)
        {
            _blogDal.Delete(blog);
        }

        public void TUpdate(Blog blog)
        {
            _blogDal.Update(blog);
        }

        public Blog GetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public List<Blog> GetList()
        {
            return _blogDal.GetListAll();
        }
        public List<Blog> GetLast3Blog()
        {
            return _blogDal.GetListAll().Take(3).ToList();
        }
        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetBlogListWithCategory();
        }

        public List<Blog> GetBlogById(int id)
        {
            return _blogDal.GetBlogByIdWithCategory(x => x.BlogID == id);
        }
        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.GetListAll(x => x.UserID == id);
        }

        public List<Blog> GetBlogListWithCategoryByWriter(int id)
        {
            return _blogDal.GetBlogListWithCategoryByWriter(id);
        }
        public List<Blog> GetBlogListWithCategoryByWriter()
        {
            return _blogDal.GetBlogListWithCategoryByWriter();
        }
    }
}
