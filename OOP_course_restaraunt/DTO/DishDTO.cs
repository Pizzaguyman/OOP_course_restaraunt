using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_course_restaraunt.DTO
{
    public class DishDTO
    {
        public int _id = 0;
        public string _name;
        public string _description;
        public List<string> _ingredients;
        public double _prod_price;
        public double _sell_price;
        public DishDTO(string name, string desc, List<string> ingredients, double prod_price, double? sell_price, double markup = 100)
        {
            _name = name;
            _description = desc;
            _ingredients = ingredients;
            _prod_price = prod_price;
            _sell_price = sell_price ?? prod_price * markup / 100;
        }
    }
}
