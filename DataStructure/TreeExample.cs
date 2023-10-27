namespace DataStructure;

public class TreeExample<TKey, TValue>
    where TKey : IComparable<TKey>
{
    public class Node<TKey, TValue>
    {
        public Node<TKey, TValue> parent;
        public Node<TKey, TValue> left;
        public Node<TKey, TValue> right;
        public TKey key;
        public TValue value;
    }

    private Node<TKey, TValue> root;
    private int length;

    public void Add(TKey key, TValue value)
    {
        Node<TKey, TValue> node = new Node<TKey, TValue>()
        {
            key = key,
            value = value
        };

        if (root == null)
        {
            root = node;
            length++;
            return;
        }

        Node<TKey, TValue> it = root;

        while (true)
        {
            if (Comparer<TKey>.Default.Compare(it.key, node.key) < 0)
            {
                if (it.right == null)
                {
                    it.right = node;
                    node.parent = it;
                    length++;
                    break;
                }

                it = it.right;
            }
            else
            {
                if (it.left == null)
                {
                    it.left = node;
                    node.parent = it;
                    length++;
                    break;
                }

                it = it.left;
            }
        }
    }

    public void Remove(TKey key)
    {
        Node<TKey, TValue> it = root;
        int compareResult = 0;

        while (it != null)
        {
            compareResult = Comparer<TKey>.Default.Compare(it.key, key);

            if (compareResult == 0)
            {
                if (it == root)
                {
                    if (it.right != null)
                        root = it.right;
                    else if (it.left != null)
                        root = it.left;
                }

                if (it.right != null)
                {
                    it.right.parent = it.parent;

                    if (it.parent != null)
                    {
                        if (it.parent.right == it)
                            it.parent.right = it.right;
                        else
                            it.parent.left = it.right;
                    }

                    if (it.left != null)
                    {
                        Node<TKey, TValue> pivot = it.right;
                        while (pivot.left != null)
                            pivot = pivot.left;

                        pivot.left = it.left;
                        it.left.parent = pivot;
                    }
                }
                else if (it.left != null)
                {
                    it.left.parent = it.parent;
                    it.parent.left = it.left;
                }

                it.right = null;
                it.left = null;
                it.parent = null;
                length--;
                return;
            }
            else if (compareResult > 0)
            {
                it = it.left;
            }
            else
            {
                it = it.right;
            }
        }
    }

    public TValue[] ToArray()
    {
        TValue[] arr = new TValue[length];
        int index = 0;
        return AddToArray(root, arr, ref index);
    }

    private TValue[] AddToArray(Node<TKey, TValue> node, TValue[] arr, ref int index)
    {
        if (node != null)
        {
            AddToArray(node.right, arr, ref index);
            arr[index++] = node.value;
            AddToArray(node.left, arr, ref index);
        }

        return arr;
    }

    public void Show(Node<TKey, TValue> node)
    {
        if (node != null)
        {
            Show(node.right);
            Console.WriteLine(node.value);
            Show(node.left);
        }
    }

    public void Example()
    {
        TreeExample<int, string> tree = new TreeExample<int, string>();

        tree.Add(100, "100");
        tree.Add(89, "89");
        tree.Add(99, "99");
        tree.Add(78, "78");
        tree.Add(55, "55");
        tree.Add(59, "59");
        tree.Add(65, "65");
        tree.Add(69, "69");
        tree.Add(79, "79");
        tree.Add(58, "58");
        tree.Add(67, "67");
        tree.Add(30, "30");
        tree.Add(105, "105");
        tree.Add(110, "110");
        tree.Add(103, "103");

        //tree.Remove(105);

        var a = tree.ToArray();

        foreach (var aa in a)
        {
            Console.WriteLine(aa);
        }

        //tree.Show(tree.root);
    }
}