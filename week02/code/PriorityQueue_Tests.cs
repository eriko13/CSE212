using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Test basic enqueue and dequeue functionality with different priorities
    // Expected: Higher priority item (5) should be dequeued before lower priority item (2)
    // Defect(s) Found: Loop condition in Dequeue misses last element (should be < _queue.Count, not < _queue.Count - 1)
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low Priority", 2);
        priorityQueue.Enqueue("High Priority", 5);
        
        string result = priorityQueue.Dequeue();
        Assert.AreEqual("High Priority", result);
    }

    [TestMethod]
    // Test FIFO behavior when multiple items have the same highest priority
    // Expected: First item with priority 3 should be dequeued first
    // Defect(s) Found: Using >= instead of > when comparing priorities violates FIFO for same priority items
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First High", 3);
        priorityQueue.Enqueue("Second High", 3);
        priorityQueue.Enqueue("Low Priority", 1);
        
        string result = priorityQueue.Dequeue();
        Assert.AreEqual("First High", result);
    }

    [TestMethod]
    // Test that dequeue throws InvalidOperationException when queue is empty
    // Expected: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None - this functionality works correctly
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        
        var exception = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", exception.Message);
    }

    [TestMethod]
    // Test multiple dequeues to ensure items are removed properly
    // Expected: Items should be dequeued in priority order and removed from queue
    // Defect(s) Found: Dequeue method doesn't actually remove items from the queue
    public void TestPriorityQueue_MultipleDequeues()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Priority 1", 1);
        priorityQueue.Enqueue("Priority 3", 3);
        priorityQueue.Enqueue("Priority 2", 2);
        
        Assert.AreEqual("Priority 3", priorityQueue.Dequeue());
        Assert.AreEqual("Priority 2", priorityQueue.Dequeue());
        Assert.AreEqual("Priority 1", priorityQueue.Dequeue());
        
        // Queue should now be empty
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    [TestMethod]
    // Test complex scenario with multiple items of same and different priorities
    // Expected: FIFO within same priority, priority order across different priorities
    // Defect(s) Found: Combination of >= comparison and missing removal causes incorrect FIFO behavior
    public void TestPriorityQueue_ComplexScenario()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 2);
        priorityQueue.Enqueue("D", 5);
        priorityQueue.Enqueue("E", 1);
        
        // Should get: B (first priority 5), then D (second priority 5), 
        // then A (first priority 2), then C (second priority 2), then E (priority 1)
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("E", priorityQueue.Dequeue());
    }
}