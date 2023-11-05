namespace DataStructure;

public class ArrayExample<T>
{
    public ArrayExample()
    {
    }

    public T[] Add(T[] array, T item)
    {
        T[] copy = new T[array.Length + 1];

        for (int i = 0; i < array.Length; i++)
        {
            copy[i] = array[i];
        }

        copy[array.Length] = item;
        array = copy;
        return array;
    }

    public T[] Remove(T[] array, int index)
    {
        if (index < 0 || index + 1 > array.Length)
            throw new ArgumentOutOfRangeException();

        T[] copy = new T[array.Length - 1];
        int copyIndex = 0;

        for (int i = 0; i < copy.Length; i++)
        {
            if (i == index)
                continue;

            copy[copyIndex] = array[i];
            copyIndex++;
        }

        array = copy;
        return array;
    }

    public void Show(T[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine($"index{i}: {arr[i]}");
        }
    }

    public void Example()
    {
        ArrayExample<int> arrayExample = new ArrayExample<int>();
        int[] arr = new int[1];

        arr = arrayExample.Add(arr, 11);
        arrayExample.Show(arr);
        Console.WriteLine("");

        arr = arrayExample.Add(arr, 22);
        arrayExample.Show(arr);
        Console.WriteLine("");

        arr = arrayExample.Remove(arr, 1);
        arr = arrayExample.Remove(arr, 1);
        arrayExample.Show(arr);
    }
}