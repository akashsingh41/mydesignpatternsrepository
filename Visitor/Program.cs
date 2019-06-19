﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class IncomeVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            Employee employee = element as Employee;

            // Provide 10% pay raise
            employee.Income *= 1.10;
            Console.WriteLine("{0} {1}'s new income: {2:C}",
            employee.GetType().Name, employee.Name,
            employee.Income);
        }
    }

    class VacationVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            Employee employee = element as Employee;

            // Provide 3 extra vacation days
            employee.VacationDays += 3;
            Console.WriteLine("{0} {1}'s new vacation days: {2}",
            employee.GetType().Name, employee.Name,
            employee.VacationDays);
        }
    }


   public abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
    }
    public interface IVisitor
    {
        void Visit(Element element);
    }

    public class Employee : Element
    {
        private string _name;
        private double _income;
        private int _vacationDays;

        // Constructor
        public Employee(string name, double income,
          int vacationDays)
        {
            this._name = name;
            this._income = income;
            this._vacationDays = vacationDays;
        }

        // Gets or sets the name
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Gets or sets income
        public double Income
        {
            get { return _income; }
            set { _income = value; }
        }

        // Gets or sets number of vacation days
        public int VacationDays
        {
            get { return _vacationDays; }
            set { _vacationDays = value; }
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Employees
    {
        private List<Employee> _employees = new List<Employee>();
        public void Attach(Employee employee)
        {
            _employees.Add(employee);
        }
        public void Detach(Employee employee)
        {
            _employees.Remove(employee);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (Employee e in _employees)
            {
                e.Accept(visitor);
            }
            Console.WriteLine();
        }
    }

    class Clerk : Employee
    {
        public Clerk() : base("Hank", 25000.0, 14)
        {
        }
    }
    public class Director : Employee
    {
        // Constructor
        public Director()
          : base("Elly", 35000.0, 16)
        {
        }
    }

    public class President : Employee
    {
        // Constructor
        public President()
          : base("Dick", 45000.0, 21)
        {
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Employees e = new Employees();
            e.Attach(new Clerk());
            e.Attach(new Director());
            e.Attach(new President());

            // Employees are 'visited'
            e.Accept(new IncomeVisitor());
            e.Accept(new VacationVisitor());

            // Wait for user
            Console.ReadKey();
        }
    }

}