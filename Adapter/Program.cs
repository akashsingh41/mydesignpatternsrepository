using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class Product
    {
        public int product_id;
        public string product_name;
        public string product_specifications;
        public int product_quantity;
        public Product(int _id, string _name, string _specs, int _quantity)
        {
            this.product_id = _id;
            this.product_name = _name;
            this.product_specifications = _specs;
            this.product_quantity = _quantity;
        }
    }

    interface IInventory
    {
        List<Product> GetInventoryData();
    }

    public class Inventory
    {
        public List<Product> GetProductList()
        {
            List<Product> product_list = new List<Product>();
            product_list.Add(new Product(1, "Bajaj Iron FX-II", "Teflon Coated Aluminium Plate, Copper Wiring", 3));
            product_list.Add(new Product(2, "Voltas Air Conditioner DSX-309", "1.5 Ton, Copper Condensor, 5 Star BEE Rating", 5));
            product_list.Add(new Product(3, "Legrand Single Switch", "Myland, Double Ceramic, Silicon Plate", 2));

            return product_list;
        }
    }



    class Adapter : IInventory
    {
        public List<Product> GetInventoryData()
        {
            Inventory inventory_instance = new Inventory();
            return inventory_instance.GetProductList();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Adapter adapter_instance = new Adapter();
            Console.WriteLine("Product ID - Product Name");
            foreach (Product x in adapter_instance.GetInventoryData())
            {
                Console.WriteLine(x.product_id+" - "+x.product_name);
            }

            Console.ReadLine();
        }
    }
}
