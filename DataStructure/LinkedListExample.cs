namespace DataStructure;

public class LinkedListExample<T>
{
    private class Node<T>
    {
        public Node<T> Next { get; set; }
        public Node<T> Prev { get; set; }
        public T Value { get; set; }
    }

    private Node<T> head;
    private Node<T> tail;
    private int length;

    public LinkedListExample()
    {
    }
    
    public int Length
    {
        get => length;
    }

    public void AddLast(T value)
    {
        Node<T> node = new Node<T>
        {
            Value = value
        };

        if (head == null)
        {
            head = node;
            tail = node;
        }
        else
        {
            node.Prev = tail;
            tail.Next = node;
            tail = node;
        }

        length++;
    }

    public void AddFirst(T value)
    {
        Node<T> node = new Node<T>
        {
            Value = value
        };

        if (head == null)
        {
            head = node;
            tail = node;
        }
        else
        {
            node.Next = head;
            head.Prev = node;
            head = node;
        }

        length++;
    }

    public void RemoveFirst()
    {
        if (length == 0)
            throw new InvalidOperationException("List is empty");

        head = head.Next;
        head.Prev = null;
        length--;
    }

    public void RemoveLast()
    {
        if (length == 0)
            throw new InvalidOperationException("List is empty");

        tail = tail.Prev;
        tail.Next = null;
        length--;
    }

    public void Remove(T value)
    {
        Node<T> node = head;

        while (node != null)
        {
            if (node.Value.Equals(value))
            {
                if (node.Prev != null)
                    node.Prev.Next = node.Next;
                else
                    head = node.Next;
                if (node.Next != null)
                    node.Next.Prev = node.Prev;
                else
                    tail = node.Prev;

                length--;
                break;
            }

            node = node.Next;
        }
    }

    public T Find(int index)
    {
        if (index + 1 > length || index < 0)
            throw new ArgumentOutOfRangeException();

        Node<T> node = head;

        for (int i = 0; i < index; i++)
        {
            node = node.Next;
        }

        return node.Value;
    }

    public bool IsEmpty()
    {
        return length == 0;
    }

    public T this[int index]
    {
        get => Find(index);
    }

    public void Show()
    {
        Node<T> node = head;

        while (node != null)
        {
            Console.WriteLine(node.Value);
            node = node.Next;
        }
    }

    public void Example()
    {
        LinkedListExample<int> list = new LinkedListExample<int>();
        list.AddLast(11);
        list.AddLast(22);

        list.Remove(11);
        list.Remove(22);
        
        list.AddLast(22);
        list.AddFirst(33);
        
        list.Remove(33);
        list.Remove(22);
        
        list.Show();
    }
}