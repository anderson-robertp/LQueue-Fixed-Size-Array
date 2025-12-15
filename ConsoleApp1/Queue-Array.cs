namespace AQueue;

using System;

/// <summary>
/// Queue using an array using a fixed size with a circular buffer.
/// Support enqueue, dequeue, peek, contains, and size.
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public class AQueue<T>
{
    // Constructor
    private readonly T[] _data; // array to store the queue items
    private int _front = 0; // front of the queue or index of the first element
    private int _rear = 0; // rear of the queue or index where to enqueue the next item
    private int _size = 0; // size of the queue or number of elements in the queue
    
    /// <summary>
    /// Create a new queue with the specified capacity.
    /// </summary>
    /// <param name="capacity">Maximum number of elements allowed in the queue</param>
    /// <exception cref="ArgumentException"></exception>
    public AQueue(int capacity)
    {
        if (capacity < 1) throw new ArgumentException("Capacity must be greater than 0");
        _data = new T[ capacity];
    }
    
    /// <summary>
    /// Return the number of elements in the queue.
    /// </summary>
    /// <returns></returns>
    public int Size => _size;
    
    // Methods
    /// <summary>
    /// Adds an item to the end of the queue.
    /// Expected time complexity: O(1)
    /// </summary>
    /// <param name="item">The item to be added to the queue.</param>
    /// <exception cref="InvalidOperationException">Thrown if the queue is full.</exception>
    public void Enqueue(T item)
    {
        // Check if the queue is full
        if (_size == _data.Length) throw new InvalidOperationException("Queue is full");
        // Add the item to the rear of the queue
        _data[_rear] = item;
        // Update the rear
        _rear = (_rear + 1) % _data.Length;
        // Increment the size
        _size++;
    }
    
    // Dequeue
    /// <summary>
    /// Remove and return the item at the front of the queue.
    /// Expected time complexity: O(1)
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public T Dequeue()
    {
        // Check if the queue is empty
        if (_size == 0) throw new InvalidOperationException("Queue is empty");
        // Remove the item from the front of the queue
        T item = _data[0];
        // Update the front and size
        _front = (_front + 1) % _data.Length;
        _size--;
        // Return the removed item
        return item;
    }
    
    /// <summary>
    /// Return the item at the front of the queue without removing it.
    /// </summary>
    /// <returns>The first item in the queue</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public T Peek()
    {
        // Check if the queue is empty
        if (_size == 0) throw new InvalidOperationException("Queue is empty");
        // Return the item at the front of the queue
        return _data[_front];
    }
    
    // Contains
    /// <summary>
    /// Return true if the queue contains the specified item, false otherwise.
    /// </summary>
    /// <param name="item"></param>
    /// <returns>Bool</returns>
    public bool Contains(T item)
    {
        // Check if the queue contains the specified item
        foreach (T queueItem in _data)
        {
            if (queueItem == null) continue;
            if (queueItem.Equals(item)) return true;
        }
        return false;
    }
}

