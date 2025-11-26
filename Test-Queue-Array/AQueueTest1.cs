using AQueue;

namespace Test_LQueue_Array;

using System;

using NUnit.Framework;

/// <summary>
/// Unit Tests for AQueue
/// 
/// </summary>

public class AQueueTests
{
    /// <summary>
    /// Purpose: Test enqueue and verify inserts correctly
    /// and size increases.
    /// Expected: Size == 2 and element ==10
    /// </summary>
    
    [Test]
    public void TestEnqueue()
    {
        // fill queue
        var q = new AQueue<int>(10);
        q.Enqueue(10);
        q.Enqueue(20);
     
        // verify
        Assert.AreEqual(2, q.Size);
        Assert.AreEqual(10, q.Peek());
    }
    
    /// <summary>
    /// Purpose: Test dequeue and verify removes correctly
    /// and size decreases.
    /// Expected: Size == 1 and an element == 20
    /// </summary>
    [Test]
    public void TestDequeue()
    {
        // fill queue
        var q = new AQueue<int>(10);
        q.Enqueue(10);
        q.Enqueue(20);
        
        // verify
        Assert.AreEqual(10, q.Dequeue());
        Assert.AreEqual(1, q.Size);
        Assert.AreEqual(20, q.Peek());
    }
    
    /// <summary>
    /// Purpose: Test peek and verify returns a correct element.
    /// Expected: Peek returns 10 and size == 2
    /// </summary>
    [Test]
    public void TestPeek()
    {
        // fill queue
        var q = new AQueue<int>(10);
        q.Enqueue(10);
        q.Enqueue(20);
        
        // verify
        Assert.AreEqual(10, q.Peek());
        Assert.AreEqual(2, q.Size);
    }
    
    /// <summary>
    /// Purpose: Test contains and verify returns true if element is in queue.
    /// Expected: Contains(10) == true and Contains(30) == false
    /// </summary>
    [Test]
    public void TestContains()
    {
        // fill queue
        var q = new AQueue<int>(10);
        q.Enqueue(10);
        q.Enqueue(20);
        
        // verify
        Assert.True(q.Contains(10));
        Assert.False(q.Contains(30));
    }
    
    /// <summary>
    /// Purpose: Verify enqueue throws when queue is full.
    /// Expected: InvalidOperationException thrown.
    /// </summary>
    [Test]
    public void TestEnqueueFull()
    {
        // fill queue
        var q = new AQueue<int>(2);
        q.Enqueue(10);
        q.Enqueue(20);
        
        // should throw
        Assert.Throws<InvalidOperationException>(() => q.Enqueue(30));
    }
    
    /// <summary>
    /// Purpose: Verify peek throws when the queue is empty.
    /// Expected: InvalidOperationException thrown.
    /// </summary>
    
    [Test]
    public void TestPeekEmpty()
    {
        // empty queue
        var q = new AQueue<int>(10);
        
        // should throw
        Assert.Throws<InvalidOperationException>(() => q.Peek());
    }

    /// <summary>
    /// Purpose: Verify dequeue throws when the queue is empty.
    /// Expected: InvalidOperationException thrown.
    /// </summary>
    
    [Test]
    public void TestDequeueEmpty()
    {
        var q = new AQueue<int>(10); // empty queue
        
        Assert.Throws<InvalidOperationException>(() => q.Dequeue()); // should throw
    }
    
    /// <summary>
    /// Purpose: Verify queue wraps around when full.
    /// Expected: 40 is in the queue and peek returns 20.
    /// </summary>
    [Test]
    public void TestQueueWrapAround()
    {
     var q = new AQueue<int>(3);
     q.Enqueue(10);
     q.Enqueue(20);
     q.Enqueue(30);
     
     q.Dequeue(); // should remove 10
     
     q.Enqueue(40); // should wrap around to 20 and insert 40
     
     Assert.True(q.Contains(40)); // verify 40 is in queue
     Assert.AreEqual(20, q.Peek()); // verify peek returns 20
    }
}