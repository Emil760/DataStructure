namespace DataStructure;

public class QueueExample
{
    private Queue<string> _queue;

    public QueueExample()
    {
        _queue = new Queue<string>();
    }

    public void CallToCallCenter(string phoneNumber)
    {
        _queue.Enqueue(phoneNumber);
    }


    public void AnswerCustomer()
    {
        var phoneNumber = _queue.Dequeue();
        Console.WriteLine($"Hello {phoneNumber}");
    }

    public void Example()
    {
        QueueExample example = new QueueExample();

        example.CallToCallCenter("0517606617");
        example.CallToCallCenter("0556434787");
        
        example.AnswerCustomer();
        
        example.CallToCallCenter("0502301717");
        
        example.AnswerCustomer();
        example.AnswerCustomer();
    }
}