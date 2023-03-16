using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;

namespace Shop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContext context)
        {
            if (!context.Category.Any())
                context.Category.AddRange(Categories.Select(c => c.Value));

            if (!context.Car.Any())
            {
                context.AddRange(
                new Car
                {
                    name = "Tesla Model S",
                    shortDesc = "Швидкий автомобіль",
                    longDesc = "Красивий, швидкий и дуже тихий автомобіль",
                    img = "/img/tesla.jpg",
                    price = 45000,
                    isFavourite = true,
                    available = true,
                    Category = Categories["Електромобілі"]
                },
                    new Car
                    {
                        name = "BMW M3",
                        shortDesc = "Зухвалий і стильний",
                        longDesc = "Зручне авто для громадського життя",
                        img = "/img/m3.jpg",
                        price = 65000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Класичні автомобілі"]
                    },
                    new Car
                    {
                        name = "Ford Fiesta",
                        shortDesc = "Тихий і спокійний",
                        longDesc = "Зручний автомобіль для громадського життя",
                        img = "/img/fiesta.jpg",
                        price = 11000,
                        isFavourite = false,
                        available = true,
                        Category = Categories["Класичні автомобілі"]
                    },
                    new Car
                    {
                        name = "Mercedes C class",
                        shortDesc = "Зручний і великий",
                        longDesc = "Класне авто щоб повимахуватись",
                        img = "/img/MercC.jpg",
                        price = 40000,
                        isFavourite = true,
                        available = false,
                        Category = Categories["Класичні автомобілі"]
                    },
                    new Car
                    {
                        name = "Mercedes-Benz GLE-class",
                        shortDesc = "Кросовер преміум класу",
                        longDesc = "Велике та надійне авто",
                        img = "/img/GLE-Class.jpeg",
                        price = 59990,
                        isFavourite = true,
                        available = false,
                        Category = Categories["Класичні автомобілі"]
                    },
                    new Car
                    {
                        name = "Ford",
                        shortDesc = "EuroTour і Poland",
                        longDesc = "Авто Мішанчика",
                        img = "/img/FordM.jpg",
                        price = 2400,
                        isFavourite = true,
                        available = false,
                        Category = Categories["Класичні автомобілі"]
                    },
                    new Car
                    {
                        name = "Skoda",
                        shortDesc = "78 і Сіжка",
                        longDesc = "Авто Чижухіка",
                        img = "/img/SkodaM.jpg",
                        price = 6500,
                        isFavourite = true,
                        available = false,
                        Category = Categories["Класичні автомобілі"]
                    },
                    new Car
                    {
                        name = "Skoda",
                        shortDesc = "Платінум і БРНО",
                        longDesc = "Авто Максюхіка",
                        img = "/img/SkodaMaks.jpg",
                        price = 5000,
                        isFavourite = true,
                        available = false,
                        Category = Categories["Класичні автомобілі"]
                    },
                    new Car()
                    {
                        name = "Skoda SuperB",
                        shortDesc = "Начальник решіток",
                        longDesc = "Авто Данюхіка",
                        img = "/img/SkodaD.jpg",
                        price = 22000,
                        isFavourite = true,
                        available = false,
                        Category = Categories["Класичні автомобілі"]
                    }
                );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if(category == null)
                {
                    var list = new Category[]
                    {
                         new Category { categoryName = "Електромобілі", desc = "Сучасний вид транспорту"},
                         new Category { categoryName = "Класичні автомобілі", desc = "Машини з двигуном швидкого згорання"}
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.categoryName, el);
                }

                return category;
            }
        }
    }
}
