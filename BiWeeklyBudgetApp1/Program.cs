using System.Threading.Channels;

namespace BiWeeklyBudgetApp1
{
    class Program
    {
        static void HelpMenu()
        {
            Console.WriteLine("Instructions: \n");
            Console.WriteLine("To run your program, first type your desired function\n");
            Console.WriteLine("Your desired function options:");
            Console.WriteLine("\tdeposit - track incoming funds");
            Console.WriteLine("\twithdraw - track outgoing funds");
            Console.WriteLine("\tsave - track savings\n");
            Console.WriteLine("\tset - set current amount\n");
            Console.WriteLine("Once you have selected your function, you will be asked to provide your desired amount");
            Console.WriteLine("NOTE: this should be a non-negative number");
        }

        static void ErrorMessage()
        {
            Console.WriteLine("The program ran into an issue, pass in 'help' to read instructions");
        }

        static void Main(string[] args)
        {
            string function = "";
            //float funds;
            float currentAmount = 0;
            float savings = 0;
            int i = 0;

            Console.WriteLine("WELCOME TO YOUR BUDGET APP\n");
            Console.WriteLine("Pass in 'QUIT' to exit or 'HELP' for instructions");
            //HelpMenu();

            Console.WriteLine("How can I help you today?");

            while (function.ToLower() != "quit")
            {
                if (i > 0)
                {
                    Console.WriteLine("Anything else I can help you with?");
                }
                
                function = Console.ReadLine();

                if (function == "quit")
                {
                    return;
                }

                switch (function.ToLower())
                {
                    case "help":
                        HelpMenu();
                        break;
                    case "set":
                        Console.WriteLine("Set your desired current amount: ");
                        float temp = float.Parse(Console.ReadLine());
                        if (temp < 0) 
                        { 
                            Console.WriteLine("Please provide a non-negative integer");
                            break;
                        }
                        currentAmount = temp;
                        Console.WriteLine($"Your current amount is set to: {currentAmount}");
                        break;
                    case "deposit":
                        Console.WriteLine("How much would you like to deposit?");
                        temp = float.Parse(Console.ReadLine());
                        if (temp < 0)
                        {
                            Console.WriteLine("Please provide a non-negative integer");
                            break;
                        }
                        currentAmount += temp;
                        Console.WriteLine($"You have deposited {temp} and your total is {currentAmount}");
                        break;
                    case "withdraw":
                        Console.WriteLine("How much would you like to withdraw?");
                        temp = float.Parse(Console.ReadLine());
                        if (temp < 0)
                        {
                            Console.WriteLine("Please provide a non-negative integer");
                            break;
                        }
                        if (temp > currentAmount)
                        {
                            Console.WriteLine($"Not enough funds, your current amount is {currentAmount}");
                            break;
                        }
                        currentAmount -= temp;
                        Console.WriteLine($"You have withdrawn {temp} and your current amount is {currentAmount}");                       
                        break;
                    case "save":
                        Console.WriteLine("How much would you like to save?");
                        temp = float.Parse(Console.ReadLine());
                        if (temp < 0)
                        {
                            Console.WriteLine("Please provide a non-negative integer");
                            break;
                        }
                        if (temp > currentAmount)
                        {
                            Console.WriteLine($"Not enough funds, your current amount is {currentAmount}");
                            break;
                        }
                        currentAmount -= temp;
                        savings += temp;
                        Console.WriteLine($"You have saved {temp} and your current savings are {savings}");
                        Console.WriteLine($"Your remaining total is {currentAmount}");
                        break;
                    default:
                        Console.WriteLine("Invalid function, type 'HELP' to review instructions");
                        break;
                }

                i++;

            }



        }
    }
}