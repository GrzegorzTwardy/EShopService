namespace Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            string n = Console.ReadLine();

            while (true)
            {
                try
                {
                    int result = 0;


                }
                catch (FormatException)
                {
                    Console.Write("There's been a mistake. Enter a number correctly: ");
                    n = Console.ReadLine();
                }
                catch (OverflowException)
                {
                    Console.Write("There's been a mistake. Enter a number correctly: ");
                    n = Console.ReadLine();
                }
            }

            
        }
    }
}
