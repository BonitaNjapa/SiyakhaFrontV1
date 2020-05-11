using BusinessLogic;
using Data.ShoppingCartM;
using SiyakhaFrontV1.Controllers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiyakhaFrontV1.Controllers
{
    public class DepartmentsController : Controller
    {
        DepartmentBusiness department_Service = new DepartmentBusiness();
        // private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index(string sortOrder, string searchString)
        {
            var students = from s in department_Service.GetDepartments()
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Department_Name.Contains(searchString)
                                       || s.Description.Contains(searchString));
                return View(students.ToList());

            }
            return View(department_Service.GetDepartments());
        }
        public ActionResult Details(int id)
        {
          
            if (department_Service.GetDepartment(id) != null)
                return View(department_Service.GetDepartment(id));
            else
                return RedirectToAction("Not_Found", "Error");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department model)
        {
            if (ModelState.IsValid)
            {
                department_Service.AddDepartment(model);
                this.AddToastMessage("Success","Department succesfully created",Model.HelperToast.ToastType.Success);
                return RedirectToAction("Index");
            }

            return View(model);
        }
        public ActionResult Edit(int id)
        {
         
            if (department_Service.GetDepartment(id) != null)
                return View(department_Service.GetDepartment(id));
            else
                return RedirectToAction("Not_Found", "Error");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department model)
        {
            if (ModelState.IsValid)
            {
                department_Service.UpdateDepartment(model);
                this.AddToastMessage("Success", "Department updated succesfully", Model.HelperToast.ToastType.Success);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public JsonResult Delete(int id)
        {
            try
            {
                var update = department_Service.RemoveDepartment(department_Service.GetDepartment(id));
                this.AddToastMessage("Success", "Department succesfully deleted", Model.HelperToast.ToastType.Success);
            }
            catch
            {
            }
            return Json(new object[] { new object() }, JsonRequestBehavior.AllowGet);
        }
    }
}