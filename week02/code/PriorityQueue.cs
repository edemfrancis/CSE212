using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private List<PriorityItem> _queue = new List<PriorityItem>();

    /// <summary>
    /// Add a new value to the queue with an associated priority.
    /// The node is always added to the back of the queue regardless of the priority.
    /// </summary>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // First pass: find maximum priority
        int maxPri = _queue[0].Priority;
        for (int i = 1; i < _queue.Count; i++)
        {
            if (_queue[i].Priority > maxPri)
            {
                maxPri = _queue[i].Priority;
            }
        }

        // Second pass: find first (smallest index) occurrence of maxPri for FIFO
        int highPriorityIndex = -1;
        for (int i = 0; i < _queue.Count; i++)
        {
            if (_queue[i].Priority == maxPri)
            {
                highPriorityIndex = i;
                break;
            }
        }

        string value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex);

        return value;
    }

    // DO NOT MODIFY
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    // DO NOT MODIFY THE CODE IN THIS METHOD
    // The graders rely on this method to check if you fixed all the bugs, so changes to it will cause you to lose points.
    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}