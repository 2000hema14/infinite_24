using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3_dotnet
{
    class saleDetails
    {
        //data members of class saleDetails
        private int salesNo;
        private int productNo;
        private double price;
        private DateTime dateOfSale;
        private int qty;
        private double totalAmount;

        // Constructor
        public saleDetails(int salesNo, int productNo, double price, int qty, DateTime dateOfSale)
        {
            this.salesNo = salesNo;
            this.productNo = productNo;
            this.price = price;
            this.qty = qty;
            this.dateOfSale = dateOfSale;
            Sales();
        }

        //  to update TotalAmount based on Qty and Price
        public void Sales()
        {
            totalAmount = qty * price;
        }

        //data method used to display details
        public void ShowData()
        {
            Console.WriteLine($"Sales Number: {salesNo}");
            Console.WriteLine($"Product Number: {productNo}");
            Console.WriteLine($"Price: {price}");
            Console.WriteLine($"Quantity: {qty}");
            Console.WriteLine($"Date of Sale: {dateOfSale.ToShortDateString()}");
            Console.WriteLine($"Total Amount: {totalAmount}");
        }


        static void Main()
        {
            // Creating instance of sales class(providing input thr constructor)
            saleDetails sale1 = new saleDetails(100, 009, 100.0, 6, DateTime.Now); 

            // Display sale details
            sale1.ShowData();
            Console.ReadLine();
        }
    }
}






