using System;

public class MyMatrix
{
    private int[,] matrix;
    private Random random = new Random();

    public MyMatrix(int rows, int cols, int minValue, int maxValue)
    {
        matrix = new int[rows, cols];
        Fill(minValue, maxValue);
    }

    public void Fill(int minValue, int maxValue)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = random.Next(minValue, maxValue);
            }
        }
    }

    public void ChangeSize(int newRows, int newCols, int minValue, int maxValue)
    {
        int[,] newMatrix = new int[newRows, newCols];

        int minRows = Math.Min(newRows, matrix.GetLength(0));
        int minCols = Math.Min(newCols, matrix.GetLength(1));

        for (int i = 0; i < minRows; i++)
        {
            for (int j = 0; j < minCols; j++)
            {
                newMatrix[i, j] = matrix[i, j];
            }
        }

        for (int i = 0; i < newRows; i++)
        {
            for (int j = 0; j < newCols; j++)
            {
                if (i >= minRows || j >= minCols)
                {
                    newMatrix[i, j] = random.Next(minValue, maxValue);
                }
            }
        }

        matrix = newMatrix;
    }

    public void ShowPartialy(int startRow, int endRow, int startCol, int endCol)
    {
        for (int i = startRow; i <= endRow && i < matrix.GetLength(0); i++)
        {
            for (int j = startCol; j <= endCol && j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    public void Show()
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    public int this[int index1, int index2]
    {
        get { return matrix[index1, index2]; }
        set { matrix[index1, index2] = value; }
    }
}

class exercise1
{
    static void Main()
    {
        Console.Write("Введите количество строк: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Введите количество столбцов: ");
        int cols = int.Parse(Console.ReadLine());

        Console.Write("Введите минимальное значение: ");
        int minValue = int.Parse(Console.ReadLine());

        Console.Write("Введите максимальное значение: ");
        int maxValue = int.Parse(Console.ReadLine());

        MyMatrix matrix = new MyMatrix(rows, cols, minValue, maxValue);
        Console.WriteLine("Исходная матрица:");
        matrix.Show();
        
        matrix.Fill(minValue, maxValue);
        Console.WriteLine("Перезаполненная матрица:");
        matrix.Show(); 

        // Изменение размера матрицы
        Console.WriteLine("Изменение размера матрицы:");
        matrix.ChangeSize(rows + 2, cols + 2, minValue, maxValue);
        matrix.Show();

        // Вывод части матрицы
        Console.WriteLine("Часть матрицы:");
        matrix.ShowPartialy(1, 3, 1, 3);
    }
}
