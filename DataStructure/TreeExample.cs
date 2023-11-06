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

    public Node<TKey, TValue> Root
    {
        get => root;
    }

    public int Length
    {
        get => length;
    }

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
        Remove(root, key);
    }

    private void Remove(Node<TKey, TValue> node, TKey key)
    {
        if (node == null)
            throw new ArgumentException($"The node {key} does not exist.");

        int comparer = Comparer<TKey>.Default.Compare(key, node.key);

        if (comparer < 0)
        {
            Remove(node.left, key);
        }
        else if (comparer > 0)
        {
            Remove(node.right, key);
        }
        else
        {
            if (node.left == null && node.right == null)
            {
                ReplaceInParent(node, null);
                length--;
            }
            else if (node.right == null)
            {
                ReplaceInParent(node, node.left);
                length--;
            }
            else if (node.left == null)
            {
                ReplaceInParent(node, node.right);
                length--;
            }
            else
            {
                Node<TKey, TValue> successor = FindMinimumInSubtree(node.right);
                node.key = successor.key;
                node.value = successor.value;
                Remove(successor, successor.key);
            }
        }
    }

    private void ReplaceInParent(Node<TKey, TValue> node, Node<TKey, TValue> newNode)
    {
        if (node.parent != null)
        {
            if (node.parent.left == node)
            {
                node.parent.left = newNode;
            }
            else
            {
                node.parent.right = newNode;
            }
        }
        else
        {
            root = newNode;
        }

        if (newNode != null)
        {
            newNode.parent = node.parent;
        }
    }

    private Node<TKey, TValue> FindMinimumInSubtree(Node<TKey, TValue> node)
    {
        while (node.left != null)
        {
            node = node.left;
        }

        return node;
    }

    public TValue Get(TKey key)
    {
        Node<TKey, TValue> node = root;
        int comparer;
        while (node != null)
        {
            comparer = Comparer<TKey>.Default.Compare(key, node.key);

            if (comparer == 0)
                return node.value;
            else if (comparer > 0)
                node = node.right;
            else
                node = node.left;
        }

        throw new KeyNotFoundException();
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

    public void ShowDescending(Node<TKey, TValue> node)
    {
        if (node != null)
        {
            ShowDescending(node.right);
            Console.WriteLine(node.value);
            ShowDescending(node.left);
        }
    }

    public void ShowAscending(Node<TKey, TValue> node)
    {
        if (node != null)
        {
            ShowAscending(node.left);
            Console.WriteLine(node.value);
            ShowAscending(node.right);
        }
    }

    public void PreOrderShow(Node<TKey, TValue> node)
    {
        if (node != null)
        {
            Console.WriteLine(node.value);
            PreOrderShow(node.left);
            PreOrderShow(node.right);
        }
    }

    public void PostOrderShow(Node<TKey, TValue> node)
    {
        if (node != null)
        {
            PostOrderShow(node.left);
            PostOrderShow(node.right);
            Console.WriteLine(node.value);
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

        tree.Remove(59);

        tree.PostOrderShow(tree.root);
    }
}