/// <summary>
/// This queue is circular.  When people are added via AddPerson, then they are added to the 
/// back of the queue (per FIFO rules).  When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue.  Thus,
/// each person stays in the queue and is given turns.  When a person is added to the queue, 
/// a turns parameter is provided to identify how many turns they will be given.  If the turns is 0 or
/// less than they will stay in the queue forever.  If a person is out of turns then they will 
/// not be added back into the queue.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Add new people to the queue with a name and number of turns
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="turns">Number of turns remaining</param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue and return them. The person should
    /// go to the back of the queue again unless the turns variable shows that they 
    /// have no more turns left.  Note that a turns value of 0 or less means the 
    /// person has an infinite number of turns.  An error exception is thrown 
    /// if the queue is empty.
    /// </summary>
    /// 

    // DEBUG:
    private int vuelta = -1;
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }
        else
        {
            // Check if "person" still has turns avaible
            Person peek_person = _people.Peek();

            if (peek_person.Turns > 0 || peek_person.Turns < 0)
            {
                Person person = _people.Dequeue();

                // Players with finite turns left
                if (person.Turns > 0)
                {

                    _people.Enqueue(person);
                    vuelta += 1;
                    // DEBUG:
                    Console.WriteLine($"[{vuelta}]{person}");
                    person.Turns -= 1;
                    return person;
                }

                // Players with infinite("Forever)" turns left
                else if (person.Turns < 0)
                {

                    _people.Enqueue(person);
                    vuelta += 1;
                    // DEBUG:
                    Console.WriteLine($"[{vuelta}]{person}");
                    return person;
                }

                // Players with no turns left
                else if (person.Turns == 0)
                {
                    // DEBUG:
                    vuelta += 1;
                    Console.WriteLine($"{person} tiene 0 turns VERSION ADENTRO");
                    return person;
                }

            }

            else if (peek_person.Turns == 0)
            {
                // DEBUG:
                Console.WriteLine($"[{vuelta}]{peek_person} se quedo sin turnos - CHAU");

                _people.Dequeue();
                Person person = _people.Dequeue();
                while (person.Turns > 0 || peek_person.Turns < 0)
                {
                    _people.Enqueue(person);
                    // DEBUG:
                    vuelta += 1;
                    Console.WriteLine($"[{vuelta}]{person}");

                    // creo que el problema esta en que esto quita turnos pero no quita a el que tiene 0 
                    //  entonces la fila se extiende uno mas al final por que no hay otra vuelta que pueda
                    //  quitar ese item con un cero. la final se extiende uno mas.
                    person.Turns -= 1;
                    return person;
                    ;
                }


            }

            // DEBUG:
            vuelta += 1;
            return peek_person;

        }


    }

    public override string ToString()
    {
        return _people.ToString();
    }
}