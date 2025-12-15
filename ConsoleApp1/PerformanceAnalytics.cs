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
        int[] sizes = { 10, 10, 100, 1000, 10000, 100000 };
        
        int trials = 10;
        
        Console.WriteLine("Performance Analytics");
        Console.WriteLine("=====================");
        
        // Warmup
        Warmup();
        
        foreach (int size in sizes)
        {
            Console.WriteLine($"Size: {size}");
            
            MeasureEnqueue(size, trials);
            MeasureDequeue(size, trials);
            MeasurePeek(size, trials);
            MeasureContains(size, trials);
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
    
    // Warm up
    private static void Warmup()
    {
        var q = Build(10000);
        q.Enqueue(-1);
        q.Peek();
        q.Contains(-1);
        q.Dequeue();
    }

    /// <summary>
    /// Measures the time taken to perform the enqueue operation on a queue of the specified size.
    /// </summary>
    /// <param name="size">The size of the queue for which the enqueue operation is to be measured.</param>
    /// <param name="trials"></param>
    private static void MeasureEnqueue(int size, int trials)
    {
        // Timed operations
        long total = 0;
        for (int i = 0; i < trials; i++)
        {
            var q = Build(size); // reset queue
            total += MeasureTime(() => q.Enqueue(-1));
        }
        Console.WriteLine($"Enqueue: {total / trials} ticks");
    }

    /// <summary>
    /// Measures the time taken to perform the dequeue operation on a queue of the specified size.
    /// </summary>
    /// <param name="size">The size of the queue for which the dequeue operation is to be measured.</param>
    /// <param name="trials"></param>
    private static void MeasureDequeue(int size, int trials) {
        
        // Timed operations
        long total = 0;
        for (int i = 0; i < trials; i++)
        {
            var q = Build(size); // reset queue
            total += MeasureTime(() => q.Dequeue());
            
        }
        Console.WriteLine($"Dequeue: {total / trials} ticks");
    }

    /// <summary>
    /// Measures the time taken to perform the peek operation on a queue of the specified size.
    /// </summary>
    /// <param name="size">The size of the queue for which the peek operation is to be measured.</param>
    /// <param name="trials"></param>
    private static void MeasurePeek(int size, int trials)
    {
        
        // Timed operations
        long total = 0;
        for (int i = 0; i < trials; i++)
        {
            var q = Build(size); // reset queue
            total += MeasureTime(() => q.Peek());
            
        }
        Console.WriteLine($"Peek: {total / trials} ticks");
    }

    /// <summary>
    /// Measures the time taken to execute the "Contains" operation on a queue of a given size over multiple trials.
    /// </summary>
    /// <param name="size">The size of the queue on which the "Contains" operation will be tested.</param>
    /// <param name="trials">The number of trials to perform for measuring the "Contains" operation.</param>
    private static void MeasureContains(int size, int trials)
    {
        // Timed operations
        long total = 0;
        for (int i = 0; i < trials; i++)
        {
            var q = Build(size); // reset queue
            total += MeasureTime(() => q.Contains(-1));
            
        }
        Console.WriteLine($"Contains: {total / trials} ticks");
    }
}