namespace DataStructure;

public class InsertionSortExample
{
    public int[] Sort(int[] arr)
    {
        int swap;
        int minValue;
        int swapIndex;
        for (int i = 1; i < arr.Length; i++)
        {
            minValue = arr[i];
            swapIndex = i;
            for (int j = i - 1; j >= 0; j--)
            {
                if (arr[j] > minValue)
                {
                    minValue = arr[j];
                    swapIndex = j;
                }
            }

            swap = arr[swapIndex];
            arr[i] = swap;
            arr[swapIndex] = minValue;
        }

        return arr;
    }

    public void Example()
    {
        int[] a = new int[] { -1, -7, -3, 22, -8, 111, 8, 7, 111 };
        a = Sort(a);
        Show(a);
    }

    public void Show(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i] + " ");
        }
    }
}