namespace AQueue;

using System;
using System.Diagnostics;

/// <summary>
/// Performance Analytics
/// 
///
/// Enqueue expected time: O(1)
/// Dequeue expected time: O(1)
/// Peek expected time: O(1)
/// Contains expected time: O(n)
/// </summary>

public static class PerformanceAnalytics
{
    /// <summary>
    /// Measure the time taken by the method in ticks
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
    
    public static long MeasureTime(Action method)
    {
        var watch = Stopwatch.StartNew();
        method();
        return watch.ElapsedTicks;
    }

    private static AQueue<int> Build(int size)
    {
        var q = new AQueue<int>(size + 1);
        for (int i = 0; i < size; i++)
        {
            q.Enqueue(i);
        }
        return q;
    }

    private static void MeasureEnqueue(int size)
    {
        var q = Build(size);
        MeasureTime(() => q.Enqueue(size));
        Console.WriteLine($"Enqueue: {MeasureTime(() => q.Enqueue(size))} ticks");
    }
    private static void MeasureDequeue(int size)
    {
        var q = Build(size);
        MeasureTime(() => q.Dequeue());
        Console.WriteLine($"Dequeue: {MeasureTime(() => q.Dequeue())} ticks");
    }
    private static void MeasurePeek(int size)
    {
        var q = Build(size);
        MeasureTime(() => q.Peek());
        Console.WriteLine($"Peek: {MeasureTime(() => q.Peek())} ticks");
    }
    private static void MeasureContains(int size)
    {
        var q = Build(size);
        MeasureTime(() => q.Contains(size));
        Console.WriteLine($"Contains: {MeasureTime(() => q.Contains(size))} ticks");
    }
}