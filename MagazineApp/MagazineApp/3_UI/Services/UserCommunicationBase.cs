
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
        
        protected T GetValueFromUser<T>(string comment) where T : struct
        {
            while (true)
            {
                var input = GetInputFromUser(comment);
                try
                {
                    if (typeof(T) == typeof(int))
                    {
                        return (T)(object)int.Parse(input);
                    }
                    else if (typeof(T) == typeof(double))
                    {
                        return (T)(object)double.Parse(input);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Inavlid value, please try again.");
                }
            }
        }
    }
}
