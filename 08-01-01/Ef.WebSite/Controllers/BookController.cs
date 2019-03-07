using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ef.WebSite.Models;
using EF.Core.Data;
using EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ef.WebSite.Controllers
{
    public class BookController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private Repository<Book> bookRepository;

        public BookController()
        {
            bookRepository = unitOfWork.Repository<Book>();
        }
        // GET: Book
        public ActionResult Index()

        {
            var books = bookRepository.Table.ProjectTo<BookDTO>().ToList();
            return View(books);
        }
        /// <summary>
        /// 获取编辑书籍信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult CreateEditBook(int? id)
        {
            var bookDTO = new BookDTO();
            if (id.HasValue)
            {
                var entity = bookRepository.GetById(id.Value);
                bookDTO = Mapper.Map<Book, BookDTO>(entity);
            }
            return View(bookDTO);
        }

        /// <summary>
        /// 添加或编辑书籍信息
        /// </summary>
        /// <param name="bookDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateEditBook(BookDTO bookDTO)
        {
            if (bookDTO.ID == 0)
            {
                var model = Mapper.Map<BookDTO, Book>(bookDTO);

                model.ModifiedTime = DateTime.Now;
                model.CreatedTime = DateTime.Now;
                model.Url = string.Empty;
                model.IP = Request.UserHostAddress;

                bookRepository.Insert(model);
                unitOfWork.Commit();
            }
            else
            {
                var editModel = bookRepository.GetById(bookDTO.ID);

                bookDTO.ID = editModel.ID;
                editModel.Author = bookDTO.Author;
                editModel.ISBN = bookDTO.ISBN;
                editModel.Title = bookDTO.Title;
                editModel.Published = bookDTO.Published;
                editModel.ModifiedTime = DateTime.Now;
                editModel.IP = Request.UserHostAddress;
                bookRepository.Update(editModel);
                unitOfWork.Commit();
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// 获取删除书籍信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteBook(int id)
        {
            var entity = bookRepository.GetById(id);
            if (ReferenceEquals(entity, null))
            {
                return RedirectToAction("Index");
            }

            var model = Mapper.Map<Book, BookDTO>(entity);

            return View(model);
        }

        /// <summary>
        /// 删除书籍
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("DeleteBook")]
        public ActionResult ConfirmDeleteBook(int id)
        {
            var model = bookRepository.GetById(id);
            bookRepository.Delete(model);
            unitOfWork.Commit();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 书籍概述
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DetailBook(int id)
        {
            var model = bookRepository.GetById(id);

            var bookDTO = Mapper.Map<Book, BookDTO>(model);

            return View(bookDTO);
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}