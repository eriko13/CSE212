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

        // Step 1: Create array of specified length
        double[] multiples = new double[length];
        
        // Step 2: Loop through each position and calculate the multiple
        for (int i = 0; i < length; i++)
        {
            // Step 3: Calculate multiple by multiplying number by (position + 1)
            multiples[i] = number * (i + 1);
        }
        
        // Step 4: Return the completed array
        return multiples;
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

        // Step 1: Get the last 'amount' elements that will move to the front
        List<int> elementsToMoveToFront = data.GetRange(data.Count - amount, amount);
        
        // Step 2: Get the remaining elements that will move to the back
        List<int> elementsToMoveToBack = data.GetRange(0, data.Count - amount);
        
        // Step 3: Clear the list and rebuild in rotated order
        data.Clear();
        data.AddRange(elementsToMoveToFront);  // Add the last elements first
        data.AddRange(elementsToMoveToBack);   // Add the remaining elements second
    }
}
