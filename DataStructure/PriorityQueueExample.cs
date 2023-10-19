namespace DataStructure;

public class PriorityQueueExample
{
    private PriorityQueue<string, int> _queue;  
    
    public PriorityQueueExample()
    {
        _queue = new PriorityQueue<string, int>();
    }

    public void NewTask(int priority, string task)
    {
        _queue.Enqueue(task, priority);
    }

    public void DoneTaskByPriority()
    {
        var task = _queue.Dequeue();
        Console.WriteLine($"Dequeue: {task}");
    }

    public void Example()
    {
        PriorityQueueExample example = new PriorityQueueExample();

        example.NewTask(2, "read file");
        example.NewTask(3, "open word document");
        example.NewTask(1, "clean up unused memory");
        example.NewTask(5, "check for updates");
        example.NewTask(2, "check available ports");
        
        example.DoneTaskByPriority();
        example.DoneTaskByPriority();
        example.DoneTaskByPriority();
        example.DoneTaskByPriority();
        example.DoneTaskByPriority();
    }
}