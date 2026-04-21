class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== ЗАДАНИЕ 1: Метод Sum ===");
        FirstPart.GenerateTask1File();
        int digit;
        do
        {
            Console.Write("Введите цифру (0–9) для отбора чисел: ");
        } while (!int.TryParse(Console.ReadLine(), out digit) || digit < 0 || digit > 9);
        int result = FirstPart.Sum(digit);
        Console.WriteLine($"Результат: {result}\n");


        Console.WriteLine("=== ЗАДАНИЕ 2: Метод Delta ===");
        FirstPart.GenerateTask2File();
        FirstPart.Delta();


        Console.WriteLine("\n=== ЗАДАНИЕ 3: Метод Rewrite ===");
        FirstPart.GenerateTask3File();
        FirstPart.Rewrite();
        Console.WriteLine("Готово. Проверьте созданный файл.\n");


        Console.WriteLine("=== ЗАДАНИЕ 4: Метод NoRepeats ===");
        FirstPart.GenerateTask4File();
        FirstPart.NoRepeats();


        Console.WriteLine("=== ЗАДАНИЕ 5: Метод BinaryAndStruct ===");
        FirstPart.GenerateTask5File();
        FirstPart.BinaryAndStruct();


        Console.WriteLine("\n=== ЗАДАНИЕ 6: Симметрическая разность списков ===");
        List<int> L1 = ReadList("первого");
        List<int> L2 = ReadList("второго");
        Console.WriteLine("Результирующий список (симметрическая разность):");
        PrintList(SecondPart.Task6_SymmetricDifference(L1, L2));


        Console.WriteLine("\n=== ЗАДАНИЕ 7: Удаление элементов между min и max (LinkedList) ===");
        LinkedList<int> list = ReadLinkedList();
        Console.WriteLine("Результат после удаления:");
        PrintLinkedList(SecondPart.Task7_RemoveBetweenMinMax(list));


        Console.WriteLine("\n=== ЗАДАНИЕ 8: Анализ телешоу (HashSet) ===");
        SecondPart.Task8_TVShows();


        Console.WriteLine("\n=== ЗАДАНИЕ 9: Поиск цифр в текстовом файле ===");
        SecondPart.Task9_FindDigitsInTextFile();


        Console.WriteLine("\n=== ЗАДАНИЕ 10: Самый старший человек ===");
        SecondPart.Task10_OldestPerson();
    }

    private static List<int> ReadList(string name)
    {
        List<int> list = new List<int>();
        Console.Write($"Введите элементы {name} списка через пробел: ");
        string[] parts = Console.ReadLine().Split(new char[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries);
        foreach (string part in parts)
        {
            if (int.TryParse(part, out int val))
                list.Add(val);
            else
                Console.WriteLine($"Некорректное число '{part}' пропущено.");
        }
        return list;
    }
    
    private static void PrintList(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Console.Write(list[i] + (i < list.Count - 1 ? " " : ""));
        }
        Console.WriteLine();
    }

    private static LinkedList<int> ReadLinkedList()
    {
        LinkedList<int> list = new LinkedList<int>();
        Console.Write("Введите элементы связного списка через пробел: ");
        string[] parts = Console.ReadLine().Split(new char[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries);
        foreach (string part in parts)
        {
            if (int.TryParse(part, out int val))
            {
                list.AddLast(val);
            }
        }
        return list;
    }

    private static void PrintLinkedList(LinkedList<int> list)
    {
        foreach (int val in list)
            Console.Write(val + " ");
        Console.WriteLine();
    }
}