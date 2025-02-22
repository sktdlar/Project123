using System;
using System.Collections.Generic;
using System.Linq;

namespace Project123.Components.DataBase
{
    public partial class Products
    {
        // Добавляем поле для хранения значения цены
        private double _price;

        // Свойство Price, которое будет как для чтения, так и для записи
        public double Price
        {
            get
            {
                if (_price == 0)
                {
                    // Рассчитываем цену, если она не была установлена вручную
                    _price = CalculatePrice();
                }
                return _price;
            }
            set
            {
                // Устанавливаем цену вручную
                _price = value;
            }
        }

        // Метод для расчета цены товара
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
