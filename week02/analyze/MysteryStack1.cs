public static class MysteryStack1
{
    public static string Run(string text) 
    {
        var stack = new Stack<char>();
        foreach (var letter in text)
            stack.Push(letter);

        var result = "";
        while (stack.Count > 0)
            result += stack.Pop();

        return result;
    }
}

/*
Determine the output of the function if the input text is equal to the following:

    racecar
    stressed
    a nut for a jar of tuna
*/