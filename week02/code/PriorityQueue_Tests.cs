using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a priority queue with the following items and priorities: ("ItemA", 7), ("ItemB", 3), ("ItemC", 10),
    // ("ItemD", 1), ("ItemE", 5), ("ItemF", 8), ("ItemG", 2), ("ItemH", 9), ("ItemI", 4), ("ItemJ", 6) and run until the
    // queue is empty.
    // Expected Result: [ItemC, ItemH, ItemF, ItemA, ItemJ, ItemE, ItemI, ItemB, ItemG, ItemD]
    // Defect(s) Found: 1
    /*
        NOTE: 
            Added a getter to get the length of the queue, in order to facilitate testing.
        

        1 - The Dequeue() method didn't dequeue any items
             . The problem: The highest priority item is just selected and returned, the Dequeue() method was missing code that
                            would remove the item from the queue.
             . Solution: Added a method for removing the item, which is called inside of Dequeue() when the highest priority
                         item is found.

        2 - The loop that checks for the highest priority item skips some indexes
            . The problem: The loop starts to check at index 1 (instead of index 0) and stops one index less than the length of
                            the queue, instead of running to the end.
            . Solution: "for (int index = 1; index < _queue.Count - 1; index++)"
                         =>
                        "for (int index = 0; index < _queue.Count; index++)"

    */


    public void TestPriorityQueue_1()
    {
        // create items with corresponding values & properties
        var ItemA = new PriorityItem("ItemA", 7);
        var ItemB = new PriorityItem("ItemB", 3);
        var ItemC = new PriorityItem("ItemC", 10);
        var ItemD = new PriorityItem("ItemD", 1);
        var ItemE = new PriorityItem("ItemE", 5);
        var ItemF = new PriorityItem("ItemF", 8);
        var ItemG = new PriorityItem("ItemG", 2);
        var ItemH = new PriorityItem("ItemH", 9);
        var ItemI = new PriorityItem("ItemI", 4);
        var ItemJ = new PriorityItem("ItemJ", 6);

        PriorityItem[] expectedResult = [ItemC, ItemH, ItemF, ItemA, ItemJ, ItemE, ItemI, ItemB, ItemG, ItemD];

        var priorityQueue = new PriorityQueue();

        // add items to the queue
        priorityQueue.Enqueue(ItemA.Value, ItemA.Priority);
        priorityQueue.Enqueue(ItemB.Value, ItemB.Priority);
        priorityQueue.Enqueue(ItemC.Value, ItemC.Priority);
        priorityQueue.Enqueue(ItemD.Value, ItemD.Priority);
        priorityQueue.Enqueue(ItemE.Value, ItemE.Priority);
        priorityQueue.Enqueue(ItemF.Value, ItemF.Priority);
        priorityQueue.Enqueue(ItemG.Value, ItemG.Priority);
        priorityQueue.Enqueue(ItemH.Value, ItemH.Priority);
        priorityQueue.Enqueue(ItemI.Value, ItemI.Priority);
        priorityQueue.Enqueue(ItemJ.Value, ItemJ.Priority);

        int i = 0;

        while (priorityQueue.GetLength() > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            // get the highest priority item's value from the queue
            var value = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, value);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Create a priority queue with the following items and priorities, where some items share the same priority 
    // value: ("ItemA", 10), ("ItemB", 5), ("ItemC", 10), ("ItemD", 10), ("ItemE", 4), ("ItemF", 10), ("ItemG", 3), 
    // ("ItemH", 2), ("ItemI", 9), ("ItemJ", 1). Run until the queue is empty.
    // Expected Result: [ItemA, ItemC, ItemD, ItemF, ItemI, ItemE, ItemB, ItemG, ItemH, ItemJ]
    // Defect(s) Found: 1
    /*
    
        1- When faced with multiple items sharing the same priority value, the queue assigngs the last to be checked as the
           highest priority item. (when it should instead, solve ties comparing the order in which they were added)
            . The Problem: Dequeue() is lacking instructions for ties on priority
            . The solution: Added the following snippet of code to the Dequeue() method:
                            else if (_queue[index].Priority == _queue[highPriorityIndex].Priority)
                            {
                                if (index < highPriorityIndex)
                                    highPriorityIndex = index;
                            }
                            
    */
    public void TestPriorityQueue_2()
    {
        // create items with corresponding values & properties
        var ItemA = new PriorityItem("ItemA", 10);
        var ItemB = new PriorityItem("ItemB", 5);
        var ItemC = new PriorityItem("ItemC", 10);
        var ItemD = new PriorityItem("ItemD", 10);
        var ItemE = new PriorityItem("ItemE", 9);
        var ItemF = new PriorityItem("ItemF", 10);
        var ItemG = new PriorityItem("ItemG", 3);
        var ItemH = new PriorityItem("ItemH", 2);
        var ItemI = new PriorityItem("ItemI", 9);
        var ItemJ = new PriorityItem("ItemJ", 1);

        PriorityItem[] expectedResult = [ItemA, ItemC, ItemD, ItemF, ItemE, ItemI, ItemB, ItemG, ItemH, ItemJ];

        var priorityQueue = new PriorityQueue();

        // add items to the queue
        priorityQueue.Enqueue(ItemA.Value, ItemA.Priority);
        priorityQueue.Enqueue(ItemB.Value, ItemB.Priority);
        priorityQueue.Enqueue(ItemC.Value, ItemC.Priority);
        priorityQueue.Enqueue(ItemD.Value, ItemD.Priority);
        priorityQueue.Enqueue(ItemE.Value, ItemE.Priority);
        priorityQueue.Enqueue(ItemF.Value, ItemF.Priority);
        priorityQueue.Enqueue(ItemG.Value, ItemG.Priority);
        priorityQueue.Enqueue(ItemH.Value, ItemH.Priority);
        priorityQueue.Enqueue(ItemI.Value, ItemI.Priority);
        priorityQueue.Enqueue(ItemJ.Value, ItemJ.Priority);

        int i = 0;

        while (priorityQueue.GetLength() > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            // get the highest priority item's value from the queue
            var value = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, value);
            i++;
        }
    }

    // Add more test cases as needed below.
}