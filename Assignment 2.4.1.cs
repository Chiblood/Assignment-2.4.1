/* Assignment 2.4.1
1. Write a program in C# Sharp to find the sum of all array elements.
    Test Data :
    Input the number of elements to be stored in the array :3
    Input 3 elements in the array :
    element - 0 : 2
    element - 1 : 5
    element - 2 : 8
    Expected Output :
    Sum of all elements stored in the array is : 15
*/

namespace Assignment_2._4._1
{
    class Program
    {
        /// <summary> Prompts the user for input and ensures a non-empty string is returned. This is the non-generic overload.</summary>
        /// <param name="prompt">The message to display to the user.</param>
        /// <returns>A non-null, non-whitespace string from the user.</returns>
        private static string GetUserInput(string prompt)
        {
            string? input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty. Please try again.");
                }
            } while (string.IsNullOrWhiteSpace(input));
            return input;
        }

        /// <summary>
        /// Prompts the user for input, validates it, and converts it to the specified type `T`.
        /// See https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics for more details.
        /// </summary>
        /// <typeparam name="T">The desired type (e.g., int, decimal, double), which must be parsable.</typeparam>
        /// <param name="prompt">The message to display to the user.</param>
        /// <param name="parseErrorMessage">An optional custom error message to display on parsing failure.</param>
        /// <returns>A valid value of type `T` from the user.</returns>
        private static T GetUserInput<T>(string prompt, string? parseErrorMessage = null) where T : IParsable<T>
        {
            T? value;
            while (!T.TryParse(GetUserInput(prompt), null, out value)) // Calls GetUserInput() to get the raw user input first.
            {
                Console.WriteLine(parseErrorMessage ?? $"Invalid input. Please enter a valid {typeof(T).Name}.");
            }
            return value;
        }
        static void Main(string[] args)
        {
            int numElements = GetUserInput<int>("Input the number of elements to be stored in the array: ", "Invalid input. Please enter a whole number.");
            int[] elements = new int[numElements];

            Console.WriteLine($"Input {numElements} elements in the array:");
            for (int i = 0; i < numElements; i++)
            {
                elements[i] = GetUserInput<int>($"element - {i} : ", "Invalid input. Please enter a whole number.");
            }

            int sum = 0;
            foreach (int element in elements)
            {
                sum += element;
            }

            Console.WriteLine($"Sum of all elements stored in the array is : {sum}");
        }
    }
}