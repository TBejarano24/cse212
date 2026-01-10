public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        var multiples = new double[length]; // First, I create an array with the same capacity as the length specified by the user, which will store all the multiples

        for (int i = 1; i <= length; i++) // Then we loop through each of the numbers from 1 up to the length specified
        {
            multiples[i - 1] = number * i; // And from each of those numbers we get the multiples of the specific number up to the specified length, and all the results are stored in the previously created array
        }

        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // First, I can grab the numbers from the specified index all the way to the end by subtracting the amount to the length of the data, and use the GetRange method to create a new array with the last values of the original array.
        // With this new array, I can now append to it the starting values of the original array using the AddRange method

        int startIndex = data.Count - amount;
        List<int> lastValues = data.GetRange(startIndex, amount);

        data.RemoveRange(startIndex, amount);
        data.InsertRange(0, lastValues);
    }
}
