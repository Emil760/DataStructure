namespace DataStructure;

public class SelectionSortExample<T>
{
    public T[] Sort(T[] arr)
    {
        int j = 0, minIndex = 0;
        T minValue, swap;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            minValue = arr[i];
            minIndex = i;
            for (j = i; j < arr.Length; j++)
            {
                if (Comparer<T>.Default.Compare(arr[j], minValue) < 0)
                {
                    minValue = arr[j];
                    minIndex = j;
                }
            }

            swap = arr[i];
            arr[i] = minValue;
            arr[minIndex] = swap;
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