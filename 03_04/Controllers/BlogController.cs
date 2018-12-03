using _03_04.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03_04.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            var blogs = new List<Blog>();
            using (var _context = new EFDbContext())
            {
                blogs = _context.Blogs
                    .AsNoTracking()
                    .ToList();

            };
            return View(blogs);
        }

        /// <summary>
        /// 博客站内搜索
        /// </summary>
        /// <param name="Owner"></param>
        /// <returns></returns>
        public ActionResult Search(string Owner)
        {
            var blogs = new List<Blog>();
            using (var _context = new EFDbContext())
            {
                blogs = _context.Blogs.ToList();
                blogs.All(b =>
                {
                    b.Owner = Transfer(b._Owner);
                    return true;
                });

            };
            if (!string.IsNullOrEmpty(Owner))
            {
                blogs = blogs
               .Where(d => d.Owner.Name == Owner || d.Owner.EnglishName == Owner)
               .ToList();
            }
            return View("Index", blogs);
        }

        Person Transfer(string p)
        {
            return JsonConvert.DeserializeObject<Person>(p);
        }

        public ActionResult Insert()
        {
            return View();
        }

        /// <summary>
        /// 获取单个博客实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Get(int? id)
        {
            if (ReferenceEquals(id, null) || id.Value <= 0)
            {
                return Content("<script  type='text/javascript'>alert('提交参数不正确!');location.href='/';</script>");
            }
            using (var _context = new EFDbContext())
            {
                var blog = _context.Blogs.Find(id);
                if (ReferenceEquals(blog, null))
                {
                    return Content("<script  type='text/javascript'>alert('该博客不存在!');location.href='/';</script>");
                }
                return View("Update", blog);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (ReferenceEquals(id, null) || id.Value <= 0)
            {
                return Content("<script  type='text/javascript'>alert('提交参数不正确!');location.href='/';</script>");
            }
            using (var _context = new EFDbContext())
            {
                var dbBlog = _context.Blogs.Find(id);
                if (ReferenceEquals(dbBlog, null))
                {
                    return Content("<script  type='text/javascript'>alert('该博客不存在!');location.href='/';</script>");
                }
                else
                {
                    _context.Blogs.Remove(dbBlog);
                    var result = _context.SaveChanges();
                    if (result > 0)
                    {
                        return View("Index");
                    }
                    return Content("<script  type='text/javascript'>alert('删除失败!');location.href='/';</script>");
                }
            }
        }

        /// <summary>
        /// 添加或更新博客
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Blog blog)
        {
            if (ModelState.IsValid)
            {
                using (var _context = new EFDbContext())
                {
                    var dbBlog = _context.Blogs.Find(blog.Id);
                    if (ReferenceEquals(blog, null))
                    {
                        return Content("<script  type='text/javascript'>alert('提交参数不正确!');location.href='/';</script>");
                    }
                    else
                    {
                        dbBlog.Owner = blog.Owner;
                        dbBlog.Tags = blog.Tags;
                        dbBlog.Url = blog.Url;
                        dbBlog.ModifiedTime = DateTime.Now;
                    }
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                };
            }
            return View();
        }
        /// <summary>
        /// 添加或更新博客
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert([Bind(Exclude = "Id")]Blog blog)
        {
            if (ModelState.IsValid)
            {
                using (var _context = new EFDbContext())
                {
                    if (blog.Id <= 0)
                    {
                        _context.Blogs.Add(blog);
                        blog.CreatedTime = DateTime.Now;
                        blog.ModifiedTime = DateTime.Now;
                    }
                    else
                    {
                        var dbBlog = _context.Blogs.Find(blog.Id);
                        if (ReferenceEquals(blog, null))
                        {
                            _context.Blogs.Add(blog);
                            blog.CreatedTime = DateTime.Now;
                            blog.ModifiedTime = DateTime.Now;
                        }
                        else
                        {
                            return Content("<script  type='text/javascript'>alert('提交参数不正确!');location.href='/';</script>");
                        }
                    }
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                };
            }
            return View();
        }
    }
}
