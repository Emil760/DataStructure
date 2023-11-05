namespace DataStructure;

public class QuickSortExample<T>
{
    public T[] Sort(T[] arr, int left, int right)
    {
        if (right - left <= 1)
            return arr;

        int pivot = left + 1;
        T swap;

        for (int i = left; i < right; i++)
        {
            if (Comparer<T>.Default.Compare(arr[left], arr[i]) > 0)
            {
                swap = arr[pivot];
                arr[pivot] = arr[i];
                arr[i] = swap;
                pivot++;
            }
        }

        swap = arr[left];
        arr[left] = arr[pivot - 1];
        arr[pivot - 1] = swap;

        arr = Sort(arr, left, pivot);
        arr = Sort(arr, pivot, right);

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