using System;
using static Person;
using static TakingTurnsQueue;
using static PriorityQueue;
using static PersonQueue;
using System.Security.Cryptography.X509Certificates;


public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- DEBUGGING ---");

        var setA = new HashSet<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var setB = new HashSet<int> { 7, 8, 9, 10 };
        var setC = new HashSet<int> { };
        var setD = new HashSet<int> { 11, 12, 13, 14 };


        Console.WriteLine("");
        Console.WriteLine("CUSTOM INTERSECT:");
        Console.WriteLine("");
        IEnumerable<int> amongus = CustomIntersect(setA, setB);
        DisplayResults(amongus);
        IEnumerable<int> amongus2 = CustomIntersect(setA, setC);
        DisplayResults(amongus2);
        IEnumerable<int> amongus3 = CustomIntersect(setB, setD);
        DisplayResults(amongus3);
        Console.WriteLine("");
        Console.WriteLine("CUSTOM UNION:");
        Console.WriteLine("");
        // Adds new ints
        CustomUnion(setA, setD);
        DisplayResults(setA);
        // doesnt add duplicates
        CustomUnion(setA, setB);
        DisplayResults(setA);
        // handles null correctly
        CustomUnion(setA, setC);
        DisplayResults(setA);

    }

    // var intersection = CustomIntersect(setA, setB);
    public static IEnumerable<int> CustomIntersect(HashSet<int> setA, HashSet<int> setB)
    {
        foreach (var n in setB)
        {
            if (setA.Contains(n))
            {
                yield return n;
            }
        }
    }

    public static void CustomUnion(HashSet<int> setA, HashSet<int> setB)
    {
        foreach (var n in setB)
        {
            if (!setA.Contains(n))
            {
                setA.Add(n);
            }
        }
    }

    public static void DisplayResults(IEnumerable<int> amongus)
    {
        Console.WriteLine("RESULTADOS:");
        foreach (var a in amongus)
        {
            Console.WriteLine(a);
        }
    }

}
