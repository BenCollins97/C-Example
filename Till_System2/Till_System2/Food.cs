using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Till_System2
{
    class Food
    {
        string mProduct;
        decimal mPrice;
        

        public Food(string product, decimal price)
        {
            mProduct = product;
            mPrice = price;
            
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

        
    }
}
