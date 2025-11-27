namespace AQueue;

using System;
using System.Diagnostics;

/// <summary>
/// Performance Analytics
/// Initial test results were skewed due to warmup of the JIT compiler.
///
/// Enqueue expected time: O(1)
///     Execution was around 0-1 ticks per operation. This matches the expected time complexity.
/// 
/// Dequeue expected time: O(1)
///     Dequeue was around 0-1 ticks per operation. This matches the expected time complexity.
/// 
/// Peek expected time: O(1)
///     No variation was observed. Behavior was consistent with O(1).
/// 
/// Contains expected time: O(n)
///     The execution time increase linearly with queue size.
/// </summary>

public static class PerformanceAnalytics
{
    /// <summary>
    /// Executes performance analytics by measuring the time taken for various queue operations
    /// (enqueue, dequeue, peek, and contains) across multiple queue sizes.
    /// </summary>
    public static void Run()
    {
        int[] sizes = {10,100,1000,10000};
        
        Console.WriteLine("Performance Analytics");
        Console.WriteLine("=====================");
        
        foreach (int size in sizes)
        {
            Console.WriteLine($"Size: {size}");
            
            MeasureEnqueue(size);
            MeasureDequeue(size);
            MeasurePeek(size);
            MeasureContains(size);
        }
    }

    /// <summary>
    /// Measures the time taken to execute the specified method in ticks.
    /// </summary>
    /// <param name="method">The method whose execution time is to be measured.</param>
    /// <returns>The time taken to execute the method, measured in ticks.</returns>
    private static long MeasureTime(Action method)
    {
        var watch = Stopwatch.StartNew();
        method();
        watch.Stop();
        return watch.ElapsedTicks;
    }

    /// <summary>
    /// Builds and initializes a queue of the specified size, populating it with consecutive integers
    /// starting from zero.
    /// </summary>
    /// <param name="size">The number of elements to initialize the queue with.</param>
    /// <returns>Returns an instance of <see cref="AQueue{T}"/> initialized with the specified number of elements.</returns>
    private static AQueue<int> Build(int size)
    {
        var q = new AQueue<int>(size + 1);
        for (int i = 0; i < size; i++)
        {
            q.Enqueue(i);
        }
        return q;
    }

    /// <summary>
    /// Measures the time taken to perform the enqueue operation on a queue of the specified size.
    /// </summary>
    /// <param name="size">The size of the queue for which the enqueue operation is to be measured.</param>
    private static void MeasureEnqueue(int size)
    {
        var q = Build(size);
        
        // Warmup isn't measured
        for (int i = 0; i < 1000; i++)
        {
            q.Enqueue(i % size);
            q.Dequeue();
        }
        
        // Timed operations
        long total = 0;
        for (int i = 0; i < 10; i++)
        {
            q = Build(size); // reset queue
            total += MeasureTime(() => q.Enqueue(-1));
            Console.WriteLine($"Enqueue: {total / 10} ticks");
        }
    }

    /// <summary>
    /// Measures the time taken to perform the dequeue operation on a queue of the specified size.
    /// </summary>
    /// <param name="size">The size of the queue for which the dequeue operation is to be measured.</param>
    private static void MeasureDequeue(int size)
    {
        var q = Build(size);
        
        // Warmup isn't measured
        for (int i = 0; i < 1000; i++)
        {
            q.Enqueue(i % size);
            q.Dequeue();
        }
        
        // Timed operations
        long total = 0;
        for (int i = 0; i < 10; i++)
        {
            q = Build(size); // reset queue
            total += MeasureTime(() => q.Dequeue());
            Console.WriteLine($"Dequeue: {total / 10} ticks");
        }
    }

    /// <summary>
    /// Measures the time taken to perform the peek operation on a queue of the specified size.
    /// </summary>
    /// <param name="size">The size of the queue for which the peek operation is to be measured.</param>
    private static void MeasurePeek(int size)
    {
        var q = Build(size);
        
        // Warmup isn't measured
        for (int i = 0; i < 1000; i++)
        {
            q.Enqueue(i % size);
            q.Dequeue();
        }
        
        // Timed operations
        long total = 0;
        for (int i = 0; i < 10; i++)
        {
            q = Build(size); // reset queue
            total += MeasureTime(() => q.Peek());
            Console.WriteLine($"Peek: {total / 10} ticks");
        }
    }
    private static void MeasureContains(int size)
    {
        var q = Build(size);
        
        // Warmup isn't measured
        for (int i = 0; i < 1000; i++)
        {
            q.Enqueue(i % size);
            q.Dequeue();
        }
        
        // Timed operations
        long total = 0;
        for (int i = 0; i < 10; i++)
        {
            q = Build(size); // reset queue
            total += MeasureTime(() => q.Contains(-1));
            Console.WriteLine($"Contains: {total / 10} ticks");
        }
    }
}