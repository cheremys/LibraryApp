using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using LibraryBLL.DataTransferObjects;
using LibraryBLL.Interfaces;
using LibraryWeb.Models;

namespace LibraryWeb.Controllers
{
    public class HomeController : Controller
    {
        ICategoryService categoryService;
        IBookService bookService;

        public HomeController(ICategoryService categoryService, IBookService bookService)
        {
            this.categoryService = categoryService;
            this.bookService = bookService;
        }

        public ActionResult Index()
        {
            var categoryModels = GetCategories();
            return View(categoryModels);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AppConsultant()
        {
            return PartialView("AppConsultant");
        }

        public ActionResult CreateConsultant()
        {
            return PartialView("CreateConsultant");
        }

        [HttpPost]
        public bool CreateBook(BookModel[] models)
        {
            foreach (var model in models)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var config = new MapperConfiguration(cfg =>
                        {
                            cfg.CreateMap<CategoryModel, CategoryDTO>();
                            cfg.CreateMap<BookModel, BookDTO>();
                        });

                        config.AssertConfigurationIsValid();

                        var mapper = config.CreateMapper();
                        var book = mapper.Map<BookModel, BookDTO>(model);

                        bookService.CreateBook(book);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

            return true;
        }

        [HttpPost]
        public bool DeleteBook(string[] titles)
        {
            foreach (var title in titles)
            {
                BookDTO book = null;
                try
                {
                    book = bookService.FindBookByName(title);
                }
                catch (Exception ex)
                {
                }

                if (book != null)
                {
                    bookService.Delete(book.Id);
                }
            }

            return true;
        }


        protected override void Dispose(bool disposing)
        {
            categoryService.Dispose();
            bookService.Dispose();
            base.Dispose(disposing);
        }

        private List<CategoryModel> GetCategories()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryDTO, CategoryModel>();
                cfg.CreateMap<BookDTO, BookModel>();
            });

            config.AssertConfigurationIsValid();

            var categories = this.categoryService.GetCategories();

            var mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<CategoryDTO>, List<CategoryModel>>(categories);
        }
    }
}