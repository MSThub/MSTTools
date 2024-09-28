using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public static class MSTTools
{
    public static string colorG = "\u001b[38;2;2;219;111m";
    public static string colorR = "\u001b[38;2;219;0;0m";
    public static string ResetColor = "\u001b[0m";

    public static void ConfirmExit()
    {
        while (true)
        {
            Console.WriteLine($"{colorR}Are you sure you want to exit? {ResetColor}(yes/no)");
            string confirmation = Console.ReadLine().ToLower().Trim();
            if (confirmation == "yes") Environment.Exit(0);
            else if (confirmation == "no")
            {
                Console.WriteLine($"\n{colorG}Alright then {ResetColor}\n");
                break;
            }
            else PrintErrorMessage("Invalid Confirmation input!");
        }
    }

    public static void MenuItem(string num, string task)
    {
        Console.WriteLine($"{colorG}+[{num}]{ResetColor} {task}");
    }

    public static void PrintErrorMessage(string text)
    {
        Console.WriteLine($"\n{colorR}{text}{ResetColor}\n");
    }

    public static void PrintResult(string text, string result)
    {
        Console.WriteLine($"{colorG}+ {ResetColor}{text} {colorG}--> {ResetColor}{result}");
    }
    public static string GetInput(string text)
    {
        string input;
        do
        {
            Console.Write($"{colorG}+ {ResetColor}{text} {colorG}==> {ResetColor}");
            input = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(input)) Console.WriteLine($"{colorR}Invalid input. Please enter a non-empty input.{ResetColor}");
            else if (input.Equals("Exit()", StringComparison.OrdinalIgnoreCase)) ConfirmExitInput(ref input);
        } while (string.IsNullOrWhiteSpace(input));
        return input;
    }

    public static void ConfirmExitInput(ref string input)
    {
        Console.WriteLine($"{colorR}Are you sure you want to exit? {ResetColor}(yes/no)");
        while (true)
        {
            string confirmation = Console.ReadLine().ToLower().Trim();
            if (confirmation == "no")
            {
                Console.WriteLine($"\n{colorG}Alright then {ResetColor}\n");
                input = null;
                break;
            }
            else if (confirmation == "yes") Environment.Exit(0);
            else PrintErrorMessage("Enter a Valid Confirmation (yes/no)");
        }
    }
    public static int GetIntInput(string prompt)
    {
        while (true)
        {
            string input = GetInput(prompt);
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            else PrintErrorMessage("Invalid input! Please enter a valid integer.");
        }
    }
    public static decimal GetDecimalInput(string prompt)
    {
        while (true)
        {
            string input = GetInput(prompt);
            if (decimal.TryParse(input, out decimal result))
            {
                return result;
            }
            else PrintErrorMessage("Invalid input! Please enter a valid decimal number.");
        }
    }
    public static void PrintSuccessMessage(string message)
    {
        Console.WriteLine($"{colorG}{message}{ResetColor}");
    }

}
