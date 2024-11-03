using System;

public class MyDictionary<TKey, TValue>
{
    private TKey[] keys;
    private TValue[] values;
    private int count;

    public MyDictionary(int capacity = 4)
    {
        keys = new TKey[capacity];
        values = new TValue[capacity];
        count = 0;
    }

    public int Count
    {
        get { return count; }
    }

    public void Add(TKey key, TValue value)
    {
        if (count == keys.Length)
        {
            Resize();
        }

        // Проверка на дублирующиеся ключи
        for (int i = 0; i < count; i++)
        {
            if (EqualityComparer<TKey>.Default.Equals(keys[i], key))
            {
                throw new ArgumentException("Ключ уже существует");
            }
        }

        keys[count] = key;
        values[count] = value;
        count++;
    }

    public TValue this[TKey key]
    {
        get
        {
            for (int i = 0; i < count; i++)
            {
                if (EqualityComparer<TKey>.Default.Equals(keys[i], key))
                {
                    return values[i];
                }
            }
            throw new KeyNotFoundException("Ключ не найден");
        }
        set
        {
            for (int i = 0; i < count; i++)
            {
                if (EqualityComparer<TKey>.Default.Equals(keys[i], key))
                {
                    values[i] = value;
                    return;
                }
            }
            throw new KeyNotFoundException("Ключ не найден");
        }
    }

    private void Resize()
    {
        int newCapacity = keys.Length * 2;
        TKey[] newKeys = new TKey[newCapacity];
        TValue[] newValues = new TValue[newCapacity];
        Array.Copy(keys, newKeys, keys.Length);
        Array.Copy(values, newValues, values.Length);
        keys = newKeys;
        values = newValues;
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        for (int i = 0; i < count; i++)
        {
            yield return new KeyValuePair<TKey, TValue>(keys[i], values[i]);
        }
    }

    // Необходимый класс для поддержки перебора элементов
    public struct KeyValuePair<TKey, TValue>
    {
        public TKey Key { get; }
        public TValue Value { get; }

        public KeyValuePair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}

// Пример использования:
class Program
{
    static void Main()
    {
        MyDictionary<string, int> myDict = new MyDictionary<string, int>();
        
        myDict.Add("FirstString", 1);
        myDict.Add("SecondString", 2);
        myDict.Add("ThirdString", 3);

        Console.WriteLine("Количество элементов: " + myDict.Count);

        foreach (var kvp in myDict)
        {
            Console.WriteLine($"Ключ: {kvp.Key}, Значение: {kvp.Value}");
        }

        // Получение значения по ключу
        Console.WriteLine($"Значение для 'FirstString': {myDict["FirstString"]}");

        // Изменение значения
        myDict["FirstString"] = 5;
        Console.WriteLine($"Новое значение для 'FirstString': {myDict["FirstString"]}");
    }
}
