using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Shop.Data.Models
{
    public class ShopCart
    {
        private AppDBContext appDBContext;

        public ShopCart(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public string ShopCartId { get; set; }

        public List<ShopCartItem> listShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };

        }

        public void AddToCart(Car car)
        {
            appDBContext.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                car = car,
                price = car.price
            });

            appDBContext.SaveChanges();
        }

        public List<ShopCartItem> getShopItems()
        {
            return appDBContext.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.car).ToList();
        }
    }
}
