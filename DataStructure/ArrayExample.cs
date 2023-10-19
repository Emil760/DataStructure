using System.Net.Sockets;

namespace DataStructure;

public class ArrayExample<T>
{
    public ArrayExample()
    {
    }

    T[] Add(T[] array, T item, int index)
    {
        if (array.Length < index - 1)
        {
            T[] copy = new T[index - 1];
            for (int i = 0; i < array.Length; i++)
            {
                copy[i] = array[i];
            }

            copy[index] = item;
            array = copy;
            return array;
        }

        array[index] = item;
        return array;
    }
    
    
}