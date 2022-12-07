namespace Common;

public static class Validator
{
    public static bool ContinueOrExit()
    {
        Console.WriteLine("Continue? [ Y / N ]");
        var answer = Console.ReadLine();
        if (answer != "y") return false;
        Console.Clear();
        return true;
    }
    public static int ParseInt()
    {
        while (true)
        {
            var isValid = int.TryParse(Console.ReadLine(), out int textInInt);
            if (isValid)
            {
                return textInInt;
            }

            Console.WriteLine("Wrong Input! Try again");
        }
    }
}