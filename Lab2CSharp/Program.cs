using System;
using System.Text;

namespace Lab2CSharp
{
    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("=== Головне меню (Лабораторна 2) ===");
                Console.WriteLine("1 - Завдання 1.1 (Вектор: парні індекси)");
                Console.WriteLine("2 - Завдання 1.2 (Матриця: сума індексів парна)");
                Console.WriteLine("3 - Завдання 2 (Кратність сусідніх елементів)");
                Console.WriteLine("4 - Завдання 3 (Середнє під побічною діагоналлю)");
                Console.WriteLine("5 - Завдання 4 (Східчастий масив: суми стовпців)");
                Console.WriteLine("0 - Вихід");
                Console.Write("Оберіть варіант: ");

                string choice = Console.ReadLine()!;
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        RunTask1Vector();
                        break;
                    case "2":
                        RunTask1Matrix();
                        break;
                    case "3":
                        RunTask2();
                        break;
                    case "4":
                        RunTask3();
                        break;
                    case "5":
                        RunTask4();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Некоректний вибір. Спробуйте ще раз.\n");
                        break;
                }
            }
        }

        private static void RunTask1Vector()
        {
            Console.WriteLine("=== Завдання 1.1 (Вектор) ===");
            Console.Write("Введіть розмірність масиву n: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0) return;

            int[] array = new int[n];
            Random rand = new Random();

            Console.WriteLine("Масив:");
            for (int i = 0; i < n; i++)
            {
                array[i] = rand.Next(1, 100);
                Console.Write($"{array[i]} ");
            }

            Console.WriteLine("\n\nЕлементи з парними індексами:");
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 0) Console.Write($"[{i}]:{array[i]} ");
            }
            Console.WriteLine("\n");
        }

        private static void RunTask1Matrix()
        {
            Console.WriteLine("=== Завдання 1.2 (Матриця) ===");
            Console.Write("Введіть кількість рядків n: ");
            if (!int.TryParse(Console.ReadLine(), out int n)) return;
            Console.Write("Введіть кількість стовпців m: ");
            if (!int.TryParse(Console.ReadLine(), out int m)) return;

            int[,] matrix = new int[n, m];
            Random rand = new Random();

            Console.WriteLine("Матриця:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = rand.Next(1, 100);
                    Console.Write($"{matrix[i, j],4}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nЕлементи, де сума індексів (i + j) парна:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((i + j) % 2 == 0) Console.Write($"({i},{j}):{matrix[i, j]} ");
                }
            }
            Console.WriteLine("\n");
        }

        private static void RunTask2()
        {
            Console.WriteLine("=== Завдання 2 (Кратність) ===");
            Console.Write("Введіть кількість елементів n: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 1) return;

            double[] array = new double[n];
            Random rand = new Random();

            Console.WriteLine("Послідовність:");
            for (int i = 0; i < n; i++)
            {
                array[i] = rand.Next(1, 21);
                Console.Write($"{array[i]}  ");
            }
            Console.WriteLine();

            int pairsCount = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i + 1] != 0 && array[i] % array[i + 1] == 0)
                {
                    pairsCount++;
                    Console.WriteLine($"Пара: {array[i]} кратне {array[i + 1]}");
                }
            }
            Console.WriteLine($"\nКількість пар: {pairsCount}\n");
        }

        private static void RunTask3()
        {
            Console.WriteLine("=== Завдання 3 (Побічна діагональ) ===");
            Console.Write("Введіть розмірність n: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 1) return;

            int[,] matrix = new int[n, n];
            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rand.Next(1, 11);
                    Console.Write($"{matrix[i, j],4}");
                }
                Console.WriteLine();
            }

            double sum = 0;
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i + j > n - 1)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
            }

            Console.WriteLine(count > 0
                ? $"\nСереднє арифметичне під побічною діагоналлю: {sum / count:F2}\n"
                : "\nЕлементів не знайдено.\n");
        }

        private static void RunTask4()
        {
            Console.WriteLine("=== Завдання 4 (Східчастий масив) ===");
            Console.Write("Введіть кількість рядків n: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0) return;

            int[][] jagged = new int[n][];
            Random rand = new Random();
            int maxCols = 0;

            for (int i = 0; i < n; i++)
            {
                int mj = rand.Next(1, 10);
                jagged[i] = new int[mj];
                maxCols = mj > maxCols ? mj : maxCols;
                for (int j = 0; j < mj; j++) jagged[i][j] = rand.Next(-10, 30);
            }

            Console.WriteLine("\nСхідчастий масив:");
            foreach (var row in jagged)
            {
                foreach (var val in row) Console.Write($"{val,4}");
                Console.WriteLine();
            }

            int[] columnSums = new int[maxCols];
            for (int j = 0; j < maxCols; j++)
            {
                int sum = 0;
                for (int i = 0; i < n; i++)
                {
                    if (j < jagged[i].Length)
                    {
                        int val = jagged[i][j];
                        if (val > 0 && val % 2 == 0) sum += val;
                    }
                }
                columnSums[j] = sum;
            }

            Console.WriteLine("\nСуми парних додатних елементів по стовпцях:");
            for (int i = 0; i < columnSums.Length; i++)
                Console.WriteLine($"Стовпець {i}: {columnSums[i]}");
            Console.WriteLine();
        }
    }
}