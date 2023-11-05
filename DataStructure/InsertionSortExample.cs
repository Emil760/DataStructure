namespace DataStructure;

public class InsertionSortExample<T>
{
    public T[] Sort(T[] arr)
    {
        T swap;
        T minValue;
        int j;
        for (int i = 1; i < arr.Length; i++)
        {
            minValue = arr[i];
            j = i;
            while (j > 0 && Comparer<T>.Default.Compare(arr[j - 1], minValue) > 0)
            {
                swap = arr[j - 1];
                arr[j] = swap;
                arr[j - 1] = minValue;
                j--;
            }
        }

        return arr;
    }

    public void Show(T[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i] + " ");
        }
    }
}