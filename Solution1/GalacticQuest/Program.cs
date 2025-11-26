namespace GalacticQuest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isGameRunning = true;

            while (isGameRunning)
            {
                string input = Console.ReadLine();
                int.TryParse(input, out int inputValue);
                switch (inputValue)
                {
                    case (int)Menu.Monsters:
                        Console.WriteLine("You selected Monsters.");
                        break;
                    case (int)Menu.Exit:
                        Console.WriteLine("You choosed exit");
                        isGameRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }
}
