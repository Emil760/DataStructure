namespace DataStructure;

public class HeapExample<TValue>
    where TValue : IComparable<TValue>
{
    public class Node<TValue>
    {
        public Node<TValue> parent;
        public Node<TValue> left;
        public Node<TValue> right;
        public TValue value;
    }

    private Node<TValue> root;
    private int length;

    public void ConvertToMinHeap(TValue[] arr)
    {
        if (arr.Length == 0)
            throw new ArgumentNullException();

        root = ConvertToTree(arr);
        root = MakeHeap();
    }

    public void ConvertToMaxHeap(TValue[] arr)
    {
    }

    private Node<TValue> ConvertToTree(TValue[] arr)
    {
        root = new Node<TValue>();
        root.value = arr[0];

        Node<TValue> it = root;

        for (int i = 1; i < arr.Length - 1; i++)
        {
            Node<TValue> node = new Node<TValue>();
            node.value = arr[i];
            if (Comparer<TValue>.Default.Compare(arr[i], it.value) > 0)
                it.right = new Node<TValue>();
            else
                it.left = new Node<TValue>();

            node.parent = it;
            length++;
        }

        return root;
    }

    private Node<TValue> MakeHeap()
    {
        return root;  
    }
}