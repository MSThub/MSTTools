namespace MST.Tools.ConsoleHelpers;

using System;

public static class ConsoleHelper
{
    private const string ColorGreen = "\u001b[38;2;2;219;111m";
    private const string ColorRed = "\u001b[38;2;219;0;0m";
    private const string ResetColor = "\u001b[0m";

    public static void ConfirmExit()
    {
        while (true)
        {
            PrintColored(ColorRed, "Are you sure you want to exit? (yes/no)");
            var confirmation = Console.ReadLine()?.Trim().ToLower();

            switch (confirmation)
            {
                case "yes":
                    Environment.Exit(0);
                    break;
                case "no":
                    PrintSuccessMessage("Alright then");
                    return;
                default:
                    PrintErrorMessage("Invalid confirmation input!");
                    break;
            }
        }
    }

    public static void MenuItem(string number, string task)
    {
        PrintColored(ColorGreen, $"+[{number}]{ResetColor} {task}");
    }

    public static void PrintErrorMessage(string message)
    {
        PrintColored(ColorRed, message);
    }

    public static void PrintSuccessMessage(string message)
    {
        PrintColored(ColorGreen, message);
    }

    public static void PrintResult(string label, string result)
    {
        Console.WriteLine($"{ColorGreen}+ {ResetColor}{label} {ColorGreen}--> {ResetColor}{result}");
    }

    public static void ShowItem(int id, string item)
    {
        Console.WriteLine($"{ColorGreen}+ {ResetColor}{id} {ColorGreen}--> {ResetColor}{item}");
    }

    public static void WaitForUser()
    {
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }

    public static string GetInput(string prompt)
    {
        while (true)
        {
            Console.Write($"{ColorGreen}+ {ResetColor}{prompt} {ColorGreen}==> {ResetColor}");
            var input = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                PrintErrorMessage("Invalid input. Please enter a non-empty input.");
                continue;
            }

            if (input.Equals("Exit()", StringComparison.OrdinalIgnoreCase))
            {
                ConfirmExitInput(ref input);
                if (input == null) continue;
            }

            return input;
        }
    }

    public static int GetIntInput(string prompt)
    {
        while (true)
        {
            var input = GetInput(prompt);
            if (int.TryParse(input, out var result))
                return result;

            PrintErrorMessage("Invalid input! Please enter a valid integer.");
        }
    }

    public static decimal GetDecimalInput(string prompt)
    {
        while (true)
        {
            var input = GetInput(prompt);
            if (decimal.TryParse(input, out var result))
                return result;

            PrintErrorMessage("Invalid input! Please enter a valid decimal number.");
        }
    }

    private static void ConfirmExitInput(ref string input)
    {
        PrintColored(ColorRed, "Are you sure you want to exit? (yes/no)");

        while (true)
        {
            var confirmation = Console.ReadLine()?.Trim().ToLower();

            switch (confirmation)
            {
                case "yes":
                    Environment.Exit(0);
                    break;
                case "no":
                    PrintSuccessMessage("Alright then");
                    input = null;
                    return;
                default:
                    PrintErrorMessage("Enter a valid confirmation (yes/no)");
                    break;
            }
        }
    }

    private static void PrintColored(string color, string message)
    {
        Console.WriteLine($"{color}{message}{ResetColor}");
    }
}
