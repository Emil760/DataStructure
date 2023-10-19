namespace DataStructure;

public class StackExample
{
    private Stack<string> _stack;

    public StackExample()
    {
        _stack = new Stack<string>();
    }

    public void MakeSomeOperation(string operation)
    {
        _stack.Push(operation);
    }

    public string UndoOperation()
    {
        return _stack.Pop();
    }

    public void Example()
    {
        StackExample example = new StackExample();
        
        example.MakeSomeOperation("operation1");
        example.MakeSomeOperation("operation2");
        example.MakeSomeOperation("operation3");

        Console.WriteLine(example.UndoOperation());
    }
}