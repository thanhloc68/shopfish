using ShopFish.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopFish.ViewModels
{
    public class ShoppingCart
    {

        // Lấy giỏ hàng từ Session
        public static ShoppingCart Cart
        {
            get
            {
                var cart = HttpContext.Current.Session["Cart"] as ShoppingCart;
                // Nếu chưa có giỏ hàng trong session -> tạo mới và lưu vào session
                if (cart == null)
                {
                    cart = new ShoppingCart();
                    HttpContext.Current.Session["Cart"] = cart;
                }
                return cart;
            }
        }
        // Chứa các mặt hàng đã chọn
        public List<Products> Items = new List<Products>();

        public void Add(int id)
        {
           
            try // tìm thấy trong giỏ -> tăng số lượng lên 1
            {
                var item = Items.Single(i => i.ID == id);
                item.Quanlity++;
           
            }
            catch // chưa có trong giỏ -> truy vấn CSDL và bỏ vào giỏ
            {
                var db = new ShopDatabaseContext();
                var item = db.Products.Find(id);
                if(item.Quanlity > 0)
                {
                    item.Quanlity = 1;
                    
                    Items.Add(item);
                }
                else {
                    Console.Write("Hết hàng");
                }
            }
        }
        public void Addwithquantity(int id, int quantity)
        {

            try // tìm thấy trong giỏ -> tăng số lượng lên 1
            {
                var item = Items.Single(i => i.ID == id);
                item.Quanlity += quantity;
            }
            catch // chưa có trong giỏ -> truy vấn CSDL và bỏ vào giỏ
            {
                var db = new ShopDatabaseContext();
                var item = db.Products.Find(id);
                if (item.Quanlity > 0)
                {
                    item.Quanlity = quantity;
                    Items.Add(item);
                }
                else
                {
                    Console.WriteLine("alert('Found this error: ' + e +'. Check the console.'");
                }
            }
        }
        public void Remove(int id)
        {
            var item = Items.Single(i => i.ID == id);
            Items.Remove(item);
        }

        public void Update(int id, int newQuantity)
        {
            var item = Items.Single(i => i.ID == id);
            item.Quanlity = newQuantity;
        }

        public void Clear()
        {
            Items.Clear();
        }

        public int Count
        {
            get
            {
                return Items.Count;
            }
        }

        public double Total
        {
            get
            {
                return Items.Sum(p =>
                    p.Price * p.Quanlity);
            }
        }
    }
}