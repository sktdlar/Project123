using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project123.Components.DataBase
{
    public partial class Products
    {
        public double Price { get
            {
                double price = 0;
                foreach(var i in App.db.ProductionMaterials)
                {
                    if(i.ProductArticle == Article)
                    {
                        price = (double)(i.Materials.Cost * i.Quantity);
                    }
                }
                return price;
            } }
    }
}
