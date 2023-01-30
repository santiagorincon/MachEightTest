// Uncomment this part to test the code manually
//int[] test = { 1, 9, 5, 0, 20, -4, 12, 16, 7 };
//getSumPairs(test, 12);

// Testing code reading inputs from text file
#region Testing From File
// File URL, please make sure to change this path to your file   
string textFile = @"C:\MachEightTest\input.txt";

if (File.Exists(textFile))
{
    // Read the file and validate content
    string[] lines = File.ReadAllLines(textFile);
    if(lines.Length == 0)
    {
        Console.WriteLine("File is empty");
    }

    foreach (string line in lines)
    {
        string[] inputLine = line.Split(" ");
        // Each line must be only 2 data separed by space (' ')
        if(inputLine.Length == 2)
        {
            // In the first position is the int array
            int[] intArray = inputLine[0].Split(",")
                .Select(n => int.TryParse(n, out int parsedNumber) ? parsedNumber : int.MinValue)
                .Where(n => n != int.MinValue)
                .ToArray();

            // In the second position is the desired result
            bool isValidResult = int.TryParse(inputLine[1], out int desiredResult);

            if(intArray.Length > 0 && isValidResult)
            {
                // Show the result if the input text is valid
                Console.WriteLine($"Result for value '{line}':");
                getSumPairs(intArray, desiredResult);
            }
        }
        else
        {
            // Show an error if the input text is invalid
            Console.WriteLine($"'{line}' is not a valid value");
        }
    }
}
else
{
    // Show an error if the file not exist
    Console.WriteLine("File not found");
}
#endregion
void getSumPairs(int[] numbers, int desiredResult)
{
    // Get the sorted array to be sure that I'm adding the lower with the higher at first
    List<int> sortedList = numbers.ToList();
    sortedList.Sort();
    int[] sortedArray = sortedList.ToArray();

    // Get the initial indexes
    int firstIndex = 0;
    int secondIndex = sortedArray.Length - 1;

    // Save the results if they're needed after
    List<string> result = new List<string>();

    // Loop into the array until the 2 indexes are the same
    while (firstIndex < secondIndex)
    {
        // Validate the desired result and print/save the numbers
        if (sortedArray[firstIndex] + sortedArray[secondIndex] == desiredResult)
        {
            Console.WriteLine($"{sortedArray[firstIndex]},{sortedArray[secondIndex]}");
            result.Add($"{sortedArray[firstIndex]},{sortedArray[secondIndex]}");
        }

        if (sortedArray[firstIndex] + sortedArray[secondIndex] < desiredResult)
        {
            // Increment first index if the total is less than the desired sum
            firstIndex++;
        }
        else
        {
            // Decrement second index if the total is more than the desired sum
            secondIndex--;
        }
    }
}