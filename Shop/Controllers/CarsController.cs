using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars iAllCars, ICarsCategory ICarsCat)
        { 
            _allCars = iAllCars;
            _allCategories = ICarsCat;
        }

        public ViewResult List()
        {
            ViewBag.Title = "Cторінка з автомобілями";
            CarsListViewModel obj = new CarsListViewModel();
            obj.allCars = _allCars.Cars;
            obj.currCategory = "Автомобілі";

            return View(obj);

        }
    }
}
