using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Classes
{
    internal class Inventory
    {
        // need item#, itemPrice, itemName, how many items in stock
        public int prodID;
        public string prodName;
        public int prodPrice;
        public int prodStock;
        public int prodSold;

        public Inventory (int id, string name, int price, int stock, int sold)
        {
           prodID = id;
           prodName = name;
           prodPrice = price;
           prodStock = stock;
           prodSold = sold;
        }

        public override string ToString()
        {
            return $"\nProduct ID:		     {prodID}" +
                $"\nProduct Name:		{prodName}" +
                $"\nPrice:	            {prodPrice}" +
                $"\nCurrent Stock:		{prodStock}" +
                $"\nTotal Sold:		    {prodSold}";
        }
    }
}
