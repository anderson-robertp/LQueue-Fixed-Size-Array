namespace AQueue;

using System;

public class AQueue<T>
{
    // Constructor
    private T[] queue;
    
    // initialize the queue
    public AQueue()
    {
        queue = new T[10];
    }
    
    // Properties
    public int Size() => queue.Length;
    
    // Methods
    // Enqueue
    // Add an item to the back of the queue
    // Time Complexity: O(1)
    public void Enqueue(T item)
    {
        queue[queue.Length] = item;
    }
    
    // Dequeue
    // Remove an item from the front of the queue
    // Expected time complexity: O(1)
    // Throws InvalidOperationException if the queue is empty
    // Returns the item that was removed
    public T Dequeue()
    {
        if (queue.Length == 0) throw new InvalidOperationException("Queue is empty");
        T item = queue[0];
        Array.Copy(queue, 1, queue, 0, queue.Length - 1);
        return item;
    }
    
    // Peek
    // Return the item at the front of the queue without removing it
    // Expected time complexity: O(1)
    // Throws InvalidOperationException if the queue is empty
    public T Peek()
    {
        if (queue.Length == 0) throw new InvalidOperationException("Queue is empty");
        return queue[0];
    }
    
    // Contains
    // Return true if the queue contains the specified item, false otherwise
    // Expected time complexity: O(n)
    public bool Contains(T item)
    {
        foreach (T queueItem in queue)
        {
            if (queueItem.Equals(item)) return true;
        }
        return false;
    }
}

