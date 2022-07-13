using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Helper;
using Store.BL.Interface;
using Store.BL.ViewModels;
using Store.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    public class ProductController : Controller
    {

        #region Fields
        private readonly IProductRep product;
        private readonly IMapper mapper;

        #endregion


        #region Ctor 
        public ProductController(IProductRep product, IMapper mapper)
        {
            this.product = product;
            this.mapper = mapper;
        }

        #endregion



        #region Actions 
        public IActionResult Index()
        {
            var data = product.Get();
            var model = mapper.Map < IEnumerable<ProductVM>>(data);
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var data = product.GetById(id);
            var model = mapper.Map<ProductVM>(data);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.PhotoName = FileUpload.UploadFile("/wwwroot/Files/Imgs", model.Photo);
                    model.Cost = (model.Quantity * model.Salary);
                    model.Total = model.Cost - model.Vat;

                    var data = mapper.Map<Product>(model);
                    product.Create(data);
                    return RedirectToAction("Index");
                }
                return View(model);

                
                
            }
            catch (Exception)
            {
                return View(model);

            }
        }

        public IActionResult Edit(int id)
        {
            var data = product.GetById(id);
            var model = mapper.Map<ProductVM>(data);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProductVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Product>(model);
                    product.Edit(data);
                    return RedirectToAction("Index");
                }
                return View(model);

            }
            catch (Exception)
            {
                return View(model);

            }
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = product.GetById(id);
            var model = mapper.Map<ProductVM>(data);
            return View(model);
        }


        [HttpPost]
        public IActionResult Delete(ProductVM model)
        {

            try
            {
                var data = mapper.Map<Product>(model);
                product.Delete(data);
                return RedirectToAction("Index");
            }
            catch (Exception )
            {
                return View(model);
            }
        }
        #endregion

     
    }
}
