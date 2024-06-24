using System;
using System.Collections.Generic;

internal class asm1
{
    private class Customer
    {
        public string Name { get; set; }

        public int LastMonth { get; set; }

        public int ThisMonth { get; set; }

        public string CustomerType { get; set; }

        public int NumberPeople { get; set; }

        public double TotalBill { get; set; }
    }

    static void Main()
    {
        List<Customer> customers = new List<Customer>();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("------Menu------");
            Console.WriteLine("1. Calculate water bill");
            Console.WriteLine("2. Search for customer names");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option (1-3): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddCustomer(customers);
                    break;
                case "2":
                    SearchCustomer(customers);
                    break;
                case "3":
                    return; 
                default:
                    Console.WriteLine("Invalid selection, please select again.");
                    break;
            }
        }
    }

    static void AddCustomer(List<Customer> customers)
    {
        Console.Write("Enter customer name: ");
        string name = Console.ReadLine();
        Console.Write("Enter last month's water index: ");
        int lastMonth = int.Parse(Console.ReadLine());
        Console.Write("Enter this month's water index: ");
        int thisMonth = int.Parse(Console.ReadLine());

        if (thisMonth < lastMonth)
        {
            Console.WriteLine("Error: This month's water index cannot be smaller than last month's.");
            Console.ReadKey();
            return;
        }

        Console.Write("Choose type customer: "+"\n1. Household"+"\n2. Administrative"+"\n3. Production"+"\n4. Business" + "\nEnter the customer type :");
        string customerType = Console.ReadLine();

        int numberPeople = 0;
        if (customerType == "1")
        {
            Console.Write("Enter the number of people in the household: ");
            numberPeople = int.Parse(Console.ReadLine());
        }

        int consumption = thisMonth - lastMonth;
        double totalBill = CalculateWaterBill(customerType, consumption, numberPeople);

        Customer customer = new Customer
        {
            Name = name,
            LastMonth = lastMonth,
            ThisMonth = thisMonth,
            CustomerType = customerType,
            NumberPeople = numberPeople,
            TotalBill = totalBill
        };

        customers.Add(customer);
        Console.WriteLine("\nCustomer information:");
        Console.WriteLine("Name: " + customer.Name);
        Console.WriteLine($"Last month's index: {customer.LastMonth}");
        Console.WriteLine($"Index this month: {customer.ThisMonth}");
        Console.WriteLine($"Water consumption: {consumption} m³");
        Console.WriteLine($"Total amount (excluding VAT): {customer.TotalBill:N0} VND");
        Console.WriteLine($"Total amount (with 10% VAT): {customer.TotalBill * 1.1:N0} VND\n");
        Console.ReadKey();
    }

    static void SearchCustomer(List<Customer> customers)
    {
        Console.Write("Enter the name of the customer you want to search for: ");
        string searchName = Console.ReadLine();
        Customer foundCustomer = customers.Find(c => c.Name.ToLower() == searchName.ToLower());

        if (foundCustomer != null)
        {
            Console.WriteLine("Customers found:");
            Console.WriteLine("Name: " + foundCustomer.Name);
            Console.WriteLine($"Last month's index: {foundCustomer.LastMonth}");
            Console.WriteLine($"Index this month: {foundCustomer.ThisMonth}");
            Console.WriteLine($"Water consumption: {foundCustomer.ThisMonth - foundCustomer.LastMonth} m³");
            Console.WriteLine($"Total amount (excluding VAT): {foundCustomer.TotalBill:N0} VND");
            Console.WriteLine($"Total amount (with 10% VAT): {foundCustomer.TotalBill * 1.1:N0} VND\n");
        }
        else
        {
            Console.WriteLine("No customers found.");
        }
        Console.ReadKey();
    }


    private static double CalculateWaterBill(string customerType, int consumption, int numberOfPeople)
    {
        double bill = 0.0;
        double rate = 0.0;
        switch (customerType)
        {
            case "1":
                double consumptionPerPerson = (double)consumption / (double)numberOfPeople;
                if (consumptionPerPerson <= 10)
                {
                    rate = 5973;
                }
                else if (consumptionPerPerson <= 20)
                {
                    rate = 7052;
                }
                else if (consumptionPerPerson <= 30)
                {
                    rate = 8699;
                }
                else
                {
                    rate = 15929;
                }
                bill = (rate * consumption)*1.1;
                break;
            case "2":
                rate = 9955.0;
                bill = (rate * (double)consumption) * 1.1;
                break;
            case "3":
                rate = 11615.0;
                bill = (rate * (double)consumption) * 1.1;
                break;
            case "4":
                rate = 22068.0;
                bill = (rate * (double)consumption) * 1.1;
                break;
            default:
                Console.WriteLine("Invalid customer type.");
                break;
        }
        return bill;
    }
}
