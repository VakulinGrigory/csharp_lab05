using System;

public class MyList<T>
{
    private T[] items;
    private int count;

    public MyList(int capacity = 4)
    {
        items = new T[capacity];
        count = 0;
    }

    public int Count
    {
        get { return count; }
    }
    
    private void Resize()
    {
        int newCapacity = items.Length * 2;
        T[] newItems = new T[newCapacity];
        Array.Copy(items, newItems, items.Length);
        items = newItems;
    }

    public void Add(T item)
    {
        if (count == items.Length)
        {
            Resize();
        }
        items[count++] = item;
    }

    public T this[int index]
    {
        get { return items[index]; }
        set { items[index] = value; }
    }

    // Поддержка инициализатора коллекции
    public MyList(params T[] initialItems)
    {
        count = initialItems.Length;
        items = new T[count];
        Array.Copy(initialItems, items, count);
    }
}

// Пример использования:
class Program
{
    static void Main()
    {
        MyList<int> myList = new MyList<int>();
        
        myList.Add(1);
        myList.Add(2);
        myList.Add(3);

        Console.WriteLine($"Количество элементов: {myList.Count}");

        for (int i = 0; i < myList.Count; i++)
        {
            Console.WriteLine($"Элемент {i + 1}: {myList[i]}");
        }

        MyList<string> stringList = new MyList<string>("FirstString", "SecondString", "ThirdString");
        Console.WriteLine("Количество элементов в строковом списке: " + stringList.Count);
        for (int i = 0; i < stringList.Count; i++)
        {
            Console.WriteLine($"Элемент {i + 1}: {stringList[i]}");
        }
    }
}