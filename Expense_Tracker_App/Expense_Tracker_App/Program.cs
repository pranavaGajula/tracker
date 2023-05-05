using System.Diagnostics;
using System.Transactions;

namespace Expense_Tracker_App
{
    class Data
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
    }
    class Details
    {
        List<Data> list;
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }
        public Details()
        {
            list = new List<Data>()
            {
           // new Data { Title = "app", Description = "check", Amount = 5600, Date = "05/04/2023" },
              
            };
        }
        public void AddTransaction()
        {
            Console.WriteLine("Enter Title");
            string title = Console.ReadLine();
            Console.WriteLine("Enter Description");
            string description = Console.ReadLine();
            Console.WriteLine("Enter Amount");
            int amount = Convert.ToInt16(Console.ReadLine());
            DateTime date = new DateTime();
            try
            {
                Console.Write("Enter Date(DD/MM/YYYY): ");
                date = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Enter in format dd/mm/yyyy");
                return;
            }

            if (amount < 0)
            {
                Console.WriteLine("Expense Transactions");
                Expenses += Math.Abs(amount);
            }
            else
            {
                Console.WriteLine("Income Transactions");
                Income += amount;
            }
            list.Add(new Data() { Title = title, Description = description, Date = date });
            Console.WriteLine("Transaction Added Successfully");
        }

        public void ViewExpenses()
        {
            Console.WriteLine("Expenses:");
            Console.WriteLine("Title\tDescription\tAmount\tDate");
            foreach (Data c in list)
            {
                if (c.Amount < 0)
                {
                    Console.WriteLine($"{c.Title}\t{c.Description}\t\t{c.Amount}\t{c.Date}");
                }
            }

        }
        public void ViewIncome()
        {
            Console.WriteLine("Income:");
            Console.WriteLine("Title\tDescription\tAmount\tDate");
            foreach (Data c in list)
            {
                if (c.Amount >= 0)
                {
                    Console.WriteLine($"{c.Title}\t{c.Description}\t{c.Amount}\t{c.Date}");
                }
            }

        }
        public void ViewBalance()
        {
            decimal Balance = Income - Expenses;
            Console.WriteLine($"Available Balance: {Balance}");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Details details = new Details();
            string res = "y";
            do
            {
                Console.WriteLine("1. Add Transaction");
                Console.WriteLine("2. View Expenses");
                Console.WriteLine("3. View Income");
                Console.WriteLine("4. Check Available Balance");
                int choice = Convert.ToInt16(Console.ReadLine());


            
                switch (choice)
                {
                    case 1:
                        {
                            details.AddTransaction();
                            break;
                        }
                    case 2:
                        {
                            
                            details.ViewExpenses();
                            break;
                        }
                    case 3:
                        {
                            
                            details.ViewIncome();
                            break;
                        }
                    case 4:
                        {
                            details.ViewBalance();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong Choice Entered");
                            break;
                        }

                }
                Console.WriteLine("Do you wish to continue? [y/n] ");
                res = Console.ReadLine();
            } while (res.ToLower() == "y");
            
        }

    }
}