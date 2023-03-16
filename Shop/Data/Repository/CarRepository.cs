using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDBContext appDBContext;

        public CarRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public IEnumerable<Car> Cars => appDBContext.Car.Include(c => c.Category);

        public IEnumerable<Car> getFavCars => appDBContext.Car.Where(p => p.isFavourite).Include(c => c.Category);

        public Car getObjectCar(int carId) => appDBContext.Car.FirstOrDefault(p => p.id == carId);
            
        
    }
}
