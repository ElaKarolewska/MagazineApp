
namespace MagazineApp._3_UI.Services
{
    public abstract class UserCommunicationBase
    {
        protected string GetInputFromUser(string comment)
        {
            Console.WriteLine(comment);
            string userInput = Console.ReadLine();
            return userInput;
        }
        protected void EmptyInputWarning(ref string input, string inputName)
        {
            while (String.IsNullOrEmpty(input))
            {
                Console.WriteLine("You nedd to provide data.");
                input = GetInputFromUser($"{inputName}:");
            }
        }
        protected int GetIntValueFromUser(string comment)
        {
            while (true)
            {
                Console.WriteLine(comment);
                var input = Console.ReadLine();
                int valueInt;
                double valueDouble;

                if (int.TryParse(input, out valueInt))
                {
                   return valueInt; 
                }
                else
                {
                    Console.WriteLine("Invalid value please try again.");
                }
            }
        }
        protected static double GetDoubleValueFromUser(string comment) 
        {
            while (true) 
            {
                Console.WriteLine(comment);
                var input = Console.ReadLine();
                double valueDouble;
                if (double.TryParse(input, out valueDouble))
                {
                    return valueDouble;
                }
                else 
                {
                    Console.WriteLine("Invalid value please try again.");
                }
            }
        }
    }
}
