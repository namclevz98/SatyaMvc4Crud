﻿using SatyaMvc4Crud.DataAccess;
using SatyaMvc4Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SatyaMvc4Crud.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        //  
        // GET: /Customer/  
        [HttpGet]
        public ActionResult InsertCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertCustomer(Customer objCustomer)
        {
            objCustomer.Birthdate = Convert.ToDateTime(objCustomer.Birthdate);
            if(ModelState.IsValid)
            {
                DataAccessLayer objDB = new DataAccessLayer();
                string result = objDB.InsertData(objCustomer);
                TempData["insertedSuccess"] = result;
                ModelState.Clear();
                return RedirectToAction("ShowAllCustomerDetails");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }    
        }

        [HttpGet]

        public ActionResult ShowAllCustomerDetails()
        {
            Customer objCustomer = new Customer();
            DataAccessLayer objDB = new DataAccessLayer();
            objCustomer.ShowallCustomer = objDB.Selectalldata();
            return View(objCustomer);
        }

        [HttpGet]
        public ActionResult Details(string ID)
        {
            Customer objCustomer = new Customer();
            DataAccessLayer objDB = new DataAccessLayer();
            return View(objDB.SelectDatabyID(ID));
        }
        
        [HttpGet]
        public ActionResult Edit(string ID)
        {
            Customer objCustomer = new Customer();
            DataAccessLayer objDB = new DataAccessLayer();
            return View(objDB.SelectDatabyID(ID));

        }

        [HttpPost]
        public ActionResult Edit(Customer objCustomer)
        {
            objCustomer.Birthdate = Convert.ToDateTime(objCustomer.Birthdate);
            if(ModelState.IsValid)
            {
                DataAccessLayer objDB = new DataAccessLayer();
                string result = objDB.UpdateData(objCustomer);
                TempData["updatedSuccess"] = result;
                ModelState.Clear();
                return RedirectToAction("ShowAllCustomerDetails");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }                
        }

        [HttpGet]
        public ActionResult Delete(string ID)
        {
            DataAccessLayer objDB = new DataAccessLayer();
            int result = objDB.DeleteData(ID);
            TempData["deletedSuccess"] = result;
            ModelState.Clear();
            return RedirectToAction("ShowAllCustomerDetails");
        }
    }
}