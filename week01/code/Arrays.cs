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

        // Problem Solving - Yain Huento

        /*
        
        1 - I read the requirements and took note focusing on the main idea.

        2- If the program is to produce an array of an specific length, we would need some way for us to
           tell the function how long we want the array to be. The parameter "int length"
           would work fine. 

        3- Then, if it's required to specify which number we want the multiples of, we would also need to
           add another parameter for that. We are going to be using "double number". Specifying a type "double"
           instead of a type "int" enables more precision when requesting for certain multiples of a number.

        4- We need to define the array to store the multiples of our numbers. We do so with 
           "double[] multiples = new double[length];". We give the array the capacity of "lenght" to avoid 
           overflows or having to resize the array too often.

        5- With "for (int i = 0; i < length; i++)" we define a "for" loop that is going to run "length" times.

        6- To get multiples of a number we just have to multiple our number by consecutive numbers, for example,
            if we want to get the multiples of 7, we would first multiply it times 1, then times 2, times 3, etc.
            and the results of those multiplications are the multiples we are looking for.
        
        7- We need our program to multiply our "number" times "length" and store that result in our "multiples" array. 
            We can store each multiple in our array by replacing by index. In code that would look like "multiples[i] = number * (i + 1);"

        8- After the loop finishes running times "length", the resulting array is returned.

        */

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
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

        // Problem Solving - Yain Huento

        /*

        1- Our program must rotate our items to the right. We could essentialy achieve this by getting the last "amount"
        items in our list, storing them, and adding them to the index 0 of the list.

        2- The first thing we should do is define where to store our "rotated" items. "List<int> rotated = new List<int>();"
           should do.
        
        2- As stated before, we are going to use list slicing in order to rotate our items. With "data.GetRange" we can
           get items starting from a index of our chosing. If, for example, "amount" was 3 and "data.Count" was 9, with 
           "data.GetRange(data.Count - amount, amount);" our starting index would be 6 (9-3=6) and we could get "amount" 
           items.
        
        3- We store our "rotated" items in List<int> rotated with "rotated = data.GetRange(data.Count - amount, amount);"

        4- Now that we have our "rotated" items and we stored them in a temporary list, we should remove them from "data". 
           we do so with "data.RemoveRange(data.Count - amount, amount);"

        5- Finally, we insert the "rotated" to the begginng of the list with "data.InsertRange(0, rotated);"
    
        */

        List<int> rotated = new List<int>();
        rotated = data.GetRange(data.Count - amount, amount);
        data.RemoveRange(data.Count - amount, amount);
        data.InsertRange(0, rotated);
    }
}
