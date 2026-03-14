using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue to verify highest priority is removed first.
    // Expected Result: High -> Medium -> Low
    public void TestPriorityQueue_BasicPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("Medium", 2);
        pq.Enqueue("High", 3);

        Assert.AreEqual("High", pq.Dequeue());
        Assert.AreEqual("Medium", pq.Dequeue());
        Assert.AreEqual("Low", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with same priority to verify FIFO behavior.
    // Expected Result: First -> Second -> Third
    public void TestPriorityQueue_TiePriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("First", 1);
        pq.Enqueue("Second", 1);
        pq.Enqueue("Third", 1);

        Assert.AreEqual("First", pq.Dequeue());
        Assert.AreEqual("Second", pq.Dequeue());
        Assert.AreEqual("Third", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Mixed priorities with ties.
    // Expected Result: B -> A -> C -> D
    public void TestPriorityQueue_MixedPriorities()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("D", 1);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 2);
        pq.Enqueue("A", 3);

        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("D", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: InvalidOperationException
    public void TestPriorityQueue_EmptyDequeue()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception: {e.Message}");
        }
    }
}