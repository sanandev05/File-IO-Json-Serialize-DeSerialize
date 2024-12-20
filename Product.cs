using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIO_JSON_Serialize.Desrialize
{
    public class Product
    {
        double _salePrice;
        static int _id;
        public static int ID { get=>_id; private set { } }
        public int Index { get; private set; }

        public string Name {  get;  set; }
        public double CostPrice { get; set; }
        public double SalePrice
        {
            get=>_salePrice;
            set
            {
                if (CostPrice <= value)
                {
                    _salePrice = value;
                }
                else
                {
                    throw new BelowSalePriceException("Sale Price can not be below cost price !");
                }
            }
        }
        public Product(string name, double costPrice,double salePrice)
        {
            ID++;
            Name = name;
            CostPrice = costPrice;
            SalePrice = salePrice;
            Index = ID;
        }

    }
}
