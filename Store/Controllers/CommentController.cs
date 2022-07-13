using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Interface;
using Store.BL.ViewModels;
using Store.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentRep comment;
        private readonly IMapper mapper;

        public CommentController(ICommentRep comment , IMapper mapper)
        {
            this.comment = comment;
            this.mapper = mapper;
        }

        #region Get 
        public IActionResult Index()
        {

            var data = comment.Get();
            var model = mapper.Map<IEnumerable<CommentVM>>(data);
            return View(model);
        }
        #endregion


        #region Create 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CommentVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {

             

                    var data = mapper.Map<Comment>(model);
                    comment.Create(data);
                    return RedirectToAction("Index");
                }
                return View(model);

            }
            catch (Exception)
            {
                return RedirectToAction("Error404");

            }



        }
        #endregion

        #region Details
        public IActionResult Details(int id)
        {
            var data = comment.GetById(id);
            var model = mapper.Map<CommentVM>(data);

            return View(model);

        }
        #endregion

        #region Edit 
        public IActionResult Edit(int id)
        {
            var data = comment.GetById(id);
            var model = mapper.Map<CommentVM>(data);

            return View(model);

        }
        [HttpPost]
        public IActionResult Edit(CommentVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Comment>(model);
                    comment.Edit(data);
                    return RedirectToAction("Index");
                }
                return View(model);

            }
            catch (Exception)
            {
                return View(model);
            }

        }
        #endregion

        #region Delete
        public IActionResult Delete(int id)
        {
            var data = comment.GetById(id);
            var model = mapper.Map<CommentVM>(data);
            return View(model);

        }
        [HttpPost]
        public IActionResult Delete(CommentVM model)
        {
            try
            {
                var data = mapper.Map<Comment>(model);
                comment.Delete(data);
                return RedirectToAction("Index");


            }
            catch (Exception)
            {
                return View(model);
            }

        }
        #endregion
    }
}
