using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Till_System2
{
    class Drink
    {
        string mProduct;
        decimal mPrice;
        string mType;

        public Drink(string product, decimal price, string type)
        {
            mProduct = product;
            mPrice = price;
            mType = type;
        }

        public void setPrice(decimal price)
        {
            mPrice = price;
        }
        
        public decimal getPrice()
        {
            return mPrice;
        }

        public void setProduct(string product)
        {
            mProduct = product;
        }

        public string getProduct()
        {
            return mProduct;
        }

        public void setType(string type)
        {
            mType = type;
        }

        public string getType()
        {
            return mType;
        }
    }
}

