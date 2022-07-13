using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Helper;
using Store.BL.Interface;
using Store.BL.Repository;
using Store.BL.ViewModels;
using Store.DAL.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    [Authorize]

    public class EmployeeController : Controller
    {
        #region Fiels
        //LooslyCoupled
        private readonly IEmployeeRep employee;
        //Mapper
        private readonly IMapper mapper;

        #endregion

        #region Ctor
        public EmployeeController(IEmployeeRep employee, IMapper mapper)
        {
            this.employee = employee;
            this.mapper = mapper;
        }
        #endregion


        #region Get 
        public IActionResult Index()
        {

            var data = employee.Get();
            var model = mapper.Map<IEnumerable<EmployeeVM>>(data);
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
        public IActionResult Create(EmployeeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    model.PhotoName = FileUpload.UploadFile("/wwwroot/Files/Imgs", model.Photo);
                    model.CvName = FileUpload.UploadFile("/wwwroot/Files/Docs", model.Cv);

                    var data = mapper.Map<Employee>(model);
                    employee.Create(data);
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
            var data = employee.GetById(id);
            var model = mapper.Map<EmployeeVM>(data);

            return View(model);

        }
        #endregion

        #region Edit 
        public IActionResult Edit(int id)
        {
            var data = employee.GetById(id);
            var model = mapper.Map<EmployeeVM>(data);

            return View(model);

        }
        [HttpPost]
        public IActionResult Edit(EmployeeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(model);
                    employee.Edit(data);
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
            var data = employee.GetById(id);
            var model = mapper.Map<EmployeeVM>(data);
            return View(model);

        }
        [HttpPost]
        public IActionResult Delete(EmployeeVM model)
        {
            try
            {
                var data = mapper.Map<Employee>(model);
                employee.Delete(data);
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
