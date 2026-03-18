using System;
using static Person;
using static TakingTurnsQueue;
using static PriorityQueue;
using static PersonQueue;


public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- DEBUGGING ---");
        // Console.WriteLine("-TestTakingTurnsQueue_FiniteRepetition-");
        // TestTakingTurnsQueue_FiniteRepetition();
        Console.WriteLine("-TestTakingTurnsQueue_ForeverNegative-");
        TestTakingTurnsQueue_ForeverNegative();
    }

    public static void TestTakingTurnsQueue_FiniteRepetition()
    {
        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", 5);
        var sue = new Person("Sue", 3);

        // Person[] expectedResult = [bob, tim, sue, bob, tim, sue, tim, sue, tim, tim];

        var players = new TakingTurnsQueue();
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        // int i = 0;
        while (players.Length > 0)
        {
            // if (i >= expectedResult.Length)
            // {
            //     Assert.Fail("Queue should have ran out of items by now.");
            // }

            var person = players.GetNextPerson();
            // Assert.AreEqual(expectedResult[i].Name, person.Name);
            // i++;
        }
    }

    public static void TestTakingTurnsQueue_ForeverNegative()
    {
        var timTurns = -3;
        var tim = new Person("Tim", timTurns);
        var sue = new Person("Sue", 3);

        Person[] expectedResult = [tim, sue, tim, sue, tim, sue, tim, tim, tim, tim];

        var players2 = new TakingTurnsQueue();
        players2.AddPerson(tim.Name, tim.Turns);
        players2.AddPerson(sue.Name, sue.Turns);

        for (int i = 0; i < 10; i++)
        {
            var person = players2.GetNextPerson();
            // Assert.AreEqual(expectedResult[i].Name, person.Name);
        }
    }
}