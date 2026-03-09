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
        // Thing to do in Problem 1 
        // Plan:
        // 1. We are given a starting number and a length (number of multiples to generate).
        // 2. Create a new array of doubles with size equal to length.
        // 3. Iterate from 0 up to length-1 (index variable i).
        //    a. For each position compute the multiple: (i + 1) * number.
        //    b. Store the computed value in the array at index i.
        // 4. After the loop completes, return the filled array.
        // 5. Assumption: length > 0 so the array will have at least one element.

        // implementation follows the above plan:
        var result = new double[length];
        for (int i = 0; i < length; i++)
        {
            // compute the i-th multiple (1-based multiple count)
            result[i] = (i + 1) * number;
        }

        return result;
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
        // Things to do in Problem 2 - RotateListRight:

        // 1. The function needs to rotate the list 'data' to the right by 'amount' positions in place.
        // 2. Rotating right means the last 'amount' elements move to the front of the list.
        // 3. For example, with {1,2,3,4,5,6,7,8,9} and amount=3, the last 3 {7,8,9} go to front, followed by {1,2,3,4,5,6}.
        // 4. To implement:
        //    a. Create a temporary list to hold the rotated elements.
        //    b. Add the last 'amount' elements (from index data.Count - amount to data.Count - 1) to the temp list.
        //    c. Add the first (data.Count - amount) elements (from index 0 to data.Count - amount - 1) to the temp list.
        //    d. Clear the original data list.
        //    e. Add all elements from the temp list back to data.
        // 5. This modifies data in place as required.
        // 6. Assumptions: amount is between 1 and data.Count, so no edge cases like amount=0 or amount > Count.

        // Implementation based on the plan:
        var temp = new List<int>();
        // Add the last 'amount' elements
        for (int i = data.Count - amount; i < data.Count; i++)
        {
            temp.Add(data[i]);
        }
        // Add the first (data.Count - amount) elements
        for (int i = 0; i < data.Count - amount; i++)
        {
            temp.Add(data[i]);
        }
        // Clear the original list
        data.Clear();
        // Add all from temp back to data
        data.AddRange(temp);
    }
}
