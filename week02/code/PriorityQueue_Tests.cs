using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add 6 people to a priority queue, all of them with unordered priorities. Get an ordered output
    // Expected Result: 
    // Bob
    // Adrian
    // Steve
    // Kim
    // Daisy
    // Ado
    // Defect(s) Found: The Dequeue method is not picking the user with highest priority that's closest to the front, it's picking the one closest to the back. The Dequeue method is returning values that should have been taken off the queue. The Dequeue method is picking values with wrong priorities.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        var kim = new PriorityItem("Kim", 3);
        var bob = new PriorityItem("Bob", 5);
        var steve = new PriorityItem("Steve", 4);
        var daisy = new PriorityItem("Daisy", 2);
        var adrian = new PriorityItem("Adrian", 5);
        var ado = new PriorityItem("Ado", 1);

        priorityQueue.Enqueue("Kim", 3);
        priorityQueue.Enqueue("Bob", 5);
        priorityQueue.Enqueue("Steve", 4);
        priorityQueue.Enqueue("Daisy", 2);
        priorityQueue.Enqueue("Adrian", 5);
        priorityQueue.Enqueue("Ado", 1);

        PriorityItem[] expectedResult = [bob, adrian, steve, kim, daisy, ado];

        for (int i = 0; i < 6; i++)
        {
            var person = priorityQueue.Dequeue();
            Console.WriteLine(person);
            Assert.AreEqual(expectedResult[i].Value, person);
        }
    }

    [TestMethod]
    // Scenario: Add 6 people with ascending order of priority to see if they will come out in the appropiate order.
    // Expected Result:
    // Adrian
    // Ado
    // Daisy
    // Steve
    // Bob
    // Kim
    // Defect(s) Found: No defects found.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        var kim = new PriorityItem("Kim", 1);
        var bob = new PriorityItem("Bob", 2);
        var steve = new PriorityItem("Steve", 3);
        var daisy = new PriorityItem("Daisy", 4);
        var adrian = new PriorityItem("Adrian", 5);
        var ado = new PriorityItem("Ado", 5);

        priorityQueue.Enqueue("Kim", 1);
        priorityQueue.Enqueue("Bob", 2);
        priorityQueue.Enqueue("Steve", 3);
        priorityQueue.Enqueue("Daisy", 4);
        priorityQueue.Enqueue("Adrian", 5);
        priorityQueue.Enqueue("Ado", 5);

        PriorityItem[] expectedResult = [adrian, ado, daisy, steve, bob, kim];

        for (int i = 0; i < 6; i++)
        {
            var person = priorityQueue.Dequeue();
            Console.WriteLine(person);
            Assert.AreEqual(expectedResult[i].Value, person);
        }
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Add 6 people with equal priority to see if they will come out in the appropiate order.
    // Expected Result:
    // Kim
    // Bob
    // Steve
    // Daisy
    // Adrian
    // Ado
    // Defect(s) Found: No defects found
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        var kim = new PriorityItem("Kim", 5);
        var bob = new PriorityItem("Bob", 5);
        var steve = new PriorityItem("Steve", 5);
        var daisy = new PriorityItem("Daisy", 5);
        var adrian = new PriorityItem("Adrian", 5);
        var ado = new PriorityItem("Ado", 5);

        priorityQueue.Enqueue("Kim", 5);
        priorityQueue.Enqueue("Bob", 5);
        priorityQueue.Enqueue("Steve", 5);
        priorityQueue.Enqueue("Daisy", 5);
        priorityQueue.Enqueue("Adrian", 5);
        priorityQueue.Enqueue("Ado", 5);

        PriorityItem[] expectedResult = [kim, bob, steve, daisy, adrian, ado];

        for (int i = 0; i < 6; i++)
        {
            var person = priorityQueue.Dequeue();
            Console.WriteLine(person);
            Assert.AreEqual(expectedResult[i].Value, person);
        }
    }

    [TestMethod]
    // Scenario: Add 2 people to see if the dequeue method can handle it.
    // Expected Result:
    // Kim
    // Bob
    // Defect(s) Found: No defects found
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        var kim = new PriorityItem("Kim", 1);
        var bob = new PriorityItem("Bob", 2);

        priorityQueue.Enqueue("Kim", 1);
        priorityQueue.Enqueue("Bob", 2);

        PriorityItem[] expectedResult = [bob, kim];

        for (int i = 0; i < 2; i++)
        {
            var person = priorityQueue.Dequeue();
            Console.WriteLine(person);
            Assert.AreEqual(expectedResult[i].Value, person);
        }
    }

    [TestMethod]
    // Scenario: Add 1 person to see if the dequeue method can handle it.
    // Expected Result:
    // Kim
    // Defect(s) Found: No defects found
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();

        var kim = new PriorityItem("Kim", 2);

        priorityQueue.Enqueue("Kim", 2);

        PriorityItem[] expectedResult = [kim];

        for (int i = 0; i < 1; i++)
        {
            var person = priorityQueue.Dequeue();
            Console.WriteLine(person);
            Assert.AreEqual(expectedResult[i].Value, person);
        }
    }
}