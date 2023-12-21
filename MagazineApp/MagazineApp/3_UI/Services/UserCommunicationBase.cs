
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
        protected void EmptyInputWarning(ref string? input, string inputName)
        {
            while (String.IsNullOrEmpty(input))
            {
                Console.WriteLine("You nedd to provide data.");
                input = GetInputFromUser($"{inputName}:");
            }
        }

    }
}
