using System;

namespace Bootcamp_Fundamental_Week_Projects
{
    abstract class ElectricBill
    {
        public float calculateBill(int units)
        {
            float amount;
            if (units <= 100)
                amount = units * units100OrLess();
            else if (units <= 200)
                amount = units * units200OrLess();
            else if (units <= 500)
                amount = units * units500OrLess();
            else
                amount = units * unitsMoreThan500();
            return amount += calculateTax(amount);
        }
        protected abstract int units100OrLess();
        protected abstract int units200OrLess();
        protected abstract int units500OrLess();
        protected abstract int unitsMoreThan500();
        protected abstract float calculateTax(float amount);
    }

    class ResidentialBill : ElectricBill
    {

        protected override int units100OrLess()
        {
            return 5;
        }
        protected override int units200OrLess()
        {
            return 17;
        }
        protected override int units500OrLess()
        {
            return 23;
        }
        protected override int unitsMoreThan500()
        {
            return 69;
        }
        protected override float calculateTax(float amount)
        {
            return amount * (float)13 / 100;
        }
    }

    class CommercialBill : ElectricBill
    {
        protected override int units100OrLess()
        {
            return 8;
        }
        protected override int units200OrLess()
        {
            return 21;
        }
        protected override int units500OrLess()
        {
            return 23;
        }
        protected override int unitsMoreThan500()
        {
            return 79;
        }
        protected override float calculateTax(float amount)
        {
            return amount * (float)17 / 100;
        }
    }
    class Programs
    {
        static void Main()
        {
            char input;
            bool exitProgram = false;
            Console.WriteLine("LESCO bill calculator.");

            //Made a simple UI on the CLI to make the program more presentable and loop according to will
            while (!exitProgram)
            {
                Console.WriteLine(Environment.NewLine + "Enter r or c for residential or commercial bill calculation respectively.");
                Console.Write("Input : ");
                input = Console.ReadKey().KeyChar;

                switch (input)
                {
                    case 'r':
                    case 'R':
                        Console.Write(Environment.NewLine + "Enter the amount of units consumed : ");
                        ElectricBill residentialBill = new ResidentialBill();
                        //Directly passing the units to the calculateBill function without storing in a variable
                        Console.WriteLine(Environment.NewLine + "Bill : Rs. " + residentialBill.calculateBill(Convert.ToInt32(Console.ReadLine())));
                        break;

                    case 'c':
                    case 'C':
                        Console.Write(Environment.NewLine + "Enter the amount of units consumed : ");
                        ElectricBill commercialBill = new CommercialBill();
                        //Directly passing the units to the calculateBill function without storing in a variable
                        Console.WriteLine(Environment.NewLine + "Bill : Rs. " + commercialBill.calculateBill(Convert.ToInt32(Console.ReadLine())));
                        break;

                    default:
                        Console.WriteLine(Environment.NewLine + Environment.NewLine + "Wrong Input!");
                        break;
                }

                Console.Write(Environment.NewLine + "Do you want to calculate another bill? [y/n] : ");
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();

                while (input != 'y' && input != 'Y' && input != 'n' && input != 'N')
                {
                    Console.WriteLine(Environment.NewLine + Environment.NewLine + "Wrong input!");
                    Console.Write(Environment.NewLine + "Do you want to calculate another bill? [y/n] : ");
                    input = Console.ReadKey().KeyChar;
                }
                if (input == 'n' || input == 'N')
                {
                    exitProgram = true;
                }
            }
        }

    }
}