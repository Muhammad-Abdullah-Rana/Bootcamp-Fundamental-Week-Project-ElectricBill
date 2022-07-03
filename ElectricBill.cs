using System;

namespace Bootcamp_Fundamental_Week_Projects
{
    abstract class ElectricBill
    {
        public float calculateBill(int units)
        {
            float amount;
            if (units <= 100)
                amount = units * lessThan100Units();
            else if (units <= 200)
                amount = units * lessThan200Units();
            else if (units <= 500)
                amount = units * lessThan500Units();
            else
                amount = units * moreThan500Units();
            return amount += (amount * calculateTax());
        }
        protected abstract int lessThan100Units();
        protected abstract int lessThan200Units();
        protected abstract int lessThan500Units();
        protected abstract int moreThan500Units();
        protected abstract float calculateTax();
    }

    class ResidentialBill : ElectricBill
    {

        protected override int lessThan100Units()
        {
            return 5;
        }
        protected override int lessThan200Units()
        {
            return 17;
        }
        protected override int lessThan500Units()
        {
            return 23;
        }
        protected override int moreThan500Units()
        {
            return 69;
        }
        protected override float calculateTax()
        {
            return (float)13 / 100;
        }
    }

    class CommercialBill : ElectricBill
    {
        protected override int lessThan100Units()
        {
            return 8;
        }
        protected override int lessThan200Units()
        {
            return 21;
        }
        protected override int lessThan500Units()
        {
            return 23;
        }
        protected override int moreThan500Units()
        {
            return 79;
        }
        protected override float calculateTax()
        {
            return (float)17 / 100;
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