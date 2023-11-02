namespace DataStructure;

public class SelectionSortExample
{
    public int[] Sort(int[] arr)
    {
        int j = 0, minIndex = 0;
        int minValue, swap;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            minValue = arr[i];
            minIndex = i;
            for (j = i; j < arr.Length; j++)
            {
                if (arr[j] < minValue)
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

    public void Show(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i] + " ");
        }
    }

    public void Example()
    {
        int[] a = new int[] { -7, 55, -3, 22, -8, 111, 8, 7, 111 };
        a = Sort(a);
        Show(a);
    }
}