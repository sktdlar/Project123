using System;
using System.Collections.Generic;
using System.Linq;

namespace Project123.Components.DataBase
{
    public partial class Products
    {
        private double _price;

        public double Price
        {
            get
            {
                if (_price == 0)
                {
                    _price = CalculatePrice();
                }
                return _price;
            }
            set
            {
                _price = value;
            }
        }

        private double CalculatePrice()
        {
            double price = 0;
            foreach (var i in App.db.ProductionMaterials)
            {
                if (i.ProductArticle == Article)
                {
                    price += (double)(i.Materials.Cost * i.Quantity);
                }
            }
            return price;
        }
    }
}
