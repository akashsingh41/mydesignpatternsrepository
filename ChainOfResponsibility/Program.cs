using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class PurchaseOrder
    {
        public string requesterName { get; set; }
        public int orderNumber { get; set; }
        public double amount { get; set; }
        public double price { get; set; }

        public PurchaseOrder(int _orderNumber, string _requesterName, double _amount, double _price)
        {
            this.orderNumber = _orderNumber;
            this.requesterName = _requesterName;
            this.amount = _amount;
            this.price = _price;
            Console.WriteLine("Purchase Order {0} for {1} has been submitted.",this.orderNumber,this.requesterName);
        }

    }
    abstract class Approver
    {
        protected Approver Supervisor;

        public void SetSupervisor(Approver _supervisor)
        {
            this.Supervisor = _supervisor;
        }

        public abstract void ProcessRequest(PurchaseOrder order);
    }

    class HeadChef : Approver
    {
        public override void ProcessRequest(PurchaseOrder order)
        {
            if (order.price < 1000)
                Console.WriteLine("Order# " + order.orderNumber + " processed by" + this.GetType().Name);
            else
                if (Supervisor != null)
            {
                Supervisor.ProcessRequest(order);
            }
        }
    }

    class Manager : Approver
    {
        public override void ProcessRequest(PurchaseOrder order)
        {
            if (order.price < 5000)
                Console.WriteLine("Order# " + order.orderNumber + " processed by" + this.GetType().Name);
            else
                if (Supervisor != null)
            {
                Supervisor.ProcessRequest(order);
            }
        }
    }

    class Director : Approver
    {
        public override void ProcessRequest(PurchaseOrder order)
        {
            if (order.price < 20000)
                Console.WriteLine("Order# " + order.orderNumber + " processed by " + this.GetType().Name);
            else
                if (Supervisor != null)
            {
                Supervisor.ProcessRequest(order);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Approver a = new HeadChef();
            Approver b = new Manager();
            Approver c = new Director();

            a.SetSupervisor(b);
            b.SetSupervisor(c);

            PurchaseOrder order = new PurchaseOrder(1, "Stacy", 2.50, 680);
            a.ProcessRequest(order);

            order = new PurchaseOrder(4, "Sam", 4.00, 12500);
            a.ProcessRequest(order);

            order = new PurchaseOrder(9, "Samantha", 2.75, 3000);
            a.ProcessRequest(order);
        }
    }
}
