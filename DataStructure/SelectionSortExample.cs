namespace DataStructure;

public class SelectionSortExample
{
    public int[] Sort(int[] arr)
    {
        int j = 0, m = 0;
        int min, swap;
        for (int i = 0; i < arr.Length; i++)
        {
            min = arr[i];
            m = i;
            for (j = i; j < arr.Length; j++)
            {
                if (arr[j] < min)
                {
                    min = arr[j];
                    m = j;
                }
            }

            swap = arr[i];
            arr[i] = min;
            arr[m] = swap;
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