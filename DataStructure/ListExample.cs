namespace DataStructure;

public class ListExample<T>
{
    private T[] arr;
    private const int defaultCapacity = 2;
    private int lenght;

    public ListExample()
    {
        arr = new T[defaultCapacity];
        lenght = 0;
    }

    public ListExample(int capacity)
    {
        arr = new T[capacity];
        lenght = 0;
    }

    public int Length
    {
        get => lenght;
    }

    public int Capacity
    {
        get => arr.Length;
    }

    public void Add(T item)
    {
        if (Capacity == Length)
        {
            int capacity = arr.Length * 2;
            T[] copy = new T[capacity];
            for (int i = 0; i < arr.Length; i++)
            {
                copy[i] = arr[i];
            }

            arr = copy;
        }

        arr[lenght] = item;
        lenght++;
    }

    public void Remove(int index)
    {
        if (index < 0 || index + 1 > Length)
            throw new ArgumentOutOfRangeException();

        T[] copy = new T[Length - 1];
        int copyIndex = 0;

        for (int i = 0; i < copy.Length; i++)
        {
            if (i == index)
                continue;

            copy[copyIndex] = arr[i];
            copyIndex++;
        }

        lenght--;
        arr = copy;
    }

    public T[] ToArray()
    {
        T[] copy = new T[Length];

        for (int i = 0; i < Length; i++)
        {
            copy[i] = arr[i];
        }

        return copy;
    }
    
    public void Show()
    {
        for (int i = 0; i < Length; i++)
        {
            Console.WriteLine($"index{i}: {arr[i]}");
        }
    }

    public void Example()
    {
        ListExample<int> a = new ListExample<int>();
        a.Add(11);
        a.Add(22);
        a.Add(33);
        
        a.Show();
    }
}