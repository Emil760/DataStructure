namespace DataStructure;

public class HashSetExample
{
    public void Example()
    {
        HashSet<string> basketProducts1 = new HashSet<string>();
        HashSet<string> basketProducts2 = new HashSet<string>();
        HashSet<string> basketProducts3 = new HashSet<string>();

        basketProducts1.Add("potato");
        basketProducts1.Add("tomato");
        basketProducts1.Add("lemon");
        basketProducts1.Add("watermelon");
        basketProducts1.Add("mango");
        basketProducts1.Add("banana");

        basketProducts2.Add("mango");
        basketProducts2.Add("banana");

        basketProducts3.Add("eggplant");
        basketProducts3.Add("onion");
        basketProducts3.Add("lemon");
        basketProducts3.Add("watermelon");

        if (basketProducts2.IsSubsetOf(basketProducts1))
            Console.WriteLine("basketProducts2 is subset of basketProducts1");
        Console.WriteLine();

        basketProducts1.UnionWith(basketProducts3);

        Show(basketProducts1);
    }

    public void Show(HashSet<string> basketProducts)
    {
        foreach (var basketProduct in basketProducts)
        {
            Console.WriteLine(basketProduct);
        }
    }
}