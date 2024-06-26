﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetBlogByIdWithCategory(Expression<Func<Blog, bool>> filter)
        {
            using var c = new Context();
            return c.Blogs.Where(filter).Include(x => x.Category).ToList();
        }

        public List<Blog> GetBlogListWithCategory()
        {
            using (var c = new Context())
            {
                // parantez içinde hangi entity içine dahil edilecek bu işleme Eager loading denir
                return c.Blogs.Include(x => x.Category).Include(y => y.User).ToList();
            }
        }

        public List<Blog> GetBlogListWithCategoryByWriter(int id)
        {
            using (var c = new Context())
            {
                // parantez içinde hangi entity içine dahil edilecek bu işleme Eager loading denir
                return c.Blogs.Include(x => x.Category).Where(y => y.UserID == id).ToList();
            }
        }
        public List<Blog> GetBlogListWithCategoryByWriter()
        {
            using Context c = new Context();
            return c.Blogs.Include(x => x.Category).Include(y => y.User).ToList();
        }
        public List<Blog> GetBlogByCategory(int id)
        {
            using Context c = new Context();
            return c.Blogs.Where(y => y.CategoryID == id).Include(x => x.Category).Include(z=>z.User).ToList();
        }
    }
}
